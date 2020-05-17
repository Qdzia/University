using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorytmy.TestFunctions;


namespace Algorytmy.Mod7
{
    class Swarm : IOpti
    {
        public string GetName() => "Swarm";
        private static Random random = new Random();
        public double[] Space = { -10.0, 10.0 };
        public int dimension = 10;
        public int iterarion = 800;
        public int moleculesCount = 100;

        public double velocity = 0.5;
        public double bestPositionFactor = 0.75;
        public double bestSwarmPos = 2;


        public double FindMin(IFunction fun)
        {
            List<Molecule> molecules = new List<Molecule>();
            double[] bestSwarmPosition = RandGenerator.RandomArray(dimension, Space[0], Space[1]);


            for (int i = 0; i < moleculesCount; i++)
            {
                molecules.Add(
                    new Molecule(
                        RandGenerator.RandomArray(dimension, Space[0], Space[1]), 
                        RandGenerator.RandomArray(dimension, -1.0, 1.0))
                    );

                if (fun.Calculate(molecules.Last().bestPosition) < fun.Calculate(bestSwarmPosition))
                    bestSwarmPosition = molecules.Last().bestPosition;
                
            }

            for (int i = 0; i < iterarion; i++)
            {
                foreach (Molecule p in molecules)
                {
                    for (int j = 0; j < dimension; j++)
                    {
                        double randomPositionFactor = random.NextDouble();
                        double randomSwarmFactor = random.NextDouble();

                        p.velocity[j] = (p.velocity[j] * velocity) + bestPositionFactor * randomPositionFactor * 
                            (p.bestPosition[j] - p.position[j]) +bestSwarmPos * randomSwarmFactor * (bestSwarmPosition[j] - p.position[j]);
                    }

                    for (int j = 0; j < dimension; j++) p.position[j] += p.velocity[j];
                    
                    if (fun.Calculate(p.position) < fun.Calculate(p.bestPosition))  p.bestPosition = p.position;
                    if (fun.Calculate(p.position) < fun.Calculate(bestSwarmPosition)) bestSwarmPosition = p.position;
                      
                }
            }
            return fun.Calculate(bestSwarmPosition);
        }
    }
}
