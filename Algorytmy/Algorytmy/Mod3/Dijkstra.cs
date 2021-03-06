﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorytmy.Mod3
{
    class Dijkstra
    {
        int V = 9;
        public void Init() {

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
        public void Search(int[,] graph, int src)
        {
            int[] dist = new int[V]; 

            bool[] sptSet = new bool[V];

            for (int i = 0; i < V; i++)
            {
                dist[i] = int.MaxValue;
                sptSet[i] = false;
            }
            dist[src] = 0;

            for (int count = 0; count < V - 1; count++)
            {
    
                int u = minDistance(dist, sptSet);
                sptSet[u] = true;

                for (int v = 0; v < V; v++)
                {
                    if (!sptSet[v] && graph[u, v] != 0 && dist[u] != int.MaxValue && dist[u] + graph[u, v] < dist[v])
                        dist[v] = dist[u] + graph[u, v];
                }
            }
            printSolution(dist);
        }

        int minDistance(int[] dist,bool[] sptSet)
        {
            int min = int.MaxValue, min_index = -1;

            for (int v = 0; v < V; v++)
                if (sptSet[v] == false && dist[v] <= min)
                {
                    min = dist[v];
                    min_index = v;
                }

            return min_index;
        }

        void printSolution(int[] dist)
        {
            Console.Write("Vertex \t\t Distance "
                          + "from Source\n");
            for (int i = 0; i < V; i++)
                Console.Write(i + " \t\t " + dist[i] + "\n");
        }

    }
}
//BFS bts = new BFS();
//DFS dfs = new DFS();
//Dijkstra dijkstra = new Dijkstra();
//Floyd floyd = new Floyd();

//Console.WriteLine("BTS: ");
//            bts.Init();

//            Console.WriteLine("DFS: ");
//            dfs.Init();

//            Console.WriteLine("Dijkstra: ");
//            dijkstra.Init();

//            Console.WriteLine("Floyd: ");
//            floyd.Init();