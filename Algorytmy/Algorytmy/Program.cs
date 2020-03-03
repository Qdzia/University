using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorytmy
{
    class Program
    {
        static void Main(string[] args)
        {
            PolishNotation a = new PolishNotation();
            a.ConvertNotation();
            a.Reverse();
            Console.ReadLine();

        }
    }
}
