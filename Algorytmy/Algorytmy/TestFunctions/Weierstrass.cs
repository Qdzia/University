using System;

namespace Algorytmy.TestFunctions
{
    public class Weierstrass : IFunction
    {
        public string GetName() => "Weierstrass";

        public double Calculate(double[] input)
        {
            double result = 0;
            for (int i = 0; i < input.Length; i++)
            {
                result += Math.Pow(Math.Abs(input[i] + 0.5), 2.0);
            }
            return result;
        }
    }


}