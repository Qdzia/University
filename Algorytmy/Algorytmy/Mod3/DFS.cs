using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorytmy.Mod3
{
    class DFS
    {

        int V = 9;
        public void Init()
        {

            int[,] graph = new int[,] { { 0, 1, 0, 0, 0, 0, 0, 1, 0 },
                                        { 1, 0, 1, 0, 0, 0, 0, 1, 0 },
                                        { 0, 1, 0, 1, 0, 1, 0, 0, 1 },
                                        { 0, 0, 1, 0, 1, 1, 0, 0, 0 },
                                        { 0, 0, 0, 1, 0, 1, 0, 0, 0 },
                                        { 0, 0, 1, 1, 9, 0, 1, 0, 0 },
                                        { 0, 0, 0, 0, 0, 1, 0, 1, 1 },
                                        { 1, 1, 0, 0, 0, 0, 1, 0, 1 },
                                        { 0, 0, 1, 0, 0, 0, 1, 1, 0 } };


            Search(graph, 0);


        }

        void Search(int[,] graph, int src)
        {
            bool[] visited = new bool[V];

            Stack<int> stack = new Stack<int>();

            visited[src] = true;
            stack.Push(src);

            while (stack.Count() != 0)
            {
                src = stack.Peek();
                Console.WriteLine(src);

                for (int i = 0; i < V; i++)
                {
                    if (graph[src, i] > 0 && !visited[i])
                    {
                        stack.Push(i);
                        visited[i] = true;
                        break;
                    }
                }

                if (src == stack.Peek()) stack.Pop();

            }



        
    }
}
}
