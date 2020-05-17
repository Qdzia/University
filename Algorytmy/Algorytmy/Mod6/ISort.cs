using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorytmy.Mod6
{
    interface ISort
    {
        void PerformSorting(double[] arr, int left, int right);
        string GetName();
    }
}
