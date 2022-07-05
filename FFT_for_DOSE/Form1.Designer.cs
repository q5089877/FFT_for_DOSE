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
            this.button2 = new System.Windows.Forms.Button();
            this.RS232_PLC = new System.IO.Ports.SerialPort(this.components);
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.RS232_DOSE = new System.IO.Ports.SerialPort(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cbx_plc = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbx_dose = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbx_power = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbx_mouse_x_max = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbx_mouse_x_min = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbx_mouse_y_min = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbx_mouse_y_max = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbx_shutter_min = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbx_shutter_max = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbx_frame_min = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbx_frame_max = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbx_ir_min = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbx_ir_max = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tbx_iq_min = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tbx_iq_max = new System.Windows.Forms.TextBox();
            this.btn_set_th = new System.Windows.Forms.Button();
            this.btn_ass_chk = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.tbx_batt_min = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.tbx_batt_max = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.btn_clr_pcb = new System.Windows.Forms.Button();
            this.btn_ttl_send = new System.Windows.Forms.Button();
            this.tbx_Pcb_feed_back = new System.Windows.Forms.TextBox();
            this.tbx_ttl_send = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.btn_clear_com = new System.Windows.Forms.Button();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timer_chk_COM = new System.Windows.Forms.Timer(this.components);
            this.label20 = new System.Windows.Forms.Label();
            this.lbl_charge_curr = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.tbx_gyro_z_min = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.tbx_gyro_z_max = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.tbx_gyro_y_min = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.tbx_gyro_y_max = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.tbx_gyro_x_min = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.tbx_gyro_x_max = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.tbx_acc_z_min = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.tbx_acc_z_max = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.tbx_acc_y_min = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.tbx_acc_y_max = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.tbx_acc_x_min = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.tbx_acc_x_max = new System.Windows.Forms.TextBox();
            this.cbxSleeve = new System.Windows.Forms.ComboBox();
            this.label33 = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(808, 694);
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
            this.button6.Location = new System.Drawing.Point(1001, 694);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(107, 23);
            this.button6.TabIndex = 5;
            this.button6.Text = "Write M2(PLC)";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(920, 694);
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
            this.label1.Location = new System.Drawing.Point(16, 21);
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 12F);
            this.label3.Location = new System.Drawing.Point(794, 663);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 18);
            this.label3.TabIndex = 32;
            this.label3.Text = "DOSE ComPort:";
            this.label3.Visible = false;
            // 
            // cbx_dose
            // 
            this.cbx_dose.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbx_dose.FormattingEnabled = true;
            this.cbx_dose.Location = new System.Drawing.Point(946, 657);
            this.cbx_dose.Name = "cbx_dose";
            this.cbx_dose.Size = new System.Drawing.Size(209, 24);
            this.cbx_dose.TabIndex = 31;
            this.cbx_dose.Visible = false;
            this.cbx_dose.SelectedIndexChanged += new System.EventHandler(this.cbx_dose_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 12F);
            this.label4.Location = new System.Drawing.Point(16, 51);
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
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 12F);
            this.label13.Location = new System.Drawing.Point(19, 96);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(123, 18);
            this.label13.TabIndex = 80;
            this.label13.Text = "Mouse_X_Max";
            // 
            // tbx_mouse_x_max
            // 
            this.tbx_mouse_x_max.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbx_mouse_x_max.Location = new System.Drawing.Point(148, 87);
            this.tbx_mouse_x_max.Name = "tbx_mouse_x_max";
            this.tbx_mouse_x_max.Size = new System.Drawing.Size(81, 27);
            this.tbx_mouse_x_max.TabIndex = 79;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F);
            this.label2.Location = new System.Drawing.Point(235, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 18);
            this.label2.TabIndex = 82;
            this.label2.Text = "Mouse_X_Min";
            // 
            // tbx_mouse_x_min
            // 
            this.tbx_mouse_x_min.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbx_mouse_x_min.Location = new System.Drawing.Point(364, 87);
            this.tbx_mouse_x_min.Name = "tbx_mouse_x_min";
            this.tbx_mouse_x_min.Size = new System.Drawing.Size(81, 27);
            this.tbx_mouse_x_min.TabIndex = 81;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 12F);
            this.label5.Location = new System.Drawing.Point(235, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 18);
            this.label5.TabIndex = 86;
            this.label5.Text = "Mouse_Y_Min";
            // 
            // tbx_mouse_y_min
            // 
            this.tbx_mouse_y_min.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbx_mouse_y_min.Location = new System.Drawing.Point(364, 120);
            this.tbx_mouse_y_min.Name = "tbx_mouse_y_min";
            this.tbx_mouse_y_min.Size = new System.Drawing.Size(81, 27);
            this.tbx_mouse_y_min.TabIndex = 85;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 12F);
            this.label6.Location = new System.Drawing.Point(19, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 18);
            this.label6.TabIndex = 84;
            this.label6.Text = "Mouse_Y_Max";
            // 
            // tbx_mouse_y_max
            // 
            this.tbx_mouse_y_max.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbx_mouse_y_max.Location = new System.Drawing.Point(148, 120);
            this.tbx_mouse_y_max.Name = "tbx_mouse_y_max";
            this.tbx_mouse_y_max.Size = new System.Drawing.Size(81, 27);
            this.tbx_mouse_y_max.TabIndex = 83;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 12F);
            this.label7.Location = new System.Drawing.Point(235, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 18);
            this.label7.TabIndex = 90;
            this.label7.Text = "Shutter_Min";
            // 
            // tbx_shutter_min
            // 
            this.tbx_shutter_min.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbx_shutter_min.Location = new System.Drawing.Point(364, 153);
            this.tbx_shutter_min.Name = "tbx_shutter_min";
            this.tbx_shutter_min.Size = new System.Drawing.Size(81, 27);
            this.tbx_shutter_min.TabIndex = 89;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 12F);
            this.label8.Location = new System.Drawing.Point(19, 162);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 18);
            this.label8.TabIndex = 88;
            this.label8.Text = "Shutter_Max";
            // 
            // tbx_shutter_max
            // 
            this.tbx_shutter_max.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbx_shutter_max.Location = new System.Drawing.Point(148, 153);
            this.tbx_shutter_max.Name = "tbx_shutter_max";
            this.tbx_shutter_max.Size = new System.Drawing.Size(81, 27);
            this.tbx_shutter_max.TabIndex = 87;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 12F);
            this.label9.Location = new System.Drawing.Point(235, 195);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 18);
            this.label9.TabIndex = 94;
            this.label9.Text = "Frame_Min";
            // 
            // tbx_frame_min
            // 
            this.tbx_frame_min.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbx_frame_min.Location = new System.Drawing.Point(364, 186);
            this.tbx_frame_min.Name = "tbx_frame_min";
            this.tbx_frame_min.Size = new System.Drawing.Size(81, 27);
            this.tbx_frame_min.TabIndex = 93;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 12F);
            this.label10.Location = new System.Drawing.Point(19, 195);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 18);
            this.label10.TabIndex = 92;
            this.label10.Text = "Frame_Max";
            // 
            // tbx_frame_max
            // 
            this.tbx_frame_max.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbx_frame_max.Location = new System.Drawing.Point(148, 186);
            this.tbx_frame_max.Name = "tbx_frame_max";
            this.tbx_frame_max.Size = new System.Drawing.Size(81, 27);
            this.tbx_frame_max.TabIndex = 91;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 12F);
            this.label11.Location = new System.Drawing.Point(235, 261);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 18);
            this.label11.TabIndex = 102;
            this.label11.Text = "IR_Min";
            // 
            // tbx_ir_min
            // 
            this.tbx_ir_min.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbx_ir_min.Location = new System.Drawing.Point(364, 252);
            this.tbx_ir_min.Name = "tbx_ir_min";
            this.tbx_ir_min.Size = new System.Drawing.Size(81, 27);
            this.tbx_ir_min.TabIndex = 101;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 12F);
            this.label12.Location = new System.Drawing.Point(19, 261);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 18);
            this.label12.TabIndex = 100;
            this.label12.Text = "IR_Max";
            // 
            // tbx_ir_max
            // 
            this.tbx_ir_max.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbx_ir_max.Location = new System.Drawing.Point(148, 252);
            this.tbx_ir_max.Name = "tbx_ir_max";
            this.tbx_ir_max.Size = new System.Drawing.Size(81, 27);
            this.tbx_ir_max.TabIndex = 99;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Verdana", 12F);
            this.label14.Location = new System.Drawing.Point(235, 228);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(66, 18);
            this.label14.TabIndex = 98;
            this.label14.Text = "IQ_Min";
            // 
            // tbx_iq_min
            // 
            this.tbx_iq_min.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbx_iq_min.Location = new System.Drawing.Point(364, 219);
            this.tbx_iq_min.Name = "tbx_iq_min";
            this.tbx_iq_min.Size = new System.Drawing.Size(81, 27);
            this.tbx_iq_min.TabIndex = 97;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Verdana", 12F);
            this.label15.Location = new System.Drawing.Point(19, 228);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(70, 18);
            this.label15.TabIndex = 96;
            this.label15.Text = "IQ_Max";
            // 
            // tbx_iq_max
            // 
            this.tbx_iq_max.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbx_iq_max.Location = new System.Drawing.Point(148, 219);
            this.tbx_iq_max.Name = "tbx_iq_max";
            this.tbx_iq_max.Size = new System.Drawing.Size(81, 27);
            this.tbx_iq_max.TabIndex = 95;
            // 
            // btn_set_th
            // 
            this.btn_set_th.Font = new System.Drawing.Font("Verdana", 12F);
            this.btn_set_th.ForeColor = System.Drawing.Color.Navy;
            this.btn_set_th.Location = new System.Drawing.Point(22, 602);
            this.btn_set_th.Name = "btn_set_th";
            this.btn_set_th.Size = new System.Drawing.Size(423, 38);
            this.btn_set_th.TabIndex = 103;
            this.btn_set_th.Text = "#SET_ASS_TH";
            this.btn_set_th.UseVisualStyleBackColor = true;
            this.btn_set_th.Click += new System.EventHandler(this.btn_set_th_Click);
            // 
            // btn_ass_chk
            // 
            this.btn_ass_chk.Font = new System.Drawing.Font("Verdana", 12F);
            this.btn_ass_chk.ForeColor = System.Drawing.Color.Navy;
            this.btn_ass_chk.Location = new System.Drawing.Point(22, 646);
            this.btn_ass_chk.Name = "btn_ass_chk";
            this.btn_ass_chk.Size = new System.Drawing.Size(423, 38);
            this.btn_ass_chk.TabIndex = 104;
            this.btn_ass_chk.Text = "#ASS_CHECK";
            this.btn_ass_chk.UseVisualStyleBackColor = true;
            this.btn_ass_chk.Click += new System.EventHandler(this.btn_ass_chk_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Verdana", 12F);
            this.label16.Location = new System.Drawing.Point(235, 294);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(106, 18);
            this.label16.TabIndex = 108;
            this.label16.Text = "Battery_Min";
            // 
            // tbx_batt_min
            // 
            this.tbx_batt_min.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbx_batt_min.Location = new System.Drawing.Point(364, 285);
            this.tbx_batt_min.Name = "tbx_batt_min";
            this.tbx_batt_min.Size = new System.Drawing.Size(81, 27);
            this.tbx_batt_min.TabIndex = 107;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Verdana", 12F);
            this.label17.Location = new System.Drawing.Point(19, 294);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(110, 18);
            this.label17.TabIndex = 106;
            this.label17.Text = "Battery_Max";
            // 
            // tbx_batt_max
            // 
            this.tbx_batt_max.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbx_batt_max.Location = new System.Drawing.Point(148, 285);
            this.tbx_batt_max.Name = "tbx_batt_max";
            this.tbx_batt_max.Size = new System.Drawing.Size(81, 27);
            this.tbx_batt_max.TabIndex = 105;
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
            this.btn_ttl_send.Location = new System.Drawing.Point(779, 610);
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
            this.tbx_ttl_send.Location = new System.Drawing.Point(578, 610);
            this.tbx_ttl_send.Name = "tbx_ttl_send";
            this.tbx_ttl_send.Size = new System.Drawing.Size(195, 27);
            this.tbx_ttl_send.TabIndex = 133;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Verdana", 12F);
            this.label19.Location = new System.Drawing.Point(460, 614);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(112, 18);
            this.label19.TabIndex = 135;
            this.label19.Text = "PC Transmit:";
            // 
            // btn_clear_com
            // 
            this.btn_clear_com.Font = new System.Drawing.Font("Verdana", 12F);
            this.btn_clear_com.ForeColor = System.Drawing.Color.Navy;
            this.btn_clear_com.Location = new System.Drawing.Point(22, 689);
            this.btn_clear_com.Name = "btn_clear_com";
            this.btn_clear_com.Size = new System.Drawing.Size(423, 38);
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
            this.chart2.Location = new System.Drawing.Point(885, 39);
            this.chart2.Name = "chart2";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart2.Series.Add(series1);
            this.chart2.Size = new System.Drawing.Size(748, 599);
            this.chart2.TabIndex = 140;
            this.chart2.Text = "chart2";
            this.chart2.Visible = false;
            // 
            // timer_chk_COM
            // 
            this.timer_chk_COM.Interval = 1000;
            this.timer_chk_COM.Tick += new System.EventHandler(this.timer_chk_COM_Tick);
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
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Verdana", 12F);
            this.label21.Location = new System.Drawing.Point(235, 492);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(104, 18);
            this.label21.TabIndex = 166;
            this.label21.Text = "Gyro_Z_Min";
            // 
            // tbx_gyro_z_min
            // 
            this.tbx_gyro_z_min.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbx_gyro_z_min.Location = new System.Drawing.Point(364, 483);
            this.tbx_gyro_z_min.Name = "tbx_gyro_z_min";
            this.tbx_gyro_z_min.Size = new System.Drawing.Size(81, 27);
            this.tbx_gyro_z_min.TabIndex = 165;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Verdana", 12F);
            this.label22.Location = new System.Drawing.Point(19, 492);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(108, 18);
            this.label22.TabIndex = 164;
            this.label22.Text = "Gyro_Z_Max";
            // 
            // tbx_gyro_z_max
            // 
            this.tbx_gyro_z_max.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbx_gyro_z_max.Location = new System.Drawing.Point(148, 483);
            this.tbx_gyro_z_max.Name = "tbx_gyro_z_max";
            this.tbx_gyro_z_max.Size = new System.Drawing.Size(81, 27);
            this.tbx_gyro_z_max.TabIndex = 163;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Verdana", 12F);
            this.label23.Location = new System.Drawing.Point(235, 459);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(104, 18);
            this.label23.TabIndex = 162;
            this.label23.Text = "Gyro_Y_Min";
            // 
            // tbx_gyro_y_min
            // 
            this.tbx_gyro_y_min.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbx_gyro_y_min.Location = new System.Drawing.Point(364, 450);
            this.tbx_gyro_y_min.Name = "tbx_gyro_y_min";
            this.tbx_gyro_y_min.Size = new System.Drawing.Size(81, 27);
            this.tbx_gyro_y_min.TabIndex = 161;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Verdana", 12F);
            this.label24.Location = new System.Drawing.Point(19, 459);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(108, 18);
            this.label24.TabIndex = 160;
            this.label24.Text = "Gyro_Y_Max";
            // 
            // tbx_gyro_y_max
            // 
            this.tbx_gyro_y_max.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbx_gyro_y_max.Location = new System.Drawing.Point(148, 450);
            this.tbx_gyro_y_max.Name = "tbx_gyro_y_max";
            this.tbx_gyro_y_max.Size = new System.Drawing.Size(81, 27);
            this.tbx_gyro_y_max.TabIndex = 159;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Verdana", 12F);
            this.label25.Location = new System.Drawing.Point(235, 426);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(104, 18);
            this.label25.TabIndex = 158;
            this.label25.Text = "Gyro_X_Min";
            // 
            // tbx_gyro_x_min
            // 
            this.tbx_gyro_x_min.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbx_gyro_x_min.Location = new System.Drawing.Point(364, 417);
            this.tbx_gyro_x_min.Name = "tbx_gyro_x_min";
            this.tbx_gyro_x_min.Size = new System.Drawing.Size(81, 27);
            this.tbx_gyro_x_min.TabIndex = 157;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Verdana", 12F);
            this.label26.Location = new System.Drawing.Point(19, 426);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(108, 18);
            this.label26.TabIndex = 156;
            this.label26.Text = "Gyro_X_Max";
            // 
            // tbx_gyro_x_max
            // 
            this.tbx_gyro_x_max.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbx_gyro_x_max.Location = new System.Drawing.Point(148, 417);
            this.tbx_gyro_x_max.Name = "tbx_gyro_x_max";
            this.tbx_gyro_x_max.Size = new System.Drawing.Size(81, 27);
            this.tbx_gyro_x_max.TabIndex = 155;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Verdana", 12F);
            this.label27.Location = new System.Drawing.Point(235, 393);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(94, 18);
            this.label27.TabIndex = 154;
            this.label27.Text = "Acc_Z_Min";
            // 
            // tbx_acc_z_min
            // 
            this.tbx_acc_z_min.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbx_acc_z_min.Location = new System.Drawing.Point(364, 384);
            this.tbx_acc_z_min.Name = "tbx_acc_z_min";
            this.tbx_acc_z_min.Size = new System.Drawing.Size(81, 27);
            this.tbx_acc_z_min.TabIndex = 153;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Verdana", 12F);
            this.label28.Location = new System.Drawing.Point(19, 393);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(98, 18);
            this.label28.TabIndex = 152;
            this.label28.Text = "Acc_Z_Max";
            // 
            // tbx_acc_z_max
            // 
            this.tbx_acc_z_max.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbx_acc_z_max.Location = new System.Drawing.Point(148, 384);
            this.tbx_acc_z_max.Name = "tbx_acc_z_max";
            this.tbx_acc_z_max.Size = new System.Drawing.Size(81, 27);
            this.tbx_acc_z_max.TabIndex = 151;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Verdana", 12F);
            this.label29.Location = new System.Drawing.Point(235, 360);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(94, 18);
            this.label29.TabIndex = 150;
            this.label29.Text = "Acc_Y_Min";
            // 
            // tbx_acc_y_min
            // 
            this.tbx_acc_y_min.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbx_acc_y_min.Location = new System.Drawing.Point(364, 351);
            this.tbx_acc_y_min.Name = "tbx_acc_y_min";
            this.tbx_acc_y_min.Size = new System.Drawing.Size(81, 27);
            this.tbx_acc_y_min.TabIndex = 149;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Verdana", 12F);
            this.label30.Location = new System.Drawing.Point(19, 360);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(98, 18);
            this.label30.TabIndex = 148;
            this.label30.Text = "Acc_Y_Max";
            // 
            // tbx_acc_y_max
            // 
            this.tbx_acc_y_max.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbx_acc_y_max.Location = new System.Drawing.Point(148, 351);
            this.tbx_acc_y_max.Name = "tbx_acc_y_max";
            this.tbx_acc_y_max.Size = new System.Drawing.Size(81, 27);
            this.tbx_acc_y_max.TabIndex = 147;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Verdana", 12F);
            this.label31.Location = new System.Drawing.Point(235, 327);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(94, 18);
            this.label31.TabIndex = 146;
            this.label31.Text = "Acc_X_Min";
            // 
            // tbx_acc_x_min
            // 
            this.tbx_acc_x_min.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbx_acc_x_min.Location = new System.Drawing.Point(364, 318);
            this.tbx_acc_x_min.Name = "tbx_acc_x_min";
            this.tbx_acc_x_min.Size = new System.Drawing.Size(81, 27);
            this.tbx_acc_x_min.TabIndex = 145;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Verdana", 12F);
            this.label32.Location = new System.Drawing.Point(19, 327);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(98, 18);
            this.label32.TabIndex = 144;
            this.label32.Text = "Acc_X_Max";
            // 
            // tbx_acc_x_max
            // 
            this.tbx_acc_x_max.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbx_acc_x_max.Location = new System.Drawing.Point(148, 318);
            this.tbx_acc_x_max.Name = "tbx_acc_x_max";
            this.tbx_acc_x_max.Size = new System.Drawing.Size(81, 27);
            this.tbx_acc_x_max.TabIndex = 143;
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
            this.cbxSleeve.Location = new System.Drawing.Point(148, 531);
            this.cbxSleeve.Name = "cbxSleeve";
            this.cbxSleeve.Size = new System.Drawing.Size(81, 24);
            this.cbxSleeve.TabIndex = 167;
            this.cbxSleeve.SelectedIndexChanged += new System.EventHandler(this.cbxSleeve_SelectedIndexChanged);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Verdana", 12F);
            this.label33.Location = new System.Drawing.Point(19, 534);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(115, 18);
            this.label33.TabIndex = 168;
            this.label33.Text = "Sleeve Name";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Verdana", 12F);
            this.label34.Location = new System.Drawing.Point(235, 534);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(30, 18);
            this.label34.TabIndex = 169;
            this.label34.Text = "SN";
            // 
            // tbxSn
            // 
            this.tbxSn.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbxSn.Location = new System.Drawing.Point(274, 531);
            this.tbxSn.Name = "tbxSn";
            this.tbxSn.Size = new System.Drawing.Size(171, 27);
            this.tbxSn.TabIndex = 170;
            this.tbxSn.Text = "22-C-DA2-001";
            // 
            // btnOpenManage
            // 
            this.btnOpenManage.Font = new System.Drawing.Font("Verdana", 12F);
            this.btnOpenManage.Location = new System.Drawing.Point(463, 689);
            this.btnOpenManage.Name = "btnOpenManage";
            this.btnOpenManage.Size = new System.Drawing.Size(194, 28);
            this.btnOpenManage.TabIndex = 171;
            this.btnOpenManage.Text = "管理工單";
            this.btnOpenManage.UseVisualStyleBackColor = true;
            this.btnOpenManage.Click += new System.EventHandler(this.btnOpenManage_Click);
            // 
            // btnConfigFW
            // 
            this.btnConfigFW.Font = new System.Drawing.Font("Verdana", 12F);
            this.btnConfigFW.ForeColor = System.Drawing.Color.Navy;
            this.btnConfigFW.Location = new System.Drawing.Point(464, 646);
            this.btnConfigFW.Name = "btnConfigFW";
            this.btnConfigFW.Size = new System.Drawing.Size(130, 27);
            this.btnConfigFW.TabIndex = 172;
            this.btnConfigFW.Text = "Conf FW Data";
            this.btnConfigFW.UseVisualStyleBackColor = true;
            this.btnConfigFW.Click += new System.EventHandler(this.btnConfigFW_Click);
            // 
            // btnShipMode
            // 
            this.btnShipMode.Font = new System.Drawing.Font("Verdana", 12F);
            this.btnShipMode.ForeColor = System.Drawing.Color.Navy;
            this.btnShipMode.Location = new System.Drawing.Point(464, 735);
            this.btnShipMode.Name = "btnShipMode";
            this.btnShipMode.Size = new System.Drawing.Size(103, 27);
            this.btnShipMode.TabIndex = 173;
            this.btnShipMode.Text = "Ship Mode";
            this.btnShipMode.UseVisualStyleBackColor = true;
            this.btnShipMode.Click += new System.EventHandler(this.btnShipMode_Click);
            // 
            // tbxHousing
            // 
            this.tbxHousing.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbxHousing.Location = new System.Drawing.Point(597, 531);
            this.tbxHousing.Name = "tbxHousing";
            this.tbxHousing.Size = new System.Drawing.Size(271, 27);
            this.tbxHousing.TabIndex = 177;
            this.tbxHousing.Text = "v8.0-02";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Verdana", 12F);
            this.label35.Location = new System.Drawing.Point(460, 534);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(140, 18);
            this.label35.TabIndex = 176;
            this.label35.Text = "Housing Version";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Verdana", 12F);
            this.label36.Location = new System.Drawing.Point(19, 562);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(106, 18);
            this.label36.TabIndex = 175;
            this.label36.Text = "PCB Version";
            // 
            // tbxPCB
            // 
            this.tbxPCB.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbxPCB.Location = new System.Drawing.Point(148, 560);
            this.tbxPCB.Name = "tbxPCB";
            this.tbxPCB.Size = new System.Drawing.Size(82, 27);
            this.tbxPCB.TabIndex = 178;
            this.tbxPCB.Text = "9.1";
            // 
            // btnStatus
            // 
            this.btnStatus.Font = new System.Drawing.Font("Verdana", 12F);
            this.btnStatus.ForeColor = System.Drawing.Color.Navy;
            this.btnStatus.Location = new System.Drawing.Point(600, 646);
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.Size = new System.Drawing.Size(80, 27);
            this.btnStatus.TabIndex = 179;
            this.btnStatus.Text = "Status";
            this.btnStatus.UseVisualStyleBackColor = true;
            this.btnStatus.Click += new System.EventHandler(this.btnStatus_Click);
            // 
            // btnDump
            // 
            this.btnDump.Font = new System.Drawing.Font("Verdana", 12F);
            this.btnDump.ForeColor = System.Drawing.Color.Navy;
            this.btnDump.Location = new System.Drawing.Point(686, 646);
            this.btnDump.Name = "btnDump";
            this.btnDump.Size = new System.Drawing.Size(109, 27);
            this.btnDump.TabIndex = 180;
            this.btnDump.Text = "Dump Data";
            this.btnDump.UseVisualStyleBackColor = true;
            this.btnDump.Click += new System.EventHandler(this.btnDump_Click);
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Verdana", 12F);
            this.label37.Location = new System.Drawing.Point(235, 564);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(54, 18);
            this.label37.TabIndex = 181;
            this.label37.Text = "Batch";
            // 
            // cbxBatch
            // 
            this.cbxBatch.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbxBatch.FormattingEnabled = true;
            this.cbxBatch.Location = new System.Drawing.Point(295, 562);
            this.cbxBatch.Name = "cbxBatch";
            this.cbxBatch.Size = new System.Drawing.Size(150, 24);
            this.cbxBatch.TabIndex = 183;
            this.cbxBatch.SelectedIndexChanged += new System.EventHandler(this.cbxBatch_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(211)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(1155, 758);
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
            this.Controls.Add(this.label21);
            this.Controls.Add(this.tbx_gyro_z_min);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.tbx_gyro_z_max);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.tbx_gyro_y_min);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.tbx_gyro_y_max);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.tbx_gyro_x_min);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.tbx_gyro_x_max);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.tbx_acc_z_min);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.tbx_acc_z_max);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.tbx_acc_y_min);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.tbx_acc_y_max);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.tbx_acc_x_min);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.tbx_acc_x_max);
            this.Controls.Add(this.lbl_charge_curr);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.btn_clear_com);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.btn_clr_pcb);
            this.Controls.Add(this.btn_ttl_send);
            this.Controls.Add(this.tbx_Pcb_feed_back);
            this.Controls.Add(this.tbx_ttl_send);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.tbx_batt_min);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.tbx_batt_max);
            this.Controls.Add(this.btn_ass_chk);
            this.Controls.Add(this.btn_set_th);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tbx_ir_min);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.tbx_ir_max);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.tbx_iq_min);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.tbx_iq_max);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbx_frame_min);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tbx_frame_max);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbx_shutter_min);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbx_shutter_max);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbx_mouse_y_min);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbx_mouse_y_max);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbx_mouse_x_min);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.tbx_mouse_x_max);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbx_power);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbx_dose);
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbx_dose;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbx_power;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbx_mouse_x_max;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbx_mouse_x_min;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbx_mouse_y_min;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbx_mouse_y_max;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbx_shutter_min;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbx_shutter_max;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbx_frame_min;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbx_frame_max;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbx_ir_min;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbx_ir_max;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbx_iq_min;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tbx_iq_max;
        private System.Windows.Forms.Button btn_set_th;
        private System.Windows.Forms.Button btn_ass_chk;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tbx_batt_min;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox tbx_batt_max;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btn_clr_pcb;
        private System.Windows.Forms.Button btn_ttl_send;
        private System.Windows.Forms.TextBox tbx_Pcb_feed_back;
        private System.Windows.Forms.TextBox tbx_ttl_send;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btn_clear_com;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.Timer timer_chk_COM;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lbl_charge_curr;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox tbx_gyro_z_min;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox tbx_gyro_z_max;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox tbx_gyro_y_min;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox tbx_gyro_y_max;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox tbx_gyro_x_min;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox tbx_gyro_x_max;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox tbx_acc_z_min;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox tbx_acc_z_max;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox tbx_acc_y_min;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox tbx_acc_y_max;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox tbx_acc_x_min;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox tbx_acc_x_max;
        private System.Windows.Forms.ComboBox cbxSleeve;
        private System.Windows.Forms.Label label33;
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
    }
}

