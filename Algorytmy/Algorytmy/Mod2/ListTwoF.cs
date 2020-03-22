using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorytmy.Mod2
{
    class ListTwoF
    {

        Node head, tail;
        int size;
        public ListTwoF()
        {
            head = null;
            tail = null;
            size = 0;
        }

        public void Add(int val)
        {
            if (size == 0)
            {
                head = tail = new Node(val);
                size++;
            }
            else
            {
                Node temp = head;
                while (temp.Next != null)
                    temp = temp.Next;

                tail = temp.Next = new Node(temp, val);
                size++;
            }
        }

        public void Remove(int x)
        {
            Node temp = head;
            Node flag = new Node(tail, x);
            tail = flag;
            while (temp.Value != x )
                temp = temp.Next;

            if (temp != flag) RemoveNode(temp);
            RemoveNode(flag);
        }
        void RemoveNode(Node temp)
        {
            if (temp.Prev == null)
            {
                head = temp.Next;
                temp.Next.Prev = null;
            }
            else if (temp.Next == null)
            {
                tail = temp.Prev;
                temp.Prev.Next = null;
            }
            else
            {
                temp.Prev.Next = temp.Next;
                temp.Next.Prev = temp.Prev;
            }
            size--;
        }
        public void Print()
        {
            Node temp = head;
            while (temp != null)
            {
                Console.Write(temp.Value + " ");
                temp = temp.Next;
            }
            Console.Write("tail: " + tail.Value + " head: " + head.Value);
        }
    }
}
