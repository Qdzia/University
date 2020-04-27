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
            key = key % 25;
            char[] ar = new char[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                int temp = (int)input[i] + key;
                if(temp > 97) temp = (temp > 122) ? temp - 26 : temp;
                else temp = (temp > 90) ? temp - 26 : temp;

                Console.WriteLine((int)input[i]);// a 97 A 65 z 122 Z 90
                ar[i] = (char)temp;
            }
            return new string(ar);
        }
    }
}
