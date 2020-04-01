using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSI
{
    class Bayes
    {
        public void Classify(double[] parameters, double[][] data, int size)
        {
            double[] numOfElements = new double[size];
            double tolerance = 0.12;

            int n = data[0].Length;
            for (int j = 0; j < size; j++)
            {
                numOfElements[j] = 0;
                for (int i = 0; i < data.Length; i++)
                    if (data[i][n - j - 1] == 1) numOfElements[j]++;
                Console.WriteLine($"Number of Elements({j}): " + numOfElements[j]);
            }

            double[][] probability = new double[size][];
            for(int k = 0;k<size;k++)
                probability[k] = new double[data[0].Length - size];

            for (int j = 0; j < data.Length; j++)
            {
                for (int i = 0; i < data[0].Length - size; i++)
                {
                    if (tolerance > Math.Abs(data[j][i] - parameters[i]))
                    {
                        for (int k = 0; k < size; k++)
                        {
                            if (data[j][n - k - 1] == 1)
                                probability[k][i]++;
                        }
                            
                    }
                }
             }

            double[] outcome = new double[size];

            for (int i = 0; i < size; i++)
                outcome[i] = numOfElements[i]/ data.Length;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < data[0].Length - size; j++)
                {
                    Console.Write(" " + probability[i][j]);
                    outcome[i] *= (probability[i][j] / numOfElements[i]);

                }
                Console.WriteLine();
            }

            double max = 0;
            int indx = 0;
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"Probability({i}): " + outcome[i]);
                if (outcome[i] > max) 
                {
                    max = outcome[i];
                    indx = i;
                }
            }

            Console.WriteLine($"Highest probability-{indx}: " + outcome[indx]);
        }
    }
}
