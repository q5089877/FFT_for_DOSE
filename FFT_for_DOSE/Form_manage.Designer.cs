namespace FFT_For_DOSE
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
            this.components = new System.ComponentModel.Container();
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.GvGtin = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.btnOpenCurrMeter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGV)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GvGtin)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_open_user
            // 
            this.btn_open_user.Font = new System.Drawing.Font("Verdana", 12F);
            this.btn_open_user.Location = new System.Drawing.Point(102, 267);
            this.btn_open_user.Name = "btn_open_user";
            this.btn_open_user.Size = new System.Drawing.Size(191, 28);
            this.btn_open_user.TabIndex = 79;
            this.btn_open_user.Text = "開啟使用者管理";
            this.btn_open_user.UseVisualStyleBackColor = true;
            this.btn_open_user.Click += new System.EventHandler(this.btn_open_user_Click);
            // 
            // btnDelMO
            // 
            this.btnDelMO.Font = new System.Drawing.Font("Verdana", 12F);
            this.btnDelMO.Location = new System.Drawing.Point(589, 36);
            this.btnDelMO.Name = "btnDelMO";
            this.btnDelMO.Size = new System.Drawing.Size(93, 28);
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
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGV.Location = new System.Drawing.Point(306, 70);
            this.dataGV.Name = "dataGV";
            this.dataGV.ReadOnly = true;
            this.dataGV.RowTemplate.Height = 24;
            this.dataGV.Size = new System.Drawing.Size(914, 244);
            this.dataGV.TabIndex = 76;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 12F);
            this.label5.Location = new System.Drawing.Point(19, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 18);
            this.label5.TabIndex = 74;
            this.label5.Text = "製作批號:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 12F);
            this.label3.Location = new System.Drawing.Point(19, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 18);
            this.label3.TabIndex = 73;
            this.label3.Text = "製作數量:";
            // 
            // cbxSleeve
            // 
            this.cbxSleeve.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSleeve.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbxSleeve.FormattingEnabled = true;
            this.cbxSleeve.Items.AddRange(new object[] {
            "FT",
            "KP",
            "SS",
            "NP5"});
            this.cbxSleeve.Location = new System.Drawing.Point(103, 69);
            this.cbxSleeve.Name = "cbxSleeve";
            this.cbxSleeve.Size = new System.Drawing.Size(191, 24);
            this.cbxSleeve.TabIndex = 72;
            // 
            // tbx_make_total
            // 
            this.tbx_make_total.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbx_make_total.Location = new System.Drawing.Point(103, 132);
            this.tbx_make_total.Name = "tbx_make_total";
            this.tbx_make_total.Size = new System.Drawing.Size(191, 27);
            this.tbx_make_total.TabIndex = 71;
            // 
            // tbx_lot
            // 
            this.tbx_lot.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbx_lot.Location = new System.Drawing.Point(103, 99);
            this.tbx_lot.Name = "tbx_lot";
            this.tbx_lot.Size = new System.Drawing.Size(191, 27);
            this.tbx_lot.TabIndex = 70;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F);
            this.label2.Location = new System.Drawing.Point(19, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 18);
            this.label2.TabIndex = 69;
            this.label2.Text = "筆型名稱:";
            // 
            // btn_add
            // 
            this.btn_add.Font = new System.Drawing.Font("Verdana", 12F);
            this.btn_add.Location = new System.Drawing.Point(102, 231);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(191, 28);
            this.btn_add.TabIndex = 68;
            this.btn_add.Text = "新增工單";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // tbx_MO
            // 
            this.tbx_MO.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbx_MO.Location = new System.Drawing.Point(103, 36);
            this.tbx_MO.Name = "tbx_MO";
            this.tbx_MO.Size = new System.Drawing.Size(191, 27);
            this.tbx_MO.TabIndex = 67;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F);
            this.label1.Location = new System.Drawing.Point(19, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 18);
            this.label1.TabIndex = 66;
            this.label1.Text = "工單號碼:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 12F);
            this.label4.Location = new System.Drawing.Point(306, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 18);
            this.label4.TabIndex = 65;
            this.label4.Text = "工單號碼:";
            // 
            // cbxMO
            // 
            this.cbxMO.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbxMO.FormattingEnabled = true;
            this.cbxMO.Location = new System.Drawing.Point(387, 38);
            this.cbxMO.Name = "cbxMO";
            this.cbxMO.Size = new System.Drawing.Size(191, 24);
            this.cbxMO.TabIndex = 64;
            this.cbxMO.SelectedIndexChanged += new System.EventHandler(this.cbxMO_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 12F);
            this.label7.Location = new System.Drawing.Point(19, 165);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 18);
            this.label7.TabIndex = 81;
            this.label7.Text = "PCB版本:";
            // 
            // tbxPCB
            // 
            this.tbxPCB.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbxPCB.Location = new System.Drawing.Point(103, 165);
            this.tbxPCB.Name = "tbxPCB";
            this.tbxPCB.Size = new System.Drawing.Size(191, 27);
            this.tbxPCB.TabIndex = 80;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 12F);
            this.label8.Location = new System.Drawing.Point(19, 198);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 18);
            this.label8.TabIndex = 83;
            this.label8.Text = "外殼版本:";
            // 
            // tbxHousing
            // 
            this.tbxHousing.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbxHousing.Location = new System.Drawing.Point(103, 198);
            this.tbxHousing.Name = "tbxHousing";
            this.tbxHousing.Size = new System.Drawing.Size(191, 27);
            this.tbxHousing.TabIndex = 82;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(221)))), ((int)(((byte)(240)))));
            this.groupBox1.Controls.Add(this.GvGtin);
            this.groupBox1.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox1.Location = new System.Drawing.Point(12, 344);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1231, 307);
            this.groupBox1.TabIndex = 84;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "GTIN設定";
            // 
            // GvGtin
            // 
            this.GvGtin.AllowUserToAddRows = false;
            this.GvGtin.AllowUserToDeleteRows = false;
            this.GvGtin.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(197)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GvGtin.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.GvGtin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GvGtin.Location = new System.Drawing.Point(22, 41);
            this.GvGtin.Name = "GvGtin";
            this.GvGtin.RowTemplate.Height = 24;
            this.GvGtin.Size = new System.Drawing.Size(581, 225);
            this.GvGtin.TabIndex = 77;
            this.GvGtin.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.GvGtin_CellEndEdit);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(221)))), ((int)(((byte)(240)))));
            this.groupBox2.Controls.Add(this.dataGV);
            this.groupBox2.Controls.Add(this.cbxMO);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.tbxHousing);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.tbx_MO);
            this.groupBox2.Controls.Add(this.tbxPCB);
            this.groupBox2.Controls.Add(this.btn_add);
            this.groupBox2.Controls.Add(this.btn_open_user);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnDelMO);
            this.groupBox2.Controls.Add(this.tbx_lot);
            this.groupBox2.Controls.Add(this.tbx_make_total);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cbxSleeve);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1231, 326);
            this.groupBox2.TabIndex = 85;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "工單管理";
            // 
            // btnOpenCurrMeter
            // 
            this.btnOpenCurrMeter.Font = new System.Drawing.Font("Verdana", 12F);
            this.btnOpenCurrMeter.Location = new System.Drawing.Point(12, 657);
            this.btnOpenCurrMeter.Name = "btnOpenCurrMeter";
            this.btnOpenCurrMeter.Size = new System.Drawing.Size(105, 28);
            this.btnOpenCurrMeter.TabIndex = 84;
            this.btnOpenCurrMeter.Text = "開啟電流計";
            this.btnOpenCurrMeter.UseVisualStyleBackColor = true;
            this.btnOpenCurrMeter.Click += new System.EventHandler(this.btnOpenCurrMeter_Click);
            // 
            // FormManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(1256, 697);
            this.Controls.Add(this.btnOpenCurrMeter);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormManage";
            this.Text = "工單管理";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_manage_FormClosed);
            this.Load += new System.EventHandler(this.Form_manage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGV)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GvGtin)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView GvGtin;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button btnOpenCurrMeter;
    }
}