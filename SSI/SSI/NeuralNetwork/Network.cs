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
        Layer[] _hiddenLayers;
        double _learningRate;

        public Network(params int[] layers)
        {
            _learningRate = 0.15;
            int len = layers.Length;
            if (len > 2)
            {
                _inputLayer = new Layer(layers[0]);
                //Console.WriteLine("new layer 0 " + layers[0]);
                _hiddenLayers = new Layer[len - 2];
                for (int i = 1; i < len - 1; i++)
                {
                    _hiddenLayers[i-1] =  new Layer(layers[i]);
                    //Console.WriteLine("new Hiddenlayer " + i + " " + layers[i]);
                }
                //Console.WriteLine("new layer last " + layers[len-1]);
                _outputLayer = new Layer(layers[len-1]);
            }
            ConnectLayers(_inputLayer, _hiddenLayers[0]);
            ConnectLayers(_hiddenLayers[0],_outputLayer);

            //for (int i = 0; i < 100; i++)
            //{
            //    Train(new double[2] { 0.30, 0.15 }, 0.21);
            //}


            //PrintWeights(_inputLayer);
            //PrintWeights(_hiddenLayers[0]);

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
                    first.Neurons[i].AddOutputSynapse(synapse,j);
                    second.Neurons[j].AddInputSynapse(synapse, i);
                }
            }
        }
        public void PushInputValues(double[] input)
        {
            _inputLayer.Neurons[0].Value = input[0];
            _inputLayer.Neurons[1].Value = input[1];
            foreach (var neuron in _hiddenLayers[0].Neurons)
            {
                neuron.CallActivationFunction();
                //Console.WriteLine("Hidden val: " + neuron.Value);
            }
            foreach (var neuron in _outputLayer.Neurons)
            {
                neuron.CallActivationFunction();
                Console.WriteLine("Output: " + neuron.Value);
            }

        }

        public void Train(double[] input,double actual)
        {
            PushInputValues(input);

            HandleOutputLayer(actual);
            HandleHiddenLayers(actual);

        }
        private void HandleOutputLayer(double expectedOutput)
        {
            foreach (var neuron in _outputLayer.Neurons)
            {
                foreach (var synapse in neuron.InputSynapses)
                {

                    var delta = (neuron.Value - expectedOutput) * synapse.FromNeuron.Value;
                    synapse.UpdateWeight(_learningRate, -delta);
                    /* var output = neuron.Value;
                     var netInput = synapse.FromNeuron.Value;

                     var nodeDelta = (expectedOutput - output) * output * (1 - output);
                     var delta = -1 * netInput * nodeDelta;

                     synapse.UpdateWeight(_learningRate, delta);

                     neuron.PreviousPartialDerivate = nodeDelta;*/
                }
            }
        }
        private void HandleHiddenLayers(double expectedOutput)
        {
            foreach (var neuron in _hiddenLayers[0].Neurons)
            {
                foreach (var synapse in neuron.InputSynapses)
                {
                    var delta = (neuron.Value - expectedOutput) * synapse.FromNeuron.Value * neuron.OutputSynapses[0].PreviousWeight;
                    synapse.UpdateWeight(_learningRate, -delta);

                    /*var output = neuron.Value;
                    var netInput = synapse.FromNeuron.Value;
                    double sumPartial = 0;

                    foreach (var outputSynapse in neuron.OutputSynapses)
                    {
                        sumPartial += outputSynapse.PreviousWeight * outputSynapse.ToNeuron.PreviousPartialDerivate;
                    }

                    var delta = -1 * netInput * sumPartial * output * (1 - output);
                    synapse.UpdateWeight(_learningRate, delta);*/
                }
            }
        }
        void PrintWeights(Layer layer) 
        {
            Console.WriteLine("Layer");
            foreach (var neuron in layer.Neurons)
            {
                Console.WriteLine("Neuron");
                neuron.PrintWeight();
            }
        }
    }
}
