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
        public Bitmap ToGrayScale(Bitmap img)
        {
            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    Color pxl = img.GetPixel(i, j);

                    int avr = (pxl.R + pxl.G + pxl.B) / 3;

                    img.SetPixel(i, j, Color.FromArgb(1, avr, avr, avr));
                }
            }
            return img;
        }

        public Bitmap Filtr(double[][] kernel,bool find,Bitmap img)
        {
            Bitmap btmF = new Bitmap(img.Width, img.Height);

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

                    if (find)
                    {
                        if (sum[0] > 200 && sum[1] > 200 && sum[2] > 200)
                            btmF.SetPixel(i, j, Color.Red);
                        else
                            btmF.SetPixel(i, j, Color.FromArgb((int)sum[0], (int)sum[1], (int)sum[2]));
                    }
                    else btmF.SetPixel(i, j, Color.FromArgb((int)sum[0], (int)sum[1], (int)sum[2]));

                }
            }

            return btmF;
        }

        public void FindKeyPoints() 
        {
            string path = @"../../data/car.jpg";
            Bitmap img = new Bitmap(path);

            double[][] k1 = new double[3][];
            double[][] k2 = new double[5][];

            k2[0] = new double[] { 1, 4, 6, 4, 1 };
            k2[1] = new double[] { 4, 16, 24, 16, 4 };
            k2[2] = new double[] { 6, 24, 36, 24, 6 };
            k2[3] = new double[] { 4, 16, 24, 16, 4 };
            k2[4] = new double[] { 1, 4, 6, 4, 1 };

            k1[0] = new double[] { -1, -1, -1 };
            k1[1] = new double[] { -1, 8, -1 };
            k1[2] = new double[] { -1, -1, -1 };

            img = ToGrayScale(img);
            img = Filtr(k2, false, img);
            img = Filtr(k1, false, img);

            k2[0] = new double[] { 0, 0,0, 0, 0 };
            k2[1] = new double[] { 0, 1,-2, 1, 0 };
            k2[2] = new double[] { 0,-2, 5,-2,0 };
            k2[3] = new double[] { 0, 1,-2, 1, 0 };
            k2[4] = new double[] { 0, 0,0, 0, 0 };

            img = Filtr(k2, true, img);

            img.Save(@"../../data/ShapeImg.jpg");
        }
    }
}

/*
 * 
 *          k1[0] = new double[] { 1, -2, 1 };
            k1[1] = new double[] { -2, 5, -2 };
            k1[2] = new double[] { 1, -2, 1 };

             kernel[0] = new double[] { -1, -1, -1 };
             kernel[1] = new double[] { -1,  8, -1 };
             kernel[2] = new double[] { -1, -1, -1 };

             kernel[0] = new double[] { 1, 4, 6, 4, 1};
             kernel[1] = new double[] { 4, 16, 24, 16, 4};
             kernel[2] = new double[] { 6, 24, 36, 24, 6};
             kernel[3] = new double[] { 4, 16, 24, 16, 4};
             kernel[4] = new double[] { 1, 4, 6, 4, 1};

             kernel[0] = new double[] { -1, -2, -1 };
             kernel[1] = new double[] { -2, 16, -2 };
             kernel[2] = new double[] { -1, -2, -1 };

            kernel[0] = new double[] { 0, 0, 0 };
            kernel[1] = new double[] { -5, 5, 0 };
            kernel[2] = new double[] { 0, 0, 0 };

            k1[0] = new double[] { 1, 2, 1 };
            k1[1] = new double[] { 2, 4, 2 };
            k1[2] = new double[] { 1, 2, 1 };
 
 * */
