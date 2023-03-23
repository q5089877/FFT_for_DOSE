namespace FFT_DOSE
{
    partial class MainForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.RS232_PLC = new System.IO.Ports.SerialPort(this.components);
            this.RS232_DOSE = new System.IO.Ports.SerialPort(this.components);
            this.btn_clr_pcb = new System.Windows.Forms.Button();
            this.btn_ttl_send = new System.Windows.Forms.Button();
            this.tbx_Pcb_feed_back = new System.Windows.Forms.TextBox();
            this.tbx_ttl_send = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.btn_clear_com = new System.Windows.Forms.Button();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label20 = new System.Windows.Forms.Label();
            this.lbl_charge_curr = new System.Windows.Forms.Label();
            this.btnOpenManage = new System.Windows.Forms.Button();
            this.btnShipMode = new System.Windows.Forms.Button();
            this.btnStatus = new System.Windows.Forms.Button();
            this.label37 = new System.Windows.Forms.Label();
            this.cbxBatch = new System.Windows.Forms.ComboBox();
            this.label38 = new System.Windows.Forms.Label();
            this.lblBatCompleteNum = new System.Windows.Forms.Label();
            this.lblBatTotal = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.cbx_name = new System.Windows.Forms.ComboBox();
            this.tbxPassword = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnLabelManual = new System.Windows.Forms.Button();
            this.cbxSleeveName_for_Mprint = new System.Windows.Forms.ComboBox();
            this.tbxSN_for_Mprint = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblPowCom = new System.Windows.Forms.Label();
            this.cbx_plc = new System.Windows.Forms.ComboBox();
            this.cbx_power = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblSleeve = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.currGroupBox = new System.Windows.Forms.GroupBox();
            this.btnPrintLabel = new System.Windows.Forms.Button();
            this.tbxSn = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.btn_ass_chk = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.currGroupBox.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // RS232_PLC
            // 
            this.RS232_PLC.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // RS232_DOSE
            // 
            this.RS232_DOSE.BaudRate = 921600;
            this.RS232_DOSE.ReadBufferSize = 40960;
            this.RS232_DOSE.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.RS232_DOSE_DataReceived);
            // 
            // btn_clr_pcb
            // 
            this.btn_clr_pcb.Font = new System.Drawing.Font("Verdana", 12F);
            this.btn_clr_pcb.ForeColor = System.Drawing.Color.Navy;
            this.btn_clr_pcb.Location = new System.Drawing.Point(332, 652);
            this.btn_clr_pcb.Name = "btn_clr_pcb";
            this.btn_clr_pcb.Size = new System.Drawing.Size(110, 27);
            this.btn_clr_pcb.TabIndex = 137;
            this.btn_clr_pcb.Text = "Clear";
            this.btn_clr_pcb.UseVisualStyleBackColor = true;
            this.btn_clr_pcb.Click += new System.EventHandler(this.btn_clr_pcb_Click);
            // 
            // btn_ttl_send
            // 
            this.btn_ttl_send.Font = new System.Drawing.Font("Verdana", 12F);
            this.btn_ttl_send.ForeColor = System.Drawing.Color.Navy;
            this.btn_ttl_send.Location = new System.Drawing.Point(211, 652);
            this.btn_ttl_send.Name = "btn_ttl_send";
            this.btn_ttl_send.Size = new System.Drawing.Size(115, 27);
            this.btn_ttl_send.TabIndex = 136;
            this.btn_ttl_send.Text = "Send";
            this.btn_ttl_send.UseVisualStyleBackColor = true;
            this.btn_ttl_send.Click += new System.EventHandler(this.btn_ttl_send_Click);
            // 
            // tbx_Pcb_feed_back
            // 
            this.tbx_Pcb_feed_back.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_Pcb_feed_back.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(184)))), ((int)(((byte)(195)))));
            this.tbx_Pcb_feed_back.Font = new System.Drawing.Font("PMingLiU", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbx_Pcb_feed_back.ForeColor = System.Drawing.Color.DarkBlue;
            this.tbx_Pcb_feed_back.Location = new System.Drawing.Point(3, 23);
            this.tbx_Pcb_feed_back.Multiline = true;
            this.tbx_Pcb_feed_back.Name = "tbx_Pcb_feed_back";
            this.tbx_Pcb_feed_back.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbx_Pcb_feed_back.Size = new System.Drawing.Size(445, 623);
            this.tbx_Pcb_feed_back.TabIndex = 134;
            // 
            // tbx_ttl_send
            // 
            this.tbx_ttl_send.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbx_ttl_send.Location = new System.Drawing.Point(64, 652);
            this.tbx_ttl_send.Name = "tbx_ttl_send";
            this.tbx_ttl_send.Size = new System.Drawing.Size(141, 27);
            this.tbx_ttl_send.TabIndex = 133;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Verdana", 12F);
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label19.Location = new System.Drawing.Point(11, 658);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(47, 18);
            this.label19.TabIndex = 135;
            this.label19.Text = "指令:";
            // 
            // btn_clear_com
            // 
            this.btn_clear_com.Font = new System.Drawing.Font("Verdana", 12F);
            this.btn_clear_com.ForeColor = System.Drawing.Color.Navy;
            this.btn_clear_com.Location = new System.Drawing.Point(25, 90);
            this.btn_clear_com.Name = "btn_clear_com";
            this.btn_clear_com.Size = new System.Drawing.Size(280, 55);
            this.btn_clear_com.TabIndex = 139;
            this.btn_clear_com.Text = "Clear ComPort";
            this.btn_clear_com.UseVisualStyleBackColor = true;
            this.btn_clear_com.Click += new System.EventHandler(this.btn_clear_com_Click);
            // 
            // chart2
            // 
            chartArea1.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart2.Legends.Add(legend1);
            this.chart2.Location = new System.Drawing.Point(9, 44);
            this.chart2.Name = "chart2";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart2.Series.Add(series1);
            this.chart2.Size = new System.Drawing.Size(722, 640);
            this.chart2.TabIndex = 140;
            this.chart2.Text = "123456";
            this.chart2.Visible = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Verdana", 12F);
            this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label20.Location = new System.Drawing.Point(6, 23);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(246, 18);
            this.label20.TabIndex = 141;
            this.label20.Text = "Chargeing Current Maximum:";
            // 
            // lbl_charge_curr
            // 
            this.lbl_charge_curr.AutoSize = true;
            this.lbl_charge_curr.Font = new System.Drawing.Font("Verdana", 12F);
            this.lbl_charge_curr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_charge_curr.Location = new System.Drawing.Point(251, 23);
            this.lbl_charge_curr.Name = "lbl_charge_curr";
            this.lbl_charge_curr.Size = new System.Drawing.Size(70, 18);
            this.lbl_charge_curr.TabIndex = 142;
            this.lbl_charge_curr.Text = "200 mA";
            // 
            // btnOpenManage
            // 
            this.btnOpenManage.Font = new System.Drawing.Font("Verdana", 12F);
            this.btnOpenManage.ForeColor = System.Drawing.Color.Navy;
            this.btnOpenManage.Location = new System.Drawing.Point(159, 28);
            this.btnOpenManage.Name = "btnOpenManage";
            this.btnOpenManage.Size = new System.Drawing.Size(269, 28);
            this.btnOpenManage.TabIndex = 171;
            this.btnOpenManage.Text = "工單管理";
            this.btnOpenManage.UseVisualStyleBackColor = true;
            this.btnOpenManage.Click += new System.EventHandler(this.btnOpenManage_Click);
            // 
            // btnShipMode
            // 
            this.btnShipMode.Font = new System.Drawing.Font("Verdana", 12F);
            this.btnShipMode.ForeColor = System.Drawing.Color.Navy;
            this.btnShipMode.Location = new System.Drawing.Point(25, 29);
            this.btnShipMode.Name = "btnShipMode";
            this.btnShipMode.Size = new System.Drawing.Size(280, 55);
            this.btnShipMode.TabIndex = 173;
            this.btnShipMode.Text = "Ship Mode";
            this.btnShipMode.UseVisualStyleBackColor = true;
            this.btnShipMode.Click += new System.EventHandler(this.btnShipMode_Click);
            // 
            // btnStatus
            // 
            this.btnStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStatus.Font = new System.Drawing.Font("Verdana", 12F);
            this.btnStatus.ForeColor = System.Drawing.Color.Navy;
            this.btnStatus.Location = new System.Drawing.Point(597, 29);
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.Size = new System.Drawing.Size(305, 55);
            this.btnStatus.TabIndex = 179;
            this.btnStatus.Text = "Status";
            this.btnStatus.UseVisualStyleBackColor = true;
            this.btnStatus.Click += new System.EventHandler(this.btnStatus_Click);
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Verdana", 12F);
            this.label37.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label37.Location = new System.Drawing.Point(74, 165);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(79, 18);
            this.label37.TabIndex = 181;
            this.label37.Text = "製作批號:";
            // 
            // cbxBatch
            // 
            this.cbxBatch.Enabled = false;
            this.cbxBatch.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbxBatch.FormattingEnabled = true;
            this.cbxBatch.Location = new System.Drawing.Point(160, 159);
            this.cbxBatch.Name = "cbxBatch";
            this.cbxBatch.Size = new System.Drawing.Size(268, 24);
            this.cbxBatch.TabIndex = 183;
            this.cbxBatch.SelectedIndexChanged += new System.EventHandler(this.cbxBatch_SelectedIndexChanged);
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Verdana", 12F);
            this.label38.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label38.Location = new System.Drawing.Point(75, 252);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(79, 18);
            this.label38.TabIndex = 185;
            this.label38.Text = "完成數量:";
            // 
            // lblBatCompleteNum
            // 
            this.lblBatCompleteNum.AutoSize = true;
            this.lblBatCompleteNum.Font = new System.Drawing.Font("Verdana", 12F);
            this.lblBatCompleteNum.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblBatCompleteNum.Location = new System.Drawing.Point(159, 252);
            this.lblBatCompleteNum.Name = "lblBatCompleteNum";
            this.lblBatCompleteNum.Size = new System.Drawing.Size(58, 18);
            this.lblBatCompleteNum.TabIndex = 186;
            this.lblBatCompleteNum.Text = "00000";
            // 
            // lblBatTotal
            // 
            this.lblBatTotal.AutoSize = true;
            this.lblBatTotal.Font = new System.Drawing.Font("Verdana", 12F);
            this.lblBatTotal.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblBatTotal.Location = new System.Drawing.Point(159, 223);
            this.lblBatTotal.Name = "lblBatTotal";
            this.lblBatTotal.Size = new System.Drawing.Size(58, 18);
            this.lblBatTotal.TabIndex = 188;
            this.lblBatTotal.Text = "00000";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("Verdana", 12F);
            this.label40.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label40.Location = new System.Drawing.Point(74, 223);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(79, 18);
            this.label40.TabIndex = 187;
            this.label40.Text = "欲做數量:";
            // 
            // cbx_name
            // 
            this.cbx_name.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbx_name.FormattingEnabled = true;
            this.cbx_name.Location = new System.Drawing.Point(160, 62);
            this.cbx_name.Name = "cbx_name";
            this.cbx_name.Size = new System.Drawing.Size(268, 24);
            this.cbx_name.TabIndex = 192;
            // 
            // tbxPassword
            // 
            this.tbxPassword.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbxPassword.Location = new System.Drawing.Point(160, 92);
            this.tbxPassword.Name = "tbxPassword";
            this.tbxPassword.PasswordChar = '*';
            this.tbxPassword.Size = new System.Drawing.Size(268, 27);
            this.tbxPassword.TabIndex = 191;
            this.tbxPassword.Text = "690422";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Verdana", 12F);
            this.label39.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label39.Location = new System.Drawing.Point(59, 101);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(95, 18);
            this.label39.TabIndex = 190;
            this.label39.Text = "使用者密碼:";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Verdana", 12F);
            this.label41.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label41.Location = new System.Drawing.Point(59, 68);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(95, 18);
            this.label41.TabIndex = 189;
            this.label41.Text = "使用者名稱:";
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("Verdana", 12F);
            this.btnLogin.ForeColor = System.Drawing.Color.Navy;
            this.btnLogin.Location = new System.Drawing.Point(158, 125);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(270, 28);
            this.btnLogin.TabIndex = 193;
            this.btnLogin.Text = "登入選擇批號";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnLabelManual
            // 
            this.btnLabelManual.Font = new System.Drawing.Font("Verdana", 12F);
            this.btnLabelManual.ForeColor = System.Drawing.Color.Navy;
            this.btnLabelManual.Location = new System.Drawing.Point(292, 64);
            this.btnLabelManual.Name = "btnLabelManual";
            this.btnLabelManual.Size = new System.Drawing.Size(136, 41);
            this.btnLabelManual.TabIndex = 194;
            this.btnLabelManual.Text = "Print Label";
            this.btnLabelManual.UseVisualStyleBackColor = true;
            this.btnLabelManual.Click += new System.EventHandler(this.btnLabelManual_Click);
            // 
            // cbxSleeveName_for_Mprint
            // 
            this.cbxSleeveName_for_Mprint.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbxSleeveName_for_Mprint.FormattingEnabled = true;
            this.cbxSleeveName_for_Mprint.Items.AddRange(new object[] {
            "SS",
            "FT",
            "KP",
            "NP5"});
            this.cbxSleeveName_for_Mprint.Location = new System.Drawing.Point(160, 34);
            this.cbxSleeveName_for_Mprint.Name = "cbxSleeveName_for_Mprint";
            this.cbxSleeveName_for_Mprint.Size = new System.Drawing.Size(83, 24);
            this.cbxSleeveName_for_Mprint.TabIndex = 195;
            // 
            // tbxSN_for_Mprint
            // 
            this.tbxSN_for_Mprint.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbxSN_for_Mprint.Location = new System.Drawing.Point(292, 31);
            this.tbxSN_for_Mprint.Name = "tbxSN_for_Mprint";
            this.tbxSN_for_Mprint.Size = new System.Drawing.Size(136, 27);
            this.tbxSN_for_Mprint.TabIndex = 196;
            this.tbxSN_for_Mprint.Text = "000000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label2.Location = new System.Drawing.Point(84, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 18);
            this.label2.TabIndex = 197;
            this.label2.Text = "Sleeve:";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(184)))), ((int)(((byte)(195)))));
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnLabelManual);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbxSleeveName_for_Mprint);
            this.groupBox1.Controls.Add(this.tbxSN_for_Mprint);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 12F);
            this.groupBox1.ForeColor = System.Drawing.Color.Navy;
            this.groupBox1.Location = new System.Drawing.Point(6, 584);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(448, 123);
            this.groupBox1.TabIndex = 198;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "手動列印區";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 12F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label3.Location = new System.Drawing.Point(249, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 18);
            this.label3.TabIndex = 198;
            this.label3.Text = "SN:";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(184)))), ((int)(((byte)(195)))));
            this.groupBox2.Controls.Add(this.lblPowCom);
            this.groupBox2.Controls.Add(this.cbx_plc);
            this.groupBox2.Controls.Add(this.cbx_power);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 12F);
            this.groupBox2.ForeColor = System.Drawing.Color.Navy;
            this.groupBox2.Location = new System.Drawing.Point(6, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(448, 102);
            this.groupBox2.TabIndex = 199;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Com Port";
            // 
            // lblPowCom
            // 
            this.lblPowCom.AutoSize = true;
            this.lblPowCom.Font = new System.Drawing.Font("Verdana", 12F);
            this.lblPowCom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPowCom.Location = new System.Drawing.Point(15, 60);
            this.lblPowCom.Name = "lblPowCom";
            this.lblPowCom.Size = new System.Drawing.Size(139, 18);
            this.lblPowCom.TabIndex = 203;
            this.lblPowCom.Text = "Power ComPort:";
            this.lblPowCom.Visible = false;
            // 
            // cbx_plc
            // 
            this.cbx_plc.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbx_plc.FormattingEnabled = true;
            this.cbx_plc.Location = new System.Drawing.Point(160, 29);
            this.cbx_plc.Name = "cbx_plc";
            this.cbx_plc.Size = new System.Drawing.Size(270, 24);
            this.cbx_plc.TabIndex = 200;
            this.cbx_plc.SelectedIndexChanged += new System.EventHandler(this.cbx_plc_SelectedIndexChanged);
            // 
            // cbx_power
            // 
            this.cbx_power.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbx_power.FormattingEnabled = true;
            this.cbx_power.Location = new System.Drawing.Point(160, 59);
            this.cbx_power.Name = "cbx_power";
            this.cbx_power.Size = new System.Drawing.Size(270, 24);
            this.cbx_power.TabIndex = 202;
            this.cbx_power.Visible = false;
            this.cbx_power.SelectedIndexChanged += new System.EventHandler(this.cbx_power_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(34, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 18);
            this.label1.TabIndex = 201;
            this.label1.Text = "PLC ComPort:";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(184)))), ((int)(((byte)(195)))));
            this.groupBox3.Controls.Add(this.lblSleeve);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.btnOpenManage);
            this.groupBox3.Controls.Add(this.btnLogin);
            this.groupBox3.Controls.Add(this.label37);
            this.groupBox3.Controls.Add(this.cbxBatch);
            this.groupBox3.Controls.Add(this.label38);
            this.groupBox3.Controls.Add(this.lblBatCompleteNum);
            this.groupBox3.Controls.Add(this.cbx_name);
            this.groupBox3.Controls.Add(this.label40);
            this.groupBox3.Controls.Add(this.tbxPassword);
            this.groupBox3.Controls.Add(this.lblBatTotal);
            this.groupBox3.Controls.Add(this.label39);
            this.groupBox3.Controls.Add(this.label41);
            this.groupBox3.Font = new System.Drawing.Font("Verdana", 12F);
            this.groupBox3.ForeColor = System.Drawing.Color.Navy;
            this.groupBox3.Location = new System.Drawing.Point(6, 120);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(448, 286);
            this.groupBox3.TabIndex = 200;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "工單管理 ＆ 批號選擇";
            // 
            // lblSleeve
            // 
            this.lblSleeve.AutoSize = true;
            this.lblSleeve.Font = new System.Drawing.Font("Verdana", 12F);
            this.lblSleeve.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblSleeve.Location = new System.Drawing.Point(159, 194);
            this.lblSleeve.Name = "lblSleeve";
            this.lblSleeve.Size = new System.Drawing.Size(62, 18);
            this.lblSleeve.TabIndex = 195;
            this.lblSleeve.Text = "Sleeve";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 12F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(74, 194);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 18);
            this.label5.TabIndex = 194;
            this.label5.Text = "製作筆型:";
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(184)))), ((int)(((byte)(195)))));
            this.groupBox5.Controls.Add(this.btn_clr_pcb);
            this.groupBox5.Controls.Add(this.tbx_ttl_send);
            this.groupBox5.Controls.Add(this.label19);
            this.groupBox5.Controls.Add(this.btn_ttl_send);
            this.groupBox5.Controls.Add(this.tbx_Pcb_feed_back);
            this.groupBox5.Font = new System.Drawing.Font("Verdana", 12F);
            this.groupBox5.ForeColor = System.Drawing.Color.Navy;
            this.groupBox5.Location = new System.Drawing.Point(460, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(457, 695);
            this.groupBox5.TabIndex = 202;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "裝置回傳";
            // 
            // currGroupBox
            // 
            this.currGroupBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(184)))), ((int)(((byte)(195)))));
            this.currGroupBox.Controls.Add(this.label20);
            this.currGroupBox.Controls.Add(this.lbl_charge_curr);
            this.currGroupBox.Controls.Add(this.chart2);
            this.currGroupBox.Font = new System.Drawing.Font("Verdana", 12F);
            this.currGroupBox.ForeColor = System.Drawing.Color.Navy;
            this.currGroupBox.Location = new System.Drawing.Point(914, 12);
            this.currGroupBox.Name = "currGroupBox";
            this.currGroupBox.Size = new System.Drawing.Size(739, 695);
            this.currGroupBox.TabIndex = 203;
            this.currGroupBox.TabStop = false;
            this.currGroupBox.Text = "電流表";
            this.currGroupBox.Visible = false;
            // 
            // btnPrintLabel
            // 
            this.btnPrintLabel.Font = new System.Drawing.Font("Verdana", 12F);
            this.btnPrintLabel.ForeColor = System.Drawing.Color.Navy;
            this.btnPrintLabel.Location = new System.Drawing.Point(311, 29);
            this.btnPrintLabel.Name = "btnPrintLabel";
            this.btnPrintLabel.Size = new System.Drawing.Size(280, 55);
            this.btnPrintLabel.TabIndex = 205;
            this.btnPrintLabel.Text = "Print Label";
            this.btnPrintLabel.UseVisualStyleBackColor = true;
            this.btnPrintLabel.Click += new System.EventHandler(this.btnPrintLabel_Click);
            // 
            // tbxSn
            // 
            this.tbxSn.Enabled = false;
            this.tbxSn.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbxSn.Location = new System.Drawing.Point(159, 30);
            this.tbxSn.Name = "tbxSn";
            this.tbxSn.Size = new System.Drawing.Size(269, 27);
            this.tbxSn.TabIndex = 170;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Verdana", 12F);
            this.label34.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label34.Location = new System.Drawing.Point(43, 32);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(111, 18);
            this.label34.TabIndex = 169;
            this.label34.Text = "目前製作序號:";
            // 
            // btn_ass_chk
            // 
            this.btn_ass_chk.Font = new System.Drawing.Font("Verdana", 12F);
            this.btn_ass_chk.ForeColor = System.Drawing.Color.Navy;
            this.btn_ass_chk.Location = new System.Drawing.Point(158, 63);
            this.btn_ass_chk.Name = "btn_ass_chk";
            this.btn_ass_chk.Size = new System.Drawing.Size(270, 86);
            this.btn_ass_chk.TabIndex = 104;
            this.btn_ass_chk.Text = "#ASS_CHECK";
            this.btn_ass_chk.UseVisualStyleBackColor = true;
            this.btn_ass_chk.Click += new System.EventHandler(this.btn_ass_chk_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(184)))), ((int)(((byte)(195)))));
            this.groupBox4.Controls.Add(this.btn_ass_chk);
            this.groupBox4.Controls.Add(this.label34);
            this.groupBox4.Controls.Add(this.tbxSn);
            this.groupBox4.Font = new System.Drawing.Font("Verdana", 12F);
            this.groupBox4.ForeColor = System.Drawing.Color.Navy;
            this.groupBox4.Location = new System.Drawing.Point(6, 412);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(448, 166);
            this.groupBox4.TabIndex = 201;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "主要作業區";
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(184)))), ((int)(((byte)(195)))));
            this.groupBox6.Controls.Add(this.btnStatus);
            this.groupBox6.Controls.Add(this.btnPrintLabel);
            this.groupBox6.Controls.Add(this.btnShipMode);
            this.groupBox6.Controls.Add(this.btn_clear_com);
            this.groupBox6.Font = new System.Drawing.Font("Verdana", 12F);
            this.groupBox6.ForeColor = System.Drawing.Color.Navy;
            this.groupBox6.Location = new System.Drawing.Point(6, 713);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(911, 158);
            this.groupBox6.TabIndex = 206;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "功能按鈕";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(922, 881);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.currGroupBox);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "DOSE Final Function Test V1.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.currGroupBox.ResumeLayout(false);
            this.currGroupBox.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.IO.Ports.SerialPort RS232_PLC;
        private System.IO.Ports.SerialPort RS232_DOSE;
        private System.Windows.Forms.Button btn_clr_pcb;
        private System.Windows.Forms.Button btn_ttl_send;
        private System.Windows.Forms.TextBox tbx_Pcb_feed_back;
        private System.Windows.Forms.TextBox tbx_ttl_send;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btn_clear_com;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lbl_charge_curr;
        private System.Windows.Forms.Button btnOpenManage;
        private System.Windows.Forms.Button btnShipMode;
        private System.Windows.Forms.Button btnStatus;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.ComboBox cbxBatch;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label lblBatCompleteNum;
        private System.Windows.Forms.Label lblBatTotal;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.ComboBox cbx_name;
        private System.Windows.Forms.TextBox tbxPassword;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnLabelManual;
        private System.Windows.Forms.ComboBox cbxSleeveName_for_Mprint;
        private System.Windows.Forms.TextBox tbxSN_for_Mprint;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblPowCom;
        private System.Windows.Forms.ComboBox cbx_plc;
        private System.Windows.Forms.ComboBox cbx_power;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox currGroupBox;
        private System.Windows.Forms.Button btnPrintLabel;
        private System.Windows.Forms.Label lblSleeve;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxSn;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Button btn_ass_chk;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox6;
    }


}

