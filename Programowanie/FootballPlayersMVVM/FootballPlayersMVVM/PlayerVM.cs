using FootballPlayersMVVM.ViewModels.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballPlayersMVVM
{
    class PlayerVM : BaseVM
    {
        private Player player;

        #region Własności
        public string FirstName
        {
            get { return player.firstName; }
            set 
            { 
                SetProperty(ref player.firstName, value); 
                RaisePropertyChanged("PlayerData"); 
            }
        }
        public string LastName
        {
            get { return player.lastName; }
            set 
            {
                SetProperty(ref player.lastName, value);
                RaisePropertyChanged("PlayerData");
            }
        }
        public double Weight
        {
            get { return player.weight; }
            set 
            { 
                SetProperty(ref player.weight, value);
                RaisePropertyChanged("PlayerData");
            }
        }
        public int Age
        {
            get { return player.age; }
            set 
            { 
                SetProperty(ref player.age, value);
                RaisePropertyChanged("PlayerData");
            }
        }

        public string PlayerData 
        {
            get { return $"{FirstName} {LastName}, wiek: {Age}, waga: {Weight} Kg"; }
        }
        #endregion

        #region Konstruktory
        public PlayerVM(string fn = "imie", string ln = "nazwisko", int age = 0, double weight = 0)
        {
            player = new Player(fn,ln,age,weight);
        }
        public PlayerVM(Player p)
        {
            player = new Player(p.firstName, p.lastName, p.age, p.weight);
        }
        #endregion
    }
}
