using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSI
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadData rd = new ReadData();
            Graphic ghp = new Graphic();
            SoftSet ss = new SoftSet();
            
            ss.Start();
            //rd.ReadFlower();
            //rd.PrintData();
            //ghp.Filtr(3);
            Console.ReadLine();
        }
    }
}
