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
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(8, 651);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(107, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Opeb PLC COM";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // RS232_PLC
            // 
            this.RS232_PLC.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(8, 622);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(107, 23);
            this.button6.TabIndex = 5;
            this.button6.Text = "Write M2";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(121, 651);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 6;
            this.button7.Text = "Read M2";
            this.button7.UseVisualStyleBackColor = true;
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
            this.cbx_plc.Size = new System.Drawing.Size(209, 24);
            this.cbx_plc.TabIndex = 27;
            this.cbx_plc.SelectedIndexChanged += new System.EventHandler(this.cbx_plc_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 12F);
            this.label3.Location = new System.Drawing.Point(16, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 18);
            this.label3.TabIndex = 32;
            this.label3.Text = "DOSE ComPort:";
            // 
            // cbx_dose
            // 
            this.cbx_dose.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbx_dose.FormattingEnabled = true;
            this.cbx_dose.Location = new System.Drawing.Point(175, 51);
            this.cbx_dose.Name = "cbx_dose";
            this.cbx_dose.Size = new System.Drawing.Size(209, 24);
            this.cbx_dose.TabIndex = 31;
            this.cbx_dose.SelectedIndexChanged += new System.EventHandler(this.cbx_dose_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 12F);
            this.label4.Location = new System.Drawing.Point(16, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 18);
            this.label4.TabIndex = 34;
            this.label4.Text = "Power ComPort:";
            // 
            // cbx_power
            // 
            this.cbx_power.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbx_power.FormattingEnabled = true;
            this.cbx_power.Location = new System.Drawing.Point(175, 81);
            this.cbx_power.Name = "cbx_power";
            this.cbx_power.Size = new System.Drawing.Size(209, 24);
            this.cbx_power.TabIndex = 33;
            this.cbx_power.SelectedIndexChanged += new System.EventHandler(this.cbx_power_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 12F);
            this.label13.Location = new System.Drawing.Point(19, 144);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(123, 18);
            this.label13.TabIndex = 80;
            this.label13.Text = "Mouse_X_Max";
            // 
            // tbx_mouse_x_max
            // 
            this.tbx_mouse_x_max.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbx_mouse_x_max.Location = new System.Drawing.Point(148, 135);
            this.tbx_mouse_x_max.Name = "tbx_mouse_x_max";
            this.tbx_mouse_x_max.Size = new System.Drawing.Size(81, 27);
            this.tbx_mouse_x_max.TabIndex = 79;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F);
            this.label2.Location = new System.Drawing.Point(235, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 18);
            this.label2.TabIndex = 82;
            this.label2.Text = "Mouse_X_Min";
            // 
            // tbx_mouse_x_min
            // 
            this.tbx_mouse_x_min.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbx_mouse_x_min.Location = new System.Drawing.Point(364, 135);
            this.tbx_mouse_x_min.Name = "tbx_mouse_x_min";
            this.tbx_mouse_x_min.Size = new System.Drawing.Size(81, 27);
            this.tbx_mouse_x_min.TabIndex = 81;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 12F);
            this.label5.Location = new System.Drawing.Point(235, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 18);
            this.label5.TabIndex = 86;
            this.label5.Text = "Mouse_Y_Min";
            // 
            // tbx_mouse_y_min
            // 
            this.tbx_mouse_y_min.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbx_mouse_y_min.Location = new System.Drawing.Point(364, 168);
            this.tbx_mouse_y_min.Name = "tbx_mouse_y_min";
            this.tbx_mouse_y_min.Size = new System.Drawing.Size(81, 27);
            this.tbx_mouse_y_min.TabIndex = 85;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 12F);
            this.label6.Location = new System.Drawing.Point(19, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 18);
            this.label6.TabIndex = 84;
            this.label6.Text = "Mouse_Y_Max";
            // 
            // tbx_mouse_y_max
            // 
            this.tbx_mouse_y_max.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbx_mouse_y_max.Location = new System.Drawing.Point(148, 168);
            this.tbx_mouse_y_max.Name = "tbx_mouse_y_max";
            this.tbx_mouse_y_max.Size = new System.Drawing.Size(81, 27);
            this.tbx_mouse_y_max.TabIndex = 83;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 12F);
            this.label7.Location = new System.Drawing.Point(235, 210);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 18);
            this.label7.TabIndex = 90;
            this.label7.Text = "Shutter_Min";
            // 
            // tbx_shutter_min
            // 
            this.tbx_shutter_min.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbx_shutter_min.Location = new System.Drawing.Point(364, 201);
            this.tbx_shutter_min.Name = "tbx_shutter_min";
            this.tbx_shutter_min.Size = new System.Drawing.Size(81, 27);
            this.tbx_shutter_min.TabIndex = 89;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 12F);
            this.label8.Location = new System.Drawing.Point(19, 210);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 18);
            this.label8.TabIndex = 88;
            this.label8.Text = "Shutter_Max";
            // 
            // tbx_shutter_max
            // 
            this.tbx_shutter_max.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbx_shutter_max.Location = new System.Drawing.Point(148, 201);
            this.tbx_shutter_max.Name = "tbx_shutter_max";
            this.tbx_shutter_max.Size = new System.Drawing.Size(81, 27);
            this.tbx_shutter_max.TabIndex = 87;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 12F);
            this.label9.Location = new System.Drawing.Point(235, 243);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 18);
            this.label9.TabIndex = 94;
            this.label9.Text = "Frame_Min";
            // 
            // tbx_frame_min
            // 
            this.tbx_frame_min.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbx_frame_min.Location = new System.Drawing.Point(364, 234);
            this.tbx_frame_min.Name = "tbx_frame_min";
            this.tbx_frame_min.Size = new System.Drawing.Size(81, 27);
            this.tbx_frame_min.TabIndex = 93;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 12F);
            this.label10.Location = new System.Drawing.Point(19, 243);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 18);
            this.label10.TabIndex = 92;
            this.label10.Text = "Frame_Max";
            // 
            // tbx_frame_max
            // 
            this.tbx_frame_max.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbx_frame_max.Location = new System.Drawing.Point(148, 234);
            this.tbx_frame_max.Name = "tbx_frame_max";
            this.tbx_frame_max.Size = new System.Drawing.Size(81, 27);
            this.tbx_frame_max.TabIndex = 91;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 12F);
            this.label11.Location = new System.Drawing.Point(235, 309);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 18);
            this.label11.TabIndex = 102;
            this.label11.Text = "IR_Min";
            // 
            // tbx_ir_min
            // 
            this.tbx_ir_min.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbx_ir_min.Location = new System.Drawing.Point(364, 300);
            this.tbx_ir_min.Name = "tbx_ir_min";
            this.tbx_ir_min.Size = new System.Drawing.Size(81, 27);
            this.tbx_ir_min.TabIndex = 101;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 12F);
            this.label12.Location = new System.Drawing.Point(19, 309);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 18);
            this.label12.TabIndex = 100;
            this.label12.Text = "IR_Max";
            // 
            // tbx_ir_max
            // 
            this.tbx_ir_max.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbx_ir_max.Location = new System.Drawing.Point(148, 300);
            this.tbx_ir_max.Name = "tbx_ir_max";
            this.tbx_ir_max.Size = new System.Drawing.Size(81, 27);
            this.tbx_ir_max.TabIndex = 99;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Verdana", 12F);
            this.label14.Location = new System.Drawing.Point(235, 276);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(66, 18);
            this.label14.TabIndex = 98;
            this.label14.Text = "IQ_Min";
            // 
            // tbx_iq_min
            // 
            this.tbx_iq_min.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbx_iq_min.Location = new System.Drawing.Point(364, 267);
            this.tbx_iq_min.Name = "tbx_iq_min";
            this.tbx_iq_min.Size = new System.Drawing.Size(81, 27);
            this.tbx_iq_min.TabIndex = 97;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Verdana", 12F);
            this.label15.Location = new System.Drawing.Point(19, 276);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(70, 18);
            this.label15.TabIndex = 96;
            this.label15.Text = "IQ_Max";
            // 
            // tbx_iq_max
            // 
            this.tbx_iq_max.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbx_iq_max.Location = new System.Drawing.Point(148, 267);
            this.tbx_iq_max.Name = "tbx_iq_max";
            this.tbx_iq_max.Size = new System.Drawing.Size(81, 27);
            this.tbx_iq_max.TabIndex = 95;
            // 
            // btn_set_th
            // 
            this.btn_set_th.Font = new System.Drawing.Font("Verdana", 12F);
            this.btn_set_th.ForeColor = System.Drawing.Color.Navy;
            this.btn_set_th.Location = new System.Drawing.Point(22, 366);
            this.btn_set_th.Name = "btn_set_th";
            this.btn_set_th.Size = new System.Drawing.Size(423, 48);
            this.btn_set_th.TabIndex = 103;
            this.btn_set_th.Text = "#SET_ASS_TH";
            this.btn_set_th.UseVisualStyleBackColor = true;
            this.btn_set_th.Click += new System.EventHandler(this.btn_set_th_Click);
            // 
            // btn_ass_chk
            // 
            this.btn_ass_chk.Font = new System.Drawing.Font("Verdana", 12F);
            this.btn_ass_chk.ForeColor = System.Drawing.Color.Navy;
            this.btn_ass_chk.Location = new System.Drawing.Point(22, 420);
            this.btn_ass_chk.Name = "btn_ass_chk";
            this.btn_ass_chk.Size = new System.Drawing.Size(423, 48);
            this.btn_ass_chk.TabIndex = 104;
            this.btn_ass_chk.Text = "#ASS_CHECK";
            this.btn_ass_chk.UseVisualStyleBackColor = true;
            this.btn_ass_chk.Click += new System.EventHandler(this.btn_ass_chk_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Verdana", 12F);
            this.label16.Location = new System.Drawing.Point(235, 342);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(106, 18);
            this.label16.TabIndex = 108;
            this.label16.Text = "Battery_Min";
            // 
            // tbx_batt_min
            // 
            this.tbx_batt_min.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbx_batt_min.Location = new System.Drawing.Point(364, 333);
            this.tbx_batt_min.Name = "tbx_batt_min";
            this.tbx_batt_min.Size = new System.Drawing.Size(81, 27);
            this.tbx_batt_min.TabIndex = 107;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Verdana", 12F);
            this.label17.Location = new System.Drawing.Point(19, 342);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(110, 18);
            this.label17.TabIndex = 106;
            this.label17.Text = "Battery_Max";
            // 
            // tbx_batt_max
            // 
            this.tbx_batt_max.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbx_batt_max.Location = new System.Drawing.Point(148, 333);
            this.tbx_batt_max.Name = "tbx_batt_max";
            this.tbx_batt_max.Size = new System.Drawing.Size(81, 27);
            this.tbx_batt_max.TabIndex = 105;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Verdana", 12F);
            this.label18.Location = new System.Drawing.Point(503, 20);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(129, 18);
            this.label18.TabIndex = 138;
            this.label18.Text = "PCB Feedback:";
            // 
            // btn_clr_pcb
            // 
            this.btn_clr_pcb.Font = new System.Drawing.Font("Verdana", 12F);
            this.btn_clr_pcb.ForeColor = System.Drawing.Color.Navy;
            this.btn_clr_pcb.Location = new System.Drawing.Point(803, 9);
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
            this.btn_ttl_send.Location = new System.Drawing.Point(822, 610);
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
            this.tbx_Pcb_feed_back.Location = new System.Drawing.Point(506, 39);
            this.tbx_Pcb_feed_back.Multiline = true;
            this.tbx_Pcb_feed_back.Name = "tbx_Pcb_feed_back";
            this.tbx_Pcb_feed_back.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbx_Pcb_feed_back.Size = new System.Drawing.Size(405, 567);
            this.tbx_Pcb_feed_back.TabIndex = 134;
            // 
            // tbx_ttl_send
            // 
            this.tbx_ttl_send.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbx_ttl_send.Location = new System.Drawing.Point(621, 610);
            this.tbx_ttl_send.Name = "tbx_ttl_send";
            this.tbx_ttl_send.Size = new System.Drawing.Size(195, 27);
            this.tbx_ttl_send.TabIndex = 133;
            this.tbx_ttl_send.Text = "#DUMP_DATA";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Verdana", 12F);
            this.label19.Location = new System.Drawing.Point(503, 614);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(112, 18);
            this.label19.TabIndex = 135;
            this.label19.Text = "PC Transmit:";
            // 
            // btn_clear_com
            // 
            this.btn_clear_com.Font = new System.Drawing.Font("Verdana", 12F);
            this.btn_clear_com.ForeColor = System.Drawing.Color.Navy;
            this.btn_clear_com.Location = new System.Drawing.Point(22, 501);
            this.btn_clear_com.Name = "btn_clear_com";
            this.btn_clear_com.Size = new System.Drawing.Size(423, 48);
            this.btn_clear_com.TabIndex = 139;
            this.btn_clear_com.Text = "Clear ComPort";
            this.btn_clear_com.UseVisualStyleBackColor = true;
            this.btn_clear_com.Click += new System.EventHandler(this.btn_clear_com_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(211)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(937, 713);
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
            this.Name = "Form1";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Form1_Load);
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
    }
}

