using MiniTC.Base;
using MiniTC.Models;
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
        private PanelTCModel _from;
        private PanelTCModel _to;
        public RelayCommand CopyCommand { get; set; }
        public MainViewModel()
        {
            From = new PanelTCModel();
            To = new PanelTCModel();
            CopyCommand = new RelayCommand(CopyFile);
        }
        public PanelTCModel From
        {
            get { return _from; }
            set { SetProperty(ref _from, value); }
        }
        public PanelTCModel To
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
