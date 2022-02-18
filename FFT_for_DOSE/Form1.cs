using Ivi.Visa;
using Ivi.Visa.FormattedIO;
using Ivi.Visa.Interop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Management;
using Microsoft.Win32;
using System.Windows.Forms.DataVisualization.Charting;

namespace FFT_DOSE
{
    public partial class Form1 : Form
    {
        static double chart_MAX = 250;
        static int int_interval = 300;
        string str_Response = "";
        bool Send_ASS_CHECK = true;
        DBConn access_data;
        string str_rece_dose = "";
        MethodInvoker mi_pcb_feedback;

        //POWER
        IMessageBasedSession session;
        MessageBasedFormattedIO formattedIO;

        //Chart
        private System.Windows.Forms.Timer timerRealTimeData;
        private Random random = new Random();
        private int pointIndex = 0;
        Chart chart1 = new RealtimeChart().GetChart;
        int[] int_curr_value = new int[] { 7200 };
        public Form1()
        {
            InitializeComponent();
        }

        string PLC_COM = "";
        string POWER_COM = "";
        string DOSE_COM = "";
        private void Form1_Load(object sender, EventArgs e)
        {
            mi_pcb_feedback = new MethodInvoker(Update_pcb_feedback);
            GetPortInformation();

            access_data = new DBConn();

            //初始化上一次選擇
            #region get save data
            string strSQL = String.Format("select * from save_data'");
            DataTable dt = access_data.ExecuteTable(strSQL);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string temp_item = dt.Rows[i][1].ToString();
                string temp_num = dt.Rows[i][2].ToString();
                if (temp_item == "Mouse_X_Max")
                { tbx_mouse_x_max.Text = temp_num; }
                if (temp_item == "Mouse_X_Min")
                { tbx_mouse_x_min.Text = temp_num; }
                if (temp_item == "Mouse_Y_Max")
                { tbx_mouse_y_max.Text = temp_num; }
                if (temp_item == "Mouse_Y_Min")
                { tbx_mouse_y_min.Text = temp_num; }

                if (temp_item == "Shutter_Max")
                { tbx_shutter_max.Text = temp_num; }
                if (temp_item == "Shutter_Min")
                { tbx_shutter_min.Text = temp_num; }
                if (temp_item == "Frame_Max")
                { tbx_frame_max.Text = temp_num; }
                if (temp_item == "Frame_Min")
                { tbx_frame_min.Text = temp_num; }

                if (temp_item == "IQ_Max")
                { tbx_iq_max.Text = temp_num; }
                if (temp_item == "IQ_Min")
                { tbx_iq_min.Text = temp_num; }
                if (temp_item == "IR_Max")
                { tbx_ir_max.Text = temp_num; }
                if (temp_item == "IR_Min")
                { tbx_ir_min.Text = temp_num; }

                if (temp_item == "Battery_Max")
                { tbx_batt_max.Text = temp_num; }
                if (temp_item == "Battery_Min")
                { tbx_batt_min.Text = temp_num; }
            }
            #endregion

            #region get select data
            try
            {
                strSQL = "select * from select_data";
                DataSet ds = new DataSet();
                DataTable dt_select_data;
                ds = access_data.ExecuteDataSet(strSQL);
                dt_select_data = ds.Tables[0];
                for (int i = 0; i < dt_select_data.Rows.Count; i++)
                {
                    string temp_select = dt_select_data.Rows[i][1].ToString();
                    string temp_item = dt_select_data.Rows[i][2].ToString();
                    if (temp_item == "1" && Convert.ToUInt16(temp_select) > 0) // plc com
                    {
                        cbx_plc.SelectedIndex = Convert.ToUInt16(temp_select);
                        PLC_COM = cbx_plc.SelectedItem.ToString();
                    }

                    if (temp_item == "3" && Convert.ToUInt16(temp_select) > 0) // power com
                    {
                        cbx_power.SelectedIndex = Convert.ToUInt16(temp_select);
                        POWER_COM = cbx_power.SelectedItem.ToString();
                    }
                }

                this.Controls.Add(chart1);
                //Chart
                timerRealTimeData = new System.Windows.Forms.Timer();
                timerRealTimeData.Enabled = true;
                timerRealTimeData.Interval = int_interval;
                timerRealTimeData.Tick += new System.EventHandler(this.timerRealTimeData_Tick);
                int_curr_value[0] = 150;
            }
            catch (Exception ex2)
            {
                MessageBox.Show("An error has occurred. Please check the COM PORT or other problems.");
            }
            #endregion
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RS232_PLC.PortName = "COM13";
            RS232_PLC.BaudRate = 9600;
            RS232_PLC.DataBits = 8;
            RS232_PLC.Parity = Parity.Even;
            RS232_PLC.StopBits = StopBits.One;
            try
            {
                RS232_PLC.Open();
                //  timer1.Enabled = true;
                MessageBox.Show("打开端口");
            }
            catch (Exception ea)
            {
                MessageBox.Show("打开端口错误");
            }

        }

