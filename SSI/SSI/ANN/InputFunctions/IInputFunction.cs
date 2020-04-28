/*
 * Author: Nikola Živković
 * Website: rubikscode.net
 * Year: 2018
 */

using SSI.ANN.Synapses;
using System.Collections.Generic;

namespace SSI.ANN.InputFunctions
{
    /// <summary>
    /// Interface for Input Functions.
    /// </summary>
    public interface IInputFunction
    {
        double CalculateInput(List<ISynapse> inputs);
    }
}
