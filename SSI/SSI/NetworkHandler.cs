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
        //UWAGA sieć niestety ma jakąś usterke przez co potrafi rozpoznać tylko jednego irysa na raz, metody jednak 
        //i sposób myślenia jest dobry, winny jest pewnie algorytm wstecznej propagacji ale od pięciu dni nie 
        //potrafie znaleść przyczyny. 
        public static void NewNetwork()
        {
            Network network = new Network(2,3,2);
            ReadData rd = new ReadData();
            rd.ReadFlower();
            double[][] data = rd.GetData();
            var trainDataSet = GetTrainData(data);
            var expectedOutput = ExpectedValVektor(data);

            network.CheckSynapsesConnection(23, 1, 2);
            network.PrintNetwork();
            //for (int i = 0; i < 2; i++)
            //{
            //    network.Train(new double[2] { 1, 1 }, new double[2] { 0, 1 });
            //    network.PrintNetwork();
            //}

            //for (int j = 0; j < 1; j++)
            //{
            //    for (int i = 0; i < 150; i++)
            //    {
            //        network.Train(trainDataSet[i], expectedOutput[i]);
            //    }

            //}

            ////100
            //network.PushInputValuesInConsole(new double[4] { 0.85, 0.38, 0.66, 0.29 });
            //network.PushInputValuesInConsole(new double[4] { 0.80, 0.32, 0.63, 0.24 });
            //network.PushInputValuesInConsole(new double[4] { 0.82, 0.38, 0.66, 0.25 });


            ////010
            //network.PushInputValuesInConsole(new double[4] { 0.71, 0.38, 0.57, 0.19 });
            //network.PushInputValuesInConsole(new double[4] { 0.73, 0.34, 0.52, 0.13 });
            //network.PushInputValuesInConsole(new double[4] { 0.78, 0.28, 0.57, 0.19 });

            ////001
            //network.PushInputValuesInConsole(new double[4] { 0.62, 0.38, 0.18, 0.03 });
            //network.PushInputValuesInConsole(new double[4] { 0.59, 0.41, 0.16, 0.03 });
            //network.PushInputValuesInConsole(new double[4] { 0.58, 0.39, 0.19, 0.03 });


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
                }
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
