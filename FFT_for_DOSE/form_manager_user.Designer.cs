namespace FFT_For_DOSE
{
    partial class formManagerUser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_add = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbx_password_chk = new System.Windows.Forms.TextBox();
            this.tbx_password = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbx_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDelName = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxDelName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_add
            // 
            this.btn_add.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_add.Location = new System.Drawing.Point(113, 112);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(191, 27);
            this.btn_add.TabIndex = 57;
            this.btn_add.Text = "新增 / 更新";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 12F);
            this.label3.Location = new System.Drawing.Point(12, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 18);
            this.label3.TabIndex = 56;
            this.label3.Text = "密碼再確認:";
            // 
            // tbx_password_chk
            // 
            this.tbx_password_chk.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbx_password_chk.Location = new System.Drawing.Point(113, 79);
            this.tbx_password_chk.Name = "tbx_password_chk";
            this.tbx_password_chk.PasswordChar = '*';
            this.tbx_password_chk.Size = new System.Drawing.Size(191, 27);
            this.tbx_password_chk.TabIndex = 55;
            // 
            // tbx_password
            // 
            this.tbx_password.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbx_password.Location = new System.Drawing.Point(113, 46);
            this.tbx_password.Name = "tbx_password";
            this.tbx_password.PasswordChar = '*';
            this.tbx_password.Size = new System.Drawing.Size(191, 27);
            this.tbx_password.TabIndex = 54;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F);
            this.label2.Location = new System.Drawing.Point(12, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 18);
            this.label2.TabIndex = 53;
            this.label2.Text = "使用者密碼:";
            // 
            // tbx_name
            // 
            this.tbx_name.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbx_name.Location = new System.Drawing.Point(113, 13);
            this.tbx_name.Name = "tbx_name";
            this.tbx_name.Size = new System.Drawing.Size(191, 27);
            this.tbx_name.TabIndex = 52;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F);
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 18);
            this.label1.TabIndex = 51;
            this.label1.Text = "使用者名稱:";
            // 
            // btnDelName
            // 
            this.btnDelName.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnDelName.Location = new System.Drawing.Point(113, 206);
            this.btnDelName.Name = "btnDelName";
            this.btnDelName.Size = new System.Drawing.Size(191, 27);
            this.btnDelName.TabIndex = 58;
            this.btnDelName.Text = "刪除使用者";
            this.btnDelName.UseVisualStyleBackColor = true;
            this.btnDelName.Click += new System.EventHandler(this.btnDelName_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 12F);
            this.label4.Location = new System.Drawing.Point(12, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 18);
            this.label4.TabIndex = 59;
            this.label4.Text = "刪除使用者:";
            // 
            // tbxDelName
            // 
            this.tbxDelName.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbxDelName.Location = new System.Drawing.Point(113, 173);
            this.tbxDelName.Name = "tbxDelName";
            this.tbxDelName.Size = new System.Drawing.Size(191, 27);
            this.tbxDelName.TabIndex = 60;
            // 
            // formManagerUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(211)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(323, 245);
            this.Controls.Add(this.tbxDelName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnDelName);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbx_password_chk);
            this.Controls.Add(this.tbx_password);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbx_name);
            this.Controls.Add(this.label1);
            this.Name = "formManagerUser";
            this.Text = "管理使用者";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formManagerUser_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbx_password_chk;
        private System.Windows.Forms.TextBox tbx_password;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbx_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDelName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxDelName;
    }
}