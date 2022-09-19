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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button2 = new System.Windows.Forms.Button();
            this.RS232_PLC = new System.IO.Ports.SerialPort(this.components);
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.RS232_DOSE = new System.IO.Ports.SerialPort(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cbx_plc = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbx_power = new System.Windows.Forms.ComboBox();
            this.btn_ass_chk = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
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
            this.btnConfigFW = new System.Windows.Forms.Button();
            this.btnShipMode = new System.Windows.Forms.Button();
            this.tbxHousing = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.tbxPCB = new System.Windows.Forms.TextBox();
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
            this.cbxSleeve = new System.Windows.Forms.ComboBox();
            this.label33 = new System.Windows.Forms.Label();
            this.btxPrintLabel2 = new System.Windows.Forms.Button();
            this.cbxSleeveName2 = new System.Windows.Forms.ComboBox();
            this.tbxSN2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1346, 701);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(107, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Opeb PLC COM";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // RS232_PLC
            // 
            this.RS232_PLC.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(1539, 701);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(107, 23);
            this.button6.TabIndex = 5;
            this.button6.Text = "Write M2(PLC)";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(1458, 701);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 6;
            this.button7.Text = "Read M2";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Visible = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // RS232_DOSE
            // 
            this.RS232_DOSE.BaudRate = 921600;
            this.RS232_DOSE.ReadBufferSize = 40960;
            this.RS232_DOSE.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.RS232_DOSE_DataReceived);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F);
            this.label1.Location = new System.Drawing.Point(49, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 18);
            this.label1.TabIndex = 28;
            this.label1.Text = "PLC ComPort:";
            // 
            // cbx_plc
            // 
            this.cbx_plc.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbx_plc.FormattingEnabled = true;
            this.cbx_plc.Location = new System.Drawing.Point(175, 20);
            this.cbx_plc.Name = "cbx_plc";
            this.cbx_plc.Size = new System.Drawing.Size(270, 24);
            this.cbx_plc.TabIndex = 27;
            this.cbx_plc.SelectedIndexChanged += new System.EventHandler(this.cbx_plc_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 12F);
            this.label4.Location = new System.Drawing.Point(30, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 18);
            this.label4.TabIndex = 34;
            this.label4.Text = "Power ComPort:";
            // 
            // cbx_power
            // 
            this.cbx_power.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbx_power.FormattingEnabled = true;
            this.cbx_power.Location = new System.Drawing.Point(175, 50);
            this.cbx_power.Name = "cbx_power";
            this.cbx_power.Size = new System.Drawing.Size(270, 24);
            this.cbx_power.TabIndex = 33;
            this.cbx_power.SelectedIndexChanged += new System.EventHandler(this.cbx_power_SelectedIndexChanged);
            // 
            // btn_ass_chk
            // 
            this.btn_ass_chk.Font = new System.Drawing.Font("Verdana", 12F);
            this.btn_ass_chk.ForeColor = System.Drawing.Color.Navy;
            this.btn_ass_chk.Location = new System.Drawing.Point(175, 391);
            this.btn_ass_chk.Name = "btn_ass_chk";
            this.btn_ass_chk.Size = new System.Drawing.Size(270, 129);
            this.btn_ass_chk.TabIndex = 104;
            this.btn_ass_chk.Text = "#ASS_CHECK";
            this.btn_ass_chk.UseVisualStyleBackColor = true;
            this.btn_ass_chk.Click += new System.EventHandler(this.btn_ass_chk_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Verdana", 12F);
            this.label18.Location = new System.Drawing.Point(460, 20);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(129, 18);
            this.label18.TabIndex = 138;
            this.label18.Text = "PCB Feedback:";
            // 
            // btn_clr_pcb
            // 
            this.btn_clr_pcb.Font = new System.Drawing.Font("Verdana", 12F);
            this.btn_clr_pcb.ForeColor = System.Drawing.Color.Navy;
            this.btn_clr_pcb.Location = new System.Drawing.Point(760, 9);
            this.btn_clr_pcb.Name = "btn_clr_pcb";
            this.btn_clr_pcb.Size = new System.Drawing.Size(108, 27);
            this.btn_clr_pcb.TabIndex = 137;
            this.btn_clr_pcb.Text = "Clear";
            this.btn_clr_pcb.UseVisualStyleBackColor = true;
            this.btn_clr_pcb.Click += new System.EventHandler(this.btn_clr_pcb_Click);
            // 
            // btn_ttl_send
            // 
            this.btn_ttl_send.Font = new System.Drawing.Font("Verdana", 12F);
            this.btn_ttl_send.ForeColor = System.Drawing.Color.Navy;
            this.btn_ttl_send.Location = new System.Drawing.Point(779, 526);
            this.btn_ttl_send.Name = "btn_ttl_send";
            this.btn_ttl_send.Size = new System.Drawing.Size(89, 27);
            this.btn_ttl_send.TabIndex = 136;
            this.btn_ttl_send.Text = "Send";
            this.btn_ttl_send.UseVisualStyleBackColor = true;
            this.btn_ttl_send.Click += new System.EventHandler(this.btn_ttl_send_Click);
            // 
            // tbx_Pcb_feed_back
            // 
            this.tbx_Pcb_feed_back.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(184)))), ((int)(((byte)(195)))));
            this.tbx_Pcb_feed_back.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbx_Pcb_feed_back.Location = new System.Drawing.Point(463, 39);
            this.tbx_Pcb_feed_back.Multiline = true;
            this.tbx_Pcb_feed_back.Name = "tbx_Pcb_feed_back";
            this.tbx_Pcb_feed_back.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbx_Pcb_feed_back.Size = new System.Drawing.Size(405, 481);
            this.tbx_Pcb_feed_back.TabIndex = 134;
            // 
            // tbx_ttl_send
            // 
            this.tbx_ttl_send.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbx_ttl_send.Location = new System.Drawing.Point(578, 526);
            this.tbx_ttl_send.Name = "tbx_ttl_send";
            this.tbx_ttl_send.Size = new System.Drawing.Size(195, 27);
            this.tbx_ttl_send.TabIndex = 133;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Verdana", 12F);
            this.label19.Location = new System.Drawing.Point(460, 530);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(112, 18);
            this.label19.TabIndex = 135;
            this.label19.Text = "PC Transmit:";
            // 
            // btn_clear_com
            // 
            this.btn_clear_com.Font = new System.Drawing.Font("Verdana", 12F);
            this.btn_clear_com.ForeColor = System.Drawing.Color.Navy;
            this.btn_clear_com.Location = new System.Drawing.Point(1438, 730);
            this.btn_clear_com.Name = "btn_clear_com";
            this.btn_clear_com.Size = new System.Drawing.Size(208, 30);
            this.btn_clear_com.TabIndex = 139;
            this.btn_clear_com.Text = "Clear ComPort";
            this.btn_clear_com.UseVisualStyleBackColor = true;
            this.btn_clear_com.Click += new System.EventHandler(this.btn_clear_com_Click);
            // 
            // chart2
            // 
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(885, 39);
            this.chart2.Name = "chart2";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart2.Series.Add(series2);
            this.chart2.Size = new System.Drawing.Size(760, 562);
            this.chart2.TabIndex = 140;
            this.chart2.Text = "chart2";
            this.chart2.Visible = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Verdana", 12F);
            this.label20.Location = new System.Drawing.Point(882, 15);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(246, 18);
            this.label20.TabIndex = 141;
            this.label20.Text = "Chargeing Current Maximum:";
            // 
            // lbl_charge_curr
            // 
            this.lbl_charge_curr.AutoSize = true;
            this.lbl_charge_curr.Font = new System.Drawing.Font("Verdana", 12F);
            this.lbl_charge_curr.Location = new System.Drawing.Point(1127, 15);
            this.lbl_charge_curr.Name = "lbl_charge_curr";
            this.lbl_charge_curr.Size = new System.Drawing.Size(70, 18);
            this.lbl_charge_curr.TabIndex = 142;
            this.lbl_charge_curr.Text = "200 mA";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Verdana", 12F);
            this.label34.Location = new System.Drawing.Point(60, 351);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(111, 18);
            this.label34.TabIndex = 169;
            this.label34.Text = "目前製作序號:";
            // 
            // tbxSn
            // 
            this.tbxSn.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbxSn.Location = new System.Drawing.Point(176, 349);
            this.tbxSn.Name = "tbxSn";
            this.tbxSn.Size = new System.Drawing.Size(269, 27);
            this.tbxSn.TabIndex = 170;
            // 
            // btnOpenManage
            // 
            this.btnOpenManage.Font = new System.Drawing.Font("Verdana", 12F);
            this.btnOpenManage.Location = new System.Drawing.Point(175, 80);
            this.btnOpenManage.Name = "btnOpenManage";
            this.btnOpenManage.Size = new System.Drawing.Size(270, 28);
            this.btnOpenManage.TabIndex = 171;
            this.btnOpenManage.Text = "管理工單";
            this.btnOpenManage.UseVisualStyleBackColor = true;
            this.btnOpenManage.Click += new System.EventHandler(this.btnOpenManage_Click);
            // 
            // btnConfigFW
            // 
            this.btnConfigFW.Font = new System.Drawing.Font("Verdana", 12F);
            this.btnConfigFW.ForeColor = System.Drawing.Color.Navy;
            this.btnConfigFW.Location = new System.Drawing.Point(1438, 766);
            this.btnConfigFW.Name = "btnConfigFW";
            this.btnConfigFW.Size = new System.Drawing.Size(207, 30);
            this.btnConfigFW.TabIndex = 172;
            this.btnConfigFW.Text = "Conf FW Data";
            this.btnConfigFW.UseVisualStyleBackColor = true;
            this.btnConfigFW.Click += new System.EventHandler(this.btnConfigFW_Click);
            // 
            // btnShipMode
            // 
            this.btnShipMode.Font = new System.Drawing.Font("Verdana", 12F);
            this.btnShipMode.ForeColor = System.Drawing.Color.Navy;
            this.btnShipMode.Location = new System.Drawing.Point(175, 799);
            this.btnShipMode.Name = "btnShipMode";
            this.btnShipMode.Size = new System.Drawing.Size(270, 57);
            this.btnShipMode.TabIndex = 173;
            this.btnShipMode.Text = "Ship Mode";
            this.btnShipMode.UseVisualStyleBackColor = true;
            this.btnShipMode.Click += new System.EventHandler(this.btnShipMode_Click);
            // 
            // tbxHousing
            // 
            this.tbxHousing.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbxHousing.Location = new System.Drawing.Point(1371, 835);
            this.tbxHousing.Name = "tbxHousing";
            this.tbxHousing.Size = new System.Drawing.Size(271, 27);
            this.tbxHousing.TabIndex = 177;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Verdana", 12F);
            this.label35.Location = new System.Drawing.Point(1234, 838);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(140, 18);
            this.label35.TabIndex = 176;
            this.label35.Text = "Housing Version";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Verdana", 12F);
            this.label36.Location = new System.Drawing.Point(1435, 670);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(106, 18);
            this.label36.TabIndex = 175;
            this.label36.Text = "PCB Version";
            // 
            // tbxPCB
            // 
            this.tbxPCB.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbxPCB.Location = new System.Drawing.Point(1564, 668);
            this.tbxPCB.Name = "tbxPCB";
            this.tbxPCB.Size = new System.Drawing.Size(82, 27);
            this.tbxPCB.TabIndex = 178;
            // 
            // btnStatus
            // 
            this.btnStatus.Font = new System.Drawing.Font("Verdana", 12F);
            this.btnStatus.ForeColor = System.Drawing.Color.Navy;
            this.btnStatus.Location = new System.Drawing.Point(463, 562);
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.Size = new System.Drawing.Size(405, 39);
            this.btnStatus.TabIndex = 179;
            this.btnStatus.Text = "Status";
            this.btnStatus.UseVisualStyleBackColor = true;
            this.btnStatus.Click += new System.EventHandler(this.btnStatus_Click);
            // 
            // btnDump
            // 
            this.btnDump.Font = new System.Drawing.Font("Verdana", 12F);
            this.btnDump.ForeColor = System.Drawing.Color.Navy;
            this.btnDump.Location = new System.Drawing.Point(1438, 802);
            this.btnDump.Name = "btnDump";
            this.btnDump.Size = new System.Drawing.Size(204, 27);
            this.btnDump.TabIndex = 180;
            this.btnDump.Text = "Dump Data";
            this.btnDump.UseVisualStyleBackColor = true;
            this.btnDump.Click += new System.EventHandler(this.btnDump_Click);
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Verdana", 12F);
            this.label37.Location = new System.Drawing.Point(124, 270);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(47, 18);
            this.label37.TabIndex = 181;
            this.label37.Text = "批號:";
            // 
            // cbxBatch
            // 
            this.cbxBatch.Enabled = false;
            this.cbxBatch.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbxBatch.FormattingEnabled = true;
            this.cbxBatch.Location = new System.Drawing.Point(177, 264);
            this.cbxBatch.Name = "cbxBatch";
            this.cbxBatch.Size = new System.Drawing.Size(269, 24);
            this.cbxBatch.TabIndex = 183;
            this.cbxBatch.SelectedIndexChanged += new System.EventHandler(this.cbxBatch_SelectedIndexChanged);
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Verdana", 12F);
            this.label38.Location = new System.Drawing.Point(92, 323);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(79, 18);
            this.label38.TabIndex = 185;
            this.label38.Text = "完成數量:";
            // 
            // lblBatCompleteNum
            // 
            this.lblBatCompleteNum.AutoSize = true;
            this.lblBatCompleteNum.Font = new System.Drawing.Font("Verdana", 12F);
            this.lblBatCompleteNum.Location = new System.Drawing.Point(177, 323);
            this.lblBatCompleteNum.Name = "lblBatCompleteNum";
            this.lblBatCompleteNum.Size = new System.Drawing.Size(18, 18);
            this.lblBatCompleteNum.TabIndex = 186;
            this.lblBatCompleteNum.Text = "0";
            // 
            // lblBatTotal
            // 
            this.lblBatTotal.AutoSize = true;
            this.lblBatTotal.Font = new System.Drawing.Font("Verdana", 12F);
            this.lblBatTotal.Location = new System.Drawing.Point(177, 296);
            this.lblBatTotal.Name = "lblBatTotal";
            this.lblBatTotal.Size = new System.Drawing.Size(18, 18);
            this.lblBatTotal.TabIndex = 188;
            this.lblBatTotal.Text = "0";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("Verdana", 12F);
            this.label40.Location = new System.Drawing.Point(76, 296);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(95, 18);
            this.label40.TabIndex = 187;
            this.label40.Text = "應完成數量:";
            // 
            // cbx_name
            // 
            this.cbx_name.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbx_name.FormattingEnabled = true;
            this.cbx_name.Location = new System.Drawing.Point(177, 127);
            this.cbx_name.Name = "cbx_name";
            this.cbx_name.Size = new System.Drawing.Size(268, 24);
            this.cbx_name.TabIndex = 192;
            // 
            // tbxPassword
            // 
            this.tbxPassword.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbxPassword.Location = new System.Drawing.Point(177, 160);
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
            this.label39.Location = new System.Drawing.Point(76, 161);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(95, 18);
            this.label39.TabIndex = 190;
            this.label39.Text = "使用者密碼:";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Verdana", 12F);
            this.label41.Location = new System.Drawing.Point(76, 128);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(95, 18);
            this.label41.TabIndex = 189;
            this.label41.Text = "使用者名稱:";
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("Verdana", 12F);
            this.btnLogin.ForeColor = System.Drawing.Color.Navy;
            this.btnLogin.Location = new System.Drawing.Point(176, 197);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(270, 57);
            this.btnLogin.TabIndex = 193;
            this.btnLogin.Text = "登入選擇批號";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // cbxSleeve
            // 
            this.cbxSleeve.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbxSleeve.FormattingEnabled = true;
            this.cbxSleeve.Items.AddRange(new object[] {
            "SS ",
            "FT ",
            "KP ",
            "NP5"});
            this.cbxSleeve.Location = new System.Drawing.Point(1564, 639);
            this.cbxSleeve.Name = "cbxSleeve";
            this.cbxSleeve.Size = new System.Drawing.Size(81, 24);
            this.cbxSleeve.TabIndex = 167;
            this.cbxSleeve.SelectedIndexChanged += new System.EventHandler(this.cbxSleeve_SelectedIndexChanged);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Verdana", 12F);
            this.label33.Location = new System.Drawing.Point(1435, 642);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(115, 18);
            this.label33.TabIndex = 168;
            this.label33.Text = "Sleeve Name";
            // 
            // btxPrintLabel2
            // 
            this.btxPrintLabel2.Font = new System.Drawing.Font("Verdana", 12F);
            this.btxPrintLabel2.ForeColor = System.Drawing.Color.Navy;
            this.btxPrintLabel2.Location = new System.Drawing.Point(885, 691);
            this.btxPrintLabel2.Name = "btxPrintLabel2";
            this.btxPrintLabel2.Size = new System.Drawing.Size(270, 57);
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
            "NP"});
            this.cbxSleeveName2.Location = new System.Drawing.Point(885, 661);
            this.cbxSleeveName2.Name = "cbxSleeveName2";
            this.cbxSleeveName2.Size = new System.Drawing.Size(81, 24);
            this.cbxSleeveName2.TabIndex = 195;
            // 
            // tbxSN2
            // 
            this.tbxSN2.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbxSN2.Location = new System.Drawing.Point(977, 658);
            this.tbxSN2.Name = "tbxSN2";
            this.tbxSN2.Size = new System.Drawing.Size(178, 27);
            this.tbxSN2.TabIndex = 196;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(211)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(1665, 869);
            this.Controls.Add(this.tbxSN2);
            this.Controls.Add(this.cbxSleeveName2);
            this.Controls.Add(this.btxPrintLabel2);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.cbx_name);
            this.Controls.Add(this.tbxPassword);
            this.Controls.Add(this.label39);
            this.Controls.Add(this.label41);
            this.Controls.Add(this.lblBatTotal);
            this.Controls.Add(this.label40);
            this.Controls.Add(this.lblBatCompleteNum);
            this.Controls.Add(this.label38);
            this.Controls.Add(this.cbxBatch);
            this.Controls.Add(this.label37);
            this.Controls.Add(this.btnDump);
            this.Controls.Add(this.btnStatus);
            this.Controls.Add(this.tbxPCB);
            this.Controls.Add(this.tbxHousing);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.btnShipMode);
            this.Controls.Add(this.btnConfigFW);
            this.Controls.Add(this.btnOpenManage);
            this.Controls.Add(this.tbxSn);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.cbxSleeve);
            this.Controls.Add(this.lbl_charge_curr);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.btn_clear_com);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.btn_clr_pcb);
            this.Controls.Add(this.btn_ttl_send);
            this.Controls.Add(this.tbx_Pcb_feed_back);
            this.Controls.Add(this.tbx_ttl_send);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.btn_ass_chk);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbx_power);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbx_plc);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.chart2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.IO.Ports.SerialPort RS232_PLC;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.IO.Ports.SerialPort RS232_DOSE;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbx_plc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbx_power;
        private System.Windows.Forms.Button btn_ass_chk;
        private System.Windows.Forms.Label label18;
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
        private System.Windows.Forms.Button btnConfigFW;
        private System.Windows.Forms.Button btnShipMode;
        private System.Windows.Forms.TextBox tbxHousing;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TextBox tbxPCB;
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
        private System.Windows.Forms.ComboBox cbxSleeve;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Button btxPrintLabel2;
        private System.Windows.Forms.ComboBox cbxSleeveName2;
        private System.Windows.Forms.TextBox tbxSN2;
    }
}

