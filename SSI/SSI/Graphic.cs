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

        public void Filtr(int choice)
        {
            string path = @"../../data/car.jpg";
            Bitmap img = new Bitmap(path);

            Bitmap btmF = new Bitmap(img.Width, img.Height);

            double[][] kernel = new double[3][];

            if (choice == 0)
            {
                kernel[0] = new double[] { -1, -1, -1 };
                kernel[1] = new double[] { -1,  8, -1 };
                kernel[2] = new double[] { -1, -1, -1 };
            }
            else if (choice == 1)
            {
                kernel[0] = new double[] { 1, 2, 1 };
                kernel[1] = new double[] { 2, 4, 2 };
                kernel[2] = new double[] { 1, 2, 1 };
            }
            else if(choice == 2)
            {
                kernel[0] = new double[] { -1, -2, -1 };
                kernel[1] = new double[] { -2, 16, -2 };
                kernel[2] = new double[] { -1, -2, -1 };
            }
            else
            {
                kernel[0] = new double[] { 0, 0, 0 };
                kernel[1] = new double[] { -5, 5, 0 };
                kernel[2] = new double[] { 0, 0, 0 };
            }

            double[] sum = new double[] { 0, 0, 0 };

            double weight = 0;
            for (int k = 0; k < 3; k++)
            {
                for (int l = 0; l < 3; l++)
                {
                    weight += kernel[k][l];
                }
            }

            for (int i = 0; i < img.Width - kernel.Length; i++)
            {
                for (int j = 0; j < img.Height - kernel[0].Length; j++)
                {
                    sum[0] = 0;
                    sum[1] = 0;
                    sum[2] = 0;
                    for (int k = kernel.Length - 1; k > -1; k--)
                    {
                        for (int l = kernel[0].Length - 1; l > -1; l--)
                        {
                            Color pxl = img.GetPixel(i + kernel.Length - 1 - k,j + kernel[0].Length - 1 - l);
                            sum[0] += pxl.R * kernel[k][l];
                            sum[1] += pxl.G * kernel[k][l];
                            sum[2] += pxl.B * kernel[k][l];
                        }
                    }

                    if (weight != 0)
                    {
                        sum[0] /= weight;
                        sum[1] /= weight;
                        sum[2] /= weight;
                    }

                    for (int m = 0; m < 3; m++)
                    {
                        if (sum[m] < 0) sum[m] = 0;
                        if (sum[m] > 255) sum[m] = 255;
                    }

                    btmF.SetPixel(i, j, Color.FromArgb((int)sum[0], (int)sum[1], (int)sum[2]));

                }
            }

            btmF.Save(@"../../data/ShapeImg.jpg");
        }
    }
}
