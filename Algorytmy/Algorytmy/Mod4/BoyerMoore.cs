using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorytmy.Mod4
{
    class BoyerMoore
    {
        static int CHARS = 256;
        static void BadTable(char[] str, int size, int[] badchar)
        {
            int i;
  
            for (i = 0; i < CHARS; i++)
                badchar[i] = -1;
 
            for (i = 0; i < size; i++)
                badchar[(int)str[i]] = i;
        }
        static int Max(int a, int b) => (a > b) ? a : b; 
        public static void Search(string pattern, string input)
        {
            char[] text = input.ToCharArray();
            char[] pat = pattern.ToCharArray();

            int m = pat.Length;
            int n = text.Length;

            int[] badchar = new int[CHARS];

            BadTable(pat, m, badchar);

            int inx = 0; 
 
            while (inx <= (n - m))
            {
                int j = m - 1;

                while (j >= 0 && pat[j] == text[inx + j])
                    j--;

                if (j < 0)
                {
                    Console.WriteLine("Patterns on: " + inx);
                    if (inx + m < n) 
                        inx += m - badchar[text[inx + m]];
                    else 
                        inx += 1;
                }
                else
                    inx += Max(1, j - badchar[text[inx + j]]);
            }
        }

    }



}
