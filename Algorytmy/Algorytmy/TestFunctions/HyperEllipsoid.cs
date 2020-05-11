namespace Algorytmy.TestFunctions
{
    public class HyperEllipsoid : IFunction
    {
        public string GetName() => "HyperEllipsoid";
        public double Calculate(double[] input)
        {
            double result = 0;
            for(int i = 0; i < input.Length; i++)
            {
                for(int j = 0; j <= i; j++)
                {
                    result += input[j]*input[j];
                }
            }
            return result;
        }
    }

}