        /// <summary>
        /// 低字节在前
        /// </summary>
        /// <param name="pDataBytes"></param>
        /// <returns></returns>
        static byte[] CRC16LH(byte[] pDataBytes)
        {
            ushort crc = 0xffff;
            ushort polynom = 0xA001;

            for (int i = 0; i < pDataBytes.Length; i++)
            {
                crc ^= pDataBytes[i];
                for (int j = 0; j < 8; j++)
                {
                    if ((crc & 0x01) == 0x01)
                    {
                        crc >>= 1;
                        crc ^= polynom;
                    }
                    else
                    {
                        crc >>= 1;
                    }
                }
            }

            byte[] result = BitConverter.GetBytes(crc);
            return result;
        }

        /// <summary>
        /// 高字节在前
        /// </summary>
        /// <param name="pDataBytes"></param>
        /// <returns></returns>
        static byte[] CRC16HL(byte[] pDataBytes)
        {
            ushort crc = 0xffff;
            ushort polynom = 0xA001;

            for (int i = 0; i < pDataBytes.Length; i++)
            {
                crc ^= pDataBytes[i];
                for (int j = 0; j < 8; j++)
                {
                    if ((crc & 0x01) == 0x01)
                    {
                        crc >>= 1;
                        crc ^= polynom;
                    }
                    else
                    {
                        crc >>= 1;
                    }
                }
            }

            byte[] result = BitConverter.GetBytes(crc).Reverse().ToArray();
            return result;
        }



        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] in_data;
            SerialPort sp = (SerialPort)sender;
            Thread.Sleep(50);


            int bytes = sp.BytesToRead;
            byte[] buffer = new byte[bytes];
            sp.Read(buffer, 0, bytes);

            //Console.WriteLine(in_data);

            if (buffer.Length > 3)
            {
                if (buffer[1] == 1 && buffer[3] == 2)
                {
                    List<byte> list = new List<byte>();
                    list.Add(0x01);
                    list.Add(0x05);
                    list.Add(0x08);
                    list.Add(0x02);
                    list.Add(0xFF);
                    list.Add(0x00);
                    byte[] array = list.ToArray();
                    byte[] Crc_data = CRC16LH(array);
                    list.Add(Crc_data[0]);
                    list.Add(Crc_data[1]);
                    byte[] all_array = list.ToArray();
                    RS232_PLC.Write(all_array, 0, all_array.Length);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                List<byte> list = new List<byte>();
                list.Add(0x01);
                list.Add(0x05);
                list.Add(0x08);
                list.Add(0x02);
                list.Add(0xFF);
                list.Add(0x00);
                byte[] array = list.ToArray();
                byte[] Crc_data = CRC16LH(array);
                list.Add(Crc_data[0]);
                list.Add(Crc_data[1]);
                byte[] all_array = list.ToArray();
                RS232_PLC.Write(all_array, 0, all_array.Length);
            }
            catch
            {
                MessageBox.Show("Com Port Error!!");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            List<byte> list = new List<byte>();
            list.Add(0x01);
            list.Add(0x01);
            list.Add(0x08);
            list.Add(0x02);
            list.Add(0x00);
            list.Add(0x01);
            byte[] array = list.ToArray();
            byte[] Crc_data = CRC16LH(array);
            list.Add(Crc_data[0]);
            list.Add(Crc_data[1]);
            byte[] all_array = list.ToArray();
            RS232_PLC.Write(all_array, 0, all_array.Length);
        }

        public string GetPortInformation()
        {
            cbx_plc.Items.Add("");
            cbx_power.Items.Add("");

            ManagementClass processClass = new ManagementClass("Win32_PnPEntity");
            ManagementObjectCollection Ports = processClass.GetInstances();
            foreach (ManagementObject property in Ports)
            {
                var name = property.GetPropertyValue("Name");
                if (name != null && name.ToString().Contains("USB") && name.ToString().Contains("COM"))
                {
                    var portInfo = new SerialPortInfo(property);
                    //Thats all information i got from port.
                    //Do whatever you want with this information   
                    cbx_plc.Items.Add(name);
                    cbx_power.Items.Add(name);
                }
            }
            return string.Empty;
        }

        #region Get DOSE COM
        public string GetPortInformation_for_DOSE_COM()
        {
            ManagementClass processClass = new ManagementClass("Win32_PnPEntity");
            ManagementObjectCollection Ports = processClass.GetInstances();
            foreach (ManagementObject property in Ports)
            {
                var name = property.GetPropertyValue("Name");
                if (name != null && name.ToString().Contains("USB") && name.ToString().Contains("COM"))
                {
                    var portInfo = new SerialPortInfo(property);
                    if (name.ToString().Contains("USB Serial Port"))
                    {
                        int str_length = name.ToString().Length;
                        string dose_com = name.ToString().Substring(17, str_length - 18);
                        return dose_com;
                    }
                }
            }
            return "NO COM";
        }
        #endregion

        #region Hide Code by PLC
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    List<byte> list = new List<byte>();
        //    list.Add(0x01);
        //    list.Add(0x0F);
        //    list.Add(0x05);
        //    list.Add(0x00);
        //    list.Add(0x00);
        //    list.Add(0x04);
        //    list.Add(0x01);
        //    list.Add(0x07);
        //    //byte[] list = new byte[] { 0x01, 0x0F, 0x05, 0x00, 0x00, 0x04, 0x01, 0x07};
        //    byte[] array = list.ToArray();
        //    byte[] Crc_data = CRC16LH(array);
        //    //   byte[] Set_data = new byte[] { 0x01, 0x0F, 0x05, 0x00, 0x00, 0x04, 0x01, 0x07 };

        //    list.Add(Crc_data[0]);
        //    list.Add(Crc_data[1]);
        //    byte[] all_array = list.ToArray();
        //    serialPort1.Write(all_array, 0, all_array.Length);
        //}

        //private void button3_Click(object sender, EventArgs e)
        //{
        //    List<byte> list = new List<byte>();
        //    list.Add(0x01);
        //    list.Add(0x0F);
        //    list.Add(0x05);
        //    list.Add(0x00);
        //    list.Add(0x00);
        //    list.Add(0x04);
        //    list.Add(0x01);
        //    list.Add(0x00);
        //    //byte[] list = new byte[] { 0x01, 0x0F, 0x05, 0x00, 0x00, 0x04, 0x01, 0x07};
        //    byte[] array = list.ToArray();
        //    byte[] Crc_data = CRC16LH(array);
        //    //   byte[] Set_data = new byte[] { 0x01, 0x0F, 0x05, 0x00, 0x00, 0x04, 0x01, 0x07 };

        //    list.Add(Crc_data[0]);
        //    list.Add(Crc_data[1]);
        //    byte[] all_array = list.ToArray();
        //    serialPort1.Write(all_array, 0, all_array.Length);
        //}

        //private void button4_Click(object sender, EventArgs e)
        //{
        //    List<byte> list = new List<byte>();
        //    list.Add(0x01);
        //    list.Add(0x05);
        //    list.Add(0x05);
        //    list.Add(0x00);
        //    list.Add(0xFF);
        //    list.Add(0x00);
        //    byte[] array = list.ToArray();
        //    byte[] Crc_data = CRC16LH(array);
        //    list.Add(Crc_data[0]);
        //    list.Add(Crc_data[1]);
        //    byte[] all_array = list.ToArray();
        //    serialPort1.Write(all_array, 0, all_array.Length);
        //}

        //private void button5_Click(object sender, EventArgs e)
        //{
        //    List<byte> list = new List<byte>();
        //    list.Add(0x01);
        //    list.Add(0x05);
        //    list.Add(0x05);
        //    list.Add(0x00);
        //    list.Add(0x00);
        //    list.Add(0x00);
        //    byte[] array = list.ToArray();
        //    byte[] Crc_data = CRC16LH(array);
        //    list.Add(Crc_data[0]);
        //    list.Add(Crc_data[1]);
        //    byte[] all_array = list.ToArray();
        //    serialPort1.Write(all_array, 0, all_array.Length);
        //}
        #endregion

        private void cbx_power_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string strSQL = String.Format("UPDATE select_data set select_data ='" + cbx_power.SelectedIndex.ToString() + "' " + "where com = '3'");
                access_data.ExecuteSQL(strSQL);

                strSQL = String.Format("UPDATE select_data set com_name ='" + cbx_power.SelectedItem.ToString() + "' " + "where com = '3'");
                access_data.ExecuteSQL(strSQL);

                string com_name = cbx_power.SelectedItem.ToString();
                int int_start = com_name.IndexOf("(");
                int int_end = com_name.IndexOf(")");
                string com_num = com_name.Substring(int_start + 4, int_end - int_start - 4);
                // Set address
                string VISA_ADDRESS = "ASRL" + com_num + "::INSTR";

                // Create a connection (session) to the RS-232 device.                                 
                session = GlobalResourceManager.Open(VISA_ADDRESS) as IMessageBasedSession;

                // Enable the Termination Character.                
                session.TerminationCharacterEnabled = true;


                // Connection parameters
                ISerialSession serial = session as ISerialSession;
                serial.BaudRate = 115200;
                serial.DataBits = 8;
                serial.Parity = Ivi.Visa.SerialParity.None;
                serial.FlowControl = SerialFlowControlModes.DtrDsr;

                // Send the *IDN? and read the response as strings
                formattedIO = new MessageBasedFormattedIO(session);
                //   formattedIO.WriteLine("MEASure:CURRent?");
                formattedIO.WriteLine("*IDN?");
                string idnResponse = formattedIO.ReadLine();

                Console.WriteLine("Current returned: {0}", idnResponse);

                Thread.Sleep(1000);


                formattedIO.WriteLine("OUTPut 0");
                formattedIO.WriteLine("OUTPut 0");
                //     idnResponse = formattedIO.ReadLine();

                Console.WriteLine("Current returned: {0}", idnResponse);

                Thread.Sleep(100);

                formattedIO.WriteLine("OUTPut 1");
                formattedIO.WriteLine("OUTPut 1");
                //   idnResponse = formattedIO.ReadLine();

                Console.WriteLine("Current returned: {0}", idnResponse);

                Thread.Sleep(100);

                formattedIO.WriteLine("MEASure:voltage?");
                idnResponse = formattedIO.ReadLine();

                Console.WriteLine("Current returned: {0}", idnResponse);

                formattedIO.WriteLine("VOLTage 5.00");
                Thread.Sleep(100);

                formattedIO.WriteLine("SYST:REM");
                Thread.Sleep(100);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show("COM port selection error!!");
            }
        }



        //更新Firmware Threshold & Database
        private void btn_set_th_Click(object sender, EventArgs e)
        {
            try
            {
                str_rece_dose = "";

                RS232_DOSE.Close();
                RS232_DOSE.Dispose();
                RS232_DOSE.PortName = GetPortInformation_for_DOSE_COM();
                RS232_DOSE.Open();

                int delay_time = 100;
                string strSQL;
                byte[] UTF8bytes = Encoding.UTF8.GetBytes("#SET_ASS_TH" + Environment.NewLine);
                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                Thread.Sleep(1000);

                UTF8bytes = Encoding.UTF8.GetBytes("Mouse_X_Max:" + tbx_mouse_x_max.Text + "\0" + Environment.NewLine);
                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                Thread.Sleep(delay_time);

                strSQL = String.Format("UPDATE save_data set num ='" + tbx_mouse_x_max.Text + "'" + "where item = 'Mouse_X_Max'");
                access_data.ExecuteSQL(strSQL);

                UTF8bytes = Encoding.UTF8.GetBytes("Mouse_X_Min:" + tbx_mouse_x_min.Text + "\0" + Environment.NewLine);
                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                Thread.Sleep(delay_time);

                strSQL = String.Format("UPDATE save_data set num ='" + tbx_mouse_x_min.Text + "'" + "where item = 'Mouse_X_Min'");
                access_data.ExecuteSQL(strSQL);

                UTF8bytes = Encoding.UTF8.GetBytes("Mouse_Y_Max:" + tbx_mouse_y_max.Text + "\0" + Environment.NewLine);
                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                Thread.Sleep(delay_time);

                strSQL = String.Format("UPDATE save_data set num ='" + tbx_mouse_y_max.Text + "'" + "where item = 'Mouse_Y_Max'");
                access_data.ExecuteSQL(strSQL);

                UTF8bytes = Encoding.UTF8.GetBytes("Mouse_Y_Min:" + tbx_mouse_y_min.Text + "\0" + Environment.NewLine);
                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                Thread.Sleep(delay_time);

                strSQL = String.Format("UPDATE save_data set num ='" + tbx_mouse_y_min.Text + "'" + "where item = 'Mouse_y_Min'");
                access_data.ExecuteSQL(strSQL);

                UTF8bytes = Encoding.UTF8.GetBytes("Shutter_Max:" + tbx_shutter_max.Text + "\0" + Environment.NewLine);
                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                Thread.Sleep(delay_time);

                strSQL = String.Format("UPDATE save_data set num ='" + tbx_shutter_max.Text + "'" + "where item = 'Shutter_Max'");
                access_data.ExecuteSQL(strSQL);

                UTF8bytes = Encoding.UTF8.GetBytes("Shutter_Min:" + tbx_shutter_min.Text + "\0" + Environment.NewLine);
                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                Thread.Sleep(delay_time);

                strSQL = String.Format("UPDATE save_data set num ='" + tbx_shutter_min.Text + "'" + "where item = 'Shutter_Min'");
                access_data.ExecuteSQL(strSQL);

                UTF8bytes = Encoding.UTF8.GetBytes("Frame_Max:" + tbx_frame_max.Text + "\0" + Environment.NewLine);
                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                Thread.Sleep(delay_time);

                strSQL = String.Format("UPDATE save_data set num ='" + tbx_frame_max.Text + "'" + "where item = 'frame_Max'");
                access_data.ExecuteSQL(strSQL);

                UTF8bytes = Encoding.UTF8.GetBytes("Frame_Min:" + tbx_frame_min.Text + "\0" + Environment.NewLine);
                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                Thread.Sleep(delay_time);

                strSQL = String.Format("UPDATE save_data set num ='" + tbx_frame_min.Text + "'" + "where item = 'frame_Min'");
                access_data.ExecuteSQL(strSQL);

                UTF8bytes = Encoding.UTF8.GetBytes("IQ_Max:" + tbx_iq_max.Text + "\0" + Environment.NewLine);
                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                Thread.Sleep(delay_time);

                strSQL = String.Format("UPDATE save_data set num ='" + tbx_iq_max.Text + "'" + "where item = 'IQ_Max'");
                access_data.ExecuteSQL(strSQL);

                UTF8bytes = Encoding.UTF8.GetBytes("IQ_Min:" + tbx_iq_min.Text + "\0" + Environment.NewLine);
                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                Thread.Sleep(delay_time);

                strSQL = String.Format("UPDATE save_data set num ='" + tbx_iq_min.Text + "'" + "where item = 'IQ_Min'");
                access_data.ExecuteSQL(strSQL);

                UTF8bytes = Encoding.UTF8.GetBytes("IR_Max:" + tbx_ir_max.Text + "\0" + Environment.NewLine);
                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                Thread.Sleep(delay_time);

                strSQL = String.Format("UPDATE save_data set num ='" + tbx_ir_max.Text + "'" + "where item = 'IR_Max'");
                access_data.ExecuteSQL(strSQL);

                UTF8bytes = Encoding.UTF8.GetBytes("IR_Min:" + tbx_ir_min.Text + "\0" + Environment.NewLine);
                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                Thread.Sleep(delay_time);

                strSQL = String.Format("UPDATE save_data set num ='" + tbx_ir_min.Text + "'" + "where item = 'IR_Min'");
                access_data.ExecuteSQL(strSQL);




                UTF8bytes = Encoding.UTF8.GetBytes("Battery_Max:" + tbx_batt_max.Text + "\0" + Environment.NewLine);
                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                Thread.Sleep(delay_time);

                strSQL = String.Format("UPDATE save_data set num ='" + tbx_batt_max.Text + "'" + "where item = 'Battery_Max'");
                access_data.ExecuteSQL(strSQL);




                UTF8bytes = Encoding.UTF8.GetBytes("Battery_Min:" + tbx_batt_min.Text + "\0" + Environment.NewLine);
                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                Thread.Sleep(delay_time);

                strSQL = String.Format("UPDATE save_data set num ='" + tbx_batt_min.Text + "'" + "where item = 'Battery_Min'");
                access_data.ExecuteSQL(strSQL);





                UTF8bytes = Encoding.UTF8.GetBytes("#ASS_TH_END" + Environment.NewLine);
                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                MessageBox.Show("SET COMPLETED.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void RS232_DOSE_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string in_data = "";
            SerialPort sp = (SerialPort)sender;
            Thread.Sleep(50);
            in_data = sp.ReadExisting();
            sp.DiscardInBuffer();
            if (in_data.Length > 3)
            {
                Console.WriteLine(in_data);
                str_rece_dose = str_rece_dose + in_data;
                this.BeginInvoke(mi_pcb_feedback, null);
            }
        }

        private void cbx_dose_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string strSQL = String.Format("UPDATE select_data set select_data ='" + cbx_dose.SelectedIndex.ToString() + "'" + "where item = '2'");
                access_data.ExecuteSQL(strSQL);

                string port_name = cbx_dose.SelectedItem.ToString();
                int int_left = port_name.ToString().IndexOf("(");
                int int_right = port_name.ToString().IndexOf(")");
                int int_length = int_right - int_left;
                string comport_num = port_name.ToString().Substring(int_left + 1, int_length - 1);
                // string com_name2 = port_name.ToString().Substring(0, int_left);


                RS232_DOSE.Close();
                RS232_DOSE.Dispose();
                RS232_DOSE.PortName = comport_num;
                RS232_DOSE.Open();
            }
            catch
            {
                //    MessageBox.Show("TTL COM port error, please select another COM port\r\nRS232轉TTL串列埠錯誤，請選擇其它埠");
                RS232_DOSE.Close();
                RS232_DOSE.Dispose();
            }
        }

        private void cbx_plc_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string strSQL = String.Format("UPDATE select_data set select_data ='" + cbx_plc.SelectedIndex.ToString() + "' " + "where com = '1'");
                access_data.ExecuteSQL(strSQL);

                strSQL = String.Format("UPDATE select_data set com_name ='" + cbx_plc.SelectedItem.ToString() + "' " + "where com = '1'");
                access_data.ExecuteSQL(strSQL);

                string port_name = cbx_plc.SelectedItem.ToString();
                int int_left = port_name.ToString().IndexOf("(");
                int int_right = port_name.ToString().IndexOf(")");
                int int_length = int_right - int_left;
                string comport_num = port_name.ToString().Substring(int_left + 1, int_length - 1);

                RS232_PLC.Close();
                RS232_PLC.Dispose();
                RS232_PLC.PortName = comport_num;
                RS232_PLC.Open();
                RS232_PLC.BaudRate = 9600;
                RS232_PLC.DataBits = 8;
                RS232_PLC.Parity = Parity.Even;
                RS232_PLC.StopBits = StopBits.One;
            }
            catch (Exception ex)
            {
                //   MessageBox.Show(ex.ToString());
                RS232_PLC.Close();
                RS232_PLC.Dispose();
            }
        }

        private void btn_ass_chk_Click(object sender, EventArgs e)
        {
            //#RE_ASS_MOUNTING
            //#ASS_CHECK
            //#ASS_MOUNTING
            //#ASS_START
            //........
            //#ASS_STOP

            str_rece_dose = "";

            ////Open Power
            //formattedIO.WriteLine("OUTPut 1");
            //Console.WriteLine("Current returned: {0}", str_Response);
            //Thread.Sleep(2000);

            RS232_DOSE.Close();
            RS232_DOSE.Dispose();
            RS232_DOSE.PortName = GetPortInformation_for_DOSE_COM();
            RS232_DOSE.Open();

            int delay_time = 100;

            byte[] UTF8bytes = Encoding.UTF8.GetBytes("#RETEST" + Environment.NewLine);
            RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
            Thread.Sleep(delay_time);

            UTF8bytes = Encoding.UTF8.GetBytes("#RE_ASS_MOUNTING" + Environment.NewLine);
            RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
            Thread.Sleep(delay_time);

            UTF8bytes = Encoding.UTF8.GetBytes("#ASS_CHECK" + Environment.NewLine);
            RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
            Thread.Sleep(500);

            UTF8bytes = Encoding.UTF8.GetBytes("#ASS_MOUNTING" + Environment.NewLine);
            RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
            Thread.Sleep(delay_time);

            UTF8bytes = Encoding.UTF8.GetBytes("#ASS_START" + Environment.NewLine);
            RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
            Thread.Sleep(delay_time);

            #region 移動PLC
            try
            {
                List<byte> list = new List<byte>();
                list.Add(0x01);
                list.Add(0x05);
                list.Add(0x08);
                list.Add(0x02);
                list.Add(0xFF);
                list.Add(0x00);
                byte[] array = list.ToArray();
                byte[] Crc_data = CRC16LH(array);
                list.Add(Crc_data[0]);
                list.Add(Crc_data[1]);
                byte[] all_array = list.ToArray();
                RS232_PLC.Write(all_array, 0, all_array.Length);
            }
            catch
            {
                MessageBox.Show("PLC Com Port Error!!");
            }
            #endregion

            //#ASS_STOP?
        }

        private void btn_ttl_send_Click(object sender, EventArgs e)
        {
            try
            {
                // mi_pcb_feedback = new MethodInvoker(Update_pcb_feedback);
                byte[] UTF8bytes = Encoding.UTF8.GetBytes(tbx_ttl_send.Text + Environment.NewLine);
                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                Thread.Sleep(50);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ComPort Error!");
            }
        }

        void Update_pcb_feedback()
        {
            tbx_Pcb_feed_back.AppendText(str_rece_dose + Environment.NewLine);
        }

        private void btn_clr_pcb_Click(object sender, EventArgs e)
        {
            tbx_Pcb_feed_back.Text = "";
        }

        private void btn_clear_com_Click(object sender, EventArgs e)
        {
            ComClear();
        }

        #region Com Clear
        private void ComClear()
        {
            /* Start COM Clear */

            string userRoot = "HKEY_LOCAL_MACHINE";
            string subkey = "SYSTEM\\CurrentControlSet\\Control\\COM Name Arbiter\\Devices";
            string keyName = userRoot + "\\" + subkey;

            // RegistryKey key = Registry.LocalMachine.OpenSubKey(subkey);
            //byte[] Data = (byte[])key.GetValue("ComDB");

            //byte[] ImportData = { 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 
            //    00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00 };

            //Registry.SetValue(keyName, "ComDB", ImportData, RegistryValueKind.Binary);
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(subkey, true))
            {
                if (key == null)
                {
                    string aa = "";
                }
                else
                {
                    //  key.DeleteValue("COM6");
                    //  key.DeleteSubKey("COM6");
                }
            }

            /* End COM Clear */

            //string keyName = @"Software\Microsoft\Windows\CurrentVersion\Run";
            //using (RegistryKey key = Registry.CurrentUser.OpenSubKey(keyName, true))
            //{
            //    if (key == null)
            //    {
            //        // Key doesn't exist. Do whatever you want to handle
            //        // this case
            //    }
            //    else
            //    {
            //        key.DeleteValue("MyApp");
            //    }
            //}
        }
        #endregion

        // Define some variables
        int numberOfPointsInChart = 30;
        int newX = 0;

        private void timerRealTimeData_Tick(object sender, EventArgs e)
        {
            try
            {
                //從POWER取得電流

                formattedIO.WriteLine("MEASure:current?");
                string Curr_Response = formattedIO.ReadLine();
                //轉為數字
                try
                {
                    int int_curr = Convert.ToInt32(Curr_Response.Substring(2, 3));
                    int_curr = int_curr - 13;
                    if (int_curr < 0)
                    {
                        int_curr = 0;
                    }
                    int_curr_value[0] = int_curr;
                    //依電流主動變化畫面高度
                    if (int_curr < 49)
                    {
                        chart1.ChartAreas[0].AxisY.Maximum = 50;
                    }
                    else if (int_curr <= 99)
                    {
                        chart1.ChartAreas[0].AxisY.Maximum = 100;
                    }
                    else if (int_curr <= 149)
                    {
                        chart1.ChartAreas[0].AxisY.Maximum = 150;
                    }
                    else if (int_curr <= 199)
                    {
                        chart1.ChartAreas[0].AxisY.Maximum = 200;
                    }
                    else if (int_curr <= 249)
                    {
                        chart1.ChartAreas[0].AxisY.Maximum = 250;
                    }
                    else if (int_curr <= 299)
                    {
                        chart1.ChartAreas[0].AxisY.Maximum = 300;
                    }
                    else
                    {
                        chart1.ChartAreas[0].AxisY.Maximum = 1000;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                // Simulate adding new data points           
                newX = pointIndex + 1;
                //  int newY = random.Next(0, 5000);

                //Chart---------------------------------------------------------------------------------------------------------------------
                int newY = int_curr_value[0];
                chart1.Series[0].Points.AddXY(newX, newY);
                ++pointIndex;

                // Adjust Y & X axis scale
                chart1.ResetAutoValues();
                if (chart1.ChartAreas["Default"].AxisX.Maximum < pointIndex)
                {
                    chart1.ChartAreas["Default"].AxisX.Maximum = pointIndex;
                }

                // Keep a constant number of points by removing them from the left
                while (chart1.Series[0].Points.Count > numberOfPointsInChart)
                {
                    // Remove data points on the left side
                    //   while (chart1.Series[0].Points.Count > numberOfPointsAfterRemoval)
                    {
                        chart1.Series[0].Points.RemoveAt(0);
                    }
                    // Adjust X axis scale
                    double _min = pointIndex - numberOfPointsInChart;
                    double _max = chart1.ChartAreas["Default"].AxisX.Minimum + numberOfPointsInChart;
                    chart1.ChartAreas["Default"].AxisX.Minimum = pointIndex - numberOfPointsInChart;
                    chart1.ChartAreas["Default"].AxisX.Maximum = chart1.ChartAreas["Default"].AxisX.Minimum + numberOfPointsInChart;
                }
            }
            catch (Exception ex)
            {
                timerRealTimeData.Stop();
                MessageBox.Show(ex.ToString());

            }
        }

        public class RealtimeChart
        {
            private Chart _chart = null;
            private int chartWidth = 748;
            private int chartHeight = 628;
            public string nameAxisX = "Counter";
            private string nameAxisY = "Charging Current (mA)";

            public RealtimeChart()
            {
                _chart = new Chart();

                ChartArea ctArea = new ChartArea();
                Legend legend = new Legend();
                Series series = new Series();

                _chart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(223)))), ((int)(((byte)(193)))));
                _chart.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
                _chart.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(64)))), ((int)(((byte)(1)))));
                _chart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
                _chart.BorderlineWidth = 2;
                _chart.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.None;
                _chart.Location = new System.Drawing.Point(885, 10);
                _chart.Name = "chart1";
                _chart.Size = new System.Drawing.Size(chartWidth, chartHeight);
                _chart.TabIndex = 1;
                //  _chart.Dock = System.Windows.Forms.DockStyle.Fill;

                ctArea.Area3DStyle.Inclination = 15;
                ctArea.Area3DStyle.IsClustered = true;
                ctArea.Area3DStyle.IsRightAngleAxes = false;
                ctArea.Area3DStyle.Perspective = 50;
                ctArea.Area3DStyle.Rotation = 10;
                ctArea.Area3DStyle.WallWidth = 0;
                ctArea.AxisX.IsLabelAutoFit = false;
                ctArea.AxisX.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
                ctArea.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
                ctArea.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
                ctArea.AxisX.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
                ctArea.AxisX.Title = nameAxisX;

                //控制point間隔
                ctArea.AxisX.Interval = 1;

                ctArea.AxisY.IsLabelAutoFit = false;
                ctArea.AxisY.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
                ctArea.AxisY.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
                ctArea.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
                ctArea.AxisY.Maximum = chart_MAX;
                ctArea.AxisY.Minimum = 0D;
                ctArea.AxisY.Title = nameAxisY;
                ctArea.BackColor = System.Drawing.Color.OldLace;
                ctArea.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
                ctArea.BackSecondaryColor = System.Drawing.Color.White;
                ctArea.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
                ctArea.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
                ctArea.Name = "Default";
                ctArea.ShadowColor = System.Drawing.Color.Transparent;
                _chart.ChartAreas.Add(ctArea);

                legend.BackColor = System.Drawing.Color.Transparent;
                legend.Enabled = false;
                legend.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
                legend.IsTextAutoFit = false;
                legend.Name = "Default";
                _chart.Legends.Add(legend);

                series.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
                series.ChartArea = "Default";
                series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;


                series.Legend = "Default";
                series.Name = "Default";
                _chart.Series.Add(series);

                //修改粗細
                _chart.Series[0].BorderWidth = 3;

                //改修字型大小
                _chart.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12);
                _chart.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12);
            }

            public Chart GetChart
            {
                get { return _chart; }
            }


        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            session.Dispose();
        }


        private void timer_chk_COM_Tick(object sender, EventArgs e)
        {
            //利用COM的變化，剛取得DOSE的COM時, 主動送出ASS_CHECK
            //DOSE_COM = GetPortInformation_for_DOSE_COM();
            //if (Send_ASS_CHECK && DOSE_COM != "NO COM")
            //{
            //    Send_ASS_CHECK = false;
               
            //    RS232_DOSE.Close();
            //    RS232_DOSE.Dispose();
            //    RS232_DOSE.PortName = DOSE_COM;
            //    RS232_DOSE.Open();

            //    int delay_time = 100;

            //    byte[] UTF8bytes = Encoding.UTF8.GetBytes("#RETEST" + Environment.NewLine);
            //    RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
            //    Thread.Sleep(delay_time);

            //    UTF8bytes = Encoding.UTF8.GetBytes("#RE_ASS_MOUNTING" + Environment.NewLine);
            //    RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
            //    Thread.Sleep(delay_time);

            //    UTF8bytes = Encoding.UTF8.GetBytes("#ASS_CHECK" + Environment.NewLine);
            //    RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
            //    Thread.Sleep(300);

            //    UTF8bytes = Encoding.UTF8.GetBytes("#ASS_MOUNTING" + Environment.NewLine);
            //    RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
            //  //  Thread.Sleep(3000);
            //}
        }
    }
}
