using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorytmy.Mod3
{
    class Floyd
    {
        int V = 4;
        public void Init()
        {
            int inf = 99999;
            int[,] graph = new int[,] { { 0, inf, -2, inf },
                                        { 4, 0, 3, inf},
                                        { inf, inf, 0, 2 },
                                        { inf, -1, inf, 0 }};


            Search(graph, 0);
        }

        void Search(int[,] graph, int src)
        {
            for (int k = 0; k < V; k++)
            {
                for (int i = 0; i < V; i++)
                {
                    for (int j = 0; j < V; j++)
                    {
                        if (graph[i, j] > graph[i, k] + graph[k, j])
                            graph[i, j] = graph[i, k] + graph[k, j];
                    }
                }
            }
            PrintArray(graph);
            
        }

        public void PrintArray(int[,] graph)
        {
            for (int i = 0; i < V; i++)
            {
                for (int j = 0; j < V; j++)
                {
                    Console.Write(graph[i, j] + " ");

                }
                Console.WriteLine();
            }

        }
    }
}
