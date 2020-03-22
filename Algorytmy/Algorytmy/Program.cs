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
            ListTwoF list = new ListTwoF();

            list.Add(2);
            list.Add(1);
            list.Add(5);
            list.Add(6);
            list.Add(3);
            list.Remove(3);
            list.Print();
            //st.Analyze();
            Console.ReadLine();
        }
    }
}
