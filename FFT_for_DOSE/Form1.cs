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
using System.Data.OleDb;
using FFT_For_DOSE;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using ZXing;
using ImageMagick;

namespace FFT_DOSE
{
    public partial class Form1 : Form
    {
        #region 公用變數
        int batteryFullCurr = 300;  //判斷充電電流是否小於此
        public bool showManage { get; set; }     //控制工單管理頁面 
        printLabel printLabel1;     //建立公用label元件        
        StreamWriter SW;

        #region SN
        int SnLength = 3;           //SN字串長度;
        int intNextSn;              //現在要製作的SN, 數字型別
        string strNextSn = "";      //現在要製作的SN, 字串型別
        string leftSN = "D";         //SN前綴;
        string rightSN = "";        //SN後綴;
        #endregion

        string GTIN = "";           //需隨批號變更內容

        string deviceID = "";       //Device ID
        string bleName = "";        //藍牙名稱
        string fwVersion = "";      //FW版本
        string pcbIQC = "";         //PCB IQC結果
        string StrSleeveName = "";  //Sleeve名稱
        string pcbVer = "";         //PCB版本
        string bottomVer = "";      //Bottom版本
        string assCheck = "";       //此字串用來判斷FFT結果 Pass or Fail      

        string batchNum = "";       //批號
        string PLC_COM = "";
        string POWER_COM = "";

        bool WriteDumpData = false; //用來控制寫入dump date的txt檔用
        bool toShippingMode = false;
        bool checkSTATUSEnd = false;//用來決定是否可以開始判斷測試完成              
        bool useCurrMeter = false;
        int FFTCurr = 0;
        byte[] UTF8bytes;
        // Define some variables
        int numberOfPointsInChart = 30;
        int newX = 0;
        int charge_max = 0;

        //校正參數用
        string buildDate = "", accXmax = "2000", accXmin = "-2000", accYmax = "2000", accYmin = "-2000", accZmax = "2000", accZmin = "-2000"
         , gyroXmax = "", gyroXmin = "", gyroYmax = "", gyroYmin = "", gyroZmax = "", gyroZmin = "", mouseXmax = "", mouseXmin = "", mouseYmax = "", mouseYmin = "", mouseSmax = ""
         , mouseSmin = "", mouseFmax = "", mouseFmin = "", mouseImax = "", mouseImin = "", IRmax = "", IRmin = "", batterymax = "", batterymin = "", mountingSwitch = "";

        int label_X_Move = 30;  //控制LABE位置  

        MethodInvoker miCreateMaxSN;
        AccessHelper accessHelper = new AccessHelper();
        string strSQL;
        static double chart_MAX = 250;

        //設定電流表更新時間
        static int chart_interval = 350;

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
        bool boolAssCheckEnd = false; //勿刪
        bool boolDeviceReceived = false;

        #endregion
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //讀取電流計是否要開啟
            // 讀取檔案內容
            if (File.Exists(Application.StartupPath + @"\meter.txt"))
            {
                string fileContent = File.ReadAllText(Application.StartupPath + @"\meter.txt");
                if (fileContent.Contains("open"))
                {
                    useCurrMeter = true;
                    currGroupBox.Visible = true;
                    lblPowCom.Visible = true;
                    cbx_power.Visible = true;
                }
                // 將檔案內容寫回檔案中以清空檔案內容
                File.WriteAllText(Application.StartupPath + @"\meter.txt", string.Empty);
            }

            printLabel1 = new printLabel();

            //載入使用者名稱到下拉選單
            loadUserName();

            //   showLogForm = false;
            mi_pcb_feedback = new MethodInvoker(Update_pcb_feedback);
            GetPortInformation();

            //初始化上一次選擇  
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

                    if (useCurrMeter == true && temp_item == "3" && Convert.ToUInt16(temp_select) > 0) // power com
                    {
                        cbx_power.SelectedIndex = Convert.ToUInt16(temp_select);
                        POWER_COM = cbx_power.SelectedItem.ToString();
                    }
                }
           
