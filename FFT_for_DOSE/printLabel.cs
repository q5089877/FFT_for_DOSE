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


        public void PrintOneLabel(string strSN,string strBLEName, string StrSleeveName)
        {
            int label_X_Move = 30;

            #region print Short label 
            try
            {
                //創造新PCX
                //  CreatePCX(strSN);

                #region pringLabel

                TSCLIB_DLL.openport("TSC TTP-644MU");
                TSCLIB_DLL.setup("49.92", "8.53", "1", "15", "0", "3", "-0.6");
                TSCLIB_DLL.clearbuffer();
                //Innovation Zed,NovaUCD.....
                TSCLIB_DLL.windowsfont(120 + label_X_Move, 20, 40, 0, 2, 0, "FreeSans", "Innovation Zed");
                TSCLIB_DLL.windowsfont(120 + label_X_Move, 47, 40, 0, 2, 0, "FreeSans", "Nova UCD");
                TSCLIB_DLL.windowsfont(120 + label_X_Move, 74, 40, 0, 2, 0, "FreeSans", "Dublin 4, Ireland");

                //BLE
                TSCLIB_DLL.windowsfont(440 + label_X_Move, 46, 44, 0, 2, 0, "FreeSans", strBLEName);
                TSCLIB_DLL.windowsfont(445 + label_X_Move, 103, 44, 0, 2, 0, "FreeSans", "DOSE-" + StrSleeveName);
                TSCLIB_DLL.windowsfont(445 + label_X_Move, 155, 40, 0, 2, 0, "FreeSans", "2022-09-12");


                //Label PCX
                string str_path = System.Windows.Forms.Application.StartupPath;
                int aa = TSCLIB_DLL.downloadpcx(str_path + "\\label.PCX", "label.PCX");
                int bb = TSCLIB_DLL.sendcommand("PUTPCX 30,25,\"label.PCX\"");


                str_path = System.Windows.Forms.Application.StartupPath;
                int aaa = TSCLIB_DLL.downloadpcx(str_path + "\\GS1.PCX", "GS1.PCX");
                int bbb = TSCLIB_DLL.sendcommand("PUTPCX 640,25,\"GS1.PCX\"");

                //以下為GSI文字
                int fontX = 800;
                TSCLIB_DLL.windowsfont(fontX + label_X_Move, 20, 30, 0, 2, 0, "FreeSans", "(01)05392000095502");
                TSCLIB_DLL.windowsfont(fontX + label_X_Move, 45, 30, 0, 2, 0, "FreeSans", "(10)0123456789KWIK");
                TSCLIB_DLL.windowsfont(fontX + label_X_Move, 70, 30, 0, 2, 0, "FreeSans", "(11)220913");
                TSCLIB_DLL.windowsfont(fontX + label_X_Move, 95, 30, 0, 2, 0, "FreeSans", "(17)250913");
                TSCLIB_DLL.windowsfont(fontX + label_X_Move, 120, 30, 0, 2, 0, "FreeSans", "(21)00000021");
                //DV專用文字
                TSCLIB_DLL.windowsfont(fontX + label_X_Move, 146, 35, 0, 2, 0, "FreeSans", strSN);
                TSCLIB_DLL.windowsfont(fontX + label_X_Move, 172, 35, 0, 2, 0, "FreeSans", "NOT FOR SALE");

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

        void CreatePCX(string strNextSn)
        {
            string strDir = System.Windows.Forms.Application.StartupPath;
            var writer = new BarcodeWriter
            {
                Format = BarcodeFormat.DATA_MATRIX,
                Options = new ZXing.Datamatrix.DatamatrixEncodingOptions
                {
                    //   SymbolShape = SymbolShapeHint.FORCE_...,
                    //  MinSize = new Dimension(50,50),
                    //  MaxSize = new Dimension(300,300),
                    Width = 181,
                    Height = 181
                    //181 為正確的
                }
            };

            string label = (char)29 + "01" + "05392000095502" + "10" + "0123456789KWIK" + (char)29 + "11" + "220912" + "17" + "250912" + "21" + strNextSn;
            writer
                .Write(label)
                .Save(strDir + "\\GS1.png");


            //png to pcx
            var beforeImage = new MagickImage(strDir + "\\GS1.png");
            using (MagickImage image = new MagickImage(beforeImage))
            {
                //增加轉換為黑白色彩
                image.Format = MagickFormat.Pcx;
                image.ColorType = ColorType.Palette;
                // image.Write(@"C:\Temp\barcode.pcx");
                //取得目錄字串

                image.Write(strDir + "\\GS1.PCX");
            }
        }
    }
}
