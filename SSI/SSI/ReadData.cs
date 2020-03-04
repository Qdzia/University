using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SSI
{
    class ReadData
    {

        public void ReadFlower()
        {

            string[] lines = File.ReadAllLines(@"../../data/Irys.txt");

            double[][] data = new double[lines.Length][];

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

            for (int i = 0; i < 140; i++)
            {

                Console.WriteLine(data[i][4]);
                Console.WriteLine(data[i][5]);
                Console.WriteLine(data[i][6]);
                Console.WriteLine("\n\n");
            }

        }

    }

}
