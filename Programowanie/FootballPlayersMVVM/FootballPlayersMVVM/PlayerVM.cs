using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballPlayersMVVM
{
    class PlayerVM
    {
        private Player player;

        public string FirstName
        {
            get { return player.firstName; }
            set { player.firstName = value; }
        }
        public string LastName
        {
            get { return player.lastName; }
            set { player.lastName = value; }
        }
        public double Weight
        {
            get { return player.weight; }
            set { player.weight = value; }
        }
        public int Age
        {
            get { return player.age; }
            set { player.age = value; }
        }

        public PlayerVM(string fn = "imie", string ln = "nazwisko", int age = 0, double weight = 0)
        {
            player = new Player();
            this.FirstName = fn;
            this.LastName = ln;
            this.Age = age;
            this.Weight = weight;
        }
        public PlayerVM(Player p)
        {
            player = new Player();
            this.FirstName = p.firstName;
            this.LastName = p.lastName;
            this.Age = p.age;
            this.Weight = p.weight;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}, wiek: {Age}, waga: {Weight} Kg";
        }
    }
}
