using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorytmy.Mod6
{
    class MergeSort : ISort
    {
        public string GetName() => "MergeSort";
        public void PerformSorting(double[] arr, int left, int right)
        {
            Sort(arr,left,right);
        }
        private void Merge(double[] input, int left, int middle, int right)
        {
            double[] leftArray = new double[middle - left + 1];
            double[] rightArray = new double[right - middle];

            Array.Copy(input, left, leftArray, 0, middle - left + 1);
            Array.Copy(input, middle + 1, rightArray, 0, right - middle);

            int i = 0;
            int j = 0;
            for (int k = left; k < right + 1; k++)
            {
                if (i == leftArray.Length)
                {
                    input[k] = rightArray[j];
                    j++;
                }
                else if (j == rightArray.Length)
                {
                    input[k] = leftArray[i];
                    i++;
                }
                else if (leftArray[i] <= rightArray[j])
                {
                    input[k] = leftArray[i];
                    i++;
                }
                else
                {
                    input[k] = rightArray[j];
                    j++;
                }
            }
        }

        public void Sort(double[] arr, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;

                Sort(arr, left, middle);
                Sort(arr, middle + 1, right);

                Merge(arr, left, middle, right);
            }
        }

    }
}
