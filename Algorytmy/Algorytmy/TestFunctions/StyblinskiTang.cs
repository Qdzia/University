using System;

namespace Algorytmy.TestFunctions
{
    public class StyblinskiTang : IFunction
    {
        public string GetName() => "StyblinskiTang";

        public double Calculate(double[] input)
        {
            double result = 0;
            for (int i = 0; i < input.Length; i++)
            {
                result += Math.Pow(input[i], 4.0) - (16.0 * input[i] * input[i]) + (5.0 * input[i]);
            }
            return 0.5 * result;
        }
    }


}