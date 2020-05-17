using Algorytmy.TestFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Algorytmy.Mod7
{
    class Cuckoo :IOpti
    {
        public string GetName() => "Cuckoo";
        public int dimension = 10;
        public int iteration = 10000;
        public int iterationWalk = 100;
        public int nestCount = 100;
        public double walkSize = 0.1;
        public double survivaleRate = 0.8;

        public double[] Space = new double[] { -10.0, 10.0 };
        private static Random rand = new Random();


        public double FindMin(IFunction fun)
        {
            List<double[]> nests = new List<double[]>();

            for (int i = 0; i < nestCount; i++) nests.Add(RandGenerator.RandomArray(dimension, Space[0], Space[1]));
            
            for (int i = 0; i < iteration; i++)
            {
                int NestIndex = rand.Next(0, nests.Count);
                double[] flightResult = Move(nests[NestIndex], iterationWalk);
                int cNestIndex = ChooseNest(NestIndex, nests);

                if (fun.Calculate(flightResult) <= fun.Calculate(nests[cNestIndex]))
                    nests[cNestIndex] = flightResult;
                    
                nests = nests.OrderBy(x => fun.Calculate(x)).ToList();
                Kill(nests, survivaleRate);

                for (int j = nests.Count; j < nestCount; j++)
                    nests.Add(RandGenerator.RandomArray(dimension, Space[0], Space[1]));
            }

            nests = nests.OrderBy(x => fun.Calculate(x)).ToList();
            return fun.Calculate(nests[0]);
        }

        private int ChooseNest(int NestIndex, List<double[]> nests)
        {
            int cNestIndex = NestIndex;
            while (cNestIndex == NestIndex) cNestIndex = rand.Next(0, nests.Count);
            return cNestIndex;
        }

        private void Kill(List<double[]> population, double survivaleRate)
        {
            int index = (int)((double)population.Count * survivaleRate);
            population.RemoveRange(index, population.Count - index);
        }

        private double[] Move(double[] start, int iteration)
        {
            double[] result = new double[start.Length];
            start.CopyTo(result, 0);
            for (int i = 0; i < iteration; i++)
            {
                for (int j = 0; j < result.Length; j++)
                    result[j] += RandGenerator.RandomNormal(-1.0, 1.0, 100) * walkSize;
            }
            return result;
        }
       
    }
}

