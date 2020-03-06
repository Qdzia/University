using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorytmy.Mod2
{
    class Stack
    {
        int[] tab;
        int last;
        int size;

        Stack(int s)
        {
            tab = new int[s];
            last = -1;
            size = s;
        }

        public void Push(int num)
        {
            if (last != size - 1)
            {
                last++;
                tab[last] = num;
            }
            else
            {
                Console.WriteLine("Stack is full");
            }
        }

        public int Pop()
        {
            if (last != -1)
            {
                last--;
                return tab[last + 1];
            }
            else
            {
                Console.WriteLine("Stack is empty");
                return -1;
            }
        }

        public int Peek()
        {
            if (last != -1)
                return tab[last];
           Console.WriteLine("Stack is empty");
           return -1;
        }

        public bool isEmpty()
        {
            if (last == -1)
                return true;
            else
                return false;
        }

        public bool isFull()
        {
            if (last == size - 1)
                return true;
            else
                return false;
        }
        public int Count()
        {
            return last + 1;
        }

        public void Print()
        {
            for (int i = 0; i <= last; i++)
                Console.WriteLine(tab[i]);
        }
    }
}
