using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorytmy.Mod3
{
    class BFS
    {
        int V = 9;
        public void Init()
        {

            int[,] graph = new int[,] { { 0, 4, 0, 0, 0, 0, 0, 8, 0 },
                                        { 4, 0, 8, 0, 0, 0, 0, 11, 0 },
                                        { 0, 8, 0, 7, 0, 4, 0, 0, 2 },
                                        { 0, 0, 7, 0, 9, 14, 0, 0, 0 },
                                        { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
                                        { 0, 0, 4, 14, 10, 0, 2, 0, 0 },
                                        { 0, 0, 0, 0, 0, 2, 0, 1, 6 },
                                        { 8, 11, 0, 0, 0, 0, 1, 0, 7 },
                                        { 0, 0, 2, 0, 0, 0, 6, 7, 0 } };


            Search(graph, 0);


        }

        void Search(int[,] graph, int src)
        {
            bool[] visited = new bool[V];

            Queue<int> queue = new Queue<int>();

            visited[src] = true;
            queue.Enqueue(src);

            while (queue.Count() != 0)
            {
                src = queue.Dequeue();
                Console.WriteLine(src);

                for (int i = 0; i < V; i++)
                {
                    if (graph[src, i] > 0 && !visited[i])
                    {
                        queue.Enqueue(i);
                        visited[i] = true;
                    } 
                }

            }



        }
    }
}

