using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorytmy.Mod2
{
    class ListOneC
    {
        Node head;
        int size;
        public ListOneC()
        {
            head = null;
            size = 0;
        }

        public void Add(int val)
        {
            if (size == 0)
            {
                head = new Node(val);
                head.Next = head;
                size++;
            }
            else
            {
                Node temp = head;
                while (temp.Next != head)
                    temp = temp.Next;

                temp.Next = new Node(val);
                temp.Next.Next = head;
                size++;
            }
        }

        public void Remove(int x)
        {
            Node temp = head;
            if (head.Value == x) RemoveHead();
            else
            {
                int count = 0;
                while (temp.Next.Value != x && count < size - 2)
                {
                    temp = temp.Next;
                    count++;
                }
                if (count != size - 2) RemoveNode(temp);
            }
        }

        public void RemoveAt(int inx)
        {
            Node temp = head;
            if (inx == 0) RemoveHead();
            else if (inx < size)
            {
                for (int i = 0; i < inx - 1; i++)
                    temp = temp.Next;

                RemoveNode(temp);
            }
            else Console.WriteLine("Out of index");
        }
        void RemoveHead() 
        {
            Node temp = head;
            while (temp.Next != head)
                temp = temp.Next;

            head = temp.Next.Next;
            temp.Next = head;
            size--;
        }
        void RemoveNode(Node temp)
        {
            if (temp.Next.Next == head)
                temp.Next = head;
            else
                temp.Next = temp.Next.Next;
            size--;
        }

        public void Print()
        {
            Node temp = head;
            while (temp.Next != head)
            {
                Console.Write(temp.Value + " ");
                temp = temp.Next;
            }
            Console.Write(temp.Value + " ");
            Console.Write(" head: " + head.Value);
        }
    }
}
