using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorytmy.Mod7
{
    public static class RandGenerator
    {
        public static Random R = new Random();
        public static double[] RandomArray(int n, double from, double to)
        {
            double[] d = new double[n];
            for (int i = 0; i < n; i++)
            {
                d[i] = R.NextDouble() * (to - from) + from;
            }
            return d;
        }

        public static double RandomNormal(double min, double max, int tightness)
        {
            double total = 0.0;
            for (int i = 1; i <= tightness; i++)
            {
                total += R.NextDouble();
            }
            return ((total / tightness) * (max - min)) + min;
        }
    }
}
