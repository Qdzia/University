using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorytmy.Mod7
{
    class Molecule
    {
        public double[] position;
        public double[] bestPosition;
        public double[] velocity;
        
        public Molecule(double[] position, double[] velocity)
        {
            this.position = position;
            this.velocity = velocity;
            bestPosition = position;
        }
    }
}
