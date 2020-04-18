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
        #region Deklaracje
        public ObservableCollection<PlayerVM> Players { get; set; }
        public RelayCommand CreatePlayerCommand { get; set; }
        public RelayCommand<PlayerVM> DeleteSelectedPlayerCommand { get; set; }
        public RelayCommand<PlayerVM> ModifySelectedPlayerCommand { get; set; }
        public RelayCommand SaveList { get; set; }

        #endregion

        #region Własności

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
        #endregion

        #region Konstruktor
        public FootballManagerVM()
        {
            CreatePlayerCommand = new RelayCommand
                (CreatePlayer, CanCreatePlayer);

            DeleteSelectedPlayerCommand = new RelayCommand<PlayerVM>
                (DeleteSelectedPlayer, CanDeleteSelectedPlayer);

            ModifySelectedPlayerCommand = new RelayCommand<PlayerVM>
                (ModifySelectedPlayer, CanModifySelectedPlayer);

            SaveList = new RelayCommand(Save);

            Players = new ObservableCollection<PlayerVM>();

            Load();
        }
        #endregion 

        #region Metody/Przyciski
        public void CreatePlayer()
        {
            if (PlayerName != "Podaj imię" & PlayerLastName != "Podaj nazwisko")
            {
                PlayerVM newPlayer = new PlayerVM(PlayerName, PlayerLastName, PlayerAge, PlayerWeight);
                Players.Add(newPlayer);
                CurrentlySelectedPlayer = new PlayerVM("Podaj imię", "Podaj nazwisko", 0, 0);
            }
        }
        public void DeleteSelectedPlayer(PlayerVM player)
        {
            Players.Remove(player);
        }
        public void ModifySelectedPlayer(PlayerVM player)
        {
            player.FirstName = PlayerName;
            player.LastName = PlayerLastName;
            player.Age = PlayerAge;
            player.Weight = PlayerWeight;
        }
        #endregion

        #region Czy Może Wykonać
        public bool CanCreatePlayer(object param)
        {
            if (string.IsNullOrWhiteSpace(PlayerName) ||
                string.IsNullOrWhiteSpace(PlayerLastName))
                return false;
            return true;
        }
        public bool CanDeleteSelectedPlayer(PlayerVM player)
        {
            if (player == null)
                return false;
            return true;
        }
        public bool CanModifySelectedPlayer(PlayerVM player)
        {
            if (player == null)
                return false;
            return true;
        }
        #endregion

        #region On Selection Change
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
        #endregion

        #region Zapis i Odczyt z Pliku
        public void Save()
        {
            List<Player> playerList = new List<Player>();
            foreach(PlayerVM p in Players)
            {
                playerList.Add(new Player(p.FirstName, p.LastName, p.Age, p.Weight));
            }
            string json = JsonConvert.SerializeObject(playerList);
            File.WriteAllText(@"../../Data/save.json", json);

        }
        public void Load()
        {
            List<Player> playerList = JsonConvert.DeserializeObject<List<Player>>(File.ReadAllText(@"../../Data/save.json")); ;
            foreach (Player p in playerList)
            {
                Players.Add(new PlayerVM(p));
            }
        }
        #endregion

    }
}
