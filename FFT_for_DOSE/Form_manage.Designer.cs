﻿namespace FFT_For_DOSE
{
    partial class FormManage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btn_open_user = new System.Windows.Forms.Button();
            this.btnDelMO = new System.Windows.Forms.Button();
            this.dataGV = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxSleeve = new System.Windows.Forms.ComboBox();
            this.tbx_make_total = new System.Windows.Forms.TextBox();
            this.tbx_lot = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_add = new System.Windows.Forms.Button();
            this.tbx_MO = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxMO = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxPCB = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbxHousing = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGV)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_open_user
            // 
            this.btn_open_user.Font = new System.Drawing.Font("Verdana", 12F);
            this.btn_open_user.Location = new System.Drawing.Point(129, 315);
            this.btn_open_user.Margin = new System.Windows.Forms.Padding(4);
            this.btn_open_user.Name = "btn_open_user";
            this.btn_open_user.Size = new System.Drawing.Size(255, 35);
            this.btn_open_user.TabIndex = 79;
            this.btn_open_user.Text = "開啟使用者管理";
            this.btn_open_user.UseVisualStyleBackColor = true;
            this.btn_open_user.Click += new System.EventHandler(this.btn_open_user_Click);
            // 
            // btnDelMO
            // 
            this.btnDelMO.Font = new System.Drawing.Font("Verdana", 12F);
            this.btnDelMO.Location = new System.Drawing.Point(779, 26);
            this.btnDelMO.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelMO.Name = "btnDelMO";
            this.btnDelMO.Size = new System.Drawing.Size(124, 35);
            this.btnDelMO.TabIndex = 78;
            this.btnDelMO.Text = "刪除";
            this.btnDelMO.UseVisualStyleBackColor = true;
            this.btnDelMO.Click += new System.EventHandler(this.btnDelMO_Click);
            // 
            // dataGV
            // 
            this.dataGV.AllowUserToAddRows = false;
            this.dataGV.AllowUserToDeleteRows = false;
            this.dataGV.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(197)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("PMingLiU", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("PMingLiU", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGV.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGV.Location = new System.Drawing.Point(401, 69);
            this.dataGV.Margin = new System.Windows.Forms.Padding(4);
            this.dataGV.Name = "dataGV";
            this.dataGV.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("PMingLiU", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGV.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGV.RowTemplate.Height = 24;
            this.dataGV.Size = new System.Drawing.Size(901, 305);
            this.dataGV.TabIndex = 76;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 12F);
            this.label5.Location = new System.Drawing.Point(18, 105);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 25);
            this.label5.TabIndex = 74;
            this.label5.Text = "製作批號:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 12F);
            this.label3.Location = new System.Drawing.Point(18, 146);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 25);
            this.label3.TabIndex = 73;
            this.label3.Text = "製作數量:";
            // 
            // cbxSleeve
            // 
            this.cbxSleeve.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSleeve.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbxSleeve.FormattingEnabled = true;
            this.cbxSleeve.Items.AddRange(new object[] {
            "FlexPen",
            "KwiPen",
            "SoloSTAR",
            "NovoPen4_5",
            "NovoPen Echo"});
            this.cbxSleeve.Location = new System.Drawing.Point(131, 68);
            this.cbxSleeve.Margin = new System.Windows.Forms.Padding(4);
            this.cbxSleeve.Name = "cbxSleeve";
            this.cbxSleeve.Size = new System.Drawing.Size(253, 28);
            this.cbxSleeve.TabIndex = 72;
            // 
            // tbx_make_total
            // 
            this.tbx_make_total.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbx_make_total.Location = new System.Drawing.Point(131, 146);
            this.tbx_make_total.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_make_total.Name = "tbx_make_total";
            this.tbx_make_total.Size = new System.Drawing.Size(253, 31);
            this.tbx_make_total.TabIndex = 71;
            // 
            // tbx_lot
            // 
            this.tbx_lot.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbx_lot.Location = new System.Drawing.Point(131, 105);
            this.tbx_lot.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_lot.Name = "tbx_lot";
            this.tbx_lot.Size = new System.Drawing.Size(253, 31);
            this.tbx_lot.TabIndex = 70;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F);
            this.label2.Location = new System.Drawing.Point(18, 68);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 25);
            this.label2.TabIndex = 69;
            this.label2.Text = "筆型名稱:";
            // 
            // btn_add
            // 
            this.btn_add.Font = new System.Drawing.Font("Verdana", 12F);
            this.btn_add.Location = new System.Drawing.Point(129, 270);
            this.btn_add.Margin = new System.Windows.Forms.Padding(4);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(255, 35);
            this.btn_add.TabIndex = 68;
            this.btn_add.Text = "新增工單";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // tbx_MO
            // 
            this.tbx_MO.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbx_MO.Location = new System.Drawing.Point(131, 26);
            this.tbx_MO.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_MO.Name = "tbx_MO";
            this.tbx_MO.Size = new System.Drawing.Size(253, 31);
            this.tbx_MO.TabIndex = 67;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F);
            this.label1.Location = new System.Drawing.Point(18, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 25);
            this.label1.TabIndex = 66;
            this.label1.Text = "工單號碼:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 12F);
            this.label4.Location = new System.Drawing.Point(401, 27);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 25);
            this.label4.TabIndex = 65;
            this.label4.Text = "工單號碼:";
            // 
            // cbxMO
            // 
            this.cbxMO.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbxMO.FormattingEnabled = true;
            this.cbxMO.Location = new System.Drawing.Point(510, 29);
            this.cbxMO.Margin = new System.Windows.Forms.Padding(4);
            this.cbxMO.Name = "cbxMO";
            this.cbxMO.Size = new System.Drawing.Size(253, 28);
            this.cbxMO.TabIndex = 64;
            this.cbxMO.SelectedIndexChanged += new System.EventHandler(this.cbxMO_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 12F);
            this.label7.Location = new System.Drawing.Point(18, 188);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 25);
            this.label7.TabIndex = 81;
            this.label7.Text = "PCB版本:";
            // 
            // tbxPCB
            // 
            this.tbxPCB.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbxPCB.Location = new System.Drawing.Point(131, 188);
            this.tbxPCB.Margin = new System.Windows.Forms.Padding(4);
            this.tbxPCB.Name = "tbxPCB";
            this.tbxPCB.Size = new System.Drawing.Size(253, 31);
            this.tbxPCB.TabIndex = 80;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 12F);
            this.label8.Location = new System.Drawing.Point(18, 229);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 25);
            this.label8.TabIndex = 83;
            this.label8.Text = "外殼版本:";
            // 
            // tbxHousing
            // 
            this.tbxHousing.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbxHousing.Location = new System.Drawing.Point(131, 229);
            this.tbxHousing.Margin = new System.Windows.Forms.Padding(4);
            this.tbxHousing.Name = "tbxHousing";
            this.tbxHousing.Size = new System.Drawing.Size(253, 31);
            this.tbxHousing.TabIndex = 82;
            // 
            // FormManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(211)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(1317, 396);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbxHousing);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbxPCB);
            this.Controls.Add(this.btn_open_user);
            this.Controls.Add(this.btnDelMO);
            this.Controls.Add(this.dataGV);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbxSleeve);
            this.Controls.Add(this.tbx_make_total);
            this.Controls.Add(this.tbx_lot);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.tbx_MO);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbxMO);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormManage";
            this.Text = "工單管理";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_manage_FormClosed);
            this.Load += new System.EventHandler(this.Form_manage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_open_user;
        private System.Windows.Forms.Button btnDelMO;
        private System.Windows.Forms.DataGridView dataGV;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxSleeve;
        private System.Windows.Forms.TextBox tbx_make_total;
        private System.Windows.Forms.TextBox tbx_lot;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.TextBox tbx_MO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxMO;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbxPCB;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbxHousing;
    }
}