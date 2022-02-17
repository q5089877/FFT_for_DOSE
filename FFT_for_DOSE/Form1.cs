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

namespace FFT_DOSE
{
    public partial class Form1 : Form
    {
        DBConn access_data;
        string str_ttl = "";
        MethodInvoker mi_pcb_feedback;
        public Form1()
        {
            InitializeComponent();
        }

        string PLC_COM = "";
        string POWER_COM = "";
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

                    //if (temp_item == "2" && Convert.ToUInt16(temp_select) > 0) // dose com
                    //{ cbx_dose.SelectedIndex = Convert.ToUInt16(temp_select); }

                    if (temp_item == "3" && Convert.ToUInt16(temp_select) > 0) // power com
                    {
                        cbx_power.SelectedIndex = Convert.ToUInt16(temp_select);
                        POWER_COM = cbx_power.SelectedItem.ToString();
                    }
                }
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
            cbx_dose.Items.Add("");
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
                    cbx_dose.Items.Add(name);
                    cbx_power.Items.Add(name);
                }
            }
            return string.Empty;
        }

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
                }
            }
            return string.Empty;
        }

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
                string strSQL = String.Format("UPDATE select_data set select_data ='" + cbx_power.SelectedIndex.ToString() + "'" + "where item = '3'");
                access_data.ExecuteSQL(strSQL);

                string com_name = cbx_power.SelectedItem.ToString();
                int int_start = com_name.IndexOf("(");
                int int_end = com_name.IndexOf(")");
                string com_num = com_name.Substring(int_start + 4, int_end - int_start - 4);
                // Set address
                string VISA_ADDRESS = "ASRL" + com_num + "::INSTR";

                // Create a connection (session) to the RS-232 device.                                 
                IMessageBasedSession session = GlobalResourceManager.Open(VISA_ADDRESS) as IMessageBasedSession;

                // Enable the Termination Character.                
                session.TerminationCharacterEnabled = true;


                // Connection parameters
                ISerialSession serial = session as ISerialSession;
                serial.BaudRate = 115200;
                serial.DataBits = 8;
                serial.Parity = Ivi.Visa.SerialParity.None;
                serial.FlowControl = SerialFlowControlModes.DtrDsr;

                // Send the *IDN? and read the response as strings
                MessageBasedFormattedIO formattedIO = new MessageBasedFormattedIO(session);
                //   formattedIO.WriteLine("MEASure:CURRent?");
                formattedIO.WriteLine("*IDN?");
                string idnResponse = formattedIO.ReadLine();

                Console.WriteLine("Current returned: {0}", idnResponse);

                Thread.Sleep(1000);


                formattedIO.WriteLine("OUTPut 0");
                formattedIO.WriteLine("OUTPut 0");
                //     idnResponse = formattedIO.ReadLine();

                Console.WriteLine("Current returned: {0}", idnResponse);

                Thread.Sleep(1000);

                formattedIO.WriteLine("OUTPut 1");
                formattedIO.WriteLine("OUTPut 1");
                //   idnResponse = formattedIO.ReadLine();

                Console.WriteLine("Current returned: {0}", idnResponse);

                Thread.Sleep(1000);

                formattedIO.WriteLine("MEASure:voltage?");
                idnResponse = formattedIO.ReadLine();

                Console.WriteLine("Current returned: {0}", idnResponse);

                // Close the connection to the instrument
                session.Dispose();
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
                GetPortInformation_for_DOSE_COM();
                str_ttl = "";

                string port_name = cbx_dose.SelectedItem.ToString();
                int int_left = port_name.ToString().IndexOf("(");
                int int_right = port_name.ToString().IndexOf(")");
                int int_length = int_right - int_left;
                string comport_num = port_name.ToString().Substring(int_left + 1, int_length - 1);
                RS232_DOSE.Close();
                RS232_DOSE.Dispose();
                RS232_DOSE.PortName = comport_num;
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
                str_ttl = str_ttl + in_data;
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
                string strSQL = String.Format("UPDATE select_data set select_data ='" + cbx_plc.SelectedIndex.ToString() + "'" + "where item = '1'");
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
            str_ttl = "";

            string port_name = cbx_dose.SelectedItem.ToString();
            int int_left = port_name.ToString().IndexOf("(");
            int int_right = port_name.ToString().IndexOf(")");
            int int_length = int_right - int_left;
            string comport_num = port_name.ToString().Substring(int_left + 1, int_length - 1);
            RS232_DOSE.Close();
            RS232_DOSE.Dispose();
            RS232_DOSE.PortName = comport_num;
            RS232_DOSE.Open();

            int delay_time = 100;

            byte[] UTF8bytes = Encoding.UTF8.GetBytes("#RE_ASS_MOUNTING" + Environment.NewLine);
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
            tbx_Pcb_feed_back.AppendText(str_ttl + Environment.NewLine);
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
                if( key ==  null)
                {
                    string aa = "";
                }
                else
                {
                    key.DeleteValue("COM6");
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
    }
}
