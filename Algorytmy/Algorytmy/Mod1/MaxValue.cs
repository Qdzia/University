using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorytmy
{
    class MaxValue
    {
        public void FindMaxValue()
        {

            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int tmp = numbers[0];

            foreach (int num in numbers)
            {
                if (num > tmp) tmp = num; 
            }

            Console.Write("Max value is: " + tmp);
        }
        

    }
}