                this.currGroupBox.Controls.Add(this.chart1);
                //Chart
                try
                {
                    timerRealTimeData = new System.Windows.Forms.Timer();
                    timerRealTimeData.Enabled = true;
                    timerRealTimeData.Interval = chart_interval;
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
                // 開啟檔案，如果不存在就建立檔案
                using (StreamWriter outputFile = new StreamWriter(Application.StartupPath + @"\log.txt"))
                {   // 寫入訊息
                    outputFile.WriteLine(ex2);
                }
            }
            #endregion                       
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                session.Dispose();
            }
            catch
            {
                //  MessageBox.Show("電流表通訊錯誤!!");
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

                    if (WriteDumpData)
                    {
                        SW.Write(inData);
                        if (inData.Contains("Assembly_Serial_Number"))
                        {
                            WriteDumpData = false;
                            toShippingMode = true;
                            SW.Close();
                        }
                    }
                    if (inData.Contains("Device ID:") == true)
                    {
                        deviceID = inData.Substring(inData.IndexOf("Device ID") + 10, inData.IndexOf("BLE ID") - (inData.IndexOf("Device ID") + 10)).Replace("\r\n", "");
                        boolDeviceReceived = true; //deviceID接收完成
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
                            bleName = inData.Substring(inData.IndexOf("BLE Device Name") + 23, 8);
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

                    //IQC_PCBA :
                    if (inData.Contains("IQC_PCBA :") == true)
                    {
                        pcbIQC = inData.Substring(inData.IndexOf("IQC_PCBA :") + 10, 4);
                    }

                    //程式一開始會執行#STATUS和checkSTATUSEnd = false, 讓下方程式碼先忽略掉裝置的回傳
                    //到後半段程式會將checkSTATUSEnd設為true, 此時才開始判斷是否測試完畢
                    if (inData.Contains("ASS_CHECK") && inData.Contains("#") == false && checkSTATUSEnd == true)
                    {
                        #region 測試跑完寫入deviceID，同時開始判斷是否pass
                        boolAssCheckEnd = true; //測試跑完
                        assCheck = inData.Substring(inData.IndexOf("ASS_CHECK") + 11, 4);
                        //create building Date
                        buildDate = DateTime.Now.ToString("yyyy MMM dd", CultureInfo.CreateSpecificCulture("en-US"));

                        //判斷deviceID是否不存在於snData, 若是則寫入一筆資料到snData
                        strSQL = string.Format("select * from snData where deviceID = '{0}'", deviceID);
                        string checkDeviceID = accessHelper.readData(strSQL);
                        if (checkDeviceID == "-1" && boolDeviceReceived)
                        {
                            boolDeviceReceived = false;
                            #region*************執行SQL二次，deviceID不存在故同時寫入snData & deviceData 各一筆資料 和設定FW*************
                            //寫入資料庫
                            //SQL語法：     
                            strSQL = "insert into snData(sn,deviceID,bleName,batchNum,fwVersion,sleeveName,buildDate,pcbVersion,housingVersion) VALUES(@sn,@deviceID,@bleName,@batchNum,@fwVersion,@sleeveName,@buildDate,@pcbVersion,@housingVersion)";
                            if (string.IsNullOrEmpty(strSQL) == false)
                            {
                                //添加參數SN之後再寫入                                                    
                                OleDbParameter[] pars = new OleDbParameter[] {
                                            new OleDbParameter("@sn",""),
                                            new OleDbParameter("@deviceID",deviceID),
                                            new OleDbParameter("@bleName",bleName),
                                            new OleDbParameter("@batchNum",batchNum),
                                            new OleDbParameter("@fwVersion",fwVersion),
                                            new OleDbParameter("@sleeveName",StrSleeveName),
                                            new OleDbParameter("@buildDate",buildDate),
                                            new OleDbParameter("@pcbVersion",pcbVer),
                                            new OleDbParameter("@housingVersion",bottomVer)
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
                                            new OleDbParameter("@sn",intNextSn.ToString("D6")),
                                            new OleDbParameter("@deviceID",deviceID),
                                            new OleDbParameter("@batchNum",batchNum),
                                            new OleDbParameter("@sleeve",StrSleeveName),
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
                                    }
                                    #endregion

                                    boolMountingSwitch = false;
                                    #region*************Config寫入FW，如果FFT測試PASS*************
                                    if (assCheck == "Pass" && pcbIQC == "Pass")
                                    {
                                        #region FFT PASS
                                        try
                                        {
                                            byte[] UTF8bytes = Encoding.UTF8.GetBytes("#SET_CONFIG_DATA" + Environment.NewLine);
                                            RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                                            Thread.Sleep(delay_time2);

                                            UTF8bytes = Encoding.UTF8.GetBytes("Housing_Version:" + bottomVer + Environment.NewLine);
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

                                            UTF8bytes = Encoding.UTF8.GetBytes("Mounted_Sleeve:" + StrSleeveName + Environment.NewLine);
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
                                            new OleDbParameter("@sn",intNextSn.ToString("D6")),
                                            new OleDbParameter("@batchNum",batchNum),
                                            new OleDbParameter("@fwVersion",fwVersion),
                                            new OleDbParameter("@sleeveName",StrSleeveName),
                                            new OleDbParameter("@buildDate",buildDate),
                                            new OleDbParameter("@pcbVersion",pcbVer),
                                            new OleDbParameter("@housingVersion",bottomVer),
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
                                                    Console.WriteLine("UPDATE snDate Completed.");
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
                                        MessageBox.Show("DOSE回傳ASS_CHECK失敗!！");
                                    }
                                    #endregion
                                }
                            }
                        }
                        #endregion

                        #region*************執行SQL，deviceID已存在，故只寫入deviceData一筆資料和設定FW*************
                        else if (boolDeviceReceived) //deviceID已存在,故只寫入測試資料  
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
                                            new OleDbParameter("@sn",intNextSn.ToString("D6")),
                                            new OleDbParameter("@deviceID",deviceID),
                                            new OleDbParameter("@batchNum",batchNum),
                                            new OleDbParameter("@sleeve",StrSleeveName),
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
                            if (assCheck == "Pass" && pcbIQC == "Pass")
                            {
                                #region FFT PASS
                                byte[] UTF8bytes = Encoding.UTF8.GetBytes("#SET_CONFIG_DATA" + Environment.NewLine);
                                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                                Thread.Sleep(delay_time2);

                                UTF8bytes = Encoding.UTF8.GetBytes("Housing_Version:" + bottomVer + Environment.NewLine);
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

                                UTF8bytes = Encoding.UTF8.GetBytes("Mounted_Sleeve:" + StrSleeveName + Environment.NewLine);
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
                                            new OleDbParameter("@sn",intNextSn.ToString("D6")),
                                            new OleDbParameter("@batchNum",batchNum),
                                            new OleDbParameter("@fwVersion",fwVersion),
                                            new OleDbParameter("@sleeveName",StrSleeveName),
                                            new OleDbParameter("@buildDate",buildDate),
                                            new OleDbParameter("@pcbVersion",pcbVer),
                                            new OleDbParameter("@housingVersion",bottomVer),
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
                                MessageBox.Show("DOSE回傳ASS_CHECK失敗！");
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

        #region Function集中區-------------------------------------------------------------------

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

        //完成數量，由assCheck + ShippingMode = "Pass" 來判斷
        int getCompletedNumForBatch()
        {
            strSQL = string.Format("SELECT count(*) from (SELECT DISTINCT deviceData.sn FROM shippingMode INNER JOIN deviceData ON shippingMode.deviceID = deviceData.deviceID"
                + " WHERE(((deviceData.assCheck) = 'Pass') AND((deviceData.sleeve) = '{0}') AND((shippingMode.shippingStatus) = 'Pass') AND((deviceData.batchNum) = '{1}')))", StrSleeveName, cbxBatch.SelectedItem.ToString());

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

        //更新UI用
        void Update_pcb_feedback()
        {
            tbx_Pcb_feed_back.AppendText(strFeedbackDose + Environment.NewLine);
        }
        

        //創造下一個SN
        private void createSnMax()
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
                    strNextSn = intNextSn.ToString("D6");
                    if (_snMax != "-1")
                    {
                        //SN = D + Sleeve + SN                        
                        tbxSn.Text = leftSN + StrSleeveName + Convert.ToInt16(strNextSn).ToString("D6");
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
            strSQL = string.Format("SELECT sn FROM shippingMode where deviceID = '{0}' and shippingStatus = '{1}'", deviceID, "Pass");
            string _sn = accessHelper.readData(strSQL);//執行SQL
            if (_sn != "-1")
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

        #region 按鈕事件集中區-------------------------------------------------------------------

        private void btnPNGtoPCX_Click(object sender, EventArgs e)
        {
            BarcodeWriter barcodeWriter1 = new BarcodeWriter();
            barcodeWriter1.Format = BarcodeFormat.DATA_MATRIX;
            barcodeWriter1.Options = new ZXing.Datamatrix.DatamatrixEncodingOptions();
            barcodeWriter1.Options.Width = 300;
            barcodeWriter1.Options.Height = 300;
            barcodeWriter1.Options.Margin = 0;
            if (GTIN == "") { MessageBox.Show("GTIN為空白"); }
            string label = (char)29 + "01" + GTIN + "10" + batchNum + (char)29 + "11" + DateTime.Now.ToString("yyMMdd") + "17" + DateTime.Now.AddYears(1).ToString("yyMMdd") + "21" + tbxSn.Text;

            Image pngTemp = barcodeWriter1.Write(label);

            using (System.Drawing.Image oOrgImg = new Bitmap(pngTemp))
            {
                using (System.IO.MemoryStream oMS = new System.IO.MemoryStream())
                {
                    //將oTarImg儲存（指定）到記憶體串流中
                    oOrgImg.Save(oMS, System.Drawing.Imaging.ImageFormat.Png);
                    //將串流整個讀到陣列中，寫入某個路徑中的某個檔案裡
                    using (System.IO.FileStream oFS = System.IO.File.Open(Application.StartupPath + @"\GS1.png", System.IO.FileMode.OpenOrCreate))
                    { oFS.Write(oMS.ToArray(), 0, oMS.ToArray().Length); }
                }
            }

            ////黑白反轉
            //using (Image PNGimage = Image.FromFile(Application.StartupPath + @"\GS1.png"))
            //{
            //    using (Bitmap pic = new Bitmap(PNGimage))
            //    {
            //        for (int y = 0; (y
            //                    <= (pic.Height - 1)); y++)
            //        {
            //            for (int x = 0; (x
            //                        <= (pic.Width - 1)); x++)
            //            {
            //                Color inv = pic.GetPixel(x, y);
            //                inv = Color.FromArgb(255, (255 - inv.R), (255 - inv.G), (255 - inv.B));
            //                pic.SetPixel(x, y, inv);
            //            }
            //        }
            //        Image PNGimage2 = pic;
            //        PNGimage2.Save(Application.StartupPath + @"\GS2.png");
            //        PNGimage2.Dispose();
            //    }
            //}


            //png to pcx
            var beforeImage = new MagickImage(Application.StartupPath + @"\GS1.png");
            using (MagickImage image = new MagickImage(beforeImage))
            {
                //增加轉換為黑白色彩
                image.Format = MagickFormat.Pcx;
                image.ColorType = ColorType.Palette;
                //取得目錄字串
                image.Write(Application.StartupPath + @"\GS1.PCX");
            }
            beforeImage.Dispose();
        }

        private void btnPrintLabel_Click(object sender, EventArgs e)
        {
            TSCLIB_DLL.openport("Bar Code Printer TT053-61");

            TSCLIB_DLL.setup("49.92", "8.7", "1", "15", "0", "3", "-0.7");

            TSCLIB_DLL.clearbuffer();
            //Innovation Zed,NovaUCD.....
            TSCLIB_DLL.windowsfont(120 + label_X_Move, 20, 40, 0, 2, 0, "FreeSans", "Innovation Zed");
            TSCLIB_DLL.windowsfont(120 + label_X_Move, 47, 40, 0, 2, 0, "FreeSans", "Nova UCD");
            TSCLIB_DLL.windowsfont(120 + label_X_Move, 74, 40, 0, 2, 0, "FreeSans", "Dublin 4, Ireland");

            //BLE
            TSCLIB_DLL.windowsfont(440 + label_X_Move, 42, 44, 0, 2, 0, "FreeSans", "3IG7MBIE");
            TSCLIB_DLL.windowsfont(445 + label_X_Move, 101, 44, 0, 2, 0, "FreeSans", "DOSE-KP");
            TSCLIB_DLL.windowsfont(445 + label_X_Move, 152, 40, 0, 2, 0, "FreeSans", "2022-09-21");


            //Label PCX
            string str_path = System.Windows.Forms.Application.StartupPath;
            int aa = TSCLIB_DLL.downloadpcx(str_path + "\\label.PCX", "label.PCX");
            int bb = TSCLIB_DLL.sendcommand("PUTPCX 30,25,\"label.PCX\"");


            str_path = System.Windows.Forms.Application.StartupPath;
            int aaa = TSCLIB_DLL.downloadpcx(str_path + "\\GS1.PCX", "GS1.PCX");
            int bbb = TSCLIB_DLL.sendcommand("PUTPCX 640,25,\"GS1.PCX\"");

            //以下為GSI文字
            int fontX = 785;
            int fontSize = 40;
            TSCLIB_DLL.windowsfont(fontX + label_X_Move, 20, fontSize, 0, 2, 0, "FreeSans", "(01)05392000095502");
            TSCLIB_DLL.windowsfont(fontX + label_X_Move, 55, fontSize, 0, 2, 0, "FreeSans", "(10)0123456789KWIK");
            TSCLIB_DLL.windowsfont(fontX + label_X_Move, 90, fontSize, 0, 2, 0, "FreeSans", "(11)220913");
            TSCLIB_DLL.windowsfont(fontX + label_X_Move, 125, fontSize, 0, 2, 0, "FreeSans", "(17)250913");
            TSCLIB_DLL.windowsfont(fontX + label_X_Move, 160, fontSize, 0, 2, 0, "FreeSans", "(21)000999");

            TSCLIB_DLL.sendcommand("PRINT 1");
            TSCLIB_DLL.sendcommand("DIRECTION 1");
            TSCLIB_DLL.closeport();
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

        private void cbxBatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //將批號放入公用變數
                batchNum = cbxBatch.SelectedItem.ToString();
                //由批號取得sleeveName, PcbVer, housingVer
                //SQL語法：        
                strSQL = string.Format("select sleeveName,pcbVersion,housingVersion,total from batchData where batchNum = '{0}'", batchNum);
                DataTable dt_selectData = accessHelper.GetDataTable(strSQL);
                for (int i = 0; i < dt_selectData.Rows.Count; i++)
                {
                    StrSleeveName = dt_selectData.Rows[i][0].ToString();
                    pcbVer = dt_selectData.Rows[i][1].ToString();
                    bottomVer = dt_selectData.Rows[i][2].ToString();
                    lblSleeve.Text = StrSleeveName;                         //顯示正在制作的Sleeve在UI上
                    lblBatTotal.Text = dt_selectData.Rows[i][3].ToString(); //批號總數
                    createSnMax();                                          //產生下一個最大SN
                    int _num = getCompletedNumForBatch();                   //取得完成數量

                    //取得GTIN
                    strSQL = string.Format("select gtin from gtin where penName = '{0}'", StrSleeveName);
                    GTIN = accessHelper.readData(strSQL);
                    //批號選擇完成, 刪掉密碼, 鎖定批號
                    tbxPassword.Text = "";
                    cbxBatch.Enabled = false;
                }
            }
            catch
            {
                MessageBox.Show("載入批號相關資訊");
            }

            // 如果批號資料夾不存在, 便建立其資料夾                    
            if (Directory.Exists("C:\\DOSE_DumpData\\" + cbxBatch.Text))
            {
                Console.WriteLine("The directory {0} already exists.", "C:\\DOSE_DumpData\\" + cbxBatch.Text);
            }
            else
            {
                Directory.CreateDirectory("C:\\DOSE_DumpData\\" + cbxBatch.Text);
                Console.WriteLine("The directory {0} was created.", "C:\\DOSE_DumpData\\" + cbxBatch.Text);
            }
        }

        //for DET TEST
        private void btxPrintLabel2_Click(object sender, EventArgs e)
        {
            try
            {
                printLabel1.PrintOneLabel_PCX();
            }
            catch
            {
                MessageBox.Show("載入批號相關資訊");
            }
        }

        private void btnDump_Click(object sender, EventArgs e)
        {
            MessageBox.Show("此功能暫時關閉");            
            //WriteDumpData = true;
            //SW = new StreamWriter("C:\\DOSE_DumpData\\" + cbxBatch.Text + "\\" + tbxSn.Text + ".txt");          
            //try
            //{
            //    RS232_DOSE.Close();
            //    RS232_DOSE.Dispose();
            //    RS232_DOSE.PortName = GetPortInformation_for_DOSE_COM();
            //    RS232_DOSE.Open();

            //    byte[] UTF8bytes = Encoding.UTF8.GetBytes("#DUMP_DATA" + Environment.NewLine);
            //    RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
            //    Thread.Sleep(100);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("ComPort Error!");
            //}
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            try
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
            catch
            {
                MessageBox.Show("DOSE COM PORT錯誤");
            }
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

        private void btnOpenManage_Click(object sender, EventArgs e)
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
                            if (showManage == false)
                            {
                                FormManage FormManage1 = new FormManage(showManage);
                                FormManage1.Owner = this;
                                FormManage1.Show();
                                showManage = true;
                            }
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

        private void btn_ttl_send_Click(object sender, EventArgs e)
        {
            try
            {
                RS232_DOSE.Close();
                RS232_DOSE.Dispose();
                RS232_DOSE.PortName = GetPortInformation_for_DOSE_COM();
                RS232_DOSE.Open();

                byte[] UTF8bytes = Encoding.UTF8.GetBytes(tbx_ttl_send.Text + Environment.NewLine);
                RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                Thread.Sleep(50);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ComPort Error!");
            }
        }

        private void btn_clr_pcb_Click(object sender, EventArgs e)
        {
            tbx_Pcb_feed_back.Text = "";
        }

        private void btn_clear_com_Click(object sender, EventArgs e)
        {
            ComClear();
        }

        private async void btn_ass_chk_Click(object sender, EventArgs e)
        {
            if (cbxBatch.SelectedItem != null)
            {
                try
                {
                    //initial data
                    deviceID = "";       //Device ID
                    bleName = "";        //藍牙名稱
                    fwVersion = "";      //FW版本
                    pcbIQC = "";      //PCB IQC結果
                    StrSleeveName = "";       //Sleeve名稱
                    pcbVer = "";         //PCB版本
                    bottomVer = "";      //Bottom版本
                    assCheck = "";       //此字串用來判斷FFT結果 Pass or Fail   
                    checkSTATUSEnd = false;
                    CheckShipping = true;
                    strSQL = string.Format("select sleeveName from batchData where batchNum = '{0}'", cbxBatch.SelectedItem.ToString()); //取得sleeveName                                                                                 
                    StrSleeveName = accessHelper.readData(strSQL);//執行SQL
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    StrSleeveName = "";
                }

                //    if (StrSleeveName != "" && pcbVer != "" && bottomVer != "")
                {
                    #region ASS_CHECK

                    charge_max = 0;
                    strFeedbackDose = "";
                    try
                    {
                        RS232_DOSE.Close();
                        RS232_DOSE.Dispose();
                        RS232_DOSE.PortName = GetPortInformation_for_DOSE_COM();
                        RS232_DOSE.Open();

                        int delay_time = 100;

                        //設定IR threshold Max
                        UTF8bytes = Encoding.UTF8.GetBytes("#SET_ASS_TH" + Environment.NewLine);
                        RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                        Thread.Sleep(delay_time);

                        UTF8bytes = Encoding.UTF8.GetBytes("IR_Max:2500" + Environment.NewLine);
                        RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                        Thread.Sleep(delay_time);

                        UTF8bytes = Encoding.UTF8.GetBytes("#ASS_TH_END" + Environment.NewLine);
                        RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                        Thread.Sleep(delay_time);
                        //設定IR threshold Max------End


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

                        #region 取得批號總數 
                        strSQL = string.Format("SELECT total FROM batchData where batchNum = '{0}'", cbxBatch.SelectedItem.ToString());
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
                                if (boolDeviceReceived) //接收到回傳繼續往下
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
                                // boolAssCheckEnd = true 代表測試跑完
                                if (boolAssCheckEnd)
                                {
                                    boolAssCheckEnd = false;
                                    //#SET_CONFIG_DATA 
                                    //Mounted_Sleeve:       
                                    UTF8bytes = Encoding.UTF8.GetBytes("#SET_CONFIG_DATA" + Environment.NewLine);
                                    RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                                    Thread.Sleep(500);

                                    UTF8bytes = Encoding.UTF8.GetBytes("Housing_Version:" + bottomVer + Environment.NewLine);
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

                                    UTF8bytes = Encoding.UTF8.GetBytes("Mounted_Sleeve:" + StrSleeveName + Environment.NewLine);
                                    RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                                    Thread.Sleep(delay_time2);

                                    //將SN補0並在左邊增加文字
                                    strNextSn = leftSN + StrSleeveName + Convert.ToInt16(strNextSn).ToString("D6");
                                    UTF8bytes = Encoding.UTF8.GetBytes("Assembly_Serial_Number:" + strNextSn + Environment.NewLine);
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
                            WriteDumpData = true; //用來判斷dump_data是否寫入完成


                            // 如果批號資料夾不存在, 便建立其資料夾                    
                            if (Directory.Exists("C:\\DOSE_DumpData\\" + cbxBatch.Text))
                            {
                                Console.WriteLine("The directory {0} already exists.", "C:\\DOSE_DumpData\\" + cbxBatch.Text);
                            }
                            else
                            {
                                Directory.CreateDirectory("C:\\DOSE_DumpData\\" + cbxBatch.Text);
                                Console.WriteLine("The directory {0} was created.", "C:\\DOSE_DumpData\\" + cbxBatch.Text);
                            }
                            SW = new StreamWriter("C:\\DOSE_DumpData\\" + cbxBatch.Text + "\\" + tbxSn.Text + ".txt");

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
                                if (assCheck == "Pass" && pcbIQC == "Pass")
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
                                                MessageBox.Show("寫入成功! " + errorInfo);
                                                MessageBox.Show("進入出貨模式，請將其它 Code Uncomment才能真的進入出貨模式");

                                                //進入出貨模式
                                                //UTF8bytes = Encoding.UTF8.GetBytes("#SHIP_MODE" + Environment.NewLine);
                                                //RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                                                //Thread.Sleep(delay_time2);
                                              
                                                //將SN補0並在左邊增加文字
                                                strNextSn = leftSN + StrSleeveName + Convert.ToInt16(strNextSn).ToString("D6");
                                              
                                                printLabel1.PrintOneLabel(strNextSn, bleName, StrSleeveName);

                                                //將SN增加為1
                                                miCreateMaxSN = new MethodInvoker(this.createSnMax);
                                                this.BeginInvoke(miCreateMaxSN);

                                                //進入Shipping Mode，須確定dump data寫入完成
                                                if (WriteDumpData && toShippingMode)
                                                {
                                                    toShippingMode = false; //進入ShippingMode, 重置bool

                                                    //UTF8bytes = Encoding.UTF8.GetBytes("#SHIP_MODE" + Environment.NewLine);
                                                    //RS232_DOSE.Write(UTF8bytes, 0, UTF8bytes.Length);
                                                    //Thread.Sleep(300);
                                                }
                                            }
                                        }
                                        #endregion
                                        #endregion
                                    }
                                    #endregion
                                }
                                else
                                {
                                    MessageBox.Show("ASS_CHECK失敗，無法進入休眠！");
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
                            MessageBox.Show("數量異常");
                        }

                    }
                    catch
                    {
                        MessageBox.Show("DOSE COM PORT異常");
                    }
                }
            }
            else
            {
                MessageBox.Show("批號未選擇");
            }
        }

        #endregion      

        #region COM PORT區-------------------------------------------------------------------

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

                try
                {
                    session = GlobalResourceManager.Open(VISA_ADDRESS) as IMessageBasedSession;

                    // Enable the Termination Character.                
                    session.TerminationCharacterEnabled = true;
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

                        Console.WriteLine("Current returned: {0}", idnResponse);
                        Thread.Sleep(100);

                        formattedIO.WriteLine("OUTPut 1");
                        formattedIO.WriteLine("OUTPut 1");

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
                        MessageBox.Show("電流表通訊錯誤!!");
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show("電流表通訊錯誤!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("電流表通訊錯誤!!");
            }
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

        #endregion              

        #region 電表圖區-------------------------------------------------------------------
        //即時電流表
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

        //電流圖
        public class RealtimeChart
        {
            private Chart _chart = null;
            private int chartWidth = 722;
            private int chartHeight = 640;
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
                //Chart1位置
                _chart.Location = new System.Drawing.Point(9, 44);
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
        #endregion

        #region CRC for PLC Using
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

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
