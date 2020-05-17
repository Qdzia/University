using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorytmy.Mod5;
using Algorytmy.Mod6;
using Algorytmy.Mod7;
using System.Collections;
using Algorytmy.TestFunctions;
using System.Collections;

namespace Algorytmy
{
    class Program
    {
        static void Main(string[] args)
        {
            Statistic stat = new Statistic();

            stat.Analyze();
            // BoyerMoore.Search("abcd", "abcdabxabcd");
            //Console.WriteLine(KarpaRabina.Search("abcd", "abcabxabcd"));

            Console.ReadLine();
        }
    }
}
