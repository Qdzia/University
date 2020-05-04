using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSI.NeuralNetwork
{
    class Network
    {
        Layer[] _layers;
        double learingRate;
        public Network(params int[] layerCount)
        {
            learingRate = 0.1;
            int n = layerCount.Length;
            _layers = new Layer[n];

            _layers[0] = new Layer(layerCount[0]);
            for (int i = 1; i < n; i++)
            {
                _layers[i] = new Layer(layerCount[i]);
                _layers[i - 1].AddNextLayer(_layers[i]);
            }
        }

        public void PushInputValues(double[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                _layers[0].Neurons[i].LastValue = input[i];
            }
            for (int i = 1; i < _layers.Length; i++)
            {
                for (int j = 0; j < _layers[i].Neurons.Length; j++)
                {
                    _layers[i].Neurons[j].CalculateOutput();
                }
            }
        }

        public void Train(double[] input, double[] expected)
        {
            PushInputValues(input);

            //Output Layer Error
            for (int i = 0; i < _layers.Last().NLength; i++)
            {
                var neuron = _layers.Last().Neurons[i];
                var error = (neuron.LastValue - expected[i]) * neuron.Derivative();
                neuron.LastError = error;
            }

            //Hidden Layers Error
            for (int i = 1; i < _layers.Length - 1; i++) //Every Layer in Hidden Layers
            {
                for (int j = 0; j < _layers[i].NLength; j++)//Every Neuron in Layer
                {
                    var neuron = _layers[i].Neurons[j];
                    double sum = 0.0;
                    for (int k = 0; k < neuron.OutputSynapses.Length; k++)//Every Synapse in Neuron
                    {
                        sum += neuron.OutputSynapses[k].To.LastError * neuron.OutputSynapses[k].Weight;
                    }
                    sum *= neuron.Derivative();
                    neuron.LastError = sum;

                }
            }

            for (int i = 0; i < _layers.Length - 1; i++) //Every Layer in Hidden Layers
            {
                for (int j = 0; j < _layers[i].NLength; j++)//Every Neuron in Layer
                {
                    var neuron = _layers[i].Neurons[j];
                    for (int k = 0; k < neuron.OutputSynapses.Length; k++)//Every Synapse in Neuron
                    {
                        neuron.OutputSynapses[k].UpdateWeight(learingRate);
                    }
                }
            }
        }
        #region Print Network Functions
        
        public void PrintNetwork()
        {
            for (int i = 0; i < _layers.Length - 1; i++)
            {
                Console.WriteLine($"\nLayer [{i}] ");
                Console.Write(" NeuronValue:  ");
                for (int j = 0; j < _layers[i].Neurons.Length; j++)
                {
                    Console.Write(_layers[i].Neurons[j].LastValue + "   ");
                }
                Console.WriteLine();
                for (int k = 0; k < _layers[i].Neurons.Length; k++)
                {
                    Console.Write($"        WeightsToNeu({k}):  ");
                    for (int j = 0; j < _layers[i].Neurons[k].OutputSynapses.Length; j++)
                    {
                        Console.Write(_layers[i].Neurons[k].OutputSynapses[j].Weight + "   ");
                    }
                    Console.WriteLine();
                }
            }
            Console.WriteLine("OutputLayer  ");
            Console.Write(" NeuronValue:  ");
            for (int j = 0; j < _layers.Last().Neurons.Length; j++)
            {
                Console.Write(_layers.Last().Neurons[j].LastValue + "   ");
            }
            Console.WriteLine();
        }
        #endregion
    }
}
