using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace FFT_DOSE
{

    public sealed class DBConn
    {

        //   Fields   
        private bool m_bIsInTransaction;
        private OleDbCommand m_objCommand;
        private OleDbConnection m_objConn;
        private OleDbTransaction m_objTransaction;
        private int m_Timeout;

        //   Methods   
        public DBConn()
        {
            this.m_bIsInTransaction = false;
            this.m_Timeout = 30;
            this.m_objConn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + @"\Database.accdb; Jet OLEDB:Database Password=1235;");
            this.m_objConn.Open();
        }


        public DBConn(string strConnectionString)
        {
            this.m_bIsInTransaction = false;
            this.m_Timeout = 30;
            this.m_objConn = new OleDbConnection(strConnectionString);
            this.m_objConn.Open();
        }

        public DBConn(string strConnectionString, bool bOpenNow)
        {
            this.m_bIsInTransaction = false;
            this.m_Timeout = 30;
            this.m_objConn = new OleDbConnection(strConnectionString);
            if (bOpenNow)
            {
                this.m_objConn.Open();
            }
        }

        public void BeginTransaction()
        {
            if (!this.m_bIsInTransaction)
            {
                this.m_objCommand = new OleDbCommand();
                this.m_objCommand.Connection = this.m_objConn;
                this.m_objTransaction = this.m_objConn.BeginTransaction();
                if (this.m_Timeout >= 30)
                {
                    this.m_objCommand.CommandTimeout = this.m_Timeout;
                }
                this.m_objCommand.Transaction = this.m_objTransaction;
                this.m_bIsInTransaction = true;
            }
        }

        public void Close()
        {
            if (this.m_objConn.State != ConnectionState.Closed)
            {
                this.m_objConn.Close();
            }
        }

        public void Commit()
        {
            if (this.m_bIsInTransaction)
            {
                this.m_objTransaction.Commit();
                this.m_bIsInTransaction = false;
                this.m_objCommand.Dispose();
            }
        }

        public void Dispose()
        {
            if (this.m_objConn.State != ConnectionState.Closed)
            {
                this.m_objConn.Close();
            }
            this.m_objConn.Dispose();
        }

        public int GetQueryCount(string Table_name, string where_str)
        {
            int queryCount = 0;

            #region Contracts

            if (string.IsNullOrEmpty(Table_name) == true) throw new ArgumentNullException();
            if (string.IsNullOrEmpty(where_str) == true) throw new ArgumentNullException();

            #endregion

            // QueryCountText
            var queryCountText = @"SELECT COUNT(*) FROM ({0}) WHERE ({1})";

            queryCountText = string.Format(queryCountText, Table_name, where_str);

            if (!this.m_bIsInTransaction)
            {
                OleDbCommand command1 = new OleDbCommand(queryCountText, this.m_objConn);
                if (this.m_Timeout >= 30)
                {
                    command1.CommandTimeout = this.m_Timeout;
                }
                queryCount = Convert.ToInt32(command1.ExecuteScalar());
                command1.Dispose();
            }
            else
            {
                this.m_objCommand.CommandText = queryCountText;
                queryCount = Convert.ToInt32(this.m_objCommand.ExecuteScalar());
            }

            // Return
            return queryCount;
        }

        public DataSet ExecuteDataSet(string strSQL)
        {
            DataSet set1 = new DataSet();
            try
            {
                OleDbCommand command1 = new OleDbCommand(strSQL, this.m_objConn);
                if (this.m_Timeout >= 30)
                {
                    command1.CommandTimeout = this.m_Timeout;
                }
                OleDbDataAdapter adapter1 = new OleDbDataAdapter(command1);
                adapter1.Fill(set1);
                command1.Dispose();
                adapter1.Dispose();
                return set1;
            }
            catch (Exception ex)
            {
                return set1;
            }
        }

        public DataSet ExecuteDataSet(string strSQL, string strTable)
        {
            DataSet set1 = new DataSet();
            OleDbCommand command1 = new OleDbCommand(strSQL, this.m_objConn);
            if (this.m_Timeout >= 30)
            {
                command1.CommandTimeout = this.m_Timeout;
            }
            OleDbDataAdapter adapter1 = new OleDbDataAdapter(command1);
            adapter1.Fill(set1, strTable);
            command1.Dispose();
            adapter1.Dispose();
            return set1;
        }



        public DataTable ExecuteTable(string strSQL)
        {
            DataSet ds1 = new DataSet();
            DataTable table1 = new DataTable();
            try
            {
                OleDbCommand command1 = new OleDbCommand(strSQL, this.m_objConn);
                if (this.m_Timeout >= 30)
                {
                    command1.CommandTimeout = this.m_Timeout;
                }
                OleDbDataAdapter adapter1 = new OleDbDataAdapter(command1);
                adapter1.Fill(ds1);
                command1.Dispose();
                adapter1.Dispose();
                return ds1.Tables[0];
            }
            catch (Exception ex)
            {
                return ds1.Tables[0];
            }
        }



        public string Read_unique_data(string strSQL)
        {
            OleDbCommand command1 = new OleDbCommand(strSQL, this.m_objConn);
            if (this.m_Timeout >= 30)
            {
                command1.CommandTimeout = this.m_Timeout;
            }
            OleDbDataReader reader1 = command1.ExecuteReader();
            try
            {
                reader1.Read();
                command1.Dispose();
                return reader1[0].ToString();
            }
            catch
            {
                return "-2";
            }
        }

        public string Read_Product_Max_id()
        {
            string strSQL = "select product_id from product order by product_id desc";
            OleDbCommand command1 = new OleDbCommand(strSQL, this.m_objConn);
            if (this.m_Timeout >= 30)
            {
                command1.CommandTimeout = this.m_Timeout;
            }
            OleDbDataReader reader1 = command1.ExecuteReader();
            try
            {
                reader1.Read();
                command1.Dispose();
                return reader1[0].ToString();
            }
            catch
            {
                return "1";
            }
        }

        public string Read_Part_Max_id()
        {
            string strSQL = "select part_id from part order by part_id desc";
            OleDbCommand command1 = new OleDbCommand(strSQL, this.m_objConn);
            if (this.m_Timeout >= 30)
            {
                command1.CommandTimeout = this.m_Timeout;
            }
            OleDbDataReader reader1 = command1.ExecuteReader();
            try
            {
                reader1.Read();
                command1.Dispose();
                return reader1[0].ToString();
            }
            catch
            {
                return "1";
            }
        }

        public string Read_Product_info_Max_id()
        {
            string strSQL = "select product_info_id from product_info order by product_info_id desc";
            OleDbCommand command1 = new OleDbCommand(strSQL, this.m_objConn);
            if (this.m_Timeout >= 30)
            {
                command1.CommandTimeout = this.m_Timeout;
            }
            OleDbDataReader reader1 = command1.ExecuteReader();
            try
            {
                reader1.Read();
                command1.Dispose();
                return reader1[0].ToString();
            }
            catch
            {
                return "1";
            }
        }

        public string Read_batch_Max_id()
        {
            string strSQL = "select batch_id from batch order by batch_id desc";
            OleDbCommand command1 = new OleDbCommand(strSQL, this.m_objConn);
            if (this.m_Timeout >= 30)
            {
                command1.CommandTimeout = this.m_Timeout;
            }
            OleDbDataReader reader1 = command1.ExecuteReader();
            try
            {
                reader1.Read();
                command1.Dispose();
                return reader1[0].ToString();
            }
            catch
            {
                return "1";
            }
        }

        public string Read_mo_Max_id()
        {
            string strSQL = "select mo_id from mo order by mo_id desc";
            OleDbCommand command1 = new OleDbCommand(strSQL, this.m_objConn);
            if (this.m_Timeout >= 30)
            {
                command1.CommandTimeout = this.m_Timeout;
            }
            OleDbDataReader reader1 = command1.ExecuteReader();
            try
            {
                reader1.Read();
                command1.Dispose();
                return reader1[0].ToString();
            }
            catch
            {
                return "1";
            }
        }

        public string Read_delivery_Max_id()
        {
            string strSQL = "select delivery_object_id from delivery_object order by delivery_object_id desc";
            OleDbCommand command1 = new OleDbCommand(strSQL, this.m_objConn);
            if (this.m_Timeout >= 30)
            {
                command1.CommandTimeout = this.m_Timeout;
            }
            OleDbDataReader reader1 = command1.ExecuteReader();
            try
            {
                reader1.Read();
                command1.Dispose();
                return reader1[0].ToString();
            }
            catch
            {
                return "1";
            }
        }


        public string Read_Assembly_part_Max_id()
        {
            string strSQL = "select id from assembly_part order by id desc";
            OleDbCommand command1 = new OleDbCommand(strSQL, this.m_objConn);
            if (this.m_Timeout >= 30)
            {
                command1.CommandTimeout = this.m_Timeout;
            }
            OleDbDataReader reader1 = command1.ExecuteReader();
            try
            {
                reader1.Read();
                command1.Dispose();
                return reader1[0].ToString();
            }
            catch
            {
                return "1";
            }
        }


        public string Read_Part_Id(string part_num)
        {
            string strSQL = "select part_id from part where part_num ='" + part_num + "'";
            OleDbCommand command1 = new OleDbCommand(strSQL, this.m_objConn);
            if (this.m_Timeout >= 30)
            {
                command1.CommandTimeout = this.m_Timeout;
            }
            OleDbDataReader reader1 = command1.ExecuteReader();
            try
            {
                reader1.Read();
                command1.Dispose();
                return reader1[0].ToString();
            }
            catch
            {
                return "-2";
            }
        }



        public string Read_Assembly_user_Id(string username)
        {
            string strSQL = "select assembly_user_id from assembly_user where username ='" + username + "'";
            OleDbCommand command1 = new OleDbCommand(strSQL, this.m_objConn);
            if (this.m_Timeout >= 30)
            {
                command1.CommandTimeout = this.m_Timeout;
            }
            OleDbDataReader reader1 = command1.ExecuteReader();
            try
            {
                reader1.Read();
                command1.Dispose();
                return reader1[0].ToString();
            }
            catch
            {
                return "-2";
            }
        }

        public string Read_Id(string unique)
        {
            string strSQL = "select id from id where unique_id ='" + unique + "'";
            OleDbCommand command1 = new OleDbCommand(strSQL, this.m_objConn);
            if (this.m_Timeout >= 30)
            {
                command1.CommandTimeout = this.m_Timeout;
            }
            OleDbDataReader reader1 = command1.ExecuteReader();
            try
            {
                reader1.Read();
                command1.Dispose();
                return reader1[0].ToString();
            }
            catch
            {
                return "-2";
            }
        }

        public string Read_Batch_Id(string batch_num)
        {
            string strSQL = "select batch_id from batch where batch_num ='" + batch_num + "'";
            OleDbCommand command1 = new OleDbCommand(strSQL, this.m_objConn);
            if (this.m_Timeout >= 30)
            {
                command1.CommandTimeout = this.m_Timeout;
            }
            OleDbDataReader reader1 = command1.ExecuteReader();
            try
            {
                reader1.Read();
                command1.Dispose();
                return reader1[0].ToString();
            }
            catch
            {
                return "-2";
            }
        }

        public string Read_Product_Id(string product_num)
        {
            try
            {
                string strSQL = "select product_id from product where product_num ='" + product_num + "'";
                OleDbCommand command1 = new OleDbCommand(strSQL, this.m_objConn);
                if (this.m_Timeout >= 30)
                {
                    command1.CommandTimeout = this.m_Timeout;
                }
                OleDbDataReader reader1 = command1.ExecuteReader();
                reader1.Read();
                command1.Dispose();
                return reader1[0].ToString();
            }
            catch
            {
                return "-2";
            }
        }

        public string Read_Account_Id(string usermane)
        {
            string strSQL = "select account_id from account where username ='" + usermane + "'";
            OleDbCommand command1 = new OleDbCommand(strSQL, this.m_objConn);
            if (this.m_Timeout >= 30)
            {
                command1.CommandTimeout = this.m_Timeout;
            }
            OleDbDataReader reader1 = command1.ExecuteReader();
            try
            {
                reader1.Read();
                command1.Dispose();
                return reader1[0].ToString();
            }
            catch
            {
                return "-2";
            }
        }

        public string Read_Username(string account_id)
        {
            string strSQL = "select username from account where account_id =" + account_id;
            OleDbCommand command1 = new OleDbCommand(strSQL, this.m_objConn);
            if (this.m_Timeout >= 30)
            {
                command1.CommandTimeout = this.m_Timeout;
            }
            OleDbDataReader reader1 = command1.ExecuteReader();
            try
            {
                reader1.Read();
                command1.Dispose();
                return reader1[0].ToString();
            }
            catch
            {
                return "-2";
            }
        }

        public OleDbDataReader ExecuteReader(string strSQL)
        {
            OleDbCommand command1 = new OleDbCommand(strSQL, this.m_objConn);
            if (this.m_Timeout >= 30)
            {
                command1.CommandTimeout = this.m_Timeout;
            }
            OleDbDataReader reader1 = command1.ExecuteReader();
            command1.Dispose();
            return reader1;
        }

        public string ExecuteSQL(string strSQL)
        {
            if (!this.m_bIsInTransaction)
            {
                OleDbCommand command1 = new OleDbCommand(strSQL, this.m_objConn);
                if (this.m_Timeout >= 30)
                {
                    command1.CommandTimeout = this.m_Timeout;
                }
                command1.ExecuteNonQuery();
                command1.Dispose();
            }
            else
            {
                this.m_objCommand.CommandText = strSQL;
                this.m_objCommand.ExecuteNonQuery();
            }
            return "-2";
        }

        public int FillDataSet(ref DataSet objDataSet, string strSQL)
        {

            OleDbCommand command1 = new OleDbCommand(strSQL, this.m_objConn);
            if (this.m_Timeout >= 30)
            {
                command1.CommandTimeout = this.m_Timeout;
            }
            OleDbDataAdapter adapter1 = new OleDbDataAdapter(command1);
            int num1 = adapter1.Fill(objDataSet);
            command1.Dispose();
            adapter1.Dispose();
            return num1;
        }

        public int FillDataSet(ref DataSet objDataSet, string strSQL, string strTable)
        {

            OleDbCommand command1 = new OleDbCommand(strSQL, this.m_objConn);
            if (this.m_Timeout >= 30)
            {
                command1.CommandTimeout = this.m_Timeout;
            }
            OleDbDataAdapter adapter1 = new OleDbDataAdapter(command1);
            int num1 = adapter1.Fill(objDataSet, strTable);
            command1.Dispose();
            adapter1.Dispose();
            return num1;
        }

        public bool Lock(string[] strArrTableName)
        {
            return true;
            //     return   this.m_objSync.Lock(strArrTableName);   
        }

        public void Open()
        {
            if (this.m_objConn.State != ConnectionState.Open)
            {
                this.m_objConn.Open();
            }
        }

        public void Rollback()
        {
            if (this.m_bIsInTransaction)
            {
                this.m_objTransaction.Rollback();
                this.m_bIsInTransaction = false;
                this.m_objCommand.Dispose();
            }
        }

        public void Update(string strSelectSQL, DataSet objDataSet)
        {
            OleDbDataAdapter adapter1;
            OleDbCommandBuilder builder1;
            if (!this.m_bIsInTransaction)
            {
                OleDbCommand command1 = new OleDbCommand(strSelectSQL, this.m_objConn);
                if (this.m_Timeout >= 30)
                {
                    command1.CommandTimeout = this.m_Timeout;
                }
                adapter1 = new OleDbDataAdapter(command1);
                builder1 = new OleDbCommandBuilder(adapter1);
                adapter1.InsertCommand = builder1.GetInsertCommand();
                adapter1.DeleteCommand = builder1.GetDeleteCommand();
                adapter1.UpdateCommand = builder1.GetUpdateCommand();
                adapter1.Update(objDataSet);
                builder1.Dispose();
                command1.Dispose();
                adapter1.Dispose();
            }
            else
            {
                adapter1 = new OleDbDataAdapter(this.m_objCommand);
                builder1 = new OleDbCommandBuilder(adapter1);
                adapter1.InsertCommand = builder1.GetInsertCommand();
                adapter1.DeleteCommand = builder1.GetDeleteCommand();
                adapter1.UpdateCommand = builder1.GetUpdateCommand();
                adapter1.Update(objDataSet);
                builder1.Dispose();
                adapter1.Dispose();
            }
        }

        public void Update(string strSelectSQL, DataTable objTable)
        {
            OleDbDataAdapter adapter1;
            OleDbCommandBuilder builder1;
            if (!this.m_bIsInTransaction)
            {
                OleDbCommand command1 = new OleDbCommand(strSelectSQL, this.m_objConn);
                if (this.m_Timeout >= 30)
                {
                    command1.CommandTimeout = this.m_Timeout;
                }
                adapter1 = new OleDbDataAdapter(command1);
                builder1 = new OleDbCommandBuilder(adapter1);
                adapter1.InsertCommand = builder1.GetInsertCommand();
                adapter1.DeleteCommand = builder1.GetDeleteCommand();
                adapter1.UpdateCommand = builder1.GetUpdateCommand();
                adapter1.Update(objTable);
                builder1.Dispose();
                command1.Dispose();
                adapter1.Dispose();
            }
            else
            {
                adapter1 = new OleDbDataAdapter(this.m_objCommand);
                builder1 = new OleDbCommandBuilder(adapter1);
                adapter1.InsertCommand = builder1.GetInsertCommand();
                adapter1.DeleteCommand = builder1.GetDeleteCommand();
                adapter1.UpdateCommand = builder1.GetUpdateCommand();
                adapter1.Update(objTable);
                builder1.Dispose();
                adapter1.Dispose();
            }
        }

        //   Properties   
        public ConnectionState State
        {
            get
            {
                return this.m_objConn.State;
            }
        }

        public int Timeout
        {
            get
            {
                return this.m_Timeout;
            }
            set
            {
                if (value < 1)
                {
                    this.m_Timeout = 1;
                }
                else
                {
                    this.m_Timeout = value;
                }
            }
        }



    }
}