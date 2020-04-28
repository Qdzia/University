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
            Network network = new Network(2,3,1);
            var trainDataSet = GetTrainData();
            var expectedOutput = ExpectedValVektor();

            for (int j = 0; j < 500; j++)
            {
                for (int i = 0; i < 150; i++)
                {
                    network.Train(new double[2] { trainDataSet[i][1], trainDataSet[i][2] }, expectedOutput[i]);
                }

            }
            

            Console.WriteLine("Teraz zera");
            network.PushInputValues(new double[2] { 0.18, 0.03 });
            network.PushInputValues(new double[2] { 0.20, 0.04 });
            network.PushInputValues(new double[2] { 0.16, 0.05 });

            Console.WriteLine("Teraz jedynki");
            network.PushInputValues(new double[2] { 0.65, 0.23 });
            network.PushInputValues(new double[2] { 0.66, 0.25 });
            network.PushInputValues(new double[2] { 0.62, 0.30 });


        }
        public static void Use() 
        {
            var network = new SimpleNeuralNetwork(3);
            var layerFactory = new NeuralLayerFactory();

            network.AddLayer(layerFactory.CreateNeuralLayer(3, new RectifiedActivationFuncion(), new WeightedSumFunction()));
            network.AddLayer(layerFactory.CreateNeuralLayer(1, new SigmoidActivationFunction(0.7), new WeightedSumFunction()));

            //network.PushExpectedValues(ExpectedValVektor());

            network.Train(GetTrainData(), 10000);

            network.PushInputValues(new double[] { 5.9, 5.1, 1.8 });
            var outputs = network.GetOutput();

            foreach (double val in outputs)
            {
                Console.WriteLine(val + "\n");
            }
            
        }

        static double[] ExpectedValVektor() 
        {
            double[] expectedValues = new double[150];
            for (int i = 0; i < 50; i++) expectedValues[i] = 0;
            for (int j = 50; j < 100; j++) expectedValues[j] = 0;
            for (int k = 100; k < 150; k++) expectedValues[k] = 1;

            return expectedValues;
        }

        static double[][] GetTrainData()
        {
            ReadData rd = new ReadData();
            rd.ReadFlower();
            //rd.PrintData();
            double[][] data = rd.GetData();
            double[][] dataValues = new double[150][];

            for (int i = 0; i < 150; i++) dataValues[i] = new double[] { data[i][0], data[i][2], data[i][3] };

            return dataValues;
        }
    }
}
