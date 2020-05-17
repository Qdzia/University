using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using MiniTC.Base;

namespace MiniTC.Models
{
    class PanelTCModel : BaseVM
    {
        private List<string> _files;
        private List<string> _drives;
        private string _selectedDrive;
        private string _path;
        private RelayCommand _goToDirCommand;
        private string _changeDirectory;

        public RelayCommand GoToDirCommand
        {
            get { return _goToDirCommand; }
            set { SetProperty(ref _goToDirCommand, value); }
        }
        public List<string> Files
        {
            get { return _files; }
            set { SetProperty(ref _files, value); }
        }
        public List<string> Drives
        {
            get { return _drives; }
            set { SetProperty(ref _drives, value); }
        }
        public string SelectedDrive
        {
            get { return _selectedDrive; }
            set { SetProperty(ref _selectedDrive, value); OnDriveChange(); }
        }
        public string Path
        {
            get { return _path; }
            set { SetProperty(ref _path, value); }
        }
        public string ChangeDirectory
        {
            get { return _changeDirectory; }
            set { SetProperty(ref _changeDirectory, value); GoToDirectory(Files[0]); }
        }
        public PanelTCModel()
        {
            GoToDirCommand = new RelayCommand(GoTo);
            Files = new List<string>();
            Drives = new List<string>();
            UpdateLogicalDrives();
            SelectedDrive = Drives[1];
            //GoToDirectory(Files[7]);
            //GoToDirectory(Files[1]);

        }

        public void UpdateDirectoryContent()
        {
            Files = new List<string>();
            Files.Add("..");
            Directory.GetDirectories(Path).ToList().ForEach(x => Files.Add("<D>" + x));
            Directory.GetFiles(Path).ToList().ForEach(x => Files.Add(x));
            for (int i = 1; i < Files.Count; i++)
            {
                string[] ar = Files[i].Split('\\');
                if (Files[i].Contains("<D>")) Files[i] = "<D>" + ar.Last();
                else Files[i] = ar.Last();
            }
        }

        public void UpdateLogicalDrives()
        {
            Drives.Clear();
            Directory.GetLogicalDrives().ToList().ForEach(x => Drives.Add(x));

        }
        public void OnDriveChange()
        {
            Path = SelectedDrive;
            UpdateDirectoryContent();
        }
        public void GoToDirectory(string directory)
        {
            if (directory == "..")
            {
                string[] toDelete = Path.Split('\\');
                Path = Path.Replace('\\' + toDelete.Last(), "");
                UpdateDirectoryContent();
            }
            if (directory.Contains("<D>"))
            {
                directory = directory.Replace("<D>", "");
                if (Path.Length >= 4) Path += '\\' + directory;
                else Path += directory;
                UpdateDirectoryContent();
            }
        }

        public void GoTo()
        {
            Path = @"D:\BackUp";
            UpdateDirectoryContent();

        }

    }
}
