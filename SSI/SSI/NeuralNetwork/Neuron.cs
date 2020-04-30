using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSI.NeuralNetwork.Functions;

namespace SSI.NeuralNetwork
{
    class Neuron
    {
        public Synapse[] InputSynapses;
        public Synapse[] OutputSynapses;
        IActivationFunction _activationFunction;
        double _value;
        public int ID { get; private set; }
        public Neuron(int id,IActivationFunction fun)
        {
            ID = id;
            _activationFunction = fun;
        }
        public double Value 
        {
            get { return _value; }
            set { _value = value; }
       
        }
        public double PreviousPartialDerivate { get; set; }

        #region Connectiong Layers Methods
        public void AddOutputSynapse(Synapse syn,int inx) => OutputSynapses[inx] = syn;
        public void AddInputSynapse(Synapse syn, int inx) => InputSynapses[inx] = syn;
        
        public void InitInputSynapses(int input) 
        {
            if(InputSynapses == null)InputSynapses = new Synapse[input];
        } 
        public void InitOutputSynapses(int output)
        {
            if(OutputSynapses == null)OutputSynapses = new Synapse[output];
        }
        #endregion
        public void GetOutput()
        {
            double result = 0;
            for (int i = 0; i < InputSynapses.Length; i++)
            {
                double num = InputSynapses[i].Weight * InputSynapses[i].FromNeuron.Value;
                result += _activationFunction.CalculateOutput(num);
            }
            Value = result;
        }
    }
}
