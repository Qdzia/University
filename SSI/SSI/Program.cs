using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSI.NeuralNetwork;

namespace SSI
{
    class Program
    {
        static void Main(string[] args)
        {
            Network nn = new Network(2, 3, 2);

            for (int i = 0; i < 2; i++)
            {
                nn.Train(new double[2] { 0.46, 0.65 }, new double[2] { 1, 0 });
            }

            nn.PrintNetwork();
            Console.ReadLine();
        }
    }
}
