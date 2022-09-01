﻿using Ivi.Visa;
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
using System.Data.OleDb;
using FFT_For_DOSE;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace FFT_DOSE
{
    public partial class Form1 : Form
    {
        int batteryFullCurr = 150; //判斷充電電流是否小於此
        #region SN
        int SnLength = 3; //SN字串長度;
        int intNextSn; //現在要製作的SN, 數字型別
        string strNextSn = ""; //現在要製作的SN, 字串型別
        string leftSN = ""; //SN前綴;
        string rightSN = ""; //SN後綴;
        #endregion
        string StrSleeveName; //Sleeve名稱
        bool checkSTATUSEnd = false; //用來決定是否可以開始判斷測試完成
        string assCheck = ""; //此字串用來判斷FFT結果 Pass or Fail      

        printLabel printLabel1; //建立公用label元件
        int FFTCurr = 0;
        byte[] UTF8bytes;
        // Define some variables
        int numberOfPointsInChart = 30;
        int newX = 0;
        int charge_max = 0;

        //參數用
        string batchNum = "", pcbVer = "", housingVer = "", deviceID = "", bleName = "", fwVersion = "", sleeveName = "", buildDate = ""
             , accXmax = "2000", accXmin = "-2000", accYmax = "2000", accYmin = "-2000", accZmax = "2000", accZmin = "-2000"
        , gyroXmax = "", gyroXmin = "", gyroYmax = "", gyroYmin = "", gyroZmax = "", gyroZmin = "", mouseXmax = "", mouseXmin = "", mouseYmax = "", mouseYmin = "", mouseSmax = ""
        , mouseSmin = "", mouseFmax = "", mouseFmin = "", mouseImax = "", mouseImin = "", IRmax = "", IRmin = "", batterymax = "", batterymin = "", mountingSwitch = "";

        public bool showLogForm { get; set; }

        MethodInvoker miCreateMaxSN;
        AccessHelper accessHelper = new AccessHelper();
        string strSQL;
        static double chart_MAX = 250;
        static int int_interval = 300;

        bool CheckShipping = false;
        // DBConn access_data;
        string strFeedbackDose = "";
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
        int delay_time2 = 100;

        //流程控制
        bool boolMountingSwitch = false;
        bool boolAssCheck = false;
        bool boolDeviceReceive = false;
        public Form1()
        {
            InitializeComponent();
        }

        string PLC_COM = "";
        string POWER_COM = "";
        string DOSE_COM = "";


        private void Form1_Load(object sender, EventArgs e)
        {
            printLabel1 = new printLabel();

            //載入使用者名稱到下拉選單
            loadUserName();

            showLogForm = false;
            mi_pcb_feedback = new MethodInvoker(Update_pcb_feedback);
            GetPortInformation();

            //初始化上一次選擇
            #region get save data            
            DataTable dt = accessHelper.GetDataTable("select * from saveData");
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
                //acc----------------------------------
                if (temp_item == "Acc_X_Max")
                { tbx_acc_x_max.Text = temp_num; }
                if (temp_item == "Acc_X_Min")
                { tbx_acc_x_min.Text = temp_num; }

                if (temp_item == "Acc_Y_Max")
                { tbx_acc_y_max.Text = temp_num; }
                if (temp_item == "Acc_Y_Min")
                { tbx_acc_y_min.Text = temp_num; }

                if (temp_item == "Acc_Z_Max")
                { tbx_acc_z_max.Text = temp_num; }
                if (temp_item == "Acc_Z_Min")
                { tbx_acc_z_min.Text = temp_num; }

                //gyro
                if (temp_item == "Gyro_X_Max")
                { tbx_gyro_x_max.Text = temp_num; }
                if (temp_item == "Gyro_X_Min")
                { tbx_gyro_x_min.Text = temp_num; }

                if (temp_item == "Gyro_Y_Max")
                { tbx_gyro_y_max.Text = temp_num; }
                if (temp_item == "Gyro_Y_Min")
                { tbx_gyro_y_min.Text = temp_num; }

                if (temp_item == "Gyro_Z_Max")
                { tbx_gyro_z_max.Text = temp_num; }
                if (temp_item == "Gyro_Z_Min")
                { tbx_gyro_z_min.Text = temp_num; }
            }
            #endregion
            cbxSleeve.SelectedIndex = 0;
            createSnMax();
            #region get select data
            try
            {
                DataTable dt_selectData = accessHelper.GetDataTable("select * from selectData");
                for (int i = 0; i < dt_selectData.Rows.Count; i++)
                {
                    string temp_select = dt_selectData.Rows[i][1].ToString();
                    string temp_item = dt_selectData.Rows[i][2].ToString();
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
                try
                {
                    timerRealTimeData = new System.Windows.Forms.Timer();
                    timerRealTimeData.Enabled = true;
                    timerRealTimeData.Interval = int_interval;
                    timerRealTimeData.Tick += new System.EventHandler(this.timerRealTimeData_Tick);
                    int_curr_value[0] = 150;
                }
                catch
                {
                    MessageBox.Show("初始化錯誤!");
                }
            }
            catch (Exception ex2)
            {
                MessageBox.Show("An error has occurred. Please check the COM PORT or other problems.");
            }
            #endregion                       
        }

        private async void btn_ass_chk_Click(object sender, EventArgs e)
        {
            try
            {
                CheckShipping = true;
                strSQL = string.Format("select sleeveName from batchData where batchNum = '{0}'", cbxBatch.SelectedItem.ToString()); //取得sleeveName                                                                                 
                sleeveName = accessHelper.readData(strSQL);//執行SQL
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                sleeveName = "";
            }

            if (sleeveName != "" && pcbVer != "" && housingVer != "")
            {
                #region ASS_CHECK

                charge_max = 0;
                strFeedbackDose = "";

                RS232_DOSE.Close();
                RS232_DOSE.Dispose();
                RS232_DOSE.PortName = GetPortInformation_for_DOSE_COM();
                RS232_DOSE.Open();

                int delay_time = 100;

                byte[] UTF8bytes;

                UTF8bytes = Encoding.UTF8.GetBytes("#CONFIG_END" + Environment.NewLine);
                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                Thread.Sleep(delay_time);

                //設定checkSTATUSEnd為false,避免誤判已經測試結束
                checkSTATUSEnd = false;
                UTF8bytes = Encoding.UTF8.GetBytes("#STATUS" + Environment.NewLine);
                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                Thread.Sleep(300);


                UTF8bytes = Encoding.UTF8.GetBytes("#RETEST" + Environment.NewLine);
                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                Thread.Sleep(delay_time);

                UTF8bytes = Encoding.UTF8.GetBytes("#RE_ASS_MOUNTING" + Environment.NewLine);
                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                Thread.Sleep(delay_time);

                UTF8bytes = Encoding.UTF8.GetBytes("#ASS_CHECK" + Environment.NewLine);
                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                Thread.Sleep(delay_time);

                UTF8bytes = Encoding.UTF8.GetBytes("#ASS_MOUNTING" + Environment.NewLine);
                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                Thread.Sleep(delay_time);

                int _counter = 0;
                while (true)
                {
                    await Task.Delay(1);
                    if (boolMountingSwitch)
                    {
                        Thread.Sleep(3000); //245
                        //690422
                        UTF8bytes = Encoding.UTF8.GetBytes("#ASS_START" + Environment.NewLine);
                        RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                        Thread.Sleep(delay_time);

                        //等待二秒                      
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
                        catch (Exception ex)
                        {
                            MessageBox.Show("PLC Com Port Error!!");
                            LoadPlcCom();
                        }
                        #endregion
                        break;
                    }
                    _counter++;
                    if (_counter == 3000)
                    {
                        UTF8bytes = Encoding.UTF8.GetBytes("#ASS_STOP" + Environment.NewLine);
                        RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                        Thread.Sleep(delay_time);
                        MessageBox.Show("超過亖秒沒按下Mounting Switch, 請重測試!!");
                        break;
                    }
                }
                #endregion

                //此時已經可判斷是否測試結束
                checkSTATUSEnd = true;

                #region  取得要寫入的SN 由批號取得sleeve, 再由sleeve取得SN最大值

                #region 不要的CODE
                //strSQL = string.Format("SELECT MAX(snData.sn) FROM snData where (SELECT snData.sleeveName from snData where snData.batchNum = '{0}')", cbxBatch.SelectedItem.ToString()); //取得SN最大值                                                                                                                    
                //string _snMax = accessHelper.readData(strSQL);//執行SQL
                //intNextSn = Convert.ToInt32(_snMax) + 1;
                //_snMax = intNextSn.ToString().PadLeft(SnLength, '0');
                //strSQL = string.Format("SELECT batchData.sleeveName from batchData where batchData.batchNum = '{0}'", cbxBatch.SelectedItem.ToString()); //取得sleeveName
                //StrSleeveName = accessHelper.readData(strSQL);//執行SQL
                #endregion
                strSQL = string.Format("SELECT total FROM batchData where batchNum = '{0}'", cbxBatch.SelectedItem.ToString()); //取得批號總數
                string strTotal = accessHelper.readData(strSQL);//執行SQL
                int intTotal = Convert.ToInt32(strTotal);
                if (strTotal == "-1")
                {
                    MessageBox.Show("查詢失敗");
                }
                #endregion

                batchNum = cbxBatch.SelectedItem.ToString();
                int _completed = getCompletedNumForBatch(); //取得此批完成的數量
                if (Convert.ToInt32(_completed) < intTotal) //判斷總數小於等於批號數量
                {
                    #region FFT主要測試區塊-----------------------------------------------------------------------------------

                    #region 若有接收到FW回傳繼續往下
                    _counter = 0;
                    while (true)
                    {
                        Thread.Sleep(1);
                        if (boolDeviceReceive) //接收到回傳繼續往下
                        {
                            break;
                        }
                        _counter++;
                        if (_counter == 6000)
                        {
                            MessageBox.Show("測試失敗, 請重測試!!");
                            break;
                        }
                    }
                    #endregion

                    #region 寫入FW Conf
                    _counter = 0;
                    while (true)
                    {
                        Thread.Sleep(1);
                        if (boolAssCheck)
                        {
                            boolAssCheck = false;
                            //#SET_CONFIG_DATA 
                            //Mounted_Sleeve:       
                            UTF8bytes = Encoding.UTF8.GetBytes("#SET_CONFIG_DATA" + Environment.NewLine);
                            RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                            Thread.Sleep(500);

                            UTF8bytes = Encoding.UTF8.GetBytes("Housing_Version:" + housingVer + Environment.NewLine);
                            RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                            Thread.Sleep(delay_time2);

                            UTF8bytes = Encoding.UTF8.GetBytes("PCBA_Version:" + pcbVer + Environment.NewLine);
                            RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                            Thread.Sleep(delay_time2);

                            UTF8bytes = Encoding.UTF8.GetBytes("Batch_ID:" + batchNum + Environment.NewLine);
                            RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                            Thread.Sleep(delay_time2);

                            string date1 = DateTime.Now.ToString("yyyy MMM dd", CultureInfo.CreateSpecificCulture("en-US"));
                            UTF8bytes = Encoding.UTF8.GetBytes("Build_Date:" + date1 + Environment.NewLine);
                            RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                            Thread.Sleep(delay_time2);

                            UTF8bytes = Encoding.UTF8.GetBytes("Mounted_Sleeve:" + sleeveName + Environment.NewLine);
                            RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                            Thread.Sleep(delay_time2);

                            UTF8bytes = Encoding.UTF8.GetBytes("Assembly_Serial_Number:" + strNextSn.ToString().PadLeft(SnLength, '0') + Environment.NewLine);
                            RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                            Thread.Sleep(delay_time2);

                            UTF8bytes = Encoding.UTF8.GetBytes("#CONFIG_END" + Environment.NewLine);
                            RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                            Thread.Sleep(delay_time2);
                            break;
                        }
                        _counter++;
                        if (_counter == 6000)
                        {
                            MessageBox.Show("測試失敗, 請重測試!!");
                            break;
                        }
                    }
                    #endregion

                    Thread.Sleep(2000);

                    #region dump_data 寫入txt
                    WriteTxt = true;
                    SW = new StreamWriter(@"C:\DET_DOSE\" + strNextSn + ".txt");
                    try
                    {
                        UTF8bytes = Encoding.UTF8.GetBytes("#DUMP_DATA" + Environment.NewLine);
                        RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                        Thread.Sleep(100);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ComPort Error!");
                    }
                    #endregion

                    #region Shipping Mode
                    try
                    {
                        if (assCheck == "Pass")
                        {
                            #region FFT PASS
                            //由電流來決定shippingStatus的狀態
                            if (FFTCurr > batteryFullCurr)
                            {
                                #region shipping Fail  

                                #region 寫入shippingMode
                                //SQL語法：       
                                strSQL = "insert into shippingMode(deviceID,sn,shippingStatus,_current) VALUES(@deviceID, @sn,@shippingStatus,@_current)";
                                if (string.IsNullOrEmpty(strSQL) == false)
                                {
                                    //添加參數
                                    OleDbParameter[] pars = new OleDbParameter[] {
                                            new OleDbParameter("@deviceID",deviceID),
                                            new OleDbParameter("@sn",strNextSn),
                                            new OleDbParameter("@shippingStatus","Fail"),
                                            new OleDbParameter("@_current",FFTCurr.ToString())
                                    };

                                    //執行SQL
                                    string errorInfo = accessHelper.ExecSql(strSQL, pars);
                                    if (errorInfo.Length != 0)
                                    {
                                        MessageBox.Show("寫入失敗！" + errorInfo);
                                    }
                                    else
                                    {
                                        Console.WriteLine("寫入成功! " + errorInfo);
                                    }
                                }
                                #endregion

                                #endregion
                            }
                            else
                            {
                                #region shipping PASS  

                                #region 寫入shippingMode
                                //SQL語法：       
                                strSQL = "insert into shippingMode(deviceID,sn,shippingStatus,_current) VALUES(@deviceID, @sn,@shippingStatus,@_current)";
                                if (string.IsNullOrEmpty(strSQL) == false)
                                {
                                    //添加參數
                                    OleDbParameter[] pars = new OleDbParameter[] {
                                            new OleDbParameter("@deviceID",deviceID),
                                            new OleDbParameter("@sn",strNextSn),
                                            new OleDbParameter("@shippingStatus","Pass"),
                                            new OleDbParameter("@_current",FFTCurr.ToString())
                                    };

                                    //執行SQL
                                    string errorInfo = accessHelper.ExecSql(strSQL, pars);
                                    if (errorInfo.Length != 0)
                                    {
                                        MessageBox.Show("寫入失敗！" + errorInfo);
                                    }
                                    else
                                    {
                                        Console.WriteLine("寫入成功! " + errorInfo);
                                        MessageBox.Show("進入出貨模式，請將其它 Code Uncomment才能真的進入出貨模式");
                                        //進入出貨模式
                                        //UTF8bytes = Encoding.UTF8.GetBytes("#SHIP_MODE" + Environment.NewLine);
                                        //RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                                        //Thread.Sleep(delay_time2);
                                        strNextSn = "22-IZD-C1-DV1-" + strNextSn + "," + StrSleeveName;
                                        printLabel1.PrintOneLabel(strNextSn, bleName);
                                        printLabel1.PrintOneLabel(strNextSn, bleName);
                                        printLabel1.PrintOneLabel(strNextSn, bleName);
                                    }
                                }
                                #endregion
                                #endregion
                            }
                            #endregion
                        }
                        else
                        {
                            MessageBox.Show("ASS_CHECK失敗！");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ComPort Error!");
                    }
                    #endregion
                    #endregion

                    #region 測試結束, 判斷該批號是否已完成-------------------------------------------------------------
                    strSQL = string.Format("SELECT total FROM batchData where batchNum = '{0}'", cbxBatch.SelectedItem.ToString()); //取得批號總數
                    strTotal = accessHelper.readData(strSQL);//執行SQL
                    intTotal = Convert.ToInt32(strTotal);
                    if (strTotal == "-1")
                    {
                        MessageBox.Show("查詢失敗，發生錯誤");
                    }

                    batchNum = cbxBatch.SelectedItem.ToString();
                    _completed = getCompletedNumForBatch(); //取得此批完成的數量
                    if (Convert.ToInt32(_completed) < intTotal) //判斷總數小於等於批號數量
                    {
                        //	
                    }
                    else if (_completed == intTotal)
                    {
                        MessageBox.Show("批號 " + batchNum + " 已完成");
                        cbxBatch.Items.Remove(cbxBatch.SelectedItem);

                        #region SQL語法，設定此批號已完成
                        strSQL = "UPDATE batchData set finished = @finished where batchNum = @batchNum";
                        if (string.IsNullOrEmpty(strSQL) == false)
                        {
                            //添加參數
                            OleDbParameter[] pars = new OleDbParameter[] {
                                            new OleDbParameter("@finished","Y"),
                                            new OleDbParameter("@batchNum",batchNum)
                                                                };
                            //執行SQL
                            string errorInfo = accessHelper.ExecSql(strSQL, pars);
                            if (errorInfo.Length != 0)
                            {
                                MessageBox.Show("批號完成更新失敗！" + errorInfo);
                            }
                        }
                        #endregion
                    }
                    else
                    {
                        MessageBox.Show("數量異常 CODE 537");
                    }
                    #endregion
                }
                else if (_completed == intTotal)
                {
                    MessageBox.Show("此批號已完成");
                    cbxBatch.Items.Remove(cbxBatch.SelectedItem);

                    #region SQL語法，設定此批號已完成
                    strSQL = "UPDATE batchData set finished = @finished where batchNum = @batchNum";
                    if (string.IsNullOrEmpty(strSQL) == false)
                    {
                        //添加參數
                        OleDbParameter[] pars = new OleDbParameter[] {
                                            new OleDbParameter("@finished","Y"),
                                            new OleDbParameter("@batchNum",batchNum)
                                                                };
                        //執行SQL
                        string errorInfo = accessHelper.ExecSql(strSQL, pars);
                        if (errorInfo.Length != 0)
                        {
                            MessageBox.Show("批號完成更新失敗！" + errorInfo);
                        }
                    }
                    #endregion
                }
                else
                {
                    MessageBox.Show("數量異常 CODE 548");
                }
            }
            else
            {
                MessageBox.Show("批號讀取錯誤");
            }
        }


        #region Function集中處
        //戴入未完成批號
        void loadBatch()
        {
            cbxBatch.Enabled = true;
            //戴入未完成批號
            cbxBatch.Items.Clear();
            #region get save data            
            DataTable dt = accessHelper.GetDataTable("select batchNum from batchData where finished = 'N'");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string str_dt = dt.Rows[i][0].ToString();
                cbxBatch.Items.Add(new ComboboxItem(str_dt, str_dt));
            }
            #endregion          
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if ((tbxPassword.Text.Length > 3) && (tbxPassword.Text != ""))
            {
                //此判斷帳號密碼是否正確
                string str_sql = string.Format("SELECT pass_word FROM _user where user_name = '{0}'", cbx_name.SelectedItem.ToString());
                string pass_word = accessHelper.readData(str_sql);

                if (pass_word != "-2")
                {
                    //帳號密碼存在，比對密碼
                    if (pass_word == tbxPassword.Text)
                    {
                        //登入成功;
                        try
                        {
                            loadBatch();
                        }
                        catch
                        {
                            MessageBox.Show("登入失敗");
                        }
                    }
                    else
                    {
                        MessageBox.Show("登入失敗");
                    }
                }
                else
                {
                    MessageBox.Show("登入失敗");
                }
            }
            else
            {
                MessageBox.Show("密碼長度不足");
            }
        }

        private void createSnMax() //創造下一個SN
        {
            try
            {
                //回傳SN最大值
                //SQL語法：                                    
                // strSQL = string.Format("SELECT MAX(snData.sn) FROM snData where snData.sleeveName = (SELECT batchData.sleeveName from batchData where batchData.batchNum = '{0}')", cbxBatch.SelectedItem.ToString()); //取得SN最大值
                string strBatch = "";
                if (cbxBatch.Items.Count > 0)
                {
                    strBatch = cbxBatch.SelectedItem.ToString();
                }
                strSQL = string.Format("SELECT batchData.sleeveName from batchData where batchData.batchNum = '{0}'", strBatch); //取得sleeveName
                StrSleeveName = accessHelper.readData(strSQL);//執行SQL
                if (StrSleeveName != "-1")
                {
                    strSQL = string.Format("SELECT MAX(sn) FROM snData where sleeveName = '{0}'", StrSleeveName); //取得SN最大值

                    string _snMax = accessHelper.readData(strSQL);//執行SQL
                    intNextSn = Convert.ToInt32(_snMax) + 1;
                    strNextSn = intNextSn.ToString().PadLeft(SnLength, '0');
                    if (_snMax != "-1")
                    {
                        //SN前綴 + SN + SN後綴
                        strNextSn = leftSN + strNextSn + rightSN;
                        tbxSn.Text = strNextSn;
                    }
                    else
                    {
                        MessageBox.Show("查詢失敗");
                    }
                }
                else
                {
                    Console.WriteLine("查詢失敗");
                }
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.ToString());
            }
        }

        //判斷此deviceID(SN)是否已進入出貨模式, 1=是 0=否
        int checkShippingExist(string deviceID)
        {
            CheckShipping = false;
            strSQL = string.Format("SELECT sn FROM shippingMode where deviceID = '{0}' and shippingStatus = '{1}'", deviceID, "Pass"); //取得批號總數
            string _sn = accessHelper.readData(strSQL);//執行SQL
            if (_sn != "" || _sn != null)
            {
                return 1;
            }
            return 0;
        }

        void loadUserName()
        {
            string str_sql = "SELECT user_name FROM _user";
            DataTable dt = accessHelper.GetDataTable(str_sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string str_dt = dt.Rows[i][0].ToString();
                cbx_name.Items.Add(new ComboboxItem(str_dt, str_dt));
            }
            tbxPassword.PasswordChar = '*';
            cbx_name.SelectedIndex = 0;
        }
        #endregion


        private void cbxBatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //由批號取得 sleeveName, PcbVer, housingVer
                //SQL語法：        
                strSQL = string.Format("select sleeveName,pcbVersion,housingVersion,total from batchData where batchNum = '{0}'", cbxBatch.SelectedItem.ToString());
                DataTable dt_selectData = accessHelper.GetDataTable(strSQL);
                for (int i = 0; i < dt_selectData.Rows.Count; i++)
                {
                    sleeveName = dt_selectData.Rows[i][0].ToString();
                    pcbVer = dt_selectData.Rows[i][1].ToString();
                    housingVer = dt_selectData.Rows[i][2].ToString();
                    lblBatTotal.Text = dt_selectData.Rows[i][3].ToString(); //批號總數
                    createSnMax(); //產生下一個最大SN
                    int _num = getCompletedNumForBatch(); //取得完成數量
                    //批號選擇完成, 刪掉密碼, 鎖定批號
                    tbxPassword.Text = "";
                    cbxBatch.Enabled = false;
                }
            }
            catch
            {
                MessageBox.Show("載入批號相關資訊");
            }
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

        int getCompletedNumForBatch()
        {
            strSQL = string.Format("SELECT count(*) from (select distinct deviceID from deviceData where sleeve = '{0}' and batchNum = '{1}' and assCheck = '{2}')",
            StrSleeveName, cbxBatch.SelectedItem.ToString(), "Pass"); //取得sleeveName
            string _return = accessHelper.readData(strSQL);//執行SQL
            int intTemp = Convert.ToInt32(_return);
            try
            {
                lblBatCompleteNum.Text = _return;
                return intTemp;
            }
            catch
            {
                return -1;
            }
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
                //SQL語法：                    
                strSQL = "UPDATE selectData set select_data =@number where com = @com";
                if (string.IsNullOrEmpty(strSQL) == false)
                {
                    //添加參數
                    OleDbParameter[] pars = new OleDbParameter[] {
                                            new OleDbParameter("@number",cbx_power.SelectedIndex.ToString()),
                                            new OleDbParameter("@com","3")
                                                                };
                    //執行SQL
                    string errorInfo = accessHelper.ExecSql(strSQL, pars);
                    if (errorInfo.Length != 0)
                    {
                        MessageBox.Show("更新失敗！" + errorInfo);
                    }
                }

                //SQL語法：                    
                strSQL = "UPDATE selectData set com_name =@com_name where com = @com";
                if (string.IsNullOrEmpty(strSQL) == false)
                {
                    //添加參數
                    OleDbParameter[] pars = new OleDbParameter[] {
                                            new OleDbParameter("@com_name",cbx_power .SelectedItem.ToString()),
                                            new OleDbParameter("@com","3")
                                                                };
                    //執行SQL
                    string errorInfo = accessHelper.ExecSql(strSQL, pars);
                    if (errorInfo.Length != 0)
                    {
                        MessageBox.Show("更新失敗！" + errorInfo);
                    }
                }


                string com_name = cbx_power.SelectedItem.ToString();
                int int_start = com_name.IndexOf("(");
                int int_end = com_name.IndexOf(")");
                string com_num = com_name.Substring(int_start + 4, int_end - int_start - 4);
                // Set address
                string VISA_ADDRESS = "ASRL" + com_num + "::INSTR";

                // Create a connection (session) to the RS-232 device.                                 

                try
                {
                    session = GlobalResourceManager.Open(VISA_ADDRESS) as IMessageBasedSession;

                    // Enable the Termination Character.                
                    session.TerminationCharacterEnabled = true;
                }
                catch (Exception err)
                {
                    MessageBox.Show("POWER Error!");
                    MessageBox.Show(err.ToString());
                }


                try
                {
                    // Connection parameters
                    ISerialSession serial = session as ISerialSession;
                    serial.BaudRate = 115200;
                    serial.DataBits = 8;
                    serial.Parity = Ivi.Visa.SerialParity.None;
                    //  serial.FlowControl = SerialFlowControlModes.DtrDsr;
                    serial.FlowControl = SerialFlowControlModes.None;

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
                    MessageBox.Show("POWER Error!");
                    MessageBox.Show(ex.ToString());
                }

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
                int update_report = 0;
                strFeedbackDose = "";
                int delay_time = 100;
                try
                {
                    RS232_DOSE.Close();
                    RS232_DOSE.Dispose();
                    RS232_DOSE.PortName = GetPortInformation_for_DOSE_COM();
                    RS232_DOSE.Open();
                }
                catch
                {
                    MessageBox.Show("Dose Com port Error!");
                }

                UTF8bytes = Encoding.UTF8.GetBytes("#SET_ASS_TH" + Environment.NewLine);
                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                Thread.Sleep(1000);

                UTF8bytes = Encoding.UTF8.GetBytes("Mouse_X_Max:" + tbx_mouse_x_max.Text + "\0" + Environment.NewLine);
                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                Thread.Sleep(delay_time);

                if (accessHelper.UpdateDataBase("saveData", "num", tbx_mouse_x_max.Text, "item", "Mouse_X_Max") == "fail")
                    update_report++;

                UTF8bytes = Encoding.UTF8.GetBytes("Mouse_X_Min:" + tbx_mouse_x_min.Text + "\0" + Environment.NewLine);
                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                Thread.Sleep(delay_time);

                if (accessHelper.UpdateDataBase("saveData", "num", tbx_mouse_x_min.Text, "item", "Mouse_X_Min") == "fail")
                    update_report++;

                UTF8bytes = Encoding.UTF8.GetBytes("Mouse_Y_Max:" + tbx_mouse_y_max.Text + "\0" + Environment.NewLine);
                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                Thread.Sleep(delay_time);

                if (accessHelper.UpdateDataBase("saveData", "num", tbx_mouse_y_max.Text, "item", "Mouse_Y_Max") == "fail")
                    update_report++;

                UTF8bytes = Encoding.UTF8.GetBytes("Mouse_Y_Min:" + tbx_mouse_y_min.Text + "\0" + Environment.NewLine);
                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                Thread.Sleep(delay_time);

                if (accessHelper.UpdateDataBase("saveData", "num", tbx_mouse_y_min.Text, "item", "Mouse_y_Min") == "fail")
                    update_report++;

                UTF8bytes = Encoding.UTF8.GetBytes("Shutter_Max:" + tbx_shutter_max.Text + "\0" + Environment.NewLine);
                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                Thread.Sleep(delay_time);

                if (accessHelper.UpdateDataBase("saveData", "num", tbx_shutter_max.Text, "item", "Shutter_Max") == "fail")
                    update_report++;

                UTF8bytes = Encoding.UTF8.GetBytes("Shutter_Min:" + tbx_shutter_min.Text + "\0" + Environment.NewLine);
                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                Thread.Sleep(delay_time);

                if (accessHelper.UpdateDataBase("saveData", "num", tbx_shutter_min.Text, "item", "Shutter_Min") == "fail")
                    update_report++;

                UTF8bytes = Encoding.UTF8.GetBytes("Frame_Max:" + tbx_frame_max.Text + "\0" + Environment.NewLine);
                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                Thread.Sleep(delay_time);

                if (accessHelper.UpdateDataBase("saveData", "num", tbx_frame_max.Text, "item", "frame_Max") == "fail")
                    update_report++;

                UTF8bytes = Encoding.UTF8.GetBytes("Frame_Min:" + tbx_frame_min.Text + "\0" + Environment.NewLine);
                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                Thread.Sleep(delay_time);

                if (accessHelper.UpdateDataBase("saveData", "num", tbx_frame_min.Text, "item", "frame_Min") == "fail")
                    update_report++;

                UTF8bytes = Encoding.UTF8.GetBytes("IQ_Max:" + tbx_iq_max.Text + "\0" + Environment.NewLine);
                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                Thread.Sleep(delay_time);

                if (accessHelper.UpdateDataBase("saveData", "num", tbx_iq_max.Text, "item", "IQ_Max") == "fail")
                    update_report++;

                UTF8bytes = Encoding.UTF8.GetBytes("IQ_Min:" + tbx_iq_min.Text + "\0" + Environment.NewLine);
                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                Thread.Sleep(delay_time);

                if (accessHelper.UpdateDataBase("saveData", "num", tbx_iq_min.Text, "item", "IQ_Min") == "fail")
                    update_report++;


                UTF8bytes = Encoding.UTF8.GetBytes("IR_Max:" + tbx_ir_max.Text + "\0" + Environment.NewLine);
                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                Thread.Sleep(delay_time);

                if (accessHelper.UpdateDataBase("saveData", "num", tbx_ir_max.Text, "item", "IR_Max") == "fail")
                    update_report++;

                UTF8bytes = Encoding.UTF8.GetBytes("IR_Min:" + tbx_ir_min.Text + "\0" + Environment.NewLine);
                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                Thread.Sleep(delay_time);

                if (accessHelper.UpdateDataBase("saveData", "num", tbx_ir_min.Text, "item", "IR_Min") == "fail")
                    update_report++;


                UTF8bytes = Encoding.UTF8.GetBytes("Battery_Max:" + tbx_batt_max.Text + "\0" + Environment.NewLine);
                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                Thread.Sleep(delay_time);

                if (accessHelper.UpdateDataBase("saveData", "num", tbx_batt_max.Text, "item", "Battery_Max") == "fail")
                    update_report++;

                UTF8bytes = Encoding.UTF8.GetBytes("Battery_Min:" + tbx_batt_min.Text + "\0" + Environment.NewLine);
                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                Thread.Sleep(delay_time);

                if (accessHelper.UpdateDataBase("saveData", "num", tbx_batt_min.Text, "item", "Battery_Min") == "fail")
                    update_report++;

                //ACC
                UTF8bytes = Encoding.UTF8.GetBytes("Acc_X_Max:" + tbx_acc_x_max.Text + "\0" + Environment.NewLine);
                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                Thread.Sleep(delay_time);

                if (accessHelper.UpdateDataBase("saveData", "num", tbx_acc_x_max.Text, "item", "Acc_X_Max") == "fail")
                    update_report++;

                UTF8bytes = Encoding.UTF8.GetBytes("Acc_X_Min:" + tbx_acc_x_min.Text + "\0" + Environment.NewLine);
                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                Thread.Sleep(delay_time);

                if (accessHelper.UpdateDataBase("saveData", "num", tbx_acc_x_min.Text, "item", "Acc_X_Min") == "fail")
                    update_report++;

                UTF8bytes = Encoding.UTF8.GetBytes("Acc_Y_Max:" + tbx_acc_y_max.Text + "\0" + Environment.NewLine);
                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                Thread.Sleep(delay_time);

                if (accessHelper.UpdateDataBase("saveData", "num", tbx_acc_y_max.Text, "item", "Acc_Y_Max") == "fail")
                    update_report++;

                UTF8bytes = Encoding.UTF8.GetBytes("Acc_Y_Min:" + tbx_acc_y_min.Text + "\0" + Environment.NewLine);
                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                Thread.Sleep(delay_time);

                if (accessHelper.UpdateDataBase("saveData", "num", tbx_acc_y_min.Text, "item", "Acc_Y_Min") == "fail")
                    update_report++;

                UTF8bytes = Encoding.UTF8.GetBytes("Acc_Z_Max:" + tbx_acc_z_max.Text + "\0" + Environment.NewLine);
                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                Thread.Sleep(delay_time);

                if (accessHelper.UpdateDataBase("saveData", "num", tbx_acc_z_max.Text, "item", "Acc_Z_Max") == "fail")
                    update_report++;

                UTF8bytes = Encoding.UTF8.GetBytes("Acc_Z_Min:" + tbx_acc_z_min.Text + "\0" + Environment.NewLine);
                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                Thread.Sleep(delay_time);

                if (accessHelper.UpdateDataBase("saveData", "num", tbx_acc_z_min.Text, "item", "Acc_Z_Min") == "fail")
                    update_report++;

                //Gyro
                UTF8bytes = Encoding.UTF8.GetBytes("Gyro_X_Max:" + tbx_gyro_x_max.Text + "\0" + Environment.NewLine);
                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                Thread.Sleep(delay_time);

                if (accessHelper.UpdateDataBase("saveData", "num", tbx_gyro_x_max.Text, "item", "Gyro_X_Max") == "fail")
                    update_report++;

                UTF8bytes = Encoding.UTF8.GetBytes("Gyro_X_Min:" + tbx_gyro_x_min.Text + "\0" + Environment.NewLine);
                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                Thread.Sleep(delay_time);

                if (accessHelper.UpdateDataBase("saveData", "num", tbx_gyro_x_min.Text, "item", "Gyro_X_Min") == "fail")
                    update_report++;

                UTF8bytes = Encoding.UTF8.GetBytes("Gyro_Y_Max:" + tbx_gyro_y_max.Text + "\0" + Environment.NewLine);
                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                Thread.Sleep(delay_time);

                if (accessHelper.UpdateDataBase("saveData", "num", tbx_gyro_y_max.Text, "item", "Gyro_Y_Max") == "fail")
                    update_report++;

                UTF8bytes = Encoding.UTF8.GetBytes("Gyro_Y_Min:" + tbx_gyro_y_min.Text + "\0" + Environment.NewLine);
                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                Thread.Sleep(delay_time);

                if (accessHelper.UpdateDataBase("saveData", "num", tbx_gyro_y_min.Text, "item", "Gyro_Y_Min") == "fail")
                    update_report++;

                UTF8bytes = Encoding.UTF8.GetBytes("Gyro_Z_Max:" + tbx_gyro_z_max.Text + "\0" + Environment.NewLine);
                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                Thread.Sleep(delay_time);

                if (accessHelper.UpdateDataBase("saveData", "num", tbx_gyro_z_max.Text, "item", "Gyro_Z_Max") == "fail")
                    update_report++;

                UTF8bytes = Encoding.UTF8.GetBytes("Gyro_Z_Min:" + tbx_gyro_z_min.Text + "\0" + Environment.NewLine);
                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                Thread.Sleep(delay_time);

                if (accessHelper.UpdateDataBase("saveData", "num", tbx_gyro_z_min.Text, "item", "Gyro_Z_Min") == "fail")
                    update_report++;

                if (update_report > 0)
                    MessageBox.Show("更新發生錯誤");

                UTF8bytes = Encoding.UTF8.GetBytes("#ASS_TH_END" + Environment.NewLine);
                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                MessageBox.Show("SET COMPLETED.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        bool WriteTxt = false;
        StreamWriter SW;
        private void btnDump_Click(object sender, EventArgs e)
        {
            WriteTxt = true;
            SW = new StreamWriter(@"C:\DET_DOSE\" + tbxSn.Text + ".txt");
            try
            {
                RS232_DOSE.Close();
                RS232_DOSE.Dispose();
                RS232_DOSE.PortName = GetPortInformation_for_DOSE_COM();
                RS232_DOSE.Open();

                byte[] UTF8bytes = Encoding.UTF8.GetBytes("#DUMP_DATA" + Environment.NewLine);
                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                Thread.Sleep(100);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ComPort Error!");
            }
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            RS232_DOSE.Close();
            RS232_DOSE.Dispose();
            RS232_DOSE.PortName = GetPortInformation_for_DOSE_COM();
            RS232_DOSE.Open();
            //#SET_CONFIG_DATA 
            //Mounted_Sleeve:       
            byte[] UTF8bytes = Encoding.UTF8.GetBytes("#STATUS" + Environment.NewLine);
            RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
            Thread.Sleep(100);
        }

        private void btnShipMode_Click(object sender, EventArgs e)
        {
            try
            {
                RS232_DOSE.Close();
                RS232_DOSE.Dispose();
                RS232_DOSE.PortName = GetPortInformation_for_DOSE_COM();
                RS232_DOSE.Open();

                byte[] UTF8bytes = Encoding.UTF8.GetBytes("#SHIP_MODE" + Environment.NewLine);
                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                Thread.Sleep(300);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ComPort Error!");
            }
        }

        private void btnConfigFW_Click(object sender, EventArgs e)
        {
            try
            {
                #region 寫入FW Conf
                strNextSn = tbxSn.Text;
                batchNum = cbxBatch.SelectedItem.ToString();
                pcbVer = tbxPCB.Text;
                housingVer = tbxHousing.Text;
                //Date
                buildDate = DateTime.Now.ToString("yyyy MMM dd", CultureInfo.CreateSpecificCulture("en-US"));

                RS232_DOSE.Close();
                RS232_DOSE.Dispose();
                RS232_DOSE.PortName = GetPortInformation_for_DOSE_COM();
                RS232_DOSE.Open();
                //#SET_CONFIG_DATA 
                //Mounted_Sleeve:       
                byte[] UTF8bytes = Encoding.UTF8.GetBytes("#SET_CONFIG_DATA" + Environment.NewLine);
                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                Thread.Sleep(500);

                UTF8bytes = Encoding.UTF8.GetBytes("Housing_Version:" + housingVer + Environment.NewLine);
                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                Thread.Sleep(delay_time2);

                UTF8bytes = Encoding.UTF8.GetBytes("PCBA_Version:" + pcbVer + Environment.NewLine);
                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                Thread.Sleep(delay_time2);

                UTF8bytes = Encoding.UTF8.GetBytes("Batch_ID:" + batchNum + Environment.NewLine);
                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                Thread.Sleep(delay_time2);

                string date1 = DateTime.Now.ToString("yyyy MMM dd", CultureInfo.CreateSpecificCulture("en-US"));
                UTF8bytes = Encoding.UTF8.GetBytes("Build_Date:" + date1 + Environment.NewLine);
                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                Thread.Sleep(delay_time2);

                UTF8bytes = Encoding.UTF8.GetBytes("Mounted_Sleeve:" + sleeveName + Environment.NewLine);
                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                Thread.Sleep(delay_time2);

                UTF8bytes = Encoding.UTF8.GetBytes("Assembly_Serial_Number:" + strNextSn.ToString().PadLeft(SnLength, '0') + Environment.NewLine);
                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                Thread.Sleep(delay_time2);

                UTF8bytes = Encoding.UTF8.GetBytes("#CONFIG_END" + Environment.NewLine);
                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                Thread.Sleep(delay_time2);
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        // static loginForm loginForm1 = new loginForm();
        private void btnOpenManage_Click(object sender, EventArgs e)
        {
            if (showLogForm == false)
            {
                loginForm loginForm1 = new loginForm(showLogForm);
                loginForm1.Owner = this;
                loginForm1.Show();
                showLogForm = true;
            }
        }

        private void RS232_DOSE_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string inData = "";
            SerialPort sp = (SerialPort)sender;
            Thread.Sleep(50);
            inData = sp.ReadExisting();
            sp.DiscardInBuffer();
            if (inData.Length > 3)
            {
                #region DOSE回傳內容
                try
                {
                    Console.WriteLine(inData);

                    if (WriteTxt)
                    {
                        SW.WriteLine(inData);
                        if (inData.Contains("Assembly_Serial_Number"))
                        {
                            WriteTxt = false;
                            SW.Close();
                        }
                    }
                    if (inData.Contains("Device ID:") == true)
                    {
                        deviceID = inData.Substring(inData.IndexOf("Device ID") + 10, inData.IndexOf("BLE ID") - (inData.IndexOf("Device ID") + 10)).Replace("\r\n", "");
                        boolDeviceReceive = true; //deviceID接收完成
                        if (CheckShipping) //按下主測試鈕後才判斷一次
                        {
                            if (checkShippingExist(deviceID) == 1)
                            {
                                MessageBox.Show("此DEVICEID " + deviceID + " 曾經進入過Shipping Mode");
                            }
                        }
                    }
                    if (inData.Contains("BLE Device Name") == true)
                    {
                        try
                        {
                            bleName = inData.Substring(inData.IndexOf("BLE Device Name") + 16, 15);
                        }
                        catch
                        {
                            Console.WriteLine("bleName Error");
                        }

                    }
                    if (inData.Contains("ACC X Max. :") == true)
                    {
                        accXmax = inData.Substring(inData.IndexOf("ACC X Max. :") + 12, inData.IndexOf("ACC X Min. :") - (inData.IndexOf("ACC X Max. :") + 12)).Replace("\r\n", "");
                    }
                    if (inData.Contains("ACC X Min. :") == true)
                    {
                        accXmin = inData.Substring(inData.IndexOf("ACC X Min. :") + 12, inData.IndexOf("ACC Y Max. :") - (inData.IndexOf("ACC X Min. :") + 12)).Replace("\r\n", "");
                    }
                    if (inData.Contains("ACC Y Max. :") == true)
                    {
                        accYmax = inData.Substring(inData.IndexOf("ACC Y Max. :") + 12, inData.IndexOf("ACC Y Min. :") - (inData.IndexOf("ACC Y Max. :") + 12)).Replace("\r\n", "");
                    }
                    if (inData.Contains("ACC Y Min. :") == true)
                    {
                        accYmin = inData.Substring(inData.IndexOf("ACC Y Min. :") + 12, inData.IndexOf("ACC Z Max. :") - (inData.IndexOf("ACC Y Min. :") + 12)).Replace("\r\n", "");
                    }
                    if (inData.Contains("ACC Z Max. :") == true)
                    {
                        accZmax = inData.Substring(inData.IndexOf("ACC Z Max. :") + 12, inData.IndexOf("ACC Z Min. :") - (inData.IndexOf("ACC Z Max. :") + 12)).Replace("\r\n", "");
                    }
                    if (inData.Contains("ACC Z Min. :") == true)
                    {
                        accZmin = inData.Substring(inData.IndexOf("ACC Z Min. :") + 12, inData.IndexOf("GYRO X Max. :") - (inData.IndexOf("ACC Z Min. :") + 12)).Replace("\r\n", "");
                    }
                    if (inData.Contains("GYRO X Max. :") == true)
                    {
                        gyroXmax = inData.Substring(inData.IndexOf("GYRO X Max. :") + 13, inData.IndexOf("GYRO X Min. :") - (inData.IndexOf("GYRO X Max. :") + 13)).Replace("\r\n", "");
                    }
                    if (inData.Contains("GYRO X Min. :") == true)
                    {
                        gyroXmin = inData.Substring(inData.IndexOf("GYRO X Min. :") + 13, inData.IndexOf("GYRO Y Max. :") - (inData.IndexOf("GYRO X Min. :") + 13)).Replace("\r\n", "");
                    }
                    if (inData.Contains("GYRO Y Max. :") == true)
                    {
                        gyroYmax = inData.Substring(inData.IndexOf("GYRO Y Max. :") + 13, inData.IndexOf("GYRO Y Min. :") - (inData.IndexOf("GYRO Y Max. :") + 13)).Replace("\r\n", "");
                    }
                    if (inData.Contains("GYRO Y Min. :") == true)
                    {
                        gyroYmin = inData.Substring(inData.IndexOf("GYRO Y Min. :") + 13, inData.IndexOf("GYRO Z Max. :") - (inData.IndexOf("GYRO Y Min. :") + 13)).Replace("\r\n", "");
                    }
                    if (inData.Contains("GYRO Z Max. :") == true)
                    {
                        gyroZmax = inData.Substring(inData.IndexOf("GYRO Z Max. :") + 13, inData.IndexOf("GYRO Z Min. :") - (inData.IndexOf("GYRO Z Max. :") + 13)).Replace("\r\n", "");
                    }
                    if (inData.Contains("GYRO Z Min. :") == true)
                    {
                        gyroZmin = inData.Substring(inData.IndexOf("GYRO Z Min. :") + 13, inData.IndexOf("Mouse X Max. :") - (inData.IndexOf("GYRO Z Min. :") + 13)).Replace("\r\n", "");
                    }
                    if (inData.Contains("Mouse X Max. :") == true)
                    {
                        mouseXmax = inData.Substring(inData.IndexOf("Mouse X Max. :") + 14, inData.IndexOf("Mouse X Min. :") - (inData.IndexOf("Mouse X Max. :") + 14)).Replace("\r\n", "");
                    }
                    if (inData.Contains("Mouse X Min. :") == true)
                    {
                        mouseXmin = inData.Substring(inData.IndexOf("Mouse X Min. :") + 14, inData.IndexOf("Mouse Y Max. :") - (inData.IndexOf("Mouse X Min. :") + 14)).Replace("\r\n", "");
                    }
                    if (inData.Contains("Mouse Y Max. :") == true)
                    {
                        mouseYmax = inData.Substring(inData.IndexOf("Mouse Y Max. :") + 14, inData.IndexOf("Mouse Y Min. :") - (inData.IndexOf("Mouse Y Max. :") + 14)).Replace("\r\n", "");
                    }
                    if (inData.Contains("Mouse Y Min. :") == true)
                    {
                        mouseYmin = inData.Substring(inData.IndexOf("Mouse Y Min. :") + 14, inData.IndexOf("Mouse Shutter Max. :") - (inData.IndexOf("Mouse Y Min. :") + 14)).Replace("\r\n", "");
                    }
                    if (inData.Contains("Mouse Shutter Max. :") == true)
                    {
                        mouseSmax = inData.Substring(inData.IndexOf("Mouse Shutter Max. :") + 20, inData.IndexOf("Mouse Shutter Min. :") - (inData.IndexOf("Mouse Shutter Max. :") + 20)).Replace("\r\n", "");
                    }
                    if (inData.Contains("Mouse Shutter Min. :") == true)
                    {
                        mouseSmin = inData.Substring(inData.IndexOf("Mouse Shutter Min. :") + 20, inData.IndexOf("Mouse Frame Max. :") - (inData.IndexOf("Mouse Shutter Min. :") + 20)).Replace("\r\n", "");
                    }
                    if (inData.Contains("Mouse Frame Max. :") == true)
                    {
                        mouseFmax = inData.Substring(inData.IndexOf("Mouse Frame Max. :") + 18, inData.IndexOf("Mouse Frame Min. :") - (inData.IndexOf("Mouse Frame Max. :") + 18)).Replace("\r\n", "");
                    }
                    if (inData.Contains("Mouse Frame Min. :") == true)
                    {
                        mouseFmin = inData.Substring(inData.IndexOf("Mouse Frame Min. :") + 18, inData.IndexOf("Mouse IQ Max. :") - (inData.IndexOf("Mouse Frame Min. :") + 18)).Replace("\r\n", "");
                    }
                    if (inData.Contains("Mouse IQ Max. :") == true)
                    {
                        mouseImax = inData.Substring(inData.IndexOf("Mouse IQ Max. :") + 15, inData.IndexOf("Mouse IQ Min. :") - (inData.IndexOf("Mouse IQ Max. :") + 15)).Replace("\r\n", "");
                    }
                    if (inData.Contains("Mouse IQ Min. :") == true)
                    {
                        mouseImin = inData.Substring(inData.IndexOf("Mouse IQ Min. :") + 15, inData.IndexOf("IR Max. :") - (inData.IndexOf("Mouse IQ Min. :") + 15)).Replace("\r\n", "");
                    }
                    if (inData.Contains("IR Max. :") == true)
                    {
                        IRmax = inData.Substring(inData.IndexOf("IR Max. :") + 9, inData.IndexOf("IR Min. :") - (inData.IndexOf("IR Max. :") + 9)).Replace("\r\n", "");
                    }
                    if (inData.Contains("IR Min. :") == true)
                    {
                        IRmin = inData.Substring(inData.IndexOf("IR Min. :") + 9, inData.IndexOf("Battery Max. :") - (inData.IndexOf("IR Min. :") + 9)).Replace("\r\n", "");
                    }
                    if (inData.Contains("Battery Max. :") == true)
                    {
                        try
                        {
                            batterymax = inData.Substring(inData.IndexOf("Battery Max. :") + 14, inData.IndexOf("Battery Min. :") - (inData.IndexOf("Battery Max. :") + 14)).Replace("\r\n", "");
                        }
                        catch
                        {
                            MessageBox.Show("Battery Max");
                        }
                    }
                    if (inData.Contains("Battery Min. :") == true)
                    {
                        try
                        {
                            batterymin = inData.Substring(inData.IndexOf("Battery Min. :") + 14, inData.IndexOf("Charging") - (inData.IndexOf("Battery Min. :") + 14)).Replace("\r\n", "");
                        }
                        catch
                        {
                            MessageBox.Show("Battery Min");
                        }
                    }
                    if (inData.Contains("Mount Btn :") == true)
                    {
                        mountingSwitch = inData.Substring(inData.IndexOf("Mount Btn :") + 11, 2);
                        if (mountingSwitch == "Pr")
                        {
                            mountingSwitch = "Pass";
                        }
                        else if (mountingSwitch == "No")
                        {
                            mountingSwitch = "Fail";
                        }
                        else
                        {
                            mountingSwitch = "Fail";
                        }
                        boolMountingSwitch = true;
                    }

                    //FW version:
                    if (inData.Contains("FW version:") == true)
                    {
                        fwVersion = inData.Substring(inData.IndexOf("FW version:") + 11, 5);
                    }

                    //程式一開始會執行#STATUS和checkSTATUSEnd為false, 要先忽略掉其回傳, 到後半段程式會將checkSTATUSEnd設為true, 此時才再加以判斷是否測完畢
                    if (inData.Contains("ASS_CHECK") && inData.Contains("#") == false && checkSTATUSEnd == true)
                    {
                        #region 測試成功                       
                        boolAssCheck = true; //測試完成
                        assCheck = inData.Substring(inData.IndexOf("ASS_CHECK") + 11, 4);

                        //Date
                        buildDate = DateTime.Now.ToString("yyyy MMM dd", CultureInfo.CreateSpecificCulture("en-US"));

                        //判斷deviceID是否不存在於snData, 若是則寫入一筆資料到snData
                        strSQL = string.Format("select * from snData where deviceID = '{0}'", deviceID);
                        string checkDeviceID = accessHelper.readData(strSQL);
                        if (checkDeviceID == "-1" && boolDeviceReceive)
                        {
                            boolDeviceReceive = false;
                            #region  執行SQL二次，deviceID不存在故同時寫入snData & deviceData 各一筆資料 和設定FW
                            //寫入資料庫
                            //SQL語法：     
                            strSQL = "insert into snData(sn,deviceID,bleName,batchNum,fwVersion,sleeveName,buildDate,pcbVersion,housingVersion) VALUES(@sn,@deviceID,@bleName,@batchNum,@fwVersion,@sleeveName,@buildDate,@pcbVersion,@housingVersion)";
                            if (string.IsNullOrEmpty(strSQL) == false)
                            {
                                //添加參數                                                    
                                OleDbParameter[] pars = new OleDbParameter[] {
                                            new OleDbParameter("@sn",""),
                                            new OleDbParameter("@deviceID",deviceID),
                                            new OleDbParameter("@bleName",bleName),
                                            new OleDbParameter("@batchNum",batchNum),
                                            new OleDbParameter("@fwVersion",fwVersion),
                                            new OleDbParameter("@sleeveName",sleeveName),
                                            new OleDbParameter("@buildDate",buildDate),
                                            new OleDbParameter("@pcbVersion",pcbVer),
                                            new OleDbParameter("@housingVersion",housingVer)
                                                                };
                                //執行SQL插入資料
                                string errorInfo = accessHelper.ExecSql(strSQL, pars);
                                if (errorInfo.Length != 0)
                                {
                                    MessageBox.Show("寫入失敗！" + errorInfo);
                                }
                                else
                                {
                                    #region 寫入deviceData

                                    //SQL語法：       
                                    strSQL = "insert into deviceData(sn,deviceID,batchNum,sleeve,buildDate,assCheck,accXmax,accXmin,accYmax,accYmin,accZmax,accZmin," +
                                        "gyroXmax,gyroXmin,gyroYmax,gyroYmin,mouseXmax,mouseXmin,mouseYmax,mouseYmin,mouseSmax,mouseSmin,mouseFmax,mouseFmin," +
                                        "mouseImax,mouseImin,IRmax,IRmin,batterymax,batterymin,mounting)" +
                                        " VALUES(@sn,@deviceID,@batchNum,@sleeve,@buildDate,@assCheck,@accXmax,@accXmin,@accYmax,@accYmin,@accZmax,@accZmin," +
                                        "@gyroXmax,@gyroXmin,@gyroYmax,@gyroYmin,@mouseXmax,@mouseXmin,@mouseYmax,@mouseYmin,@mouseSmax,@mouseSmin,@mouseFmax," +
                                        "@mouseFmin,@mouseImax,@mouseImin,@IRmax,@IRmin,@batterymax,@batterymin,@mounting)";
                                    if (string.IsNullOrEmpty(strSQL) == false)
                                    {
                                        //添加參數
                                        OleDbParameter[] pars2 = new OleDbParameter[] {
                                            new OleDbParameter("@sn",intNextSn.ToString().PadLeft(SnLength, '0')),
                                            new OleDbParameter("@deviceID",deviceID),
                                            new OleDbParameter("@batchNum",batchNum),
                                            new OleDbParameter("@sleeve",sleeveName),
                                            new OleDbParameter("@buildDate",DateTime.Now.ToString("yyyy-MM-dd HH:mm")),//改為寫入測試時間
                                            new OleDbParameter("@assCheck",assCheck),
                                            new OleDbParameter("@accXmax",accXmax),
                                            new OleDbParameter("@accXmin",accXmin),
                                            new OleDbParameter("@accYmax",accYmax),
                                            new OleDbParameter("@accYmin",accYmin),
                                            new OleDbParameter("@accZmax",accZmax),
                                            new OleDbParameter("@accZmin",accZmin),
                                            new OleDbParameter("@gyroXmax",gyroXmax),
                                            new OleDbParameter("@gyroXmin",gyroXmin),
                                            new OleDbParameter("@gyroYmax",gyroYmax),
                                            new OleDbParameter("@gyroYmin",gyroYmin),
                                            new OleDbParameter("@mouseXmax",mouseXmax),
                                            new OleDbParameter("@mouseXmin",mouseXmin),
                                            new OleDbParameter("@mouseYmax",mouseYmax),
                                            new OleDbParameter("@mouseYmin",mouseYmin),
                                            new OleDbParameter("@mouseSmax",mouseSmax),
                                            new OleDbParameter("@mouseSmin",mouseSmin),
                                            new OleDbParameter("@mouseFmax",mouseFmax),
                                            new OleDbParameter("@mouseFmin",mouseFmin),
                                            new OleDbParameter("@mouseImax",mouseImax),
                                            new OleDbParameter("@mouseImin",mouseImin),
                                            new OleDbParameter("@IRmax",IRmax),
                                            new OleDbParameter("@IRmin",IRmin),
                                            new OleDbParameter("@batterymax",batterymax),
                                            new OleDbParameter("@batterymin",batterymin),
                                            new OleDbParameter("@mounting",mountingSwitch)
                                    };
                                        //執行SQL
                                        string errorInfo2 = accessHelper.ExecSql(strSQL, pars2);
                                        if (errorInfo.Length != 0)
                                        {
                                            MessageBox.Show("寫入失敗！" + errorInfo2);
                                        }
                                        else
                                        {
                                            miCreateMaxSN = new MethodInvoker(this.createSnMax);
                                            this.BeginInvoke(miCreateMaxSN);
                                        }
                                    }
                                    #endregion

                                    boolMountingSwitch = false;
                                    #region Config寫入FW，如果FFT測試PASS
                                    if (assCheck == "Pass")
                                    {
                                        #region FFT PASS
                                        try
                                        {
                                            byte[] UTF8bytes = Encoding.UTF8.GetBytes("#SET_CONFIG_DATA" + Environment.NewLine);
                                            RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                                            Thread.Sleep(delay_time2);

                                            UTF8bytes = Encoding.UTF8.GetBytes("Housing_Version:" + housingVer + Environment.NewLine);
                                            RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                                            Thread.Sleep(delay_time2);

                                            UTF8bytes = Encoding.UTF8.GetBytes("PCBA_Version:" + pcbVer + Environment.NewLine);
                                            RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                                            Thread.Sleep(delay_time2);

                                            UTF8bytes = Encoding.UTF8.GetBytes("Batch_ID:" + batchNum + Environment.NewLine);
                                            RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                                            Thread.Sleep(delay_time2);

                                            string date1 = DateTime.Now.ToString("yyyy MMM dd", CultureInfo.CreateSpecificCulture("en-US"));
                                            UTF8bytes = Encoding.UTF8.GetBytes("Build_Date:" + date1 + Environment.NewLine);
                                            RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                                            Thread.Sleep(delay_time2);

                                            UTF8bytes = Encoding.UTF8.GetBytes("Mounted_Sleeve:" + sleeveName + Environment.NewLine);
                                            RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                                            Thread.Sleep(delay_time2);

                                            UTF8bytes = Encoding.UTF8.GetBytes("Assembly_Serial_Number:" + strNextSn.ToString().PadLeft(SnLength, '0') + Environment.NewLine);
                                            RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                                            Thread.Sleep(delay_time2);

                                            UTF8bytes = Encoding.UTF8.GetBytes("#CONFIG_END" + Environment.NewLine);
                                            RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                                            Thread.Sleep(delay_time2);

                                            #region 寫入SleeveName至DataBase                         
                                            //SQL語法：                              
                                            strSQL = "UPDATE snData set sn = @sn, batchNum = @batchNum, fwVersion = @fwVersion, sleeveName = @sleeveName, buildDate = @buildDate, pcbVersion = @pcbVersion,housingVersion = @housingVersion where deviceID = @deviceID";
                                            if (string.IsNullOrEmpty(strSQL) == false)
                                            {
                                                //添加參數
                                                OleDbParameter[] pars3 = new OleDbParameter[] {
                                            new OleDbParameter("@sn",intNextSn.ToString().PadLeft(SnLength, '0')),
                                            new OleDbParameter("@batchNum",batchNum),
                                            new OleDbParameter("@fwVersion",fwVersion),
                                            new OleDbParameter("@sleeveName",sleeveName),
                                            new OleDbParameter("@buildDate",buildDate),
                                            new OleDbParameter("@pcbVersion",pcbVer),
                                            new OleDbParameter("@housingVersion",housingVer),
                                            new OleDbParameter("@deviceID",deviceID)
                                                                };
                                                //執行SQL
                                                string errorInfo3 = accessHelper.ExecSql(strSQL, pars3);
                                                if (errorInfo3.Length != 0)
                                                {
                                                    MessageBox.Show("更新失敗！" + errorInfo3);
                                                }
                                                else
                                                {
                                                    //進入出貨模式
                                                    //UTF8bytes = Encoding.UTF8.GetBytes("#SHIP_MODE" + Environment.NewLine);
                                                    //RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                                                    //Thread.Sleep(delay_time2);
                                                    Console.WriteLine("更新snData完成3245");
                                                }

                                            }
                                            #endregion
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.ToString());
                                        }
                                        #endregion
                                    }
                                    else
                                    {
                                        MessageBox.Show("ASS_CHECK失敗！");
                                    }
                                    #endregion
                                }
                            }
                        }
                        #endregion

                        #region  執行SQL，deviceID已存在寫入deviceData一筆資料和設定FW
                        else if (boolDeviceReceive) //deviceID已存在,故只寫入測試資料  
                        {
                            #region 寫入測試資料庫

                            //SQL語法：       
                            strSQL = "insert into deviceData(sn,deviceID,batchNum,sleeve,buildDate,assCheck,accXmax,accXmin,accYmax,accYmin,accZmax,accZmin," +
                                "gyroXmax,gyroXmin,gyroYmax,gyroYmin,mouseXmax,mouseXmin,mouseYmax,mouseYmin,mouseSmax,mouseSmin,mouseFmax,mouseFmin," +
                                "mouseImax,mouseImin,IRmax,IRmin,batterymax,batterymin,mounting)" +
                                " VALUES(@sn,@deviceID,@batchNum,@sleeve,@buildDate,@assCheck,@accXmax,@accXmin,@accYmax,@accYmin,@accZmax,@accZmin," +
                                "@gyroXmax,@gyroXmin,@gyroYmax,@gyroYmin,@mouseXmax,@mouseXmin,@mouseYmax,@mouseYmin,@mouseSmax,@mouseSmin,@mouseFmax," +
                                "@mouseFmin,@mouseImax,@mouseImin,@IRmax,@IRmin,@batterymax,@batterymin,@mounting)";
                            if (string.IsNullOrEmpty(strSQL) == false)
                            {
                                //添加參數
                                OleDbParameter[] pars = new OleDbParameter[] {
                                            new OleDbParameter("@sn",intNextSn.ToString().PadLeft(SnLength, '0')),
                                            new OleDbParameter("@deviceID",deviceID),
                                            new OleDbParameter("@batchNum",batchNum),
                                            new OleDbParameter("@sleeve",sleeveName),
                                            new OleDbParameter("@buildDate",DateTime.Now.ToString("yyyy-MM-dd HH:mm")),//改為寫入測試時間
                                            new OleDbParameter("@assCheck",assCheck),
                                            new OleDbParameter("@accXmax",accXmax),
                                            new OleDbParameter("@accXmin",accXmin),
                                            new OleDbParameter("@accYmax",accYmax),
                                            new OleDbParameter("@accYmin",accYmin),
                                            new OleDbParameter("@accZmax",accZmax),
                                            new OleDbParameter("@accZmin",accZmin),
                                            new OleDbParameter("@gyroXmax",gyroXmax),
                                            new OleDbParameter("@gyroXmin",gyroXmin),
                                            new OleDbParameter("@gyroYmax",gyroYmax),
                                            new OleDbParameter("@gyroYmin",gyroYmin),
                                            new OleDbParameter("@mouseXmax",mouseXmax),
                                            new OleDbParameter("@mouseXmin",mouseXmin),
                                            new OleDbParameter("@mouseYmax",mouseYmax),
                                            new OleDbParameter("@mouseYmin",mouseYmin),
                                            new OleDbParameter("@mouseSmax",mouseSmax),
                                            new OleDbParameter("@mouseSmin",mouseSmin),
                                            new OleDbParameter("@mouseFmax",mouseFmax),
                                            new OleDbParameter("@mouseFmin",mouseFmin),
                                            new OleDbParameter("@mouseImax",mouseImax),
                                            new OleDbParameter("@mouseImin",mouseImin),
                                            new OleDbParameter("@IRmax",IRmax),
                                            new OleDbParameter("@IRmin",IRmin),
                                            new OleDbParameter("@batterymax",batterymax),
                                            new OleDbParameter("@batterymin",batterymin),
                                           new OleDbParameter("@mounting",mountingSwitch)
                                                                };
                                //執行SQL
                                string errorInfo = accessHelper.ExecSql(strSQL, pars);
                                if (errorInfo.Length != 0)
                                {
                                    MessageBox.Show("寫入失敗！" + errorInfo);
                                }
                            }
                            #endregion
                            boolMountingSwitch = false;
                            #region Config寫入FW，如果FFT測試PASS
                            if (assCheck == "Pass")
                            {
                                #region FFT PASS
                                byte[] UTF8bytes = Encoding.UTF8.GetBytes("#SET_CONFIG_DATA" + Environment.NewLine);
                                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                                Thread.Sleep(delay_time2);

                                UTF8bytes = Encoding.UTF8.GetBytes("Housing_Version:" + housingVer + Environment.NewLine);
                                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                                Thread.Sleep(delay_time2);

                                UTF8bytes = Encoding.UTF8.GetBytes("PCBA_Version:" + pcbVer + Environment.NewLine);
                                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                                Thread.Sleep(delay_time2);

                                UTF8bytes = Encoding.UTF8.GetBytes("Batch_ID:" + batchNum + Environment.NewLine);
                                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                                Thread.Sleep(delay_time2);

                                string date1 = DateTime.Now.ToString("yyyy MMM dd", CultureInfo.CreateSpecificCulture("en-US"));
                                UTF8bytes = Encoding.UTF8.GetBytes("Build_Date:" + buildDate + Environment.NewLine);
                                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                                Thread.Sleep(delay_time2);

                                UTF8bytes = Encoding.UTF8.GetBytes("Mounted_Sleeve:" + sleeveName + Environment.NewLine);
                                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                                Thread.Sleep(delay_time2);

                                UTF8bytes = Encoding.UTF8.GetBytes("Assembly_Serial_Number:" + strNextSn.ToString().PadLeft(SnLength, '0') + Environment.NewLine);
                                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                                Thread.Sleep(delay_time2);

                                UTF8bytes = Encoding.UTF8.GetBytes("#CONFIG_END" + Environment.NewLine);
                                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                                Thread.Sleep(delay_time2);

                                #region 寫入SleeveName,SN至DataBase                         
                                //SQL語法：                              
                                strSQL = "UPDATE snData set sn = @sn, batchNum = @batchNum, fwVersion = @fwVersion, sleeveName = @sleeveName, buildDate = @buildDate, pcbVersion = @pcbVersion,housingVersion = @housingVersion where deviceID = @deviceID";
                                if (string.IsNullOrEmpty(strSQL) == false)
                                {
                                    //添加參數
                                    OleDbParameter[] pars3 = new OleDbParameter[] {
                                            new OleDbParameter("@sn",intNextSn.ToString().PadLeft(SnLength, '0')),
                                            new OleDbParameter("@batchNum",batchNum),
                                            new OleDbParameter("@fwVersion",fwVersion),
                                            new OleDbParameter("@sleeveName",sleeveName),
                                            new OleDbParameter("@buildDate",buildDate),
                                            new OleDbParameter("@pcbVersion",pcbVer),
                                            new OleDbParameter("@housingVersion",housingVer),
                                            new OleDbParameter("@deviceID",deviceID)
                                                                };

                                    //執行SQL
                                    string errorInfo3 = accessHelper.ExecSql(strSQL, pars3);
                                    if (errorInfo3.Length != 0)
                                    {
                                        MessageBox.Show("更新失敗！" + errorInfo3);
                                    }
                                    else
                                    {
                                        //進入出貨模式
                                        //UTF8bytes = Encoding.UTF8.GetBytes("#SHIP_MODE" + Environment.NewLine);
                                        //RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                                        //Thread.Sleep(delay_time2);
                                        Console.WriteLine("更新snData完成3626");
                                    }

                                }
                                #endregion
                                #endregion
                            }
                            else
                            {
                                MessageBox.Show("ASS_CHECK失敗！");
                            }
                            #endregion
                        }
                        #endregion
                        #endregion
                    }
                    strFeedbackDose = strFeedbackDose + inData;
                    this.BeginInvoke(mi_pcb_feedback, null);
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.ToString());
                }
                #endregion
            }
        }

        //取得此批號完成的總數量, 再將其自ComBoBox刪除
        // 434

        private void cbx_dose_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    string strSQL = String.Format("UPDATE selectData set selectData ='" + cbx_dose.SelectedIndex.ToString() + "'" + "where item = '2'");
            //    access_data.ExecuteSQL(strSQL);

            //    string port_name = cbx_dose.SelectedItem.ToString();
            //    int int_left = port_name.ToString().IndexOf("(");
            //    int int_right = port_name.ToString().IndexOf(")");
            //    int int_length = int_right - int_left;
            //    string comport_num = port_name.ToString().Substring(int_left + 1, int_length - 1);
            //    // string com_name2 = port_name.ToString().Substring(0, int_left);


            //    RS232_DOSE.Close();
            //    RS232_DOSE.Dispose();
            //    RS232_DOSE.PortName = comport_num;
            //    RS232_DOSE.Open();
            //}
            //catch
            //{
            //    //    MessageBox.Show("TTL COM port error, please select another COM port\r\nRS232轉TTL串列埠錯誤，請選擇其它埠");
            //    RS232_DOSE.Close();
            //    RS232_DOSE.Dispose();
            //}
        }

        private void cbx_plc_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPlcCom();
        }

        private void LoadPlcCom()
        {
            try
            {
                //SQL語法：                    
                strSQL = "UPDATE selectData set select_data =@number where com = @com";
                if (string.IsNullOrEmpty(strSQL) == false)
                {
                    //添加參數
                    OleDbParameter[] pars = new OleDbParameter[] {
                                            new OleDbParameter("@number",cbx_plc.SelectedIndex.ToString()),
                                            new OleDbParameter("@com","1")
                                                                };
                    //執行SQL
                    string errorInfo = accessHelper.ExecSql(strSQL, pars);
                    if (errorInfo.Length != 0)
                    {
                        MessageBox.Show("更新失敗！" + errorInfo);
                    }
                }

                //SQL語法：                    
                strSQL = "UPDATE selectData set com_name =@com_name where com = @com";
                if (string.IsNullOrEmpty(strSQL) == false)
                {
                    //添加參數
                    OleDbParameter[] pars = new OleDbParameter[] {
                                            new OleDbParameter("@com_name",cbx_plc.SelectedItem.ToString()),
                                            new OleDbParameter("@com","1")
                                                                };
                    //執行SQL
                    string errorInfo = accessHelper.ExecSql(strSQL, pars);
                    if (errorInfo.Length != 0)
                    {
                        MessageBox.Show("更新失敗！" + errorInfo);
                    }
                }

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

        private void btn_ttl_send_Click(object sender, EventArgs e)
        {
            try
            {
                RS232_DOSE.Close();
                RS232_DOSE.Dispose();
                RS232_DOSE.PortName = GetPortInformation_for_DOSE_COM();
                RS232_DOSE.Open();
                //mi_pcb_feedback = new MethodInvoker(Update_pcb_feedback);
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
            tbx_Pcb_feed_back.AppendText(strFeedbackDose + Environment.NewLine);
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
                    if (int_curr < 0)
                    {
                        int_curr = 0;
                    }
                    //最得充電最大值
                    if (int_curr > charge_max)
                    {
                        charge_max = int_curr;
                    }
                    lbl_charge_curr.Text = charge_max.ToString() + "mA";
                    FFTCurr = int_curr;
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
                if (pointIndex > 600)
                {
                    pointIndex = 0;
                }
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
                //  MessageBox.Show("POWER發生錯誤");

            }
        }

        public class RealtimeChart
        {
            private Chart _chart = null;
            private int chartWidth = 748;
            private int chartHeight = 599;
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
                _chart.Location = new System.Drawing.Point(885, 39);
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
            try
            {
                session.Dispose();
            }
            catch
            {
                MessageBox.Show("POWER發生錯誤");
            }
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

        private void cbxSleeve_SelectedIndexChanged(object sender, EventArgs e)
        {
            // createSnMax();
            sleeveName = cbxSleeve.SelectedItem.ToString();
        }

        #region CRC
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
        #endregion
    }
}
