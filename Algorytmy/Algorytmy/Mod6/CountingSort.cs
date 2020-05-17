using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorytmy.Mod6
{
    class CountingSort : ISort
    {
        public string GetName() => "CountingSort";
        public void PerformSorting(double[] arr, int left, int right)
        {
            Sort(arr, left, right);
        }

        public void Sort(double[] data, int min, int max)
        {
            double[] count = new double[max - min + 1];
            int z = 0;

            for (int i = 0; i < count.Length; i++)
                count[i] = 0;

            for (int i = 0; i < data.Length; i++)
                count[(int)data[i] - min]++;

            for (int i = min; i <= max; i++)
            {
                while (count[i - min]-- > 0)
                {
                    data[z] = i;
                    ++z;
                }
            }
        }
    }
}
