using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballPlayersMVVM
{
    public class Player
    {
        public string firstName, lastName;
        public int age;
        public double weight;

        public Player(string firstName, string lastName, int age, double weight)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.weight = weight;
        }
    }
}
