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
    public partial class formManagerUser : Form
    {
        AccessHelper accessHelper = new AccessHelper();
        bool showManUser;
        FormManage FormManage1 = null;
        public formManagerUser(bool showManUser)
        {
            InitializeComponent();
            this.showManUser = showManUser;
        }


        private void formManagerUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormManage1 = (FormManage)this.Owner;
            FormManage1.showManUser = false;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if ((tbx_name.Text.Length > 3) && (tbx_password.Text.Length > 3) && (tbx_password.Text == tbx_password_chk.Text))
            {
                //此帳號是否己存在, 存在請先刪除
                string str_sql = string.Format("SELECT user_name FROM _user where user_name = '{0}'", tbx_name.Text);
                string username2 = accessHelper.readData(str_sql);
                if (username2 == "-1")
                {
                    //帳號不存在，新增帳號
                    str_sql = String.Format("insert into _user (user_name,pass_word) values('{0}','{1}')", tbx_name.Text, tbx_password.Text);
                    accessHelper.ExecSql(str_sql);
                    MessageBox.Show("新增使用者完成");
                }
                else
                {
                    //帳號已存在，更新密碼                 
                    str_sql = String.Format("UPDATE _user set pass_word = '{0}' where user_name = '{1}'", tbx_password.Text, tbx_name.Text);
                    accessHelper.ExecSql(str_sql);
                    MessageBox.Show("密碼更新完成");
                }
            }
            else
            {
                MessageBox.Show("密碼長度太短或不相符");
            }
        }

        private void btnDelName_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbxDelName.Text == "Neil" || tbxDelName.Text == "neil")
                {
                    MessageBox.Show("Neil為系統管理者，不可被刪除!");
                }
                else
                {
                    //刪除User
                    string str_sql = string.Format("SELECT * FROM _user where user_name = '{0}'", tbxDelName.Text);
                    string username2 = accessHelper.readData(str_sql);
                    if (username2 == "-1")
                    {
                        MessageBox.Show("無此使用者");
                    }
                    else
                    {
                        string strSQL = string.Format("DELETE FROM _user where user_name ='{0}'", tbxDelName.Text);
                        string delResult = accessHelper.ExecSql(strSQL);
                        if (delResult != "")
                        {
                            MessageBox.Show("刪除失敗!");
                        }
                        else
                        {
                            MessageBox.Show("刪除 " + tbxDelName.Text + " 完成");
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("發生錯誤!!");
            }
        }
    }
}
