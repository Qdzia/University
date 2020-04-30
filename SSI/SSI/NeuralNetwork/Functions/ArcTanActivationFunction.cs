using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSI.NeuralNetwork.Functions
{
    class ArcTanActivationFunction : IActivationFunction
    {
        public double CalculateOutput(double input)
        {
            return Math.Tanh(input);
        }
    }
}
