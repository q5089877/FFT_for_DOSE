namespace FFT_DOSE
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.RS232_PLC = new System.IO.Ports.SerialPort(this.components);
            this.RS232_DOSE = new System.IO.Ports.SerialPort(this.components);
            this.btn_ass_chk = new System.Windows.Forms.Button();
            this.btn_clr_pcb = new System.Windows.Forms.Button();
            this.btn_ttl_send = new System.Windows.Forms.Button();
            this.tbx_Pcb_feed_back = new System.Windows.Forms.TextBox();
            this.tbx_ttl_send = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.btn_clear_com = new System.Windows.Forms.Button();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label20 = new System.Windows.Forms.Label();
            this.lbl_charge_curr = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.tbxSn = new System.Windows.Forms.TextBox();
            this.btnOpenManage = new System.Windows.Forms.Button();
            this.btnShipMode = new System.Windows.Forms.Button();
            this.btnStatus = new System.Windows.Forms.Button();
            this.btnDump = new System.Windows.Forms.Button();
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
            this.btxPrintLabel2 = new System.Windows.Forms.Button();
            this.cbxSleeveName2 = new System.Windows.Forms.ComboBox();
            this.tbxSN2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbx_BLE = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbx_plc = new System.Windows.Forms.ComboBox();
            this.cbx_power = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblSleeve = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnPNGtoPCX = new System.Windows.Forms.Button();
            this.btnPrintLabel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
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
            // btn_ass_chk
            // 
            this.btn_ass_chk.Font = new System.Drawing.Font("Verdana", 12F);
            this.btn_ass_chk.ForeColor = System.Drawing.Color.Navy;
            this.btn_ass_chk.Location = new System.Drawing.Point(211, 79);
            this.btn_ass_chk.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_ass_chk.Name = "btn_ass_chk";
            this.btn_ass_chk.Size = new System.Drawing.Size(360, 108);
            this.btn_ass_chk.TabIndex = 104;
            this.btn_ass_chk.Text = "#ASS_CHECK";
            this.btn_ass_chk.UseVisualStyleBackColor = true;
            this.btn_ass_chk.Click += new System.EventHandler(this.btn_ass_chk_Click);
            // 
            // btn_clr_pcb
            // 
            this.btn_clr_pcb.Font = new System.Drawing.Font("Verdana", 12F);
            this.btn_clr_pcb.ForeColor = System.Drawing.Color.Navy;
            this.btn_clr_pcb.Location = new System.Drawing.Point(484, 815);
            this.btn_clr_pcb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_clr_pcb.Name = "btn_clr_pcb";
            this.btn_clr_pcb.Size = new System.Drawing.Size(105, 34);
            this.btn_clr_pcb.TabIndex = 137;
            this.btn_clr_pcb.Text = "Clear";
            this.btn_clr_pcb.UseVisualStyleBackColor = true;
            this.btn_clr_pcb.Click += new System.EventHandler(this.btn_clr_pcb_Click);
            // 
            // btn_ttl_send
            // 
            this.btn_ttl_send.Font = new System.Drawing.Font("Verdana", 12F);
            this.btn_ttl_send.ForeColor = System.Drawing.Color.Navy;
            this.btn_ttl_send.Location = new System.Drawing.Point(281, 815);
            this.btn_ttl_send.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_ttl_send.Name = "btn_ttl_send";
            this.btn_ttl_send.Size = new System.Drawing.Size(195, 34);
            this.btn_ttl_send.TabIndex = 136;
            this.btn_ttl_send.Text = "Send";
            this.btn_ttl_send.UseVisualStyleBackColor = true;
            this.btn_ttl_send.Click += new System.EventHandler(this.btn_ttl_send_Click);
            // 
            // tbx_Pcb_feed_back
            // 
            this.tbx_Pcb_feed_back.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(184)))), ((int)(((byte)(195)))));
            this.tbx_Pcb_feed_back.Font = new System.Drawing.Font("PMingLiU", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbx_Pcb_feed_back.ForeColor = System.Drawing.Color.DarkBlue;
            this.tbx_Pcb_feed_back.Location = new System.Drawing.Point(8, 31);
            this.tbx_Pcb_feed_back.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbx_Pcb_feed_back.Multiline = true;
            this.tbx_Pcb_feed_back.Name = "tbx_Pcb_feed_back";
            this.tbx_Pcb_feed_back.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbx_Pcb_feed_back.Size = new System.Drawing.Size(580, 775);
            this.tbx_Pcb_feed_back.TabIndex = 134;
            // 
            // tbx_ttl_send
            // 
            this.tbx_ttl_send.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbx_ttl_send.Location = new System.Drawing.Point(85, 815);
            this.tbx_ttl_send.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbx_ttl_send.Name = "tbx_ttl_send";
            this.tbx_ttl_send.Size = new System.Drawing.Size(187, 31);
            this.tbx_ttl_send.TabIndex = 133;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Verdana", 12F);
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label19.Location = new System.Drawing.Point(15, 822);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(61, 25);
            this.label19.TabIndex = 135;
            this.label19.Text = "指令:";
            // 
            // btn_clear_com
            // 
            this.btn_clear_com.Font = new System.Drawing.Font("Verdana", 12F);
            this.btn_clear_com.ForeColor = System.Drawing.Color.Navy;
            this.btn_clear_com.Location = new System.Drawing.Point(8, 968);
            this.btn_clear_com.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_clear_com.Name = "btn_clear_com";
            this.btn_clear_com.Size = new System.Drawing.Size(597, 69);
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
            this.chart2.Location = new System.Drawing.Point(12, 55);
            this.chart2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chart2.Name = "chart2";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart2.Series.Add(series1);
            this.chart2.Size = new System.Drawing.Size(963, 800);
            this.chart2.TabIndex = 140;
            this.chart2.Text = "PNGtoPCX";
            this.chart2.Visible = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Verdana", 12F);
            this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label20.Location = new System.Drawing.Point(8, 29);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(314, 25);
            this.label20.TabIndex = 141;
            this.label20.Text = "Chargeing Current Maximum:";
            // 
            // lbl_charge_curr
            // 
            this.lbl_charge_curr.AutoSize = true;
            this.lbl_charge_curr.Font = new System.Drawing.Font("Verdana", 12F);
            this.lbl_charge_curr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_charge_curr.Location = new System.Drawing.Point(335, 29);
            this.lbl_charge_curr.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_charge_curr.Name = "lbl_charge_curr";
            this.lbl_charge_curr.Size = new System.Drawing.Size(91, 25);
            this.lbl_charge_curr.TabIndex = 142;
            this.lbl_charge_curr.Text = "200 mA";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Verdana", 12F);
            this.label34.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label34.Location = new System.Drawing.Point(57, 40);
            this.label34.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(141, 25);
            this.label34.TabIndex = 169;
            this.label34.Text = "目前製作序號:";
            // 
            // tbxSn
            // 
            this.tbxSn.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbxSn.Location = new System.Drawing.Point(212, 38);
            this.tbxSn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxSn.Name = "tbxSn";
            this.tbxSn.Size = new System.Drawing.Size(357, 31);
            this.tbxSn.TabIndex = 170;
            // 
            // btnOpenManage
            // 
            this.btnOpenManage.Font = new System.Drawing.Font("Verdana", 12F);
            this.btnOpenManage.ForeColor = System.Drawing.Color.Navy;
            this.btnOpenManage.Location = new System.Drawing.Point(212, 35);
            this.btnOpenManage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOpenManage.Name = "btnOpenManage";
            this.btnOpenManage.Size = new System.Drawing.Size(359, 35);
            this.btnOpenManage.TabIndex = 171;
            this.btnOpenManage.Text = "工單管理";
            this.btnOpenManage.UseVisualStyleBackColor = true;
            this.btnOpenManage.Click += new System.EventHandler(this.btnOpenManage_Click);
            // 
            // btnShipMode
            // 
            this.btnShipMode.Font = new System.Drawing.Font("Verdana", 12F);
            this.btnShipMode.ForeColor = System.Drawing.Color.Navy;
            this.btnShipMode.Location = new System.Drawing.Point(8, 891);
            this.btnShipMode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnShipMode.Name = "btnShipMode";
            this.btnShipMode.Size = new System.Drawing.Size(597, 69);
            this.btnShipMode.TabIndex = 173;
            this.btnShipMode.Text = "Ship Mode";
            this.btnShipMode.UseVisualStyleBackColor = true;
            this.btnShipMode.Click += new System.EventHandler(this.btnShipMode_Click);
            // 
            // btnStatus
            // 
            this.btnStatus.Font = new System.Drawing.Font("Verdana", 12F);
            this.btnStatus.ForeColor = System.Drawing.Color.Navy;
            this.btnStatus.Location = new System.Drawing.Point(613, 891);
            this.btnStatus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.Size = new System.Drawing.Size(597, 69);
            this.btnStatus.TabIndex = 179;
            this.btnStatus.Text = "Status";
            this.btnStatus.UseVisualStyleBackColor = true;
            this.btnStatus.Click += new System.EventHandler(this.btnStatus_Click);
            // 
            // btnDump
            // 
            this.btnDump.Font = new System.Drawing.Font("Verdana", 12F);
            this.btnDump.ForeColor = System.Drawing.Color.Navy;
            this.btnDump.Location = new System.Drawing.Point(613, 968);
            this.btnDump.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDump.Name = "btnDump";
            this.btnDump.Size = new System.Drawing.Size(597, 69);
            this.btnDump.TabIndex = 180;
            this.btnDump.Text = "Dump Data";
            this.btnDump.UseVisualStyleBackColor = true;
            this.btnDump.Click += new System.EventHandler(this.btnDump_Click);
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Verdana", 12F);
            this.label37.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label37.Location = new System.Drawing.Point(99, 206);
            this.label37.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(101, 25);
            this.label37.TabIndex = 181;
            this.label37.Text = "製作批號:";
            // 
            // cbxBatch
            // 
            this.cbxBatch.Enabled = false;
            this.cbxBatch.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbxBatch.FormattingEnabled = true;
            this.cbxBatch.Location = new System.Drawing.Point(213, 199);
            this.cbxBatch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxBatch.Name = "cbxBatch";
            this.cbxBatch.Size = new System.Drawing.Size(356, 28);
            this.cbxBatch.TabIndex = 183;
            this.cbxBatch.SelectedIndexChanged += new System.EventHandler(this.cbxBatch_SelectedIndexChanged);
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Verdana", 12F);
            this.label38.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label38.Location = new System.Drawing.Point(100, 315);
            this.label38.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(101, 25);
            this.label38.TabIndex = 185;
            this.label38.Text = "完成數量:";
            // 
            // lblBatCompleteNum
            // 
            this.lblBatCompleteNum.AutoSize = true;
            this.lblBatCompleteNum.Font = new System.Drawing.Font("Verdana", 12F);
            this.lblBatCompleteNum.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblBatCompleteNum.Location = new System.Drawing.Point(212, 315);
            this.lblBatCompleteNum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBatCompleteNum.Name = "lblBatCompleteNum";
            this.lblBatCompleteNum.Size = new System.Drawing.Size(77, 25);
            this.lblBatCompleteNum.TabIndex = 186;
            this.lblBatCompleteNum.Text = "00000";
            // 
            // lblBatTotal
            // 
            this.lblBatTotal.AutoSize = true;
            this.lblBatTotal.Font = new System.Drawing.Font("Verdana", 12F);
            this.lblBatTotal.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblBatTotal.Location = new System.Drawing.Point(212, 279);
            this.lblBatTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBatTotal.Name = "lblBatTotal";
            this.lblBatTotal.Size = new System.Drawing.Size(77, 25);
            this.lblBatTotal.TabIndex = 188;
            this.lblBatTotal.Text = "00000";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("Verdana", 12F);
            this.label40.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label40.Location = new System.Drawing.Point(99, 279);
            this.label40.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(101, 25);
            this.label40.TabIndex = 187;
            this.label40.Text = "欲做數量:";
            // 
            // cbx_name
            // 
            this.cbx_name.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbx_name.FormattingEnabled = true;
            this.cbx_name.Location = new System.Drawing.Point(213, 78);
            this.cbx_name.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbx_name.Name = "cbx_name";
            this.cbx_name.Size = new System.Drawing.Size(356, 28);
            this.cbx_name.TabIndex = 192;
            // 
            // tbxPassword
            // 
            this.tbxPassword.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbxPassword.Location = new System.Drawing.Point(213, 115);
            this.tbxPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxPassword.Name = "tbxPassword";
            this.tbxPassword.PasswordChar = '*';
            this.tbxPassword.Size = new System.Drawing.Size(356, 31);
            this.tbxPassword.TabIndex = 191;
            this.tbxPassword.Text = "690422";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Verdana", 12F);
            this.label39.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label39.Location = new System.Drawing.Point(79, 126);
            this.label39.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(121, 25);
            this.label39.TabIndex = 190;
            this.label39.Text = "使用者密碼:";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Verdana", 12F);
            this.label41.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label41.Location = new System.Drawing.Point(79, 85);
            this.label41.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(121, 25);
            this.label41.TabIndex = 189;
            this.label41.Text = "使用者名稱:";
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("Verdana", 12F);
            this.btnLogin.ForeColor = System.Drawing.Color.Navy;
            this.btnLogin.Location = new System.Drawing.Point(211, 156);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(360, 35);
            this.btnLogin.TabIndex = 193;
            this.btnLogin.Text = "登入選擇批號";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btxPrintLabel2
            // 
            this.btxPrintLabel2.Font = new System.Drawing.Font("Verdana", 12F);
            this.btxPrintLabel2.ForeColor = System.Drawing.Color.Navy;
            this.btxPrintLabel2.Location = new System.Drawing.Point(389, 80);
            this.btxPrintLabel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btxPrintLabel2.Name = "btxPrintLabel2";
            this.btxPrintLabel2.Size = new System.Drawing.Size(181, 51);
            this.btxPrintLabel2.TabIndex = 194;
            this.btxPrintLabel2.Text = "Print Label";
            this.btxPrintLabel2.UseVisualStyleBackColor = true;
            this.btxPrintLabel2.Click += new System.EventHandler(this.btxPrintLabel2_Click);
            // 
            // cbxSleeveName2
            // 
            this.cbxSleeveName2.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbxSleeveName2.FormattingEnabled = true;
            this.cbxSleeveName2.Items.AddRange(new object[] {
            "SS ",
            "FT ",
            "KP ",
            "NP5"});
            this.cbxSleeveName2.Location = new System.Drawing.Point(213, 42);
            this.cbxSleeveName2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxSleeveName2.Name = "cbxSleeveName2";
            this.cbxSleeveName2.Size = new System.Drawing.Size(109, 28);
            this.cbxSleeveName2.TabIndex = 195;
            // 
            // tbxSN2
            // 
            this.tbxSN2.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbxSN2.Location = new System.Drawing.Point(389, 39);
            this.tbxSN2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxSN2.Name = "tbxSN2";
            this.tbxSN2.Size = new System.Drawing.Size(180, 31);
            this.tbxSN2.TabIndex = 196;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label2.Location = new System.Drawing.Point(112, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 25);
            this.label2.TabIndex = 197;
            this.label2.Text = "Sleeve:";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(184)))), ((int)(((byte)(195)))));
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbx_BLE);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btxPrintLabel2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbxSleeveName2);
            this.groupBox1.Controls.Add(this.tbxSN2);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 12F);
            this.groupBox1.ForeColor = System.Drawing.Color.Navy;
            this.groupBox1.Location = new System.Drawing.Point(8, 730);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(597, 154);
            this.groupBox1.TabIndex = 198;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "手動列印區";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 12F);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label6.Location = new System.Drawing.Point(112, 109);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 25);
            this.label6.TabIndex = 200;
            this.label6.Text = "BLE:";
            // 
            // tbx_BLE
            // 
            this.tbx_BLE.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbx_BLE.Location = new System.Drawing.Point(213, 98);
            this.tbx_BLE.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbx_BLE.Name = "tbx_BLE";
            this.tbx_BLE.Size = new System.Drawing.Size(167, 31);
            this.tbx_BLE.TabIndex = 199;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 12F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label3.Location = new System.Drawing.Point(332, 50);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 25);
            this.label3.TabIndex = 198;
            this.label3.Text = "SN:";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(184)))), ((int)(((byte)(195)))));
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cbx_plc);
            this.groupBox2.Controls.Add(this.cbx_power);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 12F);
            this.groupBox2.ForeColor = System.Drawing.Color.Navy;
            this.groupBox2.Location = new System.Drawing.Point(8, 15);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(597, 128);
            this.groupBox2.TabIndex = 199;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Com Port";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 12F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(20, 75);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(175, 25);
            this.label4.TabIndex = 203;
            this.label4.Text = "Power ComPort:";
            // 
            // cbx_plc
            // 
            this.cbx_plc.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbx_plc.FormattingEnabled = true;
            this.cbx_plc.Location = new System.Drawing.Point(213, 36);
            this.cbx_plc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbx_plc.Name = "cbx_plc";
            this.cbx_plc.Size = new System.Drawing.Size(359, 28);
            this.cbx_plc.TabIndex = 200;
            this.cbx_plc.SelectedIndexChanged += new System.EventHandler(this.cbx_plc_SelectedIndexChanged);
            // 
            // cbx_power
            // 
            this.cbx_power.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbx_power.FormattingEnabled = true;
            this.cbx_power.Location = new System.Drawing.Point(213, 74);
            this.cbx_power.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbx_power.Name = "cbx_power";
            this.cbx_power.Size = new System.Drawing.Size(359, 28);
            this.cbx_power.TabIndex = 202;
            this.cbx_power.SelectedIndexChanged += new System.EventHandler(this.cbx_power_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(45, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 25);
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
            this.groupBox3.Location = new System.Drawing.Point(8, 150);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(597, 358);
            this.groupBox3.TabIndex = 200;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "工單管理 ＆ 批號選擇";
            // 
            // lblSleeve
            // 
            this.lblSleeve.AutoSize = true;
            this.lblSleeve.Font = new System.Drawing.Font("Verdana", 12F);
            this.lblSleeve.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblSleeve.Location = new System.Drawing.Point(212, 242);
            this.lblSleeve.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSleeve.Name = "lblSleeve";
            this.lblSleeve.Size = new System.Drawing.Size(80, 25);
            this.lblSleeve.TabIndex = 195;
            this.lblSleeve.Text = "Sleeve";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 12F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(99, 242);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 25);
            this.label5.TabIndex = 194;
            this.label5.Text = "製作筆型:";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(184)))), ((int)(((byte)(195)))));
            this.groupBox4.Controls.Add(this.btn_ass_chk);
            this.groupBox4.Controls.Add(this.label34);
            this.groupBox4.Controls.Add(this.tbxSn);
            this.groupBox4.Font = new System.Drawing.Font("Verdana", 12F);
            this.groupBox4.ForeColor = System.Drawing.Color.Navy;
            this.groupBox4.Location = new System.Drawing.Point(8, 515);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Size = new System.Drawing.Size(597, 208);
            this.groupBox4.TabIndex = 201;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "主要作業區";
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(184)))), ((int)(((byte)(195)))));
            this.groupBox5.Controls.Add(this.tbx_Pcb_feed_back);
            this.groupBox5.Controls.Add(this.btn_clr_pcb);
            this.groupBox5.Controls.Add(this.tbx_ttl_send);
            this.groupBox5.Controls.Add(this.label19);
            this.groupBox5.Controls.Add(this.btn_ttl_send);
            this.groupBox5.Font = new System.Drawing.Font("Verdana", 12F);
            this.groupBox5.ForeColor = System.Drawing.Color.Navy;
            this.groupBox5.Location = new System.Drawing.Point(613, 15);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox5.Size = new System.Drawing.Size(597, 869);
            this.groupBox5.TabIndex = 202;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "裝置回傳";
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(184)))), ((int)(((byte)(195)))));
            this.groupBox6.Controls.Add(this.label20);
            this.groupBox6.Controls.Add(this.lbl_charge_curr);
            this.groupBox6.Controls.Add(this.chart2);
            this.groupBox6.Font = new System.Drawing.Font("Verdana", 12F);
            this.groupBox6.ForeColor = System.Drawing.Color.Navy;
            this.groupBox6.Location = new System.Drawing.Point(1219, 15);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox6.Size = new System.Drawing.Size(985, 869);
            this.groupBox6.TabIndex = 203;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "電流表";
            // 
            // btnPNGtoPCX
            // 
            this.btnPNGtoPCX.Font = new System.Drawing.Font("Verdana", 12F);
            this.btnPNGtoPCX.ForeColor = System.Drawing.Color.Navy;
            this.btnPNGtoPCX.Location = new System.Drawing.Point(1219, 891);
            this.btnPNGtoPCX.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPNGtoPCX.Name = "btnPNGtoPCX";
            this.btnPNGtoPCX.Size = new System.Drawing.Size(597, 69);
            this.btnPNGtoPCX.TabIndex = 204;
            this.btnPNGtoPCX.Text = "PNG to PCX";
            this.btnPNGtoPCX.UseVisualStyleBackColor = true;
            this.btnPNGtoPCX.Click += new System.EventHandler(this.btnPNGtoPCX_Click);
            // 
            // btnPrintLabel
            // 
            this.btnPrintLabel.Font = new System.Drawing.Font("Verdana", 12F);
            this.btnPrintLabel.ForeColor = System.Drawing.Color.Navy;
            this.btnPrintLabel.Location = new System.Drawing.Point(1219, 968);
            this.btnPrintLabel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPrintLabel.Name = "btnPrintLabel";
            this.btnPrintLabel.Size = new System.Drawing.Size(597, 69);
            this.btnPrintLabel.TabIndex = 205;
            this.btnPrintLabel.Text = "Print Label";
            this.btnPrintLabel.UseVisualStyleBackColor = true;
            this.btnPrintLabel.Click += new System.EventHandler(this.btnPrintLabel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(1924, 1050);
            this.Controls.Add(this.btnPrintLabel);
            this.Controls.Add(this.btnPNGtoPCX);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnStatus);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDump);
            this.Controls.Add(this.btnShipMode);
            this.Controls.Add(this.btn_clear_com);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "DOSE Final Function Test";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.IO.Ports.SerialPort RS232_PLC;
        private System.IO.Ports.SerialPort RS232_DOSE;
        private System.Windows.Forms.Button btn_ass_chk;
        private System.Windows.Forms.Button btn_clr_pcb;
        private System.Windows.Forms.Button btn_ttl_send;
        private System.Windows.Forms.TextBox tbx_Pcb_feed_back;
        private System.Windows.Forms.TextBox tbx_ttl_send;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btn_clear_com;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lbl_charge_curr;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.TextBox tbxSn;
        private System.Windows.Forms.Button btnOpenManage;
        private System.Windows.Forms.Button btnShipMode;
        private System.Windows.Forms.Button btnStatus;
        private System.Windows.Forms.Button btnDump;
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
        private System.Windows.Forms.Button btxPrintLabel2;
        private System.Windows.Forms.ComboBox cbxSleeveName2;
        private System.Windows.Forms.TextBox tbxSN2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbx_plc;
        private System.Windows.Forms.ComboBox cbx_power;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnPNGtoPCX;
        private System.Windows.Forms.Button btnPrintLabel;
        private System.Windows.Forms.Label lblSleeve;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbx_BLE;
        private System.Windows.Forms.Label label6;
    }

    partial class CopyOfForm1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CopyOfForm1));
            this.RS232_PLC = new System.IO.Ports.SerialPort(this.components);
            this.RS232_DOSE = new System.IO.Ports.SerialPort(this.components);
            this.btn_ass_chk = new System.Windows.Forms.Button();
            this.btn_clr_pcb = new System.Windows.Forms.Button();
            this.btn_ttl_send = new System.Windows.Forms.Button();
            this.tbx_Pcb_feed_back = new System.Windows.Forms.TextBox();
            this.tbx_ttl_send = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.btn_clear_com = new System.Windows.Forms.Button();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label20 = new System.Windows.Forms.Label();
            this.lbl_charge_curr = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.tbxSn = new System.Windows.Forms.TextBox();
            this.btnOpenManage = new System.Windows.Forms.Button();
            this.btnShipMode = new System.Windows.Forms.Button();
            this.btnStatus = new System.Windows.Forms.Button();
            this.btnDump = new System.Windows.Forms.Button();
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
            this.btxPrintLabel2 = new System.Windows.Forms.Button();
            this.cbxSleeveName2 = new System.Windows.Forms.ComboBox();
            this.tbxSN2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbx_BLE = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbx_plc = new System.Windows.Forms.ComboBox();
            this.cbx_power = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblSleeve = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnPNGtoPCX = new System.Windows.Forms.Button();
            this.btnPrintLabel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
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
            // btn_ass_chk
            // 
            this.btn_ass_chk.Font = new System.Drawing.Font("Verdana", 12F);
            this.btn_ass_chk.ForeColor = System.Drawing.Color.Navy;
            this.btn_ass_chk.Location = new System.Drawing.Point(211, 79);
            this.btn_ass_chk.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_ass_chk.Name = "btn_ass_chk";
            this.btn_ass_chk.Size = new System.Drawing.Size(360, 108);
            this.btn_ass_chk.TabIndex = 104;
            this.btn_ass_chk.Text = "#ASS_CHECK";
            this.btn_ass_chk.UseVisualStyleBackColor = true;
            this.btn_ass_chk.Click += new System.EventHandler(this.btn_ass_chk_Click);
            // 
            // btn_clr_pcb
            // 
            this.btn_clr_pcb.Font = new System.Drawing.Font("Verdana", 12F);
            this.btn_clr_pcb.ForeColor = System.Drawing.Color.Navy;
            this.btn_clr_pcb.Location = new System.Drawing.Point(484, 815);
            this.btn_clr_pcb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_clr_pcb.Name = "btn_clr_pcb";
            this.btn_clr_pcb.Size = new System.Drawing.Size(105, 34);
            this.btn_clr_pcb.TabIndex = 137;
            this.btn_clr_pcb.Text = "Clear";
            this.btn_clr_pcb.UseVisualStyleBackColor = true;
            this.btn_clr_pcb.Click += new System.EventHandler(this.btn_clr_pcb_Click);
            // 
            // btn_ttl_send
            // 
            this.btn_ttl_send.Font = new System.Drawing.Font("Verdana", 12F);
            this.btn_ttl_send.ForeColor = System.Drawing.Color.Navy;
            this.btn_ttl_send.Location = new System.Drawing.Point(281, 815);
            this.btn_ttl_send.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_ttl_send.Name = "btn_ttl_send";
            this.btn_ttl_send.Size = new System.Drawing.Size(195, 34);
            this.btn_ttl_send.TabIndex = 136;
            this.btn_ttl_send.Text = "Send";
            this.btn_ttl_send.UseVisualStyleBackColor = true;
            this.btn_ttl_send.Click += new System.EventHandler(this.btn_ttl_send_Click);
            // 
            // tbx_Pcb_feed_back
            // 
            this.tbx_Pcb_feed_back.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(184)))), ((int)(((byte)(195)))));
            this.tbx_Pcb_feed_back.Font = new System.Drawing.Font("PMingLiU", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbx_Pcb_feed_back.ForeColor = System.Drawing.Color.DarkBlue;
            this.tbx_Pcb_feed_back.Location = new System.Drawing.Point(8, 31);
            this.tbx_Pcb_feed_back.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbx_Pcb_feed_back.Multiline = true;
            this.tbx_Pcb_feed_back.Name = "tbx_Pcb_feed_back";
            this.tbx_Pcb_feed_back.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbx_Pcb_feed_back.Size = new System.Drawing.Size(580, 775);
            this.tbx_Pcb_feed_back.TabIndex = 134;
            // 
            // tbx_ttl_send
            // 
            this.tbx_ttl_send.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbx_ttl_send.Location = new System.Drawing.Point(85, 815);
            this.tbx_ttl_send.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbx_ttl_send.Name = "tbx_ttl_send";
            this.tbx_ttl_send.Size = new System.Drawing.Size(187, 31);
            this.tbx_ttl_send.TabIndex = 133;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Verdana", 12F);
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label19.Location = new System.Drawing.Point(15, 822);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(61, 25);
            this.label19.TabIndex = 135;
            this.label19.Text = "指令:";
            // 
            // btn_clear_com
            // 
            this.btn_clear_com.Font = new System.Drawing.Font("Verdana", 12F);
            this.btn_clear_com.ForeColor = System.Drawing.Color.Navy;
            this.btn_clear_com.Location = new System.Drawing.Point(8, 968);
            this.btn_clear_com.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_clear_com.Name = "btn_clear_com";
            this.btn_clear_com.Size = new System.Drawing.Size(597, 69);
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
            this.chart2.Location = new System.Drawing.Point(12, 55);
            this.chart2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chart2.Name = "chart2";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart2.Series.Add(series1);
            this.chart2.Size = new System.Drawing.Size(963, 800);
            this.chart2.TabIndex = 140;
            this.chart2.Text = "PNGtoPCX";
            this.chart2.Visible = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Verdana", 12F);
            this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label20.Location = new System.Drawing.Point(8, 29);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(314, 25);
            this.label20.TabIndex = 141;
            this.label20.Text = "Chargeing Current Maximum:";
            // 
            // lbl_charge_curr
            // 
            this.lbl_charge_curr.AutoSize = true;
            this.lbl_charge_curr.Font = new System.Drawing.Font("Verdana", 12F);
            this.lbl_charge_curr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_charge_curr.Location = new System.Drawing.Point(335, 29);
            this.lbl_charge_curr.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_charge_curr.Name = "lbl_charge_curr";
            this.lbl_charge_curr.Size = new System.Drawing.Size(91, 25);
            this.lbl_charge_curr.TabIndex = 142;
            this.lbl_charge_curr.Text = "200 mA";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Verdana", 12F);
            this.label34.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label34.Location = new System.Drawing.Point(57, 40);
            this.label34.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(141, 25);
            this.label34.TabIndex = 169;
            this.label34.Text = "目前製作序號:";
            // 
            // tbxSn
            // 
            this.tbxSn.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbxSn.Location = new System.Drawing.Point(212, 38);
            this.tbxSn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxSn.Name = "tbxSn";
            this.tbxSn.Size = new System.Drawing.Size(357, 31);
            this.tbxSn.TabIndex = 170;
            // 
            // btnOpenManage
            // 
            this.btnOpenManage.Font = new System.Drawing.Font("Verdana", 12F);
            this.btnOpenManage.ForeColor = System.Drawing.Color.Navy;
            this.btnOpenManage.Location = new System.Drawing.Point(212, 35);
            this.btnOpenManage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOpenManage.Name = "btnOpenManage";
            this.btnOpenManage.Size = new System.Drawing.Size(359, 35);
            this.btnOpenManage.TabIndex = 171;
            this.btnOpenManage.Text = "工單管理";
            this.btnOpenManage.UseVisualStyleBackColor = true;
            this.btnOpenManage.Click += new System.EventHandler(this.btnOpenManage_Click);
            // 
            // btnShipMode
            // 
            this.btnShipMode.Font = new System.Drawing.Font("Verdana", 12F);
            this.btnShipMode.ForeColor = System.Drawing.Color.Navy;
            this.btnShipMode.Location = new System.Drawing.Point(8, 891);
            this.btnShipMode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnShipMode.Name = "btnShipMode";
            this.btnShipMode.Size = new System.Drawing.Size(597, 69);
            this.btnShipMode.TabIndex = 173;
            this.btnShipMode.Text = "Ship Mode";
            this.btnShipMode.UseVisualStyleBackColor = true;
            this.btnShipMode.Click += new System.EventHandler(this.btnShipMode_Click);
            // 
            // btnStatus
            // 
            this.btnStatus.Font = new System.Drawing.Font("Verdana", 12F);
            this.btnStatus.ForeColor = System.Drawing.Color.Navy;
            this.btnStatus.Location = new System.Drawing.Point(613, 891);
            this.btnStatus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.Size = new System.Drawing.Size(597, 69);
            this.btnStatus.TabIndex = 179;
            this.btnStatus.Text = "Status";
            this.btnStatus.UseVisualStyleBackColor = true;
            this.btnStatus.Click += new System.EventHandler(this.btnStatus_Click);
            // 
            // btnDump
            // 
            this.btnDump.Font = new System.Drawing.Font("Verdana", 12F);
            this.btnDump.ForeColor = System.Drawing.Color.Navy;
            this.btnDump.Location = new System.Drawing.Point(613, 968);
            this.btnDump.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDump.Name = "btnDump";
            this.btnDump.Size = new System.Drawing.Size(597, 69);
            this.btnDump.TabIndex = 180;
            this.btnDump.Text = "Dump Data";
            this.btnDump.UseVisualStyleBackColor = true;
            this.btnDump.Click += new System.EventHandler(this.btnDump_Click);
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Verdana", 12F);
            this.label37.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label37.Location = new System.Drawing.Point(99, 206);
            this.label37.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(101, 25);
            this.label37.TabIndex = 181;
            this.label37.Text = "製作批號:";
            // 
            // cbxBatch
            // 
            this.cbxBatch.Enabled = false;
            this.cbxBatch.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbxBatch.FormattingEnabled = true;
            this.cbxBatch.Location = new System.Drawing.Point(213, 199);
            this.cbxBatch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxBatch.Name = "cbxBatch";
            this.cbxBatch.Size = new System.Drawing.Size(356, 28);
            this.cbxBatch.TabIndex = 183;
            this.cbxBatch.SelectedIndexChanged += new System.EventHandler(this.cbxBatch_SelectedIndexChanged);
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Verdana", 12F);
            this.label38.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label38.Location = new System.Drawing.Point(100, 315);
            this.label38.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(101, 25);
            this.label38.TabIndex = 185;
            this.label38.Text = "完成數量:";
            // 
            // lblBatCompleteNum
            // 
            this.lblBatCompleteNum.AutoSize = true;
            this.lblBatCompleteNum.Font = new System.Drawing.Font("Verdana", 12F);
            this.lblBatCompleteNum.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblBatCompleteNum.Location = new System.Drawing.Point(212, 315);
            this.lblBatCompleteNum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBatCompleteNum.Name = "lblBatCompleteNum";
            this.lblBatCompleteNum.Size = new System.Drawing.Size(77, 25);
            this.lblBatCompleteNum.TabIndex = 186;
            this.lblBatCompleteNum.Text = "00000";
            // 
            // lblBatTotal
            // 
            this.lblBatTotal.AutoSize = true;
            this.lblBatTotal.Font = new System.Drawing.Font("Verdana", 12F);
            this.lblBatTotal.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblBatTotal.Location = new System.Drawing.Point(212, 279);
            this.lblBatTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBatTotal.Name = "lblBatTotal";
            this.lblBatTotal.Size = new System.Drawing.Size(77, 25);
            this.lblBatTotal.TabIndex = 188;
            this.lblBatTotal.Text = "00000";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("Verdana", 12F);
            this.label40.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label40.Location = new System.Drawing.Point(99, 279);
            this.label40.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(101, 25);
            this.label40.TabIndex = 187;
            this.label40.Text = "欲做數量:";
            // 
            // cbx_name
            // 
            this.cbx_name.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbx_name.FormattingEnabled = true;
            this.cbx_name.Location = new System.Drawing.Point(213, 78);
            this.cbx_name.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbx_name.Name = "cbx_name";
            this.cbx_name.Size = new System.Drawing.Size(356, 28);
            this.cbx_name.TabIndex = 192;
            // 
            // tbxPassword
            // 
            this.tbxPassword.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbxPassword.Location = new System.Drawing.Point(213, 115);
            this.tbxPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxPassword.Name = "tbxPassword";
            this.tbxPassword.PasswordChar = '*';
            this.tbxPassword.Size = new System.Drawing.Size(356, 31);
            this.tbxPassword.TabIndex = 191;
            this.tbxPassword.Text = "690422";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Verdana", 12F);
            this.label39.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label39.Location = new System.Drawing.Point(79, 126);
            this.label39.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(121, 25);
            this.label39.TabIndex = 190;
            this.label39.Text = "使用者密碼:";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Verdana", 12F);
            this.label41.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label41.Location = new System.Drawing.Point(79, 85);
            this.label41.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(121, 25);
            this.label41.TabIndex = 189;
            this.label41.Text = "使用者名稱:";
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("Verdana", 12F);
            this.btnLogin.ForeColor = System.Drawing.Color.Navy;
            this.btnLogin.Location = new System.Drawing.Point(211, 156);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(360, 35);
            this.btnLogin.TabIndex = 193;
            this.btnLogin.Text = "登入選擇批號";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btxPrintLabel2
            // 
            this.btxPrintLabel2.Font = new System.Drawing.Font("Verdana", 12F);
            this.btxPrintLabel2.ForeColor = System.Drawing.Color.Navy;
            this.btxPrintLabel2.Location = new System.Drawing.Point(389, 80);
            this.btxPrintLabel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btxPrintLabel2.Name = "btxPrintLabel2";
            this.btxPrintLabel2.Size = new System.Drawing.Size(181, 51);
            this.btxPrintLabel2.TabIndex = 194;
            this.btxPrintLabel2.Text = "Print Label";
            this.btxPrintLabel2.UseVisualStyleBackColor = true;
            this.btxPrintLabel2.Click += new System.EventHandler(this.btxPrintLabel2_Click);
            // 
            // cbxSleeveName2
            // 
            this.cbxSleeveName2.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbxSleeveName2.FormattingEnabled = true;
            this.cbxSleeveName2.Items.AddRange(new object[] {
            "SS ",
            "FT ",
            "KP ",
            "NP5"});
            this.cbxSleeveName2.Location = new System.Drawing.Point(213, 42);
            this.cbxSleeveName2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxSleeveName2.Name = "cbxSleeveName2";
            this.cbxSleeveName2.Size = new System.Drawing.Size(109, 28);
            this.cbxSleeveName2.TabIndex = 195;
            // 
            // tbxSN2
            // 
            this.tbxSN2.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbxSN2.Location = new System.Drawing.Point(389, 39);
            this.tbxSN2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxSN2.Name = "tbxSN2";
            this.tbxSN2.Size = new System.Drawing.Size(180, 31);
            this.tbxSN2.TabIndex = 196;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label2.Location = new System.Drawing.Point(112, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 25);
            this.label2.TabIndex = 197;
            this.label2.Text = "Sleeve:";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(184)))), ((int)(((byte)(195)))));
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbx_BLE);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btxPrintLabel2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbxSleeveName2);
            this.groupBox1.Controls.Add(this.tbxSN2);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 12F);
            this.groupBox1.ForeColor = System.Drawing.Color.Navy;
            this.groupBox1.Location = new System.Drawing.Point(8, 730);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(597, 154);
            this.groupBox1.TabIndex = 198;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "手動列印區";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 12F);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label6.Location = new System.Drawing.Point(112, 109);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 25);
            this.label6.TabIndex = 200;
            this.label6.Text = "BLE:";
            // 
            // tbx_BLE
            // 
            this.tbx_BLE.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbx_BLE.Location = new System.Drawing.Point(213, 98);
            this.tbx_BLE.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbx_BLE.Name = "tbx_BLE";
            this.tbx_BLE.Size = new System.Drawing.Size(167, 31);
            this.tbx_BLE.TabIndex = 199;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 12F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label3.Location = new System.Drawing.Point(332, 50);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 25);
            this.label3.TabIndex = 198;
            this.label3.Text = "SN:";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(184)))), ((int)(((byte)(195)))));
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cbx_plc);
            this.groupBox2.Controls.Add(this.cbx_power);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 12F);
            this.groupBox2.ForeColor = System.Drawing.Color.Navy;
            this.groupBox2.Location = new System.Drawing.Point(8, 15);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(597, 128);
            this.groupBox2.TabIndex = 199;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Com Port";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 12F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(20, 75);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(175, 25);
            this.label4.TabIndex = 203;
            this.label4.Text = "Power ComPort:";
            // 
            // cbx_plc
            // 
            this.cbx_plc.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbx_plc.FormattingEnabled = true;
            this.cbx_plc.Location = new System.Drawing.Point(213, 36);
            this.cbx_plc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbx_plc.Name = "cbx_plc";
            this.cbx_plc.Size = new System.Drawing.Size(359, 28);
            this.cbx_plc.TabIndex = 200;
            this.cbx_plc.SelectedIndexChanged += new System.EventHandler(this.cbx_plc_SelectedIndexChanged);
            // 
            // cbx_power
            // 
            this.cbx_power.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbx_power.FormattingEnabled = true;
            this.cbx_power.Location = new System.Drawing.Point(213, 74);
            this.cbx_power.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbx_power.Name = "cbx_power";
            this.cbx_power.Size = new System.Drawing.Size(359, 28);
            this.cbx_power.TabIndex = 202;
            this.cbx_power.SelectedIndexChanged += new System.EventHandler(this.cbx_power_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(45, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 25);
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
            this.groupBox3.Location = new System.Drawing.Point(8, 150);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(597, 358);
            this.groupBox3.TabIndex = 200;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "工單管理 ＆ 批號選擇";
            // 
            // lblSleeve
            // 
            this.lblSleeve.AutoSize = true;
            this.lblSleeve.Font = new System.Drawing.Font("Verdana", 12F);
            this.lblSleeve.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblSleeve.Location = new System.Drawing.Point(212, 242);
            this.lblSleeve.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSleeve.Name = "lblSleeve";
            this.lblSleeve.Size = new System.Drawing.Size(80, 25);
            this.lblSleeve.TabIndex = 195;
            this.lblSleeve.Text = "Sleeve";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 12F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(99, 242);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 25);
            this.label5.TabIndex = 194;
            this.label5.Text = "製作筆型:";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(184)))), ((int)(((byte)(195)))));
            this.groupBox4.Controls.Add(this.btn_ass_chk);
            this.groupBox4.Controls.Add(this.label34);
            this.groupBox4.Controls.Add(this.tbxSn);
            this.groupBox4.Font = new System.Drawing.Font("Verdana", 12F);
            this.groupBox4.ForeColor = System.Drawing.Color.Navy;
            this.groupBox4.Location = new System.Drawing.Point(8, 515);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Size = new System.Drawing.Size(597, 208);
            this.groupBox4.TabIndex = 201;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "主要作業區";
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(184)))), ((int)(((byte)(195)))));
            this.groupBox5.Controls.Add(this.tbx_Pcb_feed_back);
            this.groupBox5.Controls.Add(this.btn_clr_pcb);
            this.groupBox5.Controls.Add(this.tbx_ttl_send);
            this.groupBox5.Controls.Add(this.label19);
            this.groupBox5.Controls.Add(this.btn_ttl_send);
            this.groupBox5.Font = new System.Drawing.Font("Verdana", 12F);
            this.groupBox5.ForeColor = System.Drawing.Color.Navy;
            this.groupBox5.Location = new System.Drawing.Point(613, 15);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox5.Size = new System.Drawing.Size(597, 869);
            this.groupBox5.TabIndex = 202;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "裝置回傳";
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(184)))), ((int)(((byte)(195)))));
            this.groupBox6.Controls.Add(this.label20);
            this.groupBox6.Controls.Add(this.lbl_charge_curr);
            this.groupBox6.Controls.Add(this.chart2);
            this.groupBox6.Font = new System.Drawing.Font("Verdana", 12F);
            this.groupBox6.ForeColor = System.Drawing.Color.Navy;
            this.groupBox6.Location = new System.Drawing.Point(1219, 15);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox6.Size = new System.Drawing.Size(985, 869);
            this.groupBox6.TabIndex = 203;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "電流表";
            // 
            // btnPNGtoPCX
            // 
            this.btnPNGtoPCX.Font = new System.Drawing.Font("Verdana", 12F);
            this.btnPNGtoPCX.ForeColor = System.Drawing.Color.Navy;
            this.btnPNGtoPCX.Location = new System.Drawing.Point(1219, 891);
            this.btnPNGtoPCX.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPNGtoPCX.Name = "btnPNGtoPCX";
            this.btnPNGtoPCX.Size = new System.Drawing.Size(597, 69);
            this.btnPNGtoPCX.TabIndex = 204;
            this.btnPNGtoPCX.Text = "PNG to PCX";
            this.btnPNGtoPCX.UseVisualStyleBackColor = true;
            this.btnPNGtoPCX.Click += new System.EventHandler(this.btnPNGtoPCX_Click);
            // 
            // btnPrintLabel
            // 
            this.btnPrintLabel.Font = new System.Drawing.Font("Verdana", 12F);
            this.btnPrintLabel.ForeColor = System.Drawing.Color.Navy;
            this.btnPrintLabel.Location = new System.Drawing.Point(1219, 968);
            this.btnPrintLabel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPrintLabel.Name = "btnPrintLabel";
            this.btnPrintLabel.Size = new System.Drawing.Size(597, 69);
            this.btnPrintLabel.TabIndex = 205;
            this.btnPrintLabel.Text = "Print Label";
            this.btnPrintLabel.UseVisualStyleBackColor = true;
            this.btnPrintLabel.Click += new System.EventHandler(this.btnPrintLabel_Click);
            // 
            // CopyOfForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(1924, 1050);
            this.Controls.Add(this.btnPrintLabel);
            this.Controls.Add(this.btnPNGtoPCX);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnStatus);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDump);
            this.Controls.Add(this.btnShipMode);
            this.Controls.Add(this.btn_clear_com);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "CopyOfForm1";
            this.Text = "DOSE Final Function Test";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.IO.Ports.SerialPort RS232_PLC;
        private System.IO.Ports.SerialPort RS232_DOSE;
        private System.Windows.Forms.Button btn_ass_chk;
        private System.Windows.Forms.Button btn_clr_pcb;
        private System.Windows.Forms.Button btn_ttl_send;
        private System.Windows.Forms.TextBox tbx_Pcb_feed_back;
        private System.Windows.Forms.TextBox tbx_ttl_send;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btn_clear_com;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lbl_charge_curr;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.TextBox tbxSn;
        private System.Windows.Forms.Button btnOpenManage;
        private System.Windows.Forms.Button btnShipMode;
        private System.Windows.Forms.Button btnStatus;
        private System.Windows.Forms.Button btnDump;
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
        private System.Windows.Forms.Button btxPrintLabel2;
        private System.Windows.Forms.ComboBox cbxSleeveName2;
        private System.Windows.Forms.TextBox tbxSN2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbx_plc;
        private System.Windows.Forms.ComboBox cbx_power;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnPNGtoPCX;
        private System.Windows.Forms.Button btnPrintLabel;
        private System.Windows.Forms.Label lblSleeve;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbx_BLE;
        private System.Windows.Forms.Label label6;
    }
}

