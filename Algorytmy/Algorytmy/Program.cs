using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorytmy.Mod2;
using Algorytmy.Mod3;

namespace Algorytmy
{
    class Program
    {
        static void Main(string[] args)
        {
            Dijkstra dij = new Dijkstra();
            BFS bfs = new BFS();
            DFS dfs = new DFS();
            Floyd floyd = new Floyd();

            floyd.Init();

            Console.ReadLine();

        }
    }
}
