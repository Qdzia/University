namespace Algorytmy.TestFunctions
{
    public class Sphere : IFunction
    {
        public string GetName() => "Sphere";

        public double Calculate(double[] input)
        {
            double result = 0;
            for (int i = 0; i < input.Length; i++)
            {
                result += input[i] * input[i];
            }
            return result;
        }
    }
}