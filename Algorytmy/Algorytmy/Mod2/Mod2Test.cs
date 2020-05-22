using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorytmy.Mod2
{
    class Mod2Test
    {

        public void Test()
        {
            TestQueque();
            TestStack();
            TestList();
        }

        public void TestQueque()
        {
            Console.WriteLine($"\n\nQueque: ");
            Queque que = new Queque(3);
            Console.WriteLine($"Is empty: {que.isEmpty()}");
            que.Enqueue(1);
            Console.WriteLine($"Enqueue size: {que.Count()}");
            que.Enqueue(2);
            que.Enqueue(3);
            Console.WriteLine($"Peek: {que.Peek()} \nZawartość");
            que.Print();
            Console.WriteLine();
            que.Enqueue(4);
            Console.WriteLine($"Enqueue size: {que.Count()}\nDequeue: {que.Dequeue()} ,{que.Dequeue()}, {que.Dequeue()}");

            Console.WriteLine($"\n\nPQueque: ");
            Queque queP = new Queque(3);
            Console.WriteLine($"Is empty: {queP.isEmpty()}");
            queP.Enqueue(1);
            Console.WriteLine($"Enqueue size: {queP.Count()}");
            queP.Enqueue(2);
            queP.Enqueue(3);
            Console.WriteLine($"Peek: {queP.Peek()}\nZawartość");
            queP.Print();
            Console.WriteLine();
            queP.Enqueue(4);
            Console.WriteLine($"Enqueue size: {queP.Count()}\nDequeue: {queP.Dequeue()} ,{queP.Dequeue()}, {queP.Dequeue()}");
        }

        public void TestStack() 
        {
            Console.WriteLine($"\n\nStack: ");
            Stack stack = new Stack(3);
            stack.Push(1);stack.Push(2);stack.Push(3);stack.Push(4);
            stack.Print();
            Console.WriteLine($"Peek: {stack.Peek()}");
            stack.Pop();stack.Pop();
            Console.WriteLine($"Peek: {stack.Peek()}");
            Console.WriteLine($"Count: {stack.Count()}");
        }

        public void TestList()
        {
            Console.WriteLine($"\n\nListOne: ");
            ListOne list = new ListOne();
            list.Add(1); list.Add(2); list.Add(4);
            list.Print(); Console.WriteLine();
            list.Insert(2, 3);
            list.Print(); Console.WriteLine();
            list.RemoveAt(3); list.RemoveAt(0);
            list.Print(); Console.WriteLine();
            list.Remove(2);
            list.Print();


            Console.WriteLine($"\n\nListOneC: ");
            ListOneC listC = new ListOneC();
            listC.Add(1); listC.Add(2); listC.Add(3); listC.Add(4);
            listC.Print(); Console.WriteLine();
            listC.RemoveAt(3); listC.RemoveAt(0);
            listC.Print(); Console.WriteLine();
            listC.Remove(2);
            listC.Print();
            
            Console.WriteLine($"\n\nListTwo: ");
            ListTwo listTwo = new ListTwo();
            listTwo.Add(1); listTwo.Add(2); listTwo.Add(4);
            listTwo.Print(); Console.WriteLine();
            listTwo.Insert(2, 3);
            listTwo.Print(); Console.WriteLine();
            listTwo.RemoveAt(3); listTwo.RemoveAt(0);
            listTwo.Print(); Console.WriteLine();
            listTwo.Remove(2);
            listTwo.Print();

            Console.WriteLine($"\n\nListTwoF: ");
            ListTwoF ListTwoF = new ListTwoF();
            ListTwoF.Add(1); ListTwoF.Add(2); ListTwoF.Add(3); ListTwoF.Add(4);
            ListTwoF.Print(); Console.WriteLine();
            ListTwoF.Remove(1); 
            ListTwoF.Print(); Console.WriteLine();
            ListTwoF.Remove(2);
            ListTwoF.Print();


        }

    }
}
