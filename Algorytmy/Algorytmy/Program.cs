using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorytmy.Mod5;
using Algorytmy.Mod3;
using Algorytmy.Mod4;
using System.Collections;

namespace Algorytmy
{
    class Program
    {
        static void Main(string[] args)
        {
            HuffmanCode hmc = new HuffmanCode();
            string massage = "ala ma kota"; 
            massage = hmc.Code(massage).ToString();
            Console.WriteLine(massage);
            massage = hmc.Decode(new BitArray(massage.Select(c => c == '1').ToArray()));
            Console.WriteLine(massage);

            // BoyerMoore.Search("abcd", "abcdabxabcd");
            //Console.WriteLine(KarpaRabina.Search("abcd", "abcabxabcd"));

            //Console.WriteLine(KnuthMorrisPratt.Search("abcd","abcabxabcd"));
            Console.ReadLine();
        }
    }
}
