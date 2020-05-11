using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorytmy.Mod6
{
    class ShellSort :ISort
    {
        public string GetName() => "ShellSort";
        public void PerformSorting(double[] arr, int left, int right)
        {
            Sort(arr);
        }

        public void Sort(double[] arr)
        {
            int n = arr.Length;

            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < n; i += 1)
                {
                    double temp = arr[i];

                    int j;
                    for (j = i; j >= gap && arr[j - gap] > temp; j -= gap)
                        arr[j] = arr[j - gap];
                    
                    arr[j] = temp;
                }
            }
        }

    }
}
