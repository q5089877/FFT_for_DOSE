using FFT_DOSE;
using ImageMagick;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace FFT_For_DOSE
{
    class printLabel
    {
        #region Label參數
        string deviceSN = "";
        string batchNum = "";
        string gtin = "";
        string bleName = "";
        #endregion

        int label_X_Move = 30;

        public string labenSN
        {
            get { return deviceSN; }
            set { deviceSN = value; }
        }
        public string labenBatNum
        {
            get { return batchNum; }
            set { batchNum = value; }
        }
        public string labenGTIN
        {
            get { return gtin; }
            set { gtin = value; }
        }
        public string labenBLE
        {
            get { return bleName; }
            set { bleName = value; }
        }

        //  public void PrintOneLabel(string deviceSN, string deviceBLEName, string deviceSleeve)
        public void PrintTwoLabel()
        {
            gtinToPCX();

            #region print Short label 
            try
            {
                string dirPath = System.Windows.Forms.Application.StartupPath;

                #region pringLabel
                TSCLIB_DLL.openport("Bar Code Printer TT053-61");
                TSCLIB_DLL.setup("46", "41.5", "1", "15", "0", "3", "0");
                TSCLIB_DLL.clearbuffer();                

                #region big label
                //DataMatrix
                TSCLIB_DLL.downloadpcx(dirPath + "\\GS1.pcx", "GS1.pcx");
                TSCLIB_DLL.sendcommand("PUTPCX 20,40,\"GS1.pcx\"");

                //LOT SN圖示
                TSCLIB_DLL.downloadpcx(dirPath + "\\IZDOSE_LBL02_05.pcx", "IZDOSE_LBL02_05.pcx");
                TSCLIB_DLL.sendcommand("PUTPCX 10,295,\"IZDOSE_LBL02_05.pcx\"");

                //BAT,SN 大數字
                TSCLIB_DLL.windowsfont(200, 500, 80, 0, 2, 0, "FreeSans", batchNum);
                TSCLIB_DLL.windowsfont(200, 600, 80, 0, 2, 0, "FreeSans", deviceSN);

                //Date 大數字
                TSCLIB_DLL.windowsfont(645, 363, 80, 0, 2, 0, "FreeSans", DateTime.Now.ToString("yyyy-MM-dd"));

                //以下為GSI文字
                const int fontX = 480;
                TSCLIB_DLL.windowsfont(fontX, 40, 60, 0, 2, 0, "FreeSans", "(01) " + gtin);
                TSCLIB_DLL.windowsfont(fontX, 95, 60, 0, 2, 0, "FreeSans", "(10) " + batchNum);
                TSCLIB_DLL.windowsfont(fontX, 150, 60, 0, 2, 0, "FreeSans", "(11) " + DateTime.Now.ToString("yyMMdd"));
                TSCLIB_DLL.windowsfont(fontX, 205, 60, 0, 2, 0, "FreeSans", "(17) " + DateTime.Now.AddYears(1).ToString("yyMMdd"));
                TSCLIB_DLL.windowsfont(fontX, 260, 60, 0, 2, 0, "FreeSans", "(21) " + deviceSN);
                #endregion

                #region small label
                //Date
                TSCLIB_DLL.windowsfont(445, 817, 35, 0, 2, 0, "FreeSans", DateTime.Now.ToString("yyyy-MM-dd"));
                //GTIN
                TSCLIB_DLL.windowsfont(740, 817, 35, 0, 2, 0, "FreeSans", gtin);
                //SN
                TSCLIB_DLL.windowsfont(740, 862, 35, 0, 2, 0, "FreeSans", deviceSN);
                //BLE Name
                TSCLIB_DLL.windowsfont(910, 935, 35, 0, 2, 0, "FreeSans", bleName);
                #endregion

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
      
        private void gtinToPCX()
        {
            BarcodeWriter barcodeWriter1 = new BarcodeWriter();
            barcodeWriter1.Format = BarcodeFormat.DATA_MATRIX;
            barcodeWriter1.Options = new ZXing.Datamatrix.DatamatrixEncodingOptions();
            barcodeWriter1.Options.Width = 420;
            barcodeWriter1.Options.Height = 420;
            barcodeWriter1.Options.Margin = 0;
            if (gtin == "")
            {
                MessageBox.Show("GTIN為空白,暫用其它值替代");
                labenGTIN = "5391532050133";
            }
            string label = (char)29 + "01" + gtin + "10" + batchNum + (char)29 + "11" + DateTime.Now.ToString("yyMMdd") + "17" + DateTime.Now.AddYears(1).ToString("yyMMdd") + "21" + deviceSN;

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

            //黑白反轉
            using (Image PNGimage = Image.FromFile(Application.StartupPath + @"\GS1.png"))
            {
                using (Bitmap pic = new Bitmap(PNGimage))
                {
                    for (int y = 0; (y
                                <= (pic.Height - 1)); y++)
                    {
                        for (int x = 0; (x
                                    <= (pic.Width - 1)); x++)
                        {
                            Color inv = pic.GetPixel(x, y);
                            inv = Color.FromArgb(255, (255 - inv.R), (255 - inv.G), (255 - inv.B));
                            pic.SetPixel(x, y, inv);
                        }
                    }
                    Image PNGimage2 = pic;
                    PNGimage2.Save(Application.StartupPath + @"\GS2.png");
                    PNGimage2.Dispose();
                }
            }

            //png to pcx
            var beforeImage = new MagickImage(Application.StartupPath + @"\GS2.png");
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
    }
}
