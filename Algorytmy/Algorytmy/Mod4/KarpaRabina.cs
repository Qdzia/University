using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorytmy.Mod4
{
    class KarpaRabina
    {
        const byte BASE = 255;
        const byte MOD = 97;

        public static int Search(string pattern, string input)
        {
            int n = input.Length - pattern.Length + 1;
            int inputVal = 0, patternVal = HashCode(pattern);

            for (int i = 0; i < n; i++)
            {
                inputVal = HashCode(input.Substring(i, pattern.Length));

                if (inputVal == patternVal)
                {
                    if (input.Substring(i, pattern.Length).CompareTo(pattern) == 0)
                        return i;
                }
            }
            return -1;
        }

        private static int HashCode(string text)
        {
            int code = 0;
            foreach (char character in text)
            {
                code *= BASE;
                code += character;
                code %= MOD;
            }
            return code;
        }
    }
}

