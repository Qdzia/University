using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Player
    {
        string fn, ln;
        int age;
        double weight;

        public Player(string fn = "imie", string ln = "nazwisko", int age = 0, double weight = 0)
        {
            this.fn = fn;
            this.ln = ln;
            this.age = age;
            this.weight = weight;
        }
        public Player(Player p)
        {
            this.fn = p.fn;
            this.ln = p.ln;
            this.age = p.age;
            this.weight = p.weight;
        }

        public int Age { get; set; }


    }
}
