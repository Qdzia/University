using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorytmy.Mod5;
using Algorytmy.Mod3;
using Algorytmy.Mod4;

namespace Algorytmy
{
    class Program
    {
        static void Main(string[] args)
        {
            string massage = "aAzZ"; 
            massage = CezarCode.Code(massage, 24);
            Console.WriteLine(massage);
            massage = CezarCode.Decode(massage, 1);
            Console.WriteLine(massage);

            // BoyerMoore.Search("abcd", "abcdabxabcd");
            //Console.WriteLine(KarpaRabina.Search("abcd", "abcabxabcd"));

            //Console.WriteLine(KnuthMorrisPratt.Search("abcd","abcabxabcd"));
            Console.ReadLine();
        }
    }
}
