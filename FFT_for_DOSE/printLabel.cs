using FFT_DOSE;
using ImageMagick;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace FFT_For_DOSE
{
    class printLabel
    {
        int label_X_Move = 30;
        //  public void PrintOneLabel(string deviceSN, string deviceBLEName, string deviceSleeve)
        public void PrintOneLabel()
        {
            #region print Short label 
            try
            {
                //創造新PCX
                //  CreatePCX(strSN);
                #region pringLabel
                TSCLIB_DLL.openport("Bar Code Printer TT053-61");
                TSCLIB_DLL.setup("46", "41.5", "1", "15", "0", "3", "0");

                TSCLIB_DLL.clearbuffer();
                //Innovation Zed,NovaUCD.....
                for (int i = 0; i < 1200; i += 50)
                {
                    //   TSCLIB_DLL.windowsfont(520, i, 40, 0, 2, 0, "FreeSans", i.ToString());
                }
                //TSCLIB_DLL.windowsfont(0 + label_X_Move, 20, 40, 0, 2, 0, "FreeSans", "9999 Zed");
                //TSCLIB_DLL.windowsfont(0 + label_X_Move, 47, 40, 0, 2, 0, "FreeSans", "Nova UCD");
                //TSCLIB_DLL.windowsfont(0 + label_X_Move, 74, 40, 0, 2, 0, "FreeSans", "Dublin 4, Ireland");

                //BLE
                //TSCLIB_DLL.windowsfont(440 + label_X_Move, 46, 44, 0, 2, 0, "FreeSans", deviceBLEName);
                //TSCLIB_DLL.windowsfont(445 + label_X_Move, 103, 44, 0, 2, 0, "FreeSans", "DOSE-" + deviceSleeve);
                //TSCLIB_DLL.windowsfont(445 + label_X_Move, 155, 40, 0, 2, 0, "FreeSans", "2022-09-12");

                //////Label PCX
                string dirPath = System.Windows.Forms.Application.StartupPath;
                //int aa = TSCLIB_DLL.downloadpcx(str_path + "\\label.PCX", "label.PCX");
                //int bb = TSCLIB_DLL.sendcommand("PUTPCX 30,25,\"label.PCX\"");

                int locationX = 50;
                int locationY = 50;
                TSCLIB_DLL.downloadpcx(dirPath + "\\GS1.PCX", "GS1.PCX");
                TSCLIB_DLL.sendcommand("PUTPCX 50,50,\"GS1.PCX\"");
                TSCLIB_DLL.windowsfont(200, 500, 80, 0, 2, 0, "FreeSans", "LOT XXXXXX");
                TSCLIB_DLL.windowsfont(200, 600, 80, 0, 2, 0, "FreeSans", "SN  XXXXXX");
               
                
                


                //////以下為GSI文字
                ////int fontX = 800;
                ////TSCLIB_DLL.windowsfont(fontX + label_X_Move, 20, 30, 0, 2, 0, "FreeSans", "(01)05392000095502");
                ////TSCLIB_DLL.windowsfont(fontX + label_X_Move, 45, 30, 0, 2, 0, "FreeSans", "(10)0123456789KWIK");
                ////TSCLIB_DLL.windowsfont(fontX + label_X_Move, 70, 30, 0, 2, 0, "FreeSans", "(11)220913");
                ////TSCLIB_DLL.windowsfont(fontX + label_X_Move, 95, 30, 0, 2, 0, "FreeSans", "(17)250913");
                ////TSCLIB_DLL.windowsfont(fontX + label_X_Move, 120, 30, 0, 2, 0, "FreeSans", "(21)00000021");
                //////DV專用文字
                ////TSCLIB_DLL.windowsfont(fontX + label_X_Move, 172, 35, 0, 2, 0, "FreeSans", "NOT FOR SALE");

                TSCLIB_DLL.sendcommand("PRINT 1");
                TSCLIB_DLL.sendcommand("DIRECTION 1");
                TSCLIB_DLL.closeport();
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            #endregion
        }

        public void PrintOneLabel_temp(string strDET, string strBLEName, string StrSleeveName)
        {
            #region print Short label 
            try
            {
                //創造新PCX
                //  CreatePCX(strSN);
                #region pringLabel
                TSCLIB_DLL.openport("Bar Code Printer TT053-61");
                TSCLIB_DLL.setup("49.92", "8.7", "1", "15", "0", "3", "-0.7");
                TSCLIB_DLL.clearbuffer();

                //BLE
                TSCLIB_DLL.windowsfont(350, 20, 65, 0, 2, 0, "FreeSans", strDET);
                TSCLIB_DLL.windowsfont(350, 80, 65, 0, 2, 0, "FreeSans", "BLE:" + strBLEName + " :" + StrSleeveName);
                TSCLIB_DLL.windowsfont(350, 130, 65, 0, 2, 0, "FreeSans", "Not for sale :HW 10.2");
                //22 - IZD - C1 - DE4 - 001~024
                //“Not for sale”
                //“HW10.2”

                TSCLIB_DLL.sendcommand("PRINT 1");
                TSCLIB_DLL.sendcommand("DIRECTION 1");
                TSCLIB_DLL.closeport();
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            #endregion
        }

        public void PrintOneLabel_PCX()
        {
            #region print Short label 
            try
            {
                //創造新PCX
                //  CreatePCX(strSN);
                #region pringLabel
                TSCLIB_DLL.openport("Bar Code Printer TT053-61");
                TSCLIB_DLL.setup("49.92", "8.7", "1", "15", "0", "3", "-0.3");
                TSCLIB_DLL.clearbuffer();

                //Label PCX
                string str_path = System.Windows.Forms.Application.StartupPath;
                int aa = TSCLIB_DLL.downloadpcx(str_path + "\\label2.PCX", "label2.PCX");
                int bb = TSCLIB_DLL.sendcommand("PUTPCX 30,0,\"label2.PCX\"");

                //TSCLIB_DLL.windowsfont(440 + label_X_Move,       50, 36, 0, 2, 0, "FreeSans", "2023-01-07");
                //TSCLIB_DLL.windowsfont(445 + label_X_Move + 100, 97, 36, 0, 2, 0, "FreeSans", "KP");
                //TSCLIB_DLL.windowsfont(445 + label_X_Move + 270, 97, 36, 0, 2, 0, "FreeSans", "DKP000999");
                //TSCLIB_DLL.windowsfont(440 + label_X_Move + 500, 170, 36, 0, 2, 0, "FreeSans", "3IG7MBIE");

                TSCLIB_DLL.sendcommand("PRINT 1");
                TSCLIB_DLL.sendcommand("DIRECTION 1");
                TSCLIB_DLL.closeport();
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            #endregion
        }

        /// <summary>函式說明</summary>
        /// <param name="BleName">藍芽ID</param>
        /// <param name="sleeve">Sleeve型號</param>
        /// <param name="batchNum">批號</param>
        /// <param name="strNextSn">序號</param>
        void CreatePCX(string BleName, string sleeve, string batchNum, string strNextSn)
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
    }
}
