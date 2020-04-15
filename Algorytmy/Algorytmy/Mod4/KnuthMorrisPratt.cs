using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorytmy.Mod4
{
    class KnuthMorrisPratt
    {
        public static int Search(string pattern, string text)
        {
            int k = 0, l = 0;
            int[] last = MakePattern(pattern);

            while (k + l < text.Length)
            {
                if (pattern[l] == text[k + l])
                {
                    l++;
                    if (l == pattern.Length)
                        return k;
                }
                else
                {
                    k = k + l - last[l];
                    if (l > 0)
                        l = last[l];
                }
            }
            return -1;
        }

        private static int[] MakePattern(string pattern)
        {
            int i = 2, j = 0;
            int[] lps = new int[pattern.Length];

            lps[0] = -1;
            lps[1] = 0;

            while (i < pattern.Length)
            {
                if (pattern[i - 1] == pattern[j])
                {
                    lps[i] = j + 1;
                    i++;
                    j++;
                }
                else
                {
                    if (j > 0)
                        j = lps[j];
                    else
                        lps[i] = 0; i++;
                }
            }
            return lps;
        }
    }
}
