using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MiniTC.Base;

namespace MiniTC.Models
{
    class PanelTCModel : BaseVM
    {
        #region Własności
        private List<string> _files;
        private List<string> _drives;
        private string _selectedDrive;
        private string _path;
        private string _selectedFile;
        private ICommand _changeDirCommand = null;

        public ICommand ChangeDirCommand
        {
            get
            {
                if (_changeDirCommand == null){ _changeDirCommand = new RelayCommand(GoToDirectory);}
                return _changeDirCommand;
            }
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
        public string SelectedFile
        {
            get { return _selectedFile; }
            set { SetProperty(ref _selectedFile, value); }
        }
        #endregion
        public PanelTCModel()
        {
            Drives = new List<string>();
            UpdateLogicalDrives();
            SelectedDrive = Drives[0];
        }

        public void UpdateDirectoryContent()
        {
            Files = new List<string>();
            if (Path.Length >= 4) Files.Add("..");
            Directory.GetDirectories(Path).ToList().ForEach(x => Files.Add("<D> " + x));
            Directory.GetFiles(Path).ToList().ForEach(x => Files.Add(x));
            for (int i = 1; i < Files.Count; i++)
            {
                string[] ar = Files[i].Split('\\');
                if (Files[i].Contains("<D> ")) Files[i] = "<D> " + ar.Last();
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
        public void GoToDirectory()
        {
            string directory = SelectedFile;
            if (directory == "..")
            {
                string[] toDelete = Path.Split('\\');
                Path = Path.Replace(toDelete.Last(), "");
                var str = Path.Last();
                if (str == '\\' && Path.Length >= 4) Path = Path.Remove(Path.Length - 1);
                UpdateDirectoryContent();
            }
            if (directory.Contains("<D> "))
            {
                directory = directory.Replace("<D> ", "");
                if (Path.Length >= 4) Path += '\\' + directory;
                else Path += directory;
                UpdateDirectoryContent();
            }
        }

        public void CopyTo(string destinationPath)
        {
            if (SelectedFile == null || SelectedFile.Contains("<D> ") || SelectedFile == "..") return;
            string sourcePath;
            if (Path.Last() == '\\') sourcePath = Path + SelectedFile;
            else sourcePath = Path + "\\" + SelectedFile;

            if (destinationPath.Last() == '\\') destinationPath += SelectedFile;
            else destinationPath += "\\" + SelectedFile;

            File.Copy(sourcePath, destinationPath);
        }

    }
}
