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
        public MainViewModel()
        {
            From = new PanelTCModel();
            To = new PanelTCModel();
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

        public void CopyFile(string sourcePath, string destinationPath)
        {
            //try
            //{
            //    File.Copy(sourcePath, destinationPath);
            //}
            //catch (Exception) {throw;}

        }

    }
}
