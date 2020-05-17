using Algorytmy.TestFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorytmy.Mod7
{
    class Firefly : IOpti
    {
        public string GetName() => "Firefly";
        private static Random random = new Random();
        public int generations = 10000;
        public int populations = 30;
        public double absorb = 1;
        public int dimension = 10;
        public double[] Space = { -10.0, 10.0 };

        public static double[] AttractiveSpace = { 0.0, 1.0 };
        public double rndFactor = 0.2;

        private double Calculate(Lift from, Lift to) => 1.0 * Math.Exp(-absorb * Distance(from.Pos, to.Pos) * Distance(from.Pos, to.Pos));
        public double FindMin(IFunction fun)
        {

            List<Lift> population = new List<Lift>();
            for (int i = 0; i < populations; i++)
            {
                Lift l = new Lift(RandGenerator.RandomArray(dimension, Space[0], Space[1]));
                population.Add(l);
            }

            double[] bestPos = RandGenerator.RandomArray(dimension, Space[0], Space[1]);
            double best = fun.Calculate(bestPos);

            for (int l = 0; l < generations; l++)
            {
                for (int i = 0; i < populations; i++)
                {
                    for (int j = 0; j < populations; j++)
                    {
                        if (i == j) continue;
                          
                        if (fun.Calculate(population[j].Pos) < fun.Calculate(population[i].Pos))
                        {
                            double dist = Calculate(population[i], population[j]);

                            double[] Position = new double[dimension];

                            population[i].Pos.CopyTo(Position, 0);

                            for (int k = 0; k < dimension; k++)
                            {
                                Position[k] += (population[j].Pos[k] - population[i].Pos[k])* dist;
                                Position[k] += ((random.NextDouble() - 0.5) * rndFactor);
                            }
                            if (fun.Calculate(Position) < fun.Calculate(population[i].Pos))
                                population[i].Pos = Position;
                        }
                    }
                    double[] pos = population.Aggregate((x, y) => fun.Calculate(x.Pos) < fun.Calculate(y.Pos) ? x : y).Pos;
                    if (fun.Calculate(pos) < best)
                    {
                        bestPos = pos;
                        best = fun.Calculate(bestPos);
                    }
                }
            }
            return fun.Calculate(bestPos);
        }
        private double Distance(double[] from, double[] to)
        {
            double distance = 0;
            for (int i = 0; i < from.Length; i++) distance += Math.Pow(from[i] - to[i], 2.0);
            distance = Math.Sqrt(distance);
            return distance;
        }
    }
}

