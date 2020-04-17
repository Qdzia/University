using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using FootballPlayersMVVM.ViewModels.BaseClass;
using System.Windows.Input;
using Newtonsoft.Json;
using Microsoft.Win32;
using System.IO;

namespace FootballPlayersMVVM
{
    class FootballManagerVM : BaseVM
    {
        public ObservableCollection<PlayerVM> Players { get; set; }

        private PlayerVM _currentlySelectedPlayer;
        public PlayerVM CurrentlySelectedPlayer
        {
            get { return _currentlySelectedPlayer; }
            set 
            { 
                SetProperty(ref _currentlySelectedPlayer, value); 
                OnSelectedPlayerChanged(); 
            }
        }

        public RelayCommand CreatePlayerCommand { get; set; }
        public RelayCommand<PlayerVM> DeleteSelectedPlayerCommand { get; set; }
        public RelayCommand<PlayerVM> ModifySelectedPlayerCommand { get; set; }

        public RelayCommand SaveList { get; set; }
        //public RelayCommand LoadChickens { get; set; }


        private string _playerName;
        public string PlayerName
        {
            get { return _playerName; }
            set { SetProperty<string>(ref _playerName, value); }
        }

        private string _playerLastName;
        public string PlayerLastName
        {
            get { return _playerLastName; }
            set { SetProperty<string>(ref _playerLastName, value); }
        }

        private double _playerWeight;
        public double PlayerWeight
        {
            get { return _playerWeight; }
            set { SetProperty<double>(ref _playerWeight, value); }
        }

        private int _playerAge;
        public int PlayerAge
        {
            get { return _playerAge; }
            set { SetProperty<int>(ref _playerAge, value); }
        }

        public FootballManagerVM()
        {
            CreatePlayerCommand = new RelayCommand(CreatePlayer, CanCreatePlayer);

            DeleteSelectedPlayerCommand = new RelayCommand<PlayerVM>
                (DeleteSelectedPlayer, CanDeleteSelectedPlayer);

            ModifySelectedPlayerCommand = new RelayCommand<PlayerVM>
                (ModifySelectedPlayer, CanModifySelectedPlayer);

            SaveList = new RelayCommand(SaveChickenList);
            //LoadChickens = new RelayCommand(LoadChickenList);

            Players = new ObservableCollection<PlayerVM>();
            Players.Add(new PlayerVM("Adma", "Kowalski", 55, 23));
            Players.Add(new PlayerVM("Jacek", "Kowalski", 55, 23));
        }


        public void CreatePlayer()
        {
            PlayerVM newPlayer = new PlayerVM(PlayerName, PlayerLastName, PlayerAge,PlayerWeight);
            Players.Add(newPlayer);
            CurrentlySelectedPlayer = newPlayer;
        }

        public bool CanCreatePlayer(object param)
        {
            if (string.IsNullOrWhiteSpace(PlayerName) || 
                string.IsNullOrWhiteSpace(PlayerLastName))
                return false;
            return true;
        }

        public void DeleteSelectedPlayer(PlayerVM player)
        {
            Players.Remove(player);
        }

        public bool CanDeleteSelectedPlayer(PlayerVM player)
        {
            if (player == null)
                return false;
            return true;
        }

        public void ModifySelectedPlayer(PlayerVM player)
        {
            player.FirstName = PlayerName;
            player.LastName = PlayerLastName;
            player.Age = PlayerAge;
            player.Weight = PlayerWeight;
        }

        public bool CanModifySelectedPlayer(PlayerVM player)
        {
            if (player == null)
                return false;
            return true;
        }

        public void OnSelectedPlayerChanged()
        {

            if (CurrentlySelectedPlayer == null)
                return;

            PlayerName = CurrentlySelectedPlayer.FirstName;
            PlayerLastName = CurrentlySelectedPlayer.LastName;
            PlayerAge = CurrentlySelectedPlayer.Age;
            PlayerWeight = CurrentlySelectedPlayer.Weight;
            CommandManager.InvalidateRequerySuggested();
        }

        
        public void SaveChickenList()
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.ShowDialog();
            string fileName = fileDialog.FileName;
            if (!File.Exists(fileName))
                return;

            List<Player> playersToSave = new List<Player>();
            foreach (PlayerVM cv in Players)
            {
                Player newPlayer = new Player()
                {
                    age = cv.Age,
                    lastName = cv.LastName,
                    firstName = cv.FirstName,
                    weight = cv.Weight,
                };
                playersToSave.Add(newPlayer);
            }

            string rawJson = JsonConvert.SerializeObject(playersToSave);
            File.WriteAllText(fileName, rawJson);
        }

        /*
        public void LoadChickenList()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.ShowDialog();
            string fileName = fileDialog.FileName;
            if (!File.Exists(fileName))
                return;

            List<Chicken> chickens = JsonConvert.DeserializeObject<List<Chicken>>(File.ReadAllText(fileName));
            Chickens.Clear();
            //Recreate VMs
            foreach (Chicken c in chickens)
            {
                Chickens.Add(new ChickenVM(c));
            }
        }*/
    }
}
