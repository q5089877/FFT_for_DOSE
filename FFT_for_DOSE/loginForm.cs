using FFT_DOSE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FFT_For_DOSE
{
    public partial class loginForm : Form
    {
        public bool showManage { get; set; }
        bool showLogForm;
        AccessHelper accessHelper = new AccessHelper();

        Form1 f1 = null;

        public loginForm(bool showLogForm)
        {
            InitializeComponent();
            this.showLogForm = showLogForm;
        }

        private void loginForm_Load(object sender, EventArgs e)
        {
            //載入工單號碼到下單選單
            string str_sql = "SELECT user_name FROM _user";
            DataTable dt = accessHelper.GetDataTable(str_sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string str_dt = dt.Rows[i][0].ToString();
                cbx_name.Items.Add(new ComboboxItem(str_dt, str_dt));
            }
            tbx_password.PasswordChar = '*';

            cbx_name.SelectedIndex = 0;
        }

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

        private void btn_enter_Click(object sender, EventArgs e)
        {
            if ((tbx_password.Text.Length > 3) && (tbx_password.Text != ""))
            {
                //此判斷帳號密碼是否正確
                string str_sql = string.Format("SELECT pass_word FROM _user where user_name = '{0}'", cbx_name.SelectedItem.ToString());
                string pass_word = accessHelper.readData(str_sql);

                if (pass_word != "-2")
                {
                    //帳號密碼存在，比對密碼
                    if (pass_word == tbx_password.Text)
                    {
                        //    MessageBox.Show("登入成功");
                        try
                        {
                            if (showManage == false)
                            {
                                FormManage FormManage1 = new FormManage(showManage);
                                FormManage1.Owner = this;
                                FormManage1.Show();
                                showManage = true;
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Form_manage Error");
                        }
                    }
                    else
                    {
                        MessageBox.Show("登入失敗");
                    }
                }
                else
                {
                    MessageBox.Show("登入失敗");
                }
            }
            else
            {
                MessageBox.Show("密碼長度不足");
            }
        }

        private void loginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            f1 = (Form1)this.Owner;
            f1.showLogForm = false;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbx_name.SelectedItem != null && cbx_name.SelectedItem.ToString() != "" && cbx_name.SelectedItem.ToString() != "Neil")
                {
                    //刪除該使用者
                    string strSQL = string.Format("DELETE FROM _user where user_name ='{0}'", cbx_name.SelectedItem.ToString());
                    accessHelper.ExecSql(strSQL);
                    MessageBox.Show("刪除 " + cbx_name.SelectedItem.ToString() + " 完成");

                    //載入工單號碼到下單選單
                    cbx_name.Text = "";
                    cbx_name.Items.Clear();
                    string str_sql = "SELECT user_name FROM _user";
                    DataTable dt = accessHelper.GetDataTable(str_sql);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string str_dt = dt.Rows[i][0].ToString();
                        cbx_name.Items.Add(new ComboboxItem(str_dt, str_dt));
                    }
                }
                else
                {
                    MessageBox.Show("刪除失敗");
                }
            }
            catch
            {
                MessageBox.Show("刪除失敗");
            }
        }
    }
}