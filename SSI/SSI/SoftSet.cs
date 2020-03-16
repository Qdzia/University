using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSI
{
    class SoftSet
    {
        string[] param; 
        int objNum;
        double[][] set;
        double[] results;
        int[] inxP;
        int[] inxO;

        public void Start()
        {
            param = new string[] { "drogie", "tanie", "jeans", "dresowe", "klasyczne", "modern", "fit", "granatowe", "czarne", "na zamek", "na guziki" };
            string[] setA = new string[] { "jeans", "modern", "na zamek" };
            string[] setB = new string[] { "jeans", "klasyczne", "granatowe", "na guziki" };
            double[] weights = new double[] { 1, 1, 1, 1 };

            objNum = 10;
            CreateSet();
            FindBest(setA, weights);
            Print();
            FindBest(setB, weights);
            Print();

            param = new string[] { "świeże", "mrożone", "ostre", "słodkie", "zielone", "czerwone", "lokalne", "tropikalne", "liściaste", "bulwowe" };
            setA = new string[] { "świeże", "ostre", "czerwone" };
            setB = new string[] { "mrożone", "zielone", "słodkie", "liściaste" };
            string[] setC = new string[] { "świeże", "zielone", "czerwone", "słodkie" };

            CreateSet();
            FindBest(setA, weights);
            Print();
            FindBest(setB, weights);
            Print();
            FindBest(setC, weights);
            Print();

        }

        void CreateSet()
        {
            Random rand = new Random();
            set = new double[objNum][];

            for (int i = 0; i < objNum; i++)
            {
                set[i] = new double[param.Length];

                for (int j = 0; j < param.Length; j++)
                {
                    if (rand.NextDouble() > 0.3) set[i][j] = 1;
                    else set[i][j] = 0;
                }
            }
        }

        void FindBest(string[] wishes, double[] weights)
        {
            int n = wishes.Length;
            inxP = new int[n];
            results = new double[objNum];
            
            for (int i = 0; i < n; i++)
                inxP[i] = Array.IndexOf(param, wishes[i]);

            for (int i = 0; i < objNum; i++)
            {
                results[i] = 0;
                for (int j = 0; j < n; j++)
                    results[i] += set[i][inxP[j]] * weights[j];
            }

            double max = results.Max();
            inxO = new int[objNum];

            for (int i = 0; i < objNum; i++)
            {
                if (results[i] == max) inxO[i] = 1;
                else inxO[i] = 0;
            }
        }
        void Print()
        {
            string str = "Nazwa |";
            for (int i = 0; i < param.Length; i++)
            {
                if(inxP.Contains(i))
                    str += String.Format(" {0} ", i);
            }
            Console.WriteLine(str);
            for (int i = 0; i < objNum; i++)
            {
                if (inxO[i] == 1)
                {
                    str = String.Format("Obj{0}  |", i);
                    for (int j = 0; j < param.Length; j++)
                    {
                        if (inxP.Contains(j))
                            str += String.Format(" {0} ", set[i][j]);
                    }
                    Console.WriteLine(str + "  r: " + results[i]);

                }
            }
        }

    }
}
