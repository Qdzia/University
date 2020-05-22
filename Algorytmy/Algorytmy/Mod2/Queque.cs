using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorytmy.Mod2
{
    class Queque
    {
        int[] tab;
        int first;
        int last;
        int size;

        public Queque(int s)
        {
            tab = new int[s];
            first = -1;
            last = -1;
            size = s;
        }

        public void Enqueue(int el)
        {
            if (first == -1)
            {
                first = 0;
                last = 0;
                tab[0] = el;
            }
            else if (last != size - 1)
            {
                last++;
                tab[last] = el;

            }
            else
            {
                Console.WriteLine("Queque is full");
            }

        }


        public int Dequeue()
        {
            if (first == -1)
            {
                Console.WriteLine("Queque is empty");
                return -1;
            }
            else if (first == size - 1)
            {
                first = -1;
                last = -1;
                return tab[size - 1];
            }
            else
            {
                first++;
                return tab[first - 1];
            }

        }

        public int Count()
        {
            return last - first +1 ;
        }

        public void Print()
        {
            for (int i = first; i <= last; i++)
                Console.Write(tab[i]  + " " );
        }

        public bool isEmpty()
        {
            if (first == -1)
                return true;
            else
                return false;
        }

        public bool isFull()
        {
            if (last == size -1)
                return true;
            else
                return false;
        }

        public int Peek()
        {
            return tab[first];
        }

    }
}
