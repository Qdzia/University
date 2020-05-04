using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorytmy.Mod5
{
    class CezarCode
    {
        public static string Decode(string input, int key) => Code(input, -key);
        public static string Code(string input, int key)
        {
            char[] ar = new char[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                int tmp = (int)input[i] + key;
                ar[i] = (char)tmp;
            }
            return new string(ar);
        }
    }
}
