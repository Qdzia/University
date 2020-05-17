using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorytmy.TestFunctions
{
    public interface IFunction
    {
        string GetName();
        double Calculate(double[] input);

    }
}
