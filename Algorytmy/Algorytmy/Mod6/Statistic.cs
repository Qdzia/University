using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorytmy.TestFunctions;

namespace Algorytmy.Mod6
{
    class Statistic
    {
        List<ISort> sorts;
        List<IFunction> testFunctions;
        public Statistic()
        {
            sorts = new List<ISort>();
            sorts.Add(new BubbleSort());
            sorts.Add(new QuickSort());
            sorts.Add(new HeapSort());
            sorts.Add(new ShellSort());
            sorts.Add(new MergeSort());
            //sorts.Add(new CountingSort());

            testFunctions = new List<IFunction>();
            testFunctions.Add(new HyperEllipsoid());
            testFunctions.Add(new Rastragin());
            testFunctions.Add(new Rosenbrock());
            testFunctions.Add(new Shubert());
            testFunctions.Add(new Sphere());
            testFunctions.Add(new StyblinskiTang());
            testFunctions.Add(new SumSquares());
            testFunctions.Add(new Weierstrass());

        }
        public void Analyze()
        {
            Console.WriteLine("To może potrwać kilka minut...");
            TestOnFunctions(100);
            TestOnFunctions(1000);
            TestOnFunctions(10000);
        }
        void TestOnFunctions(int range)
        {
            foreach (var fun in testFunctions)
            {
                double[] arr = new double[range];
                for (int i = 0; i < range; i++)
                {
                    arr[i] = fun.Calculate(new double[] { i });
                }
                Console.WriteLine($"Testuje {fun.GetName()} na przedziale <0,{range}>" );
                Time(arr);
            } 

        }
        void Time(double[] arr)
        {
            int n = arr.Length;
            int left = 0;
            int right = n - 1;

            foreach (var sorter in sorts)
            {
                var sw = Stopwatch.StartNew();
                sorter.PerformSorting((double[])arr.Clone(),left,right);
                sw.Stop();
                Console.WriteLine($"{sorter.GetName()} : {sw.ElapsedMilliseconds}");
            }

        }
  

    }
}
