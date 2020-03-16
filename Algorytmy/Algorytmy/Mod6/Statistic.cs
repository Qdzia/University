using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            double[] results =  Time(arr);
            foreach (double res in results)
            {
                Console.WriteLine(res);
            }

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

            Console.WriteLine("Licze...");

            var sw = Stopwatch.StartNew();
            b.Bubble((int[])arr.Clone());
            sw.Stop();
            results[0] = sw.ElapsedMilliseconds;

            sw.Restart();
            q.Quick((int[])arr.Clone(), 0, n - 1);
            sw.Stop();
            results[1] = sw.ElapsedMilliseconds;

            sw.Restart();
            h.Sort((int[])arr.Clone());
            sw.Stop();
            results[2] = sw.ElapsedMilliseconds;

            sw.Restart();
            s.Sort((int[])arr.Clone());
            sw.Stop();
            results[3] = sw.ElapsedMilliseconds;

            sw.Restart();
            m.Sort((int[])arr.Clone(), 0, n - 1);
            sw.Stop();
            results[4] = sw.ElapsedMilliseconds;

            sw.Restart();
            c.Sort((int[])arr.Clone(), min, max);
            sw.Stop();
            results[5] = sw.ElapsedMilliseconds;

            return results;
        }

        

    }
}
