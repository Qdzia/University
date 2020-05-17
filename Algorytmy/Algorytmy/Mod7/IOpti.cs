using Algorytmy.TestFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorytmy.Mod7
{
    interface IOpti
    {
        double FindMin(IFunction function);
        string GetName();
    }
}
