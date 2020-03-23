using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorytmy.Mod2;
using Algorytmy.Mod3;
using Algorytmy.Mod6;

namespace Algorytmy
{
    class Program
    {
        static void Main(string[] args)
        {
            //Statistic st = new Statistic();
            ListTwo list = new ListTwo();

            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Insert(0,4);
            list.Insert(3,5);
            list.Insert(2,6);
            list.RemoveAt(5);
            list.RemoveAt(3);
            list.RemoveAt(0);
            list.Remove(8);
            list.Remove(1);


            list.Print();
            //st.Analyze();
            Console.ReadLine();
        }
    }
}
