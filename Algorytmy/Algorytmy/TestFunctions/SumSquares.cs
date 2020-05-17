namespace Algorytmy.TestFunctions
{
    public class SumSquares : IFunction
    {
        public string GetName() => "SumSquares";

        public double Calculate(double[] input)
        {
            double result = 0;
            for (int i = 0; i < input.Length; i++)
            {
                result += i * input[i] * input[i];
            }
            return result;
        }
    }


}