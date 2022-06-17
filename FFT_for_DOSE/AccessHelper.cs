using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FFT_For_DOSE
{
    public class AccessHelper
    {

        #region 连接字符串
        private static readonly string ConStr =
        string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + @"\Database.accdb; Jet OLEDB:Database Password=1235;");     

        //accdb 数据库
        //private static readonly string ConStr =
        //    string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Persist Security Info=False;","路径\\db.accdb");
        #endregion

        #region 私有方法


        private string SqlExec(params OleDbCommand[] coms)
        {
            using (OleDbConnection con = new OleDbConnection(ConStr))
            {
                con.Open();
                OleDbTransaction st = con.BeginTransaction();
                string result = "";
                for (int i = 0; i < coms.Length; i++)
                {
                    coms[i].Connection = con;
                    coms[i].Transaction = st;
                }
                try
                {
                    foreach (OleDbCommand cmd in coms)
                    {
                        cmd.ExecuteNonQuery();
                    }
                    st.Commit();
                    result = string.Empty; //代表成功,返回空字符串
                }
                catch (Exception ex)
                {
                    result = ex.Message; //代表失败，返回错误信息
                    st.Rollback();
                }
                finally
                {
                    con.Close();
                }
                return result;
            }
        }



        /// <summary>
        /// 返回多条SQL语句执行后是否全部成功.
        /// </summary>
        /// <param name="sqlstrs">SQL语句</param>
        /// <returns></returns>
        private string GetNum(params String[] sqlstrs)
        {
            using (OleDbConnection con = new OleDbConnection(ConStr))
            {
                con.Open();

                OleDbTransaction st = con.BeginTransaction();
                string result = string.Empty;
                OleDbCommand[] myCommands = new OleDbCommand[sqlstrs.Length];
                for (int i = 0; i < sqlstrs.Length; i++)
                {
                    myCommands[i] = new OleDbCommand(sqlstrs[i], con);
                    myCommands[i].Transaction = st;
                }
                try
                {
                    foreach (OleDbCommand cmd in myCommands)
                    {
                        cmd.ExecuteNonQuery();
                    }
                    st.Commit();
                    result = string.Empty; //代表成功

                }
                catch (Exception ex)
                {
                    result = ex.Message; //代表失败，返回错误信息
                    st.Rollback();
                }
                finally
                {
                    con.Close();
                }
                return result;

            }
        }

        /// <summary>
        /// 分页使用
        /// </summary>
        /// <param name="query"></param>
        /// <param name="passCount"></param>
        /// <returns></returns>
        private static string recordID(string query, int passCount)
        {
            using (OleDbConnection con = new OleDbConnection(ConStr))
            {
                con.Open();
                OleDbCommand cmd = new OleDbCommand(query, con);
                string result = string.Empty;
                using (OleDbDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        if (passCount < 1)
                        {
                            result += "," + dr.GetInt32(0);
                        }
                        passCount--;
                    }
                }
                con.Close();
                con.Dispose();
                return result.Substring(1);
            }
        }

        /// <summary>
        /// 添加给参数添加
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="par"></param>
        private static void SetParametersAddA(OleDbCommand cmd, OleDbParameter[] par)
        {
            if (par != null)
            {
                for (int i = 0; i < par.Length; i++)
                {
                    //cmd.Parameters.Add(par[i]);
                    cmd.Parameters.AddWithValue(par[i].ParameterName, par[i].Value);
                }
            }
        }

        #endregion

        #region 公用方法

        /// <summary>
        /// 取得DataSet
        /// </summary>
        /// <param name="sqlstr">查询的Sql语句</param>
        /// <param name="par">参数集合</param>
        /// <returns></returns>
        public DataSet GetDataSet(string sqlstr, params OleDbParameter[] par)
        {
            using (OleDbConnection con = new OleDbConnection(ConStr))
            {
                con.Open();
                using (OleDbCommand cmd = new OleDbCommand(sqlstr))
                {
                    cmd.Connection = con;

                    SetParametersAddA(cmd, par);

                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        return ds;
                    }
                }
            }
        }


        /// <summary>
        /// 取得DataColumn
        /// </summary>
        /// <param name="sqlstr">查询的Sql语句</param>
        /// <param name="par">参数集合</param>
        /// <returns></returns>
        public DataRow GetDataRow(string tableName, string whereItem, string whereItemValue)
        {
            //SQL語法：                    
            string strSQL = "select * from " + tableName + " where " + whereItem + " = @whereItem";
            //添加參數
            OleDbParameter[] pars = new OleDbParameter[] { new OleDbParameter("@whereItem", whereItemValue) };
            using (OleDbConnection con = new OleDbConnection(ConStr))
            {
                con.Open();
                using (OleDbCommand cmd = new OleDbCommand(strSQL))
                {
                    cmd.Connection = con;
                    SetParametersAddA(cmd, pars);
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        return ds.Tables[0].Rows[0];
                    }
                }
            }
        }








        /// <summary>
        /// 執行語法
        /// </summary>
        /// <param name="strSQL"></param>
        /// <param name="par"></param>
        /// <returns></returns>
        public string ExecSql(string strSQL, params OleDbParameter[] par)
        {
            using (OleDbCommand cmd = new OleDbCommand(strSQL))
            {
                SetParametersAddA(cmd, par);
                return this.SqlExec(cmd);
            }
        }

        public DataTable GetDataTable(string sqlstr, params OleDbParameter[] par)
        {
            return GetDataSet(sqlstr, par).Tables[0];
        }



        /// <summary>
        /// 返回多条SQL语句是否全部执行成功.
        /// </summary>
        /// <param name="Sqlstrs">SQL语句</param>
        /// <returns></returns>
        public string ReturnNum(params String[] Sqlstrs)
        {
            return this.GetNum(Sqlstrs);
        }


        /// <summary>
        /// 執行更新語法
        /// </summary>    
        /// <returns></returns>
        public string UpdateDataBase(string tableNale, string setItem, string setItemValue, string whereItem, string whereItemValue)
        {
            //SQL語法：                    
            string strSQL = "UPDATE " + tableNale + " set " + setItem + " =@setItem where " + whereItem + " = @whereItem";
            if (string.IsNullOrEmpty(strSQL) == false)
            {
                //添加參數
                OleDbParameter[] pars = new OleDbParameter[] {
                                            new OleDbParameter("@setItem",setItemValue),
                                            new OleDbParameter("@whereItem",whereItemValue)
                                                                };
                //執行SQL
                string errorInfo = this.ExecSql(strSQL, pars);
                if (errorInfo.Length != 0)
                {
                    return "fail";
                }
                else
                {
                    return "pass";
                }
            }
            return "fail";
        }


        #region ACCESS高效分页

        /// <summary>
        /// ACCESS高效分页
        /// </summary>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">分页容量</param>
        /// <param name="strKey">主键</param>
        /// <param name="showString">显示的字段</param>
        /// <param name="queryString">查询字符串，支持联合查询(多表需要加“（）”)</param>
        /// <param name="whereString">查询条件</param>
        /// <param name="par">参数</param>
        /// <param name="orderString">排序规则</param>
        /// <param name="pageCount">传出参数：总页数统计</param>
        /// <param name="recordCount">传出参数：总记录统计</param>
        /// <returns>装载记录的DataTable</returns>
        public static DataSet ExecutePager(int pageIndex, int pageSize, string strKey, string showString, string queryString, string whereString, OleDbParameter[] par, string orderString, out int pageCount, out int recordCount)
        {
            if (pageIndex < 1) pageIndex = 1;
            if (pageSize < 1) pageSize = 10;
            if (string.IsNullOrEmpty(showString)) showString = " * ";
            if (string.IsNullOrEmpty(orderString)) orderString = string.Format("{0} asc ", strKey);
            if (whereString.Length > 0)
            {
                whereString = string.Format(" where {0}", whereString);
            }

            using (OleDbConnection con = new OleDbConnection(ConStr))
            {
                con.Open();
                string myVw = string.Format("  {0} as tempVw ", queryString);

                OleDbCommand cmdCount = new OleDbCommand(string.Format(" select count(*) as recordCount from {0} {1}", myVw, whereString), con);
                SetParametersAddA(cmdCount, par);

                recordCount = Convert.ToInt32(cmdCount.ExecuteScalar());


                if ((recordCount % pageSize) > 0)
                    pageCount = recordCount / pageSize + 1;
                else
                    pageCount = recordCount / pageSize;


                OleDbCommand cmdRecord;
                if (pageIndex == 1)//第一页
                {
                    cmdRecord = new OleDbCommand(string.Format("select top {0} {1} from {2} {3} order by {4} ", pageSize, showString, myVw, whereString, orderString), con);
                }
                else if (pageIndex > pageCount)//超出总页数
                {
                    cmdRecord = new OleDbCommand(string.Format("select top {0} {1} from {2} {3} order by {4} ", pageSize, showString, myVw, "where 1=2", orderString), con);
                }
                else
                {
                    int pageLowerBound = pageSize * pageIndex;
                    int pageUpperBound = pageLowerBound - pageSize;
                    string recordIDs = recordID(string.Format("select top {0} {1} from {2} {3} order by {4} ", pageLowerBound, strKey, myVw, whereString, orderString), pageUpperBound);
                    cmdRecord = new OleDbCommand(string.Format("select {0} from {1} where {2} in ({3}) order by {4} ", showString, myVw, strKey, recordIDs, orderString), con);
                }

                SetParametersAddA(cmdRecord, par);

                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(cmdRecord);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds);
                con.Close();
                con.Dispose();
                return ds;
            }
        }

        #endregion


        #endregion




        public string readData(string sqlStr)
        {
            using (OleDbConnection con = new OleDbConnection(ConStr))
            {
                con.Open();
                OleDbCommand cmd = new OleDbCommand(sqlStr, con);
                string result = string.Empty;
                using (OleDbDataReader dr = cmd.ExecuteReader())
                {
                    try
                    {
                        dr.Read();
                        cmd.Dispose();
                        return dr[0].ToString();
                    }
                    catch
                    {
                        cmd.Dispose();
                        return "-1";
                    }                   
                }               
                cmd.Dispose();
                return "-1";
            }
        }

    }

}
