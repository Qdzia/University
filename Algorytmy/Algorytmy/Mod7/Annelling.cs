using System;
using Algorytmy.TestFunctions;

namespace Algorytmy.Mod7
{
    public class Annealing : IOpti
    {
        public string GetName() => "Annealing";
        public int iterTreshold = 10000;
        public double maxTemp = 1000;
        public int dimensions = 10;
        public double[] searchSpace = new double[] { -100, 100 };
        static Random rand = new Random();

        public double FindMin(IFunction function)
        {
            double[] currentState = RandGenerator.RandomArray
                (dimensions, searchSpace[0], searchSpace[1]);

            double T = maxTemp;
            double alpha = 0.999;
            for (int i = 0; i < iterTreshold; i++)
            {
                double[] newState = new double[dimensions];
                currentState.CopyTo(newState,0);
                for(int j = 0; j < dimensions; j++)
                {
                    newState[j] += RandGenerator.RandomNormal(-1.0, 1.0, 1) * T;
                }
                if (AcceptanceProb(function.Calculate(currentState), function.Calculate(newState), T) >= rand.NextDouble())
                    currentState = newState;

                T *= alpha;
            } 
            return function.Calculate(currentState);
        }


        static double AcceptanceProb(double energy, double adjEnergy, double currTemp)
        {
            if (adjEnergy < energy) return 1.0;
            else return Math.Exp(-(adjEnergy - energy) / currTemp);
        }

        
    }
}