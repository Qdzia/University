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

        public void Filtr()
        {
            string path = @"../../data/img.jpg";
            Bitmap img = new Bitmap(path);

            Bitmap btmF = new Bitmap(img.Width, img.Height);

            double[][] kernel = new double[3][];

            kernel[0] = new double[] { -1, -1, -1 };
            kernel[1] = new double[] { -1,  8, -1 };
            kernel[2] = new double[] { -1, -1, -1 };

            double[] sum = new double[] { 0, 0, 0 };

            double weight = 0;
            for (int k = 0; k < 3; k++)
            {
                for (int l = 0; l < 3; l++)
                {
                    weight += kernel[k][l];
                }
            }

            for (int i = 1; i < btmF.Width-2; i++)
            {
                for (int j = 1; j < btmF.Height-2; j++)
                {
                    sum[0] = 0;
                    sum[1] = 0;
                    sum[2] = 0;
                    for (int k = -1; k < 2; k++)
                    {
                        for (int l = -1; l < 2; l++)
                        {
                            Color pxl = img.GetPixel(i+k, j+l);
                            sum[0] += pxl.R * kernel[k + 1][l + 1];
                            sum[1] += pxl.G * kernel[k + 1][l + 1];
                            sum[2] += pxl.B * kernel[k + 1][l + 1];

                            if (weight != 0)
                            {
                                sum[0] = sum[0] / weight;
                                sum[1] = sum[1] / weight;
                                sum[2] = sum[2] / weight;
                            }

                            for (int m = 0; m < 3; m++)
                            {
                                if (sum[m] < 0) sum[m] = 0;
                                if (sum[m] > 255) sum[m] = 255;
                            }

                            btmF.SetPixel(i+k, j+l, Color.FromArgb(1, (int)sum[0], (int)sum[1], (int)sum[2]));
                        }
                    }

                    
                }
            }

            btmF.Save(@"../../data/ShapeImg.jpg");
        }
    }
}
