using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FFT_For_DOSE
{

    public partial class FormManage : Form
    {
        DataTable dtForGrid;

        public bool showManUser { get; set; }
        bool showManage;
        AccessHelper accessHelper = new AccessHelper();

        loginForm logForm1 = null;

        public FormManage(bool showManage)
        {
            InitializeComponent();
            this.showManage = showManage;
        }

        private void Form_manage_Load(object sender, EventArgs e)
        {
            dataGV.AllowUserToAddRows = false;
            dataGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGV.MouseDown += dataGV_MouseDown;
            dataGV.UserDeletingRow += dataGV_UserDeletingRow;

            reLoadMoNum();
            string strSQL = string.Format("select * from batchData where moNum = '{0}'", cbxMO); //檢查MO
            dtForGrid = accessHelper.GetDataTable(strSQL);
            reLoadBatch();
        }

        private void dataGV_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult result =
                MessageBox.Show(
                    "是否刪除該筆資料",
                    "確認",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (result == DialogResult.No) e.Cancel = true;
        }

        private void dataGV_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            DataGridView dgv = sender as DataGridView;
            ShowMenu(dgv, e);
        }

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
            logForm1 = (loginForm)this.Owner;
            logForm1.showManage = false;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                string strSQL = "";
                string moNum = tbx_MO.Text;
                string batchNum = tbx_lot.Text;
                string makeTotal = tbx_make_total.Text;
                string sleeveName = cbxSleeve.SelectedItem.ToString();
                string pcbVersion = tbxPCB.Text;
                string housingVersion = tbxHousing.Text;

                if (moNum == "" || batchNum == "" || makeTotal == "" || sleeveName == "" || pcbVersion == "" || housingVersion == "")
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

                                strSQL = "select TOP 1 sn from snData order by sn desc"; //取得SN最大值
                                string getLastSn = accessHelper.readData(strSQL);



                               

                                ////執行SQL
                                //string snMax = accessHelper.readData(strSQL);
                                //intNextSn = Convert.ToInt32(snMax) + 1;
                                //snMax = intNextSn.ToString().PadLeft(7, '0');
                                //if (snMax != "-1")
                                //{
                                //    tbxSn.Text = "D" + snMax;
                                //}
                                //else
                                //{
                                //    MessageBox.Show("查詢失敗");
                                //}










                                string snMin = Convert.ToString(Convert.ToUInt32(getLastSn) + 1);
                                string snMax = Convert.ToString(Convert.ToUInt32(makeTotal) + Convert.ToUInt32(snMin)-1);
                                if (checkBatchNum == "-1")//MO不存在   
                                {
                                    #region 寫入
                                    //SQL語法：       
                                    strSQL = "insert into batchData(batchNum,moNum,total,sleeveName,pcbVersion,housingVersion,snMin,snMax)" +
                                    " VALUES(@batchNum,@moNum,@total,@sleeveName,@pcbVersion,@housingVersion,@snMin,@snMax)";
                                    if (string.IsNullOrEmpty(strSQL) == false)
                                    {
                                        //添加參數
                                        OleDbParameter[] pars2 = new OleDbParameter[] {
                                            new OleDbParameter("@batchNum",batchNum),
                                            new OleDbParameter("@moNum",moNum),
                                            new OleDbParameter("@total",makeTotal),
                                            new OleDbParameter("@sleeveName",sleeveName),
                                            new OleDbParameter("@pcbVersion",pcbVersion),
                                            new OleDbParameter("@housingVersion",housingVersion),
                                            new OleDbParameter("@snMin",snMin),
                                            new OleDbParameter("@snMax",snMax)
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
            catch
            {
                MessageBox.Show("發生錯誤!!");
            }
            reLoadMoNum();
        }

        private void btnDelMO_Click(object sender, EventArgs e)
        {
            try
            {
                //刪除Batch
                string strSQL = string.Format("DELETE FROM batchData where moNum ='{0}'", cbxMO.SelectedItem.ToString());
                string delResult = accessHelper.ExecSql(strSQL);
                //刪除MO
                strSQL = string.Format("DELETE FROM moData where moNum ='{0}'", cbxMO.SelectedItem.ToString());
                delResult = accessHelper.ExecSql(strSQL);
                if (delResult != "")
                {
                    MessageBox.Show("刪除失敗，其它資料表包含相關資料!!");
                }
                else
                {
                    MessageBox.Show("刪除 " + cbxMO.SelectedItem.ToString() + " 完成");

                    loadNullGrid();


                }
                reLoadMoNum();
            }
            catch
            {
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
            dataGV.Columns["pcbVersion"].HeaderText = "PCB版本";
            dataGV.Columns["housingVersion"].HeaderText = "外殼版本";
            dataGV.Columns["SnMin"].HeaderText = "Sn最小值";
            dataGV.Columns["SnMax"].HeaderText = "Sn最大值";

            dataGV.Columns["moNum"].Width = 120;
            dataGV.Columns["batchNum"].Width = 120;
            dataGV.Columns["total"].Width = 100;
            dataGV.Columns["sleeveName"].Width = 120;
            dataGV.Columns["pcbVersion"].Width = 120;
            dataGV.Columns["housingVersion"].Width = 120;
            dataGV.Columns["SnMin"].Width = 100;
            dataGV.Columns["SnMax"].Width = 100;

            dataGV.Columns["moNum"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGV.Columns["batchNum"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGV.Columns["total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGV.Columns["sleeveName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGV.Columns["pcbVersion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGV.Columns["housingVersion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGV.Columns["SnMin"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGV.Columns["SnMax"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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

        void loadNullGrid()
        {
            DataTable dt = (DataTable)dataGV .DataSource;
            dt.Rows.Clear();
            dataGV.DataSource = dt;
        }
    }
}
