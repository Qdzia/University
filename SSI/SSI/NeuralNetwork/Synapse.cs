using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSI.NeuralNetwork
{
    class Synapse
    {
        public Neuron FromNeuron;
        public Neuron ToNeuron;

        public Synapse(Neuron from, Neuron to)
        {
            FromNeuron = from;
            ToNeuron = to;
            Weight = 0.5;
        }
        public double Weight { get; set; }

        public double PreviousWeight { get; set; }

        public void UpdateWeight(double learningRate, double delta)
        {
            PreviousWeight = Weight;
            Weight += learningRate * delta;
        }
    }

}
