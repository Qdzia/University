using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorytmy.Mod6
{
    class QuickSort :ISort
    {
        public string GetName() => "QuickSort";
        public void PerformSorting(double[] arr, int left, int right)
        {
            Quick(arr, left, right);
        }
        int Partition(double[] arr, int left, int right)
        {
            double pivot = arr[right];

            int i = (left - 1);
            for (int j = left; j < right; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    double temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            double temp1 = arr[i + 1];
            arr[i + 1] = arr[right];
            arr[right] = temp1;

            return i + 1;
        }

        public void Quick(double[] arr, int left, int right)
        {
            if (left < right)
            {
                int pi = Partition(arr, left, right);

                Quick(arr, left, pi - 1);
                Quick(arr, pi + 1, right);
            }
        }
        
    }
}
