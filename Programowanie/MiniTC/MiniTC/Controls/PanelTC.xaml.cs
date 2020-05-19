using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MiniTC.Controls
{
    public partial class PanelTC : UserControl
    {
        public PanelTC()
        {
            InitializeComponent();
        }
        public static readonly DependencyProperty OpenDirectoryCommandProperty =
            DependencyProperty.Register("OpenDirCommand", typeof(ICommand),
                typeof(PanelTC), new PropertyMetadata(null));

        public ICommand OpenDirCommand
        {
            get { return (ICommand)GetValue(OpenDirectoryCommandProperty); }
            set { SetValue(OpenDirectoryCommandProperty, value); }
        }
        public string CurrentPath
        {
            get { return (string)GetValue(CurrentPathProperty); }
            set { SetValue(CurrentPathProperty, value); }
        }

        public static readonly DependencyProperty CurrentPathProperty =
            DependencyProperty.Register("CurrentPath", typeof(string), typeof(PanelTC), new PropertyMetadata(""));

        public List<string> DrivesList
        {
            get { return (List<string>)GetValue(DrivesListProperty); }
            set { SetValue(DrivesListProperty, value); }
        }

        public static readonly DependencyProperty DrivesListProperty =
            DependencyProperty.Register("DrivesList", typeof(List<string>), typeof(PanelTC), new PropertyMetadata(null));

        public string SelectedDrive
        {
            get { return (string)GetValue(SelectedDriveProperty); }
            set { SetValue(SelectedDriveProperty, value); }
        }

        public static readonly DependencyProperty SelectedDriveProperty =
            DependencyProperty.Register("SelectedDrive", typeof(string), typeof(PanelTC), new PropertyMetadata(""));

        public List<string> FileList
        {
            get { return (List<string>)GetValue(FileListProperty); }
            set { SetValue(FileListProperty, value); }
        }

        public static readonly DependencyProperty FileListProperty =
            DependencyProperty.Register("FileList", typeof(List<string>), typeof(PanelTC), new PropertyMetadata(null));


        public static readonly DependencyProperty SelectedFileProperty =
            DependencyProperty.Register("SelectedFile", typeof(string),
                typeof(PanelTC), new PropertyMetadata(""));

        public string SelectedFile
        {
            get { return (string)GetValue(SelectedFileProperty); }
            set { SetValue(SelectedFileProperty, value); }
        }
    }
}
