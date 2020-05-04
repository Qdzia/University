using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSI.NeuralNetwork
{
    class Synapse
    {
        public Neuron To { get; set; }
        public Neuron From { get; set; }
        public double Weight { get; set; }
        public double PreviousWeight { get; set; }

        public Synapse(Neuron to, Neuron from,double weight)
        {
            To = to;
            From = from;
            Weight = weight - 0.5;
        }
        public double GetOutput()
        {
            return Weight * From.LastValue;
        }

        public void UpdateWeight(double learingRate)
        {
            PreviousWeight = Weight;
            Weight = -2.0 * To.LastError * From.LastValue * learingRate;
        }
    }
}
