using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SSI
{
    public class ReadData
    {
        double[][] data;
        public void ReadFlower()
        {

            string[] lines = File.ReadAllLines(@"../../data/Irys.txt");

            data = new double[lines.Length][];

            Shuffle(lines);

            for (int i = 0; i < lines.Length; i++)
            {
                string[] tmp = lines[i].Split(',');
                data[i] = new double[tmp.Length + 2];
                for (int j = 0; j < tmp.Length - 1; j++)
                {
                    data[i][j] = Convert.ToDouble(tmp[j].Replace('.', ','));
                }

                for (int j = 0; j < 3; j++)
                {
                    if (tmp[4] == "Iris-setosa")
                    {
                        data[i][4] = 0;
                        data[i][5] = 0;
                        data[i][6] = 1;
                    }
                    else if (tmp[4] == "Iris-versicolor")
                    {
                        data[i][4] = 0;
                        data[i][5] = 1;
                        data[i][6] = 0;
                    }
                    else if (tmp[4] == "Iris-virginica")
                    {
                        data[i][4] = 1;
                        data[i][5] = 0;
                        data[i][6] = 0;
                    }
                }
            }
            Normalize();
        }

        void Shuffle(string[] list)
        {
            Random rng = new Random();
            int n = list.Length;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                string tmp = list[k];
                list[k] = list[n];
                list[n] = tmp;
            }
        }

        void Normalize()
        {   
            int n = data.Length;
            double max = 0;
            double min = 0;
            for (int j = 0; j < 4; j++)
            {
                for (int k = 0; k < n; k++)
                {
                    if (max < data[k][j]) max = data[k][j];
                    if (min > data[k][j]) min = data[k][j];
                }
                for (int i = 0; i < n; i++)
                {
                    data[i][j] = NormFormula(data[i][j], max, min, 1, 0);
                }
            }
        }

        double NormFormula(double x, double max, double min, double nmax, double nmin)
        {
           x = (x - min) * (nmax - nmin) / (max - min) + nmin;
           return x;
        }

        public void PrintData()
        {
            int n = data.Length;
            for (int i = 0; i < n; i++)
            {
                string str = String.Format("{0:0.0} | {1:0.0} | {2:0.0} | {3:0.0} | {4} | {5} | {6}",
                    data[i][0], data[i][1], data[i][2], data[i][3], data[i][4], data[i][5], data[i][6]);
                Console.WriteLine(str);
            }

        }

    }

}
