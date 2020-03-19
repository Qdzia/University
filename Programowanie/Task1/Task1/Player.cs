using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Player
    {
        string _FirstName, _LastName;
        int _age;
        double _weight;

        public string FirstName 
        { 
            get { return _FirstName; } 
            set { _FirstName = value;} 
        }
        public string LastName 
        { 
            get { return _LastName; }
            set { _LastName = value;} 
        }
        public double Weight 
        { 
            get { return _weight; } 
            set { _weight = value;} 
        }
        public int Age 
        { 
            get { return _age; } 
            set { _age = value;} 
        }

        public Player(string fn = "imie", string ln = "nazwisko", int age = 0, double weight = 0)
        {
            this._FirstName = fn;
            this._LastName = ln;
            this._age = age;
            this._weight = weight;
        }
        public Player(Player p)
        {
            this._FirstName = p.FirstName;
            this._LastName = p.LastName;
            this._age = p.Age;
            this._weight = p.Weight;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}, wiek: {Age}, waga: {Weight} Kg";
        }
    }
}
