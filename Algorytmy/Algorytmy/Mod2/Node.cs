using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorytmy.Mod2
{
    class Node
    {
        Node prev;
        Node next;
        int value;
        public Node(Node previous, Node next, int val)
        {
            this.prev = previous;
            this.next = next;
            this.value = val;
        }

        public Node(Node previous, int val)
        {
            this.prev = previous;
            this.next = null;
            this.value = val;
        }

        public Node(int val)
        {
            this.prev = null;
            this.next = null;
            this.value = val;
        }

        public Node Prev { get { return prev; } set { prev = value; } }
        public Node Next { get { return next; } set { next = value; } }
        public int Value { get { return value; } set { this.value = value; } }
    }
}
