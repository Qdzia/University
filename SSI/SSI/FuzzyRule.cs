using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSI
{
    class FuzzyRule
    {
        double a,b,c;
        double? d;

        private List<double> elements;

        public FuzzyRule(double a, double b, double c)
            : this(a, b, c, null) { }

        public FuzzyRule(double a, double b, double c, double? d)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
            elements = new List<double>();
        }

        public void AddElement(double x)
        {
            if (d == null) elements.Add(TriangleRule(x));
            else elements.Add(TrapezeRule(x));
        }
        public double GetElOfIndx(int indx) 
        {
            if (indx < elements.Count && indx > 0)
                return elements[indx];
            else throw new IndexOutOfRangeException("Index must be in elements list");
        }
        double TriangleRule(double x)
        {
            if ((a < x) && (x <= b)) return (x - a) / (b - a); //a -- x -- b
            if ((b < x) && (x < c)) return (c - x) / (c - b); //b -- x -- c
            return 0;
        }
        double TrapezeRule(double x)
        {
            double dd = (double)d;
            if (x <= a) return 0;                   //x -- a
            if (x <= b) return (x - a) / (b - a);   //a -- x -- b
            if (x < c) return 1;                    //b -- x -- c
            if (x <= dd) return (dd - x) / (dd - c);   //c -- x -- d
            return 0;
        }

    }
}
