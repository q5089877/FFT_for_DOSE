using FFT_DOSE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FFT_For_DOSE
{

    public partial class FormManage : Form
    {
        DataTable dtForGrid;

        // 創建一個 OleDbConnection
        OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + @"\FFTDatabase.accdb; Jet OLEDB:Database Password=1235;");

        // 創建一個 OleDbDataAdapter
        OleDbDataAdapter adapter;

        // 創建一個 OleDbCommandBuilder
        OleDbCommandBuilder builder;

        // 創建一個 DataTable 並填充資料
        DataTable dtGtin = new DataTable();

        public bool showManUser { get; set; }
        AccessHelper accessHelper = new AccessHelper();
        public FormManage(bool showManage)
        {
            InitializeComponent();
        }

        private void Form_manage_Load(object sender, EventArgs e)
        {
            //--------------------------           
            adapter = new OleDbDataAdapter("SELECT * FROM gtin", conn);
            adapter.Fill(dtGtin);

            // 將 DataTable 分配給 DataGridView 的 DataSource 屬性
            GvGtin.DataSource = dtGtin;

            // 創建一個 OleDbCommandBuilder
            builder = new OleDbCommandBuilder(adapter);
            //--------------------------

            dataGV.AllowUserToAddRows = false;
            dataGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;       

            reLoadMoNum();
            string strSQL = string.Format("select * from batchData where moNum = '{0}'", cbxMO); //檢查MO
            dtForGrid = accessHelper.GetDataTable(strSQL);
            reLoadBatch();
            reLoadGtin();
        }


        #region GridView右鍵增加刪除功能(關閉中)
        //private void dataGV_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        //{
        //    DialogResult result =
        //        MessageBox.Show(
        //            "是否刪除該筆資料",
        //            "確認",
        //            MessageBoxButtons.YesNo,
        //            MessageBoxIcon.Question);

        //    if (result == DialogResult.No) e.Cancel = true;
        //}

        //private void dataGV_MouseDown(object sender, MouseEventArgs e)
        //{
        //    if (e.Button != MouseButtons.Right) return;
        //    DataGridView dgv = sender as DataGridView;
        //    ShowMenu(dgv, e);
        //}
        #endregion

        private void btn_open_user_Click(object sender, EventArgs e)
        {
            if (showManUser == false)
            {
                formManagerUser formManagerUser1 = new formManagerUser(showManUser);
                formManagerUser1.Owner = this;
                formManagerUser1.Show();
                showManUser = true;
            }
        }

        private void Form_manage_FormClosed(object sender, FormClosedEventArgs e)
        {
            string formName = "Form1";
            Form fr = Application.OpenForms[formName];
            if (fr != null)
            {
                Form1 f1 = (Form1)fr;   //取得Form1                
                f1.showManage = false;  //改變showManage的值
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                string sleeveName = "";
                string strSQL = "";
                string moNum = tbx_MO.Text;
                string batchNum = tbx_lot.Text;
                string makeTotal = tbx_make_total.Text;
                try
                {
                    sleeveName = cbxSleeve.SelectedItem.ToString();
                }
                catch
                {
                    cbxSleeve.SelectedIndex = 0;
                    sleeveName = cbxSleeve.SelectedItem.ToString();
                }
             
                string housingVersion = tbxHousing.Text;

                if (moNum == "" || batchNum == "" || makeTotal == "" || sleeveName == "" || housingVersion == "")
                {
                    MessageBox.Show("資料不可為空值");
                }
                else
                {
                    #region 資料庫寫入判斷
                    strSQL = string.Format("select * from moData where moNum = '{0}'", moNum); //檢查MO
                    //執行SQL
                    string checkMO = accessHelper.readData(strSQL);
                    if (checkMO == "-1")//MO不存在      
                    {
                        //寫入資料庫
                        //SQL語法：       
                        strSQL = "insert into moData(moNum) VALUES(@moNum)";
                        if (string.IsNullOrEmpty(strSQL) == false)
                        {
                            //添加參數
                            OleDbParameter[] pars = new OleDbParameter[] {
                                            new OleDbParameter("@moNum",moNum)
                                                                };
                            //執行SQL
                            string errorInfo = accessHelper.ExecSql(strSQL, pars);
                            if (errorInfo.Length != 0)
                            {
                                MessageBox.Show("寫入失敗！" + errorInfo);
                            }
                            else
                            {
                                //add MO pass, then add batchData
                                strSQL = string.Format("select * from batchData where batchNum = '{0}'", batchNum); //檢查batchNum
                                string checkBatchNum = accessHelper.readData(strSQL);

                                if (checkBatchNum == "-1")//MO不存在   
                                {
                                    #region 寫入
                                    //SQL語法：       
                                    strSQL = "insert into batchData(batchNum,moNum,total,sleeveName,housingVersion,finished)" +
                                    " VALUES(@batchNum,@moNum,@total,@sleeveName,@housingVersion,@finished)";
                                    if (string.IsNullOrEmpty(strSQL) == false)
                                    {
                                        //添加參數
                                        OleDbParameter[] pars2 = new OleDbParameter[] {
                                            new OleDbParameter("@batchNum",batchNum),
                                            new OleDbParameter("@moNum",moNum),
                                            new OleDbParameter("@total",makeTotal),
                                            new OleDbParameter("@sleeveName",sleeveName),                                          
                                            new OleDbParameter("@housingVersion",housingVersion),
                                            new OleDbParameter("@finished","N")

                                    };
                                        //執行SQL
                                        string errorInfo2 = accessHelper.ExecSql(strSQL, pars2);
                                        if (errorInfo.Length != 0)
                                        {
                                            MessageBox.Show("寫入失敗！" + errorInfo2);
                                        }
                                        else
                                        {
                                            MessageBox.Show("新增工單完成");
                                            tbx_MO.Text = "";
                                            tbx_lot.Text = "";
                                            tbx_make_total.Text = "";    
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("批號已存在!!");
                                }
                                #endregion
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("工單已存在!!");
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("發生錯誤，是否有內容為空白!");
                MessageBox.Show(ex.ToString());
            }
            reLoadMoNum();
        }

        private void btnDelMO_Click(object sender, EventArgs e)
        {
            try
            {
                var result = MessageBox.Show("確認刪除", "刪除工單", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    //利用工單取得批號
                    string batchNum = string.Format("SELECT batchNum FROM batchData WHERE moNum ='{0}'", cbxMO.SelectedItem.ToString());
                    batchNum = accessHelper.readData(batchNum);
                    //刪除Batch
                    //SELECT COUNT(*) FROM deviceData WHERE batchNum = @batchNum
                    string strSQL = string.Format("SELECT COUNT(*) FROM deviceData WHERE batchNum ='{0}'", batchNum);
                    string sqlResult = accessHelper.readData(strSQL);

                    int readTotal = Convert.ToInt16(sqlResult);
                    if (readTotal > 0)
                    {
                        MessageBox.Show("已經有" + readTotal.ToString() + "筆測試資料，無法刪除");
                    }
                    else
                    {
                        //刪除batchData
                        strSQL = string.Format("DELETE FROM batchData where batchNum ='{0}'", batchNum);
                        sqlResult = accessHelper.ExecSql(strSQL);
                        //刪除moData
                        strSQL = string.Format("DELETE FROM moData where moNum ='{0}'", cbxMO.SelectedItem.ToString());
                        sqlResult = accessHelper.ExecSql(strSQL);
                        clearGrid();                        
                        MessageBox.Show("刪除 " + cbxMO.SelectedItem.ToString() + " 完成");
                        reLoadMoNum();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show("發生錯誤!!");
            }
        }

        void reLoadMoNum()
        {
            //載入工單號碼到下單選單
            cbxMO.Text = "";
            cbxMO.Items.Clear();
            string str_sql = "SELECT moNum FROM moData";
            DataTable dt = accessHelper.GetDataTable(str_sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string str_dt = dt.Rows[i][0].ToString();
                cbxMO.Items.Add(new ComboboxItem(str_dt, str_dt));
            }
        }

        private void ShowMenu(DataGridView dgv, MouseEventArgs args)
        {
            // 取得 RowIndex 
            // 方法 1：透過 HitTest()
            int RowIndex = dgv.HitTest(args.X, args.Y).RowIndex;
            // 方法 2：CurrentRow
            ////  int RowIndex = dgv.CurrentRow.Index;
            if (RowIndex < 0) return;

            ContextMenuStrip menu = new ContextMenuStrip();
            ToolStripMenuItem item = new ToolStripMenuItem("删除該筆資料");
            item.Click += (sender, e) =>
            {
                for (int i = 0; i < dtForGrid.Rows.Count; i++)
                {
                    if (i == RowIndex)
                    {
                        string str_batchNum = dtForGrid.Rows[i]["batchNum"].ToString();
                        var result = MessageBox.Show("確認刪除 " + dtForGrid.Rows[i]["batchNum"].ToString(), "刪除", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            string sql_del;
                            sql_del = string.Format("DELETE FROM batchData where batchNum ='{0}'", str_batchNum);
                            string delResult = accessHelper.ExecSql(sql_del);
                            if (delResult != "")
                            {
                                MessageBox.Show("刪除失敗，其它資料表包含相關資料!!");
                            }
                            else
                            {
                                MessageBox.Show("刪除批號 " + str_batchNum + " 完成");

                            }
                        }
                    }
                }
                dgv.Rows.RemoveAt(RowIndex);
                reLoadBatch();
                reLoadMoNum();
            };
            menu.Items.Add(item);
            menu.Show(Cursor.Position);
        }

        void reLoadBatch()
        {
            dataGV.DataSource = dtForGrid;
            dataGV.Columns["id"].Visible = false;
            dataGV.Columns["moNum"].HeaderText = "工單號碼";
            dataGV.Columns["batchNum"].HeaderText = "批號";
            dataGV.Columns["total"].HeaderText = "數量";
            dataGV.Columns["sleeveName"].HeaderText = "袖套名稱";          
            dataGV.Columns["housingVersion"].HeaderText = "外殼版本";
            dataGV.Columns["finished"].HeaderText = "完成";

            dataGV.Columns["id"].Width = 0;
            dataGV.Columns["moNum"].Width = 200;
            dataGV.Columns["batchNum"].Width = 200;
            dataGV.Columns["total"].Width = 60;
            dataGV.Columns["sleeveName"].Width = 90;           
            dataGV.Columns["housingVersion"].Width = 90;
            dataGV.Columns["finished"].Width = 80;

            dataGV.Columns["moNum"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGV.Columns["batchNum"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGV.Columns["total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGV.Columns["sleeveName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;          
            dataGV.Columns["housingVersion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGV.Columns["finished"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        void reLoadGtin()
        {
            GvGtin.Columns["id"].Visible = false;
            GvGtin.Columns["sleeveName"].HeaderText = "筆型";
            GvGtin.Columns["sleeveName"].ReadOnly = true;
            GvGtin.Columns["gtin"].HeaderText = "GTIN";
            GvGtin.Columns["sleeveName"].Width = 200;
            GvGtin.Columns["gtin"].Width = 300;
            GvGtin.Columns["sleeveName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            GvGtin.Columns["gtin"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }


        #region ComboxItem
        private class ComboboxItem
        {
            public ComboboxItem(string value, string text)
            {
                Value = value;
                Text = text;
            }

            public string Value
            {
                get;
                set;
            }

            public string Text
            {
                get;
                set;
            }

            public override string ToString()
            {
                return Text;
            }
        }
        #endregion

        private void cbxMO_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strSQL = string.Format("select * from batchData where moNum = '{0}'", cbxMO.SelectedItem.ToString()); //檢查MO
            dtForGrid = accessHelper.GetDataTable(strSQL);
            reLoadBatch();
        }

        void clearGrid()
        {
            DataTable dt = (DataTable)dataGV.DataSource;
            dt.Rows.Clear();
            dataGV.DataSource = dt;
        }

        private void GvGtin_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // 獲取修改後的資料
                DataGridViewRow row = GvGtin.Rows[e.RowIndex];
                dtGtin.Rows[e.RowIndex]["id"] = (int)row.Cells["id"].Value;
                dtGtin.Rows[e.RowIndex]["sleeveName"] = (string)row.Cells["sleeveName"].Value;
                dtGtin.Rows[e.RowIndex]["gtin"] = (string)row.Cells["gtin"].Value;

                // 更新資料庫中的資料
                adapter.Update(dtGtin);
            }
            catch
            {
                MessageBox.Show("修改失敗");

            }
        }

        private void btnOpenCurrMeter_Click(object sender, EventArgs e)
        {
            // 開啟檔案，如果不存在就建立檔案
            using (StreamWriter outputFile = new StreamWriter(Application.StartupPath + @"\meter.txt"))
            {   // 寫入訊息
                outputFile.WriteLine("open");
            }
            MessageBox.Show("電流計已開啟，請將電流計的USB和+-極接到治具上");
        }
    }
}
