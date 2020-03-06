using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorytmy.Mod2;

namespace Algorytmy
{
    class Program
    {
        static void Main(string[] args)
        {
            PQueque que = new PQueque(3);

            que.Enqueue(3);
            que.Enqueue(1);
            que.Enqueue(5);
            que.Print();
            Console.WriteLine(que.Dequeue());
            que.Print();

            que.Print();
            Console.WriteLine(que.Count());
            Console.ReadLine();

        }
    }
}
