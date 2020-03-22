using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorytmy.Mod2
{
    class ListOne
    {
        Node head;
        int size;
        public ListOne()
        {
            head = null;
            size = 0;
        }

        public int Size()
        {
            return size;
        }
        public bool isEmpty()
        {
            if (head == null)
                return true;
            else
                return false;
        }

        public void Add(int val)
        {
            if (size == 0)
            {
                head = new Node(val);
                size++;
            }
            else 
            {
                Node temp = head;
                while(temp.Next != null)
                    temp = temp.Next;

                temp.Next = new Node(temp, val);
                size++;
            }
        }
        public void Insert(int n, int val)
        {
            Node temp = head;

            if (n == 0)
            {
               temp = head;
               head = new Node(val);
               head.Next = temp;
               size++;
            }
            else if (n < size)
            {
                for (int i = 0; i < n-1; i++)
                    temp = temp.Next;

                Node nx = temp.Next;
                temp.Next = new Node(val);
                temp.Next.Next = nx;
                size++;
            }
            else Console.WriteLine("Out of index" + size);
        }

        public void Remove(int x)
        {
            Node temp = head;

            if (head.Value == x) head = temp.Next;
            else 
            {
                int count = 0;
                while (temp.Next.Value != x && count<size-2)
                {
                    temp = temp.Next;
                    count++;
                }
                if(count != size - 2) RemoveNode(temp);
            }
        }

        public void RemoveAt(int inx)
        {
            Node temp = head;
            if (inx == 0) head = temp.Next;
            else 
            {
                for (int i = 0; i < inx-1; i++)
                    temp = temp.Next;

                RemoveNode(temp);
            }
        }
        void RemoveNode(Node temp)
        {
            if (temp.Next.Next == null)
                temp.Next = null;
            else
                temp.Next = temp.Next.Next;
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
        }
    }
}
