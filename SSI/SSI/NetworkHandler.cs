using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSI.ANN.ActivationFunctions;
using SSI.ANN.InputFunctions;
using SSI.ANN;
using SSI.NeuralNetwork;

namespace SSI
{
    class NetworkHandler
    {

        public static void NewNetwork()
        {
            Network network = new Network(1,1,1,1);
            ReadData rd = new ReadData();
            rd.ReadFlower();
            //rd.PrintData();
            double[][] data = rd.GetData();
            var trainDataSet = GetTrainData(data);
            var expectedOutput = ExpectedValVektor(data);


            //network.PushInputValues(new double[4] { 0.18, 0.03, 0.5, 0.4 });
            //network.PushInputValues(new double[4] { 1, 1, 1,1 });
            for (int j = 0; j < 1; j++)
            {
                //network.Train(new double[4] { 0.1, 0.5, 0.3, 0.8 }, new double[3] { 0.1, 0.5, 0.9 });
                network.Train(new double[1] { 0.5 }, new double[1] { 1 });
            }


            network.PrintNetwork();

            //network.Train(trainDataSet[0], expectedOutput[0]);

            //for (int j = 0; j < 1; j++)
            //{
            //    for (int i = 0; i < 150; i++)
            //    {
            //        network.Train(trainDataSet[i], expectedOutput[i]);
            //    }

            //}
            /*
            Console.WriteLine("Pierwszy");
            network.PushInputValues(new double[2] { 0.18, 0.03 });
            network.PushInputValues(new double[2] { 0.20, 0.04 });
            network.PushInputValues(new double[2] { 0.16, 0.05 });

            Console.WriteLine("Drugi");
            network.PushInputValues(new double[2] { 0.57, 0.20 });
            network.PushInputValues(new double[2] { 0.52, 0.16 });
            network.PushInputValues(new double[2] { 0.42, 0.13 });

            Console.WriteLine("Trzeci");
            network.PushInputValues(new double[2] { 0.65, 0.23 });
            network.PushInputValues(new double[2] { 0.66, 0.25 });
            network.PushInputValues(new double[2] { 0.62, 0.30 });
            */
        }

        static double[][] ExpectedValVektor(double [][] data) 
        {
            double[][] expectedValues = new double[150][];

            for (int i = 0; i < 150; i++)
            {
                expectedValues[i] = new double[3];
                for (int j = 0; j < 3; j++)
                {
                    expectedValues[i][j] = data[i][4+j];
                    //Console.Write(data[i][4 + j]);
                }
                //Console.WriteLine();
            }

            return expectedValues;
        }

        static double[][] GetTrainData(double[][] data)
        {
            
            double[][] dataValues = new double[150][];

            for (int i = 0; i < 150; i++) dataValues[i] = new double[] { data[i][0], data[i][1], data[i][2], data[i][3] };

            return dataValues;
        }
    }
}
