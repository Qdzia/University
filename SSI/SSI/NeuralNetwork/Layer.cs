using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSI.NeuralNetwork
{
    class Layer
    {
        public Neuron[] Neurons { get; set; }
        public int NLength { get { return Neurons.Length; } }
        public Layer(int count)
        {
            Neurons = new Neuron[count];

            for (int i = 0; i < count; i++)
            {
                Neurons[i] = new Neuron();
            }
        }

        public void AddNextLayer(Layer nextLayer)
        {
            Random rnd = new Random();
            foreach (var neuron in nextLayer.Neurons)
            {
                neuron.InputSynapses = new Synapse[NLength];
            }
            foreach (var neuron in Neurons)
            {
                neuron.OutputSynapses = new Synapse[nextLayer.NLength]; ;
            }
            for (int i = 0; i < NLength; i++)
            {
                for (int j = 0; j < nextLayer.NLength; j++)
                {
                    Neurons[i].OutputSynapses[j] = new Synapse(nextLayer.Neurons[j], Neurons[i],rnd.NextDouble());
                    nextLayer.Neurons[j].InputSynapses[i] = Neurons[i].OutputSynapses[j];
                }
                
            }
        
        }
    }
}
