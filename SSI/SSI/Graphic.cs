using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SSI
{
    class Graphic
    {
        public void ToGrayScale()
        {
            string path = @"../../data/img.jpg";

            Bitmap img = new Bitmap(path);

            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    Color pxl = img.GetPixel(i, j);

                    int avr = (pxl.R + pxl.G + pxl.B) / 3;

                    img.SetPixel(i, j, Color.FromArgb(1, avr, avr, avr));
                }
            }

            img.Save(@"../../data/grayImg.jpg");

        }
    }
}
