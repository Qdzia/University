using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorytmy.Mod7
{
    class Lift
    {
        public double[] Pos;
        public double[] LastPos;

        public Lift(double[] Pos)
        {
            this.Pos = Pos;
            this.LastPos = Pos;
        }
    }
}
