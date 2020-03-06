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

            //rd.ReadFlower();
            //rd.PrintData();
            ghp.ToGrayScale();
            Console.ReadLine();
        }
    }
}
