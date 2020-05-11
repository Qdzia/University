using System;

namespace Algorytmy.TestFunctions
{
    public class Shubert : IFunction
    {
        public string GetName() => "Shubert";

        public double Calculate(double[] input)
        {
            double result = 1;
            for (int i = 0; i < input.Length; i++)
            {
                double temp = 0;
                for (int j = 1; j < 6; j++)
                {
                    temp += (double)j * Math.Cos(((j + 1) * input[i]) + (double)j);
                }
                result *= temp;
            }
            return result;
        }
    }
}