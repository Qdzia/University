using System;
namespace Algorytmy.TestFunctions
{
    public class Rastragin : IFunction
    {
        public string GetName() => "Rastragin";

        public double Calculate(double[] input)
        {
            double result = 10.0 * input.Length;

            for (int i = 0; i < input.Length; i++)
            {
                result += (input[i] * input[i]) - 10.0 * Math.Cos(2.0 * Math.PI * input[i]);
            }
            return result;
        }
    }
}