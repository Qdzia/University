using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSI.NeuralNetwork
{
    class Neuron
    {
        public Synapse[] OutputSynapses { get; set; }
        public Synapse[] InputSynapses { get; set; }

        public double LastError { get; set; }
        public double LastValue { get; set; }
        double alpha = 0.5;
        public double Derivative()
        { 
            return (2 * alpha * Math.Pow(Math.E, -alpha * LastValue)) / 
                (Math.Pow(1 + Math.Pow(Math.E, -alpha * LastValue), 2));
            //return LastValue * (1.0 - LastValue);
        }

        public double ActivationFunction(double input)
        {
            return (1 - Math.Pow(Math.E, -alpha * input)) / (1 + Math.Pow(Math.E, -alpha * input));
            //Sigmoid Activation Function
            //return 1 / (1 + Math.Exp(-input));
        }

        public double CalculateOutput()
        {
            double result = 0;
            for (int i = 0; i < InputSynapses.Length; i++)
            {
                result += InputSynapses[i].GetOutput();
            }
            LastValue = ActivationFunction(result);
            return LastValue;
        }
    }
}
