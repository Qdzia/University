using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace CalculatorMVVM.VIewModel
{
    using Model;
    using Model.Operations;
    using BaseClass;
    using System.Windows.Controls;
    using System.Windows;
    using System.Windows.Media;

    //  Główna klasa warstwy ViewModel będąca abstrakcją widoku kalkulatora.
    //  Zawiera cztery wielkości opisujące widok kalkulatora:
    //    - FirstArgument - typu double?
    internal class Calculating: ViewModelBase
    {
        public Calculating()
        {
            SelectedPlayer = new Player();
            AgeRange = InitComboBox();
            PlayersList = new List<Player>();
            PlayersList.Add(new Player("Adam", "Marchewa", 12, 50));
            PlayersList.Add(new Player("Jacek", "Marchewa", 12, 50));
        }
        public List<Player> PlayersList { get; set; }
        public Player SelectedPlayer { get; set; }
        public string Name 
        {
            get { return SelectedPlayer.FirstName; }
            set { SelectedPlayer.FirstName = value;
                onPropertyChanged(nameof(Name));

                onPropertyChanged(nameof(FullName));
            }
        }
        public string Surname 
        {
            get { return SelectedPlayer.LastName; }
            set { SelectedPlayer.LastName = value;}

        }
        public int Age
        {
            get { return SelectedPlayer.Age; }
            set { SelectedPlayer.Age = value; }

        }
        public double Weight
        {
            get { return SelectedPlayer.Weight; }
            set { SelectedPlayer.Weight = value; }

        }

        public string[] AgeRange { get; set; }


        string[] InitComboBox()
        {
            var ageRange = new string[51];
            for (int i = 10; i <= 60; i++)
                ageRange[i -10] = "" + i;

            return ageRange;
        }

        private ICommand _addPlayer = null;

        public ICommand AddPlayer
        {
            get
            {
                if (_addPlayer == null)
                {
                    _addPlayer = new RelayCommand(
                        arg => {
                            PlayersList.Add(new Player(SelectedPlayer.FirstName, SelectedPlayer.LastName,
                                SelectedPlayer.Age, SelectedPlayer.Weight));
                        },
                        arg => (true)
                     );

                }

                return _addPlayer;
            }
        }
        public string FullName { get {return Name; } }
        public decimal? FirstArg { get; set; }
              
        public decimal? SecondArg { get; set; }
            
        
        public string SymbolOfCurrentOperation { get; set; }

        private decimal? result = null;
        public decimal? Result
        {
            get
            {
                return result;
            }
            set
            {
                result = value;
                onPropertyChanged(nameof(Result));
            }
        }

        private ICommand _calculate = null;

        public ICommand Calculate
        { 
            get
            {
                if (_calculate == null)
                {
                    //_calculate = new RelayCommand(
                    //    arg => { Result = calculator.ExceuteOperationBySymbol(SymbolOfCurrentOperation, (decimal)FirstArg, (decimal)SecondArg); },
                    //    arg => (!string.IsNullOrEmpty(SymbolOfCurrentOperation)) && (FirstArg != null) && (SecondArg != null)
                    // );
                }

                return _calculate;
            }
        }

        private ICommand _clear = null;
        public ICommand Clear
        {
            get
            {
                if (_clear == null)
                {
                    _clear = new RelayCommand(
                        arg => { Result = null; },

                        arg => true

                        );
                }
                return _clear;
            }
        }


    }
}
