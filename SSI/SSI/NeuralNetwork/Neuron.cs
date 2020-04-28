using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSI.NeuralNetwork
{
    class Neuron
    {
        public Synapse[] InputSynapses;
        public Synapse[] OutputSynapses;
        double _value;
        public double Value 
        {
            get { return _value; }
            set { _value = Math.Min(1, value); }
       
        }
        public double PreviousPartialDerivate { get; set; }

        public void AddOutputSynapse(Synapse syn,int inx)
        {
            OutputSynapses[inx] = syn;
        }
        public void AddInputSynapse(Synapse syn, int inx)
        {
            InputSynapses[inx] = syn;
        }
        public void InitInputSynapses(int input) 
        {
            if(InputSynapses==null)InputSynapses = new Synapse[input];
        } 
        public void InitOutputSynapses(int output)
        {
            if(OutputSynapses == null)OutputSynapses = new Synapse[output];
        }
        public void CallActivationFunction()
        {
            double result = 0;
            for (int i = 0; i < InputSynapses.Length; i++)
            {
                double num = InputSynapses[i].Weight * InputSynapses[i].FromNeuron.Value;
                result += Activation(num);
            }
            Value = result;
        }

        public double Activation(double num) 
        {
            return Math.Max(0, num);
        }

        public void PrintWeight() 
        {
            foreach (var synapse in OutputSynapses)
            {
                Console.WriteLine("w: " + synapse.Weight);
            }
        }
    }
}
