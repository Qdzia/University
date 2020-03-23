using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorytmy.Mod2
{
    class ListTwo
    {
        Node head, tail;
        int size;
        public ListTwo()
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

        public void Insert(int n, int val)
        {
            Node temp = head;

            if (n == 0)
            {
                Node node = new Node(val);
                node.Next = head;
                head.Prev = node;
                head = node;
                size++;
            }
            else if (n < size)
            {
                for (int i = 0; i < n - 1; i++)
                    temp = temp.Next;

                Node node = new Node(temp, temp.Next, val);
                if (temp.Next != null) temp.Next.Prev = node;
                temp.Next = node;
                size++;
            }
            else Console.WriteLine("Out of index ");
        }

        public void Remove(int x)
        {
            Node temp = head;
            while (temp.Value != x && temp.Next != null)
                temp = temp.Next;

            if(temp.Value== x) RemoveNode(temp);
        }

        public void RemoveAt(int inx)
        {
            Node temp = head;
            if (inx >= size) return;
            for (int i = 0; i < inx; i++)
                temp = temp.Next;

            RemoveNode(temp);
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
            Console.Write("tail: "+ tail.Value + " head: " + head.Value );
        }
    }
}
