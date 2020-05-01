using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SSI.NeuralNetwork.Functions;

namespace SSI.NeuralNetwork
{
    class Layer
    {
        public Neuron[] Neurons;

        public Layer(int numOfNeuron)
        {
            Neurons = new Neuron[numOfNeuron];
            for (int i = 0; i < numOfNeuron; i++)
            {
                Neurons[i] = new Neuron(i,new RectifiedActivationFuncion());
            }
        }

    }
}
