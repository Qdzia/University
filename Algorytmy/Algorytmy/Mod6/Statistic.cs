using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorytmy.Mod6
{
    class Statistic
    {
        public void Analyze()
        {

            //int[] arr2 = (int[])arr.Clone();
            //int[] arr3 = CreateArr(2000);
            int[] arr = CreateArr(20000);
            Time(arr);

        }
        int[] CreateArr(int num)
        {
            int[] arr = new int[num*2];
            Random r = new Random();
            int rInt = 0;

            for (int i = 0; i < num*2; i++)
            {
                rInt= r.Next(-num, num);
                arr[i] = rInt;
            }
            return arr;
        }

        double[] Time(int[] arr)
        {
            double[] results = new double[6];
            int n = arr.Length;
            int max = arr.Max();
            int min = arr.Min();

            BubbleSort b = new BubbleSort();
            QuickSort q = new QuickSort();
            HeapSort h = new HeapSort();
            ShellSort s = new ShellSort();
            MergeSort m = new MergeSort();
            CountingSort c = new CountingSort();


            //q.Quick(arr, 0, n - 1);
            //b.Bubble(arr);
            //h.Sort(arr);
            //s.Sort(arr);
            //m.Sort(arr, 0, n - 1);
            //c.Sort(arr, min, max);

            var w0 = System.Diagnostics.Stopwatch.StartNew();
            h.Sort((int[])arr.Clone());
            w0.Stop();
            results[0] = w0.ElapsedMilliseconds;

            var w1 = System.Diagnostics.Stopwatch.StartNew();
            b.Bubble((int[])arr.Clone());
            w1.Stop();
            results[1] = w1.ElapsedMilliseconds;

            Console.WriteLine(results[1]);
            Console.WriteLine(results[0]);
            return results;
        }

    }
}
