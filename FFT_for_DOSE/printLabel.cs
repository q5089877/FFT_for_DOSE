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
        int label_X_Move = -50;
        int label_Y_Move = 8;
        string strNotification = "";

        public void PrintOneLabel(string strSN,string strBLEName,string strBLEName2)
        {
            #region print Short label 
            try
            {
                TSCLIB_DLL.openport("Bar Code Printer TT053-61");
                TSCLIB_DLL.setup("49.81", "8.53", "1.5", "15", "2", "3", "0");
                TSCLIB_DLL.clearbuffer();
                //22-C-DA2-001
                //IZDOSE-3IL3MBIE
                //USE FOR RESEARCH ONLY
                TSCLIB_DLL.windowsfont(300 + label_X_Move, 5 + label_Y_Move, 60, 0, 2, 0, "FreeSans", strSN);
                TSCLIB_DLL.windowsfont(300 + label_X_Move, 60 + label_Y_Move, 60, 0, 2, 0, "FreeSans", strBLEName);
                TSCLIB_DLL.windowsfont(300 + label_X_Move, 120 + label_Y_Move, 60, 0, 2, 0, "FreeSans", strBLEName2);

                TSCLIB_DLL.sendcommand("PRINT 1");
                TSCLIB_DLL.sendcommand("DIRECTION 1");
                TSCLIB_DLL.closeport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            #endregion
        }
    }
}
