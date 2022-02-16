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

namespace FFT_DOSE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            GetPortInformation();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            serialPort1.PortName = "COM13";
            serialPort1.BaudRate = 9600;
            serialPort1.DataBits = 8;
            serialPort1.Parity = Parity.Even;
            serialPort1.StopBits = StopBits.One;
            try
            {
                serialPort1.Open();
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
                    serialPort1.Write(all_array, 0, all_array.Length);
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
                serialPort1.Write(all_array, 0, all_array.Length);
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
            serialPort1.Write(all_array, 0, all_array.Length);
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
    }
}

