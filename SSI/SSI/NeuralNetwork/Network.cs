using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSI.NeuralNetwork
{
    class Network
    {
        Layer _inputLayer;
        Layer _outputLayer;
        Layer[] _layers;
        double _learningRate;

        #region Create Network Methods
        public Network(params int[] layersNum)
        {
            _learningRate = 0.2;
            int len = layersNum.Length;
            if (len > 2)
            {
                _layers = new Layer[len];
                for (int i = 0; i < len; i++)
                {
                    _layers[i] = new Layer(layersNum[i]);
                }
                _inputLayer = _layers[0];
                _outputLayer = _layers[len - 1];
            }
            for (int i = 0; i < len - 1; i++)
            {
                ConnectLayers(_layers[i], _layers[i + 1]);
            }
        }

        void ConnectLayers(Layer first, Layer second)
        {
            for (int i = 0; i < first.Neurons.Length; i++)
            {
                first.Neurons[i].InitOutputSynapses(second.Neurons.Length);

                for (int j = 0; j < second.Neurons.Length; j++)
                {
                    Synapse synapse = new Synapse(first.Neurons[i], second.Neurons[j]);
                    second.Neurons[j].InitInputSynapses(first.Neurons.Length);
                    first.Neurons[i].AddOutputSynapse(synapse, j);
                    second.Neurons[j].AddInputSynapse(synapse, i);
                }
            }
        }
        #endregion
        public void PushInputValues(double[] input)
        {
            if (input.Length != _inputLayer.Neurons.Length)
                throw new ArgumentOutOfRangeException("Wrong Input Vector");

            for (int i = 0; i < input.Length; i++)
            {
                _inputLayer.Neurons[i].Value = input[i];
            }
            for (int j = 1; j < _layers.Length; j++)
            {
                foreach (var neuron in _layers[j].Neurons)
                {
                    neuron.GetOutput();
                }
            }
        }
        public void PushInputValuesInConsole(double[] input)
        {
            PushInputValues(input);
            PrintOutputs();
        }
        public void Train(double[] input,double[] actual)
        {
            PushInputValues(input);
            //PrintNetwork();
            HandleOutputLayer(actual);
            HandleHiddenLayers();
            //PrintOutputs();
            //CalculateTotalError(actual);
        }
        private double CalculateTotalError(double[] expected)
        {
            double totalError = 0;
            foreach (Neuron neuron in _outputLayer.Neurons)
            {
                var error = Math.Pow(neuron.Value - expected[neuron.ID], 2);
                totalError += error;
                Console.WriteLine($"OutputError[{neuron.ID}]: " + error);
            }
            Console.WriteLine($"TotalError: " + totalError);
            Console.WriteLine();
            return totalError;
        }

        private void HandleOutputLayer(double[] expectedOutput)
        {
            foreach (var neuron in _outputLayer.Neurons)
            {
                //Console.WriteLine($"Neuron[{neuron.ID}] \n");
                foreach (var synapse in neuron.InputSynapses)
                {
                    var nodeDelta = (neuron.Value - expectedOutput[neuron.ID]);
                    var output = neuron.Value;
                    var derivative = output * (1.0 - output);

                    //Console.WriteLine("nodeDelta " + nodeDelta);
                    //Console.WriteLine("output " + output);
                    //Console.WriteLine("derivative " + derivative);

                    var delta = 2* nodeDelta * synapse.FromNeuron.Value;
                    synapse.UpdateWeight(_learningRate, -delta);

                    //Console.WriteLine("delta " + delta);
                    neuron.PreviousPartialDerivate = nodeDelta;
                }
               // Console.WriteLine("\n ");
            }
        }
        private void HandleHiddenLayers()
        {
            for (int i = _layers.Length - 2; i > 0; i--)
            {
                foreach (var neuron in _layers[i].Neurons)
                {
                    foreach (var synapse in neuron.InputSynapses)
                    {
                        var netInput = synapse.GetOutput();
                        var output = neuron.Value;
                        var derivative = output * (1.0 - output);

                        double sumPartial = 0;
                        foreach (var outputSynapse in neuron.OutputSynapses)
                        {
                            sumPartial += outputSynapse.PreviousWeight * outputSynapse.ToNeuron.PreviousPartialDerivate;
                        }

                        var delta = netInput * sumPartial;

                        neuron.PreviousPartialDerivate = sumPartial;

                        synapse.UpdateWeight(_learningRate, -delta);
                    }
                }
            }
        }
        #region Print Network Functions
        public void PrintOutputs()
        {
            foreach (var neuron in _outputLayer.Neurons)
            {
                Console.WriteLine($"OutputValue[{neuron.ID}]: {neuron.Value} "); 
            }
            Console.WriteLine();
        }
        public void PrintNetwork() 
        {
            for (int i = 0; i < _layers.Length-1; i++)
            {
                Console.WriteLine($"\nLayer [{i}] ");
                Console.Write(" NeuronValue:  ");
                for (int j = 0; j < _layers[i].Neurons.Length; j++)
                {
                    Console.Write(_layers[i].Neurons[j].Value + "   ");
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
            for (int j = 0; j < _outputLayer.Neurons.Length; j++)
            {
                Console.Write(_outputLayer.Neurons[j].Value + "   ");
            }
            Console.WriteLine();
        }
        #endregion
    }
}
