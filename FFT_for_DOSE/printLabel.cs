using ImageMagick;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing;

namespace FFT_For_DOSE
{
    class printLabel
    {

         public void CrecatePCX()
        {
            var writer = new BarcodeWriter
            {
                Format = BarcodeFormat.DATA_MATRIX,
                Options = new ZXing.Datamatrix.DatamatrixEncodingOptions
                {
                    //   SymbolShape = SymbolShapeHint.FORCE_...,
                    //  MinSize = new Dimension(50,50),
                    //  MaxSize = new Dimension(300,300),
                    Width = 500,
                    Height = 500
                }
            };

            string label = (char)29 + "01" + "05392000095502" + "10" + "0123456789KWIK" + (char)29 + "11" + "220701" + "17" + "230701" + "21" + "00000001";
            writer
                .Write(label)
                .Save(@"C:\Temp\11111.png");


            //png to pcx
            var beforeImage = new MagickImage(@"C:\Temp\barcode.png");
            using (MagickImage image = new MagickImage(beforeImage))
            {
                image.Format = MagickFormat.Pcx;
                //     image.ColorType = ColorType.Palette;
                image.Write(@"C:\Temp\barcode.pcx");
            }
        }
    }
}
