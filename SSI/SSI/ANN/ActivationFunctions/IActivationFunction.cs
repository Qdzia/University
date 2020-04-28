/*
 * Author: Nikola Živković
 * Website: rubikscode.net
 * Year: 2018
 */

namespace SSI.ANN.ActivationFunctions
{
    /// <summary>
    /// Interface for activation functions.
    /// </summary>
    public interface IActivationFunction
    {
        double CalculateOutput(double input);
    }
}
