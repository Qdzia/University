using MiniTC.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTC.ViewModels
{
    class MainViewModel: BaseVM
    {
        //UWAGA : Należy klikać z lewej strony listy najlepiej w znak <D> lub .. klikanie z drugiej strony nie zaskutkuje. 
        //Warto o tym pamiętać potrafi oszczędzić bardzo dużo czasu!
        private PanelTCViewModel _from;
        private PanelTCViewModel _to;
        public RelayCommand CopyCommand { get; set; }
        public MainViewModel()
        {
            From = new PanelTCViewModel();
            To = new PanelTCViewModel();
            CopyCommand = new RelayCommand(CopyFile);
        }
        public PanelTCViewModel From
        {
            get { return _from; }
            set { SetProperty(ref _from, value); }
        }
        public PanelTCViewModel To
        {
            get { return _to; }
            set { SetProperty(ref _to, value); }
        }

        public void CopyFile()
        {
            From.CopyTo(To.Path);
            To.UpdateDirectoryContent();
        }

    }
}
