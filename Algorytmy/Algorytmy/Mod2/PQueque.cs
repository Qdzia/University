using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorytmy.Mod2
{
    class PQueque
    {
        int[] tab;
        int first;
        int last;
        int size;

        public PQueque(int s)
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
            else if (first == last)
            {
                int tmp = first;
                first = -1;
                last = -1;
                return tab[tmp];
            }
            else
            {
                int min = tab[first];
                int tmp = 0;
                for(int i =first;i<=last;i++)
                {
                    if (tab[i] < min) min = i;
                }
                tmp = tab[min];
                last--;
                tab[min] = tab[last + 1];
                return tmp;
                    
            }

        }

        public int Count()
        {
            return last - first + 1;
        }

        public void Print()
        {
            for (int i = first; i <= last; i++)
                Console.WriteLine(tab[i]);
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
            if (last == size - 1)
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
