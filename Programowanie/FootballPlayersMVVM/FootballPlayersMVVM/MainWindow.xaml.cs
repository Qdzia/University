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

namespace FootballPlayersMVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitControls();
        }

        void InitControls() 
        {
            fn_tb.Text = "Podaj imię"; 
            ln_tb.Text = "Podaj nazwisko";
            fn_tb.Foreground = Brushes.Gray;
            ln_tb.Foreground = Brushes.Gray;

            for (int i = 10; i <= 60; i++)
                age_cb.Items.Add(i);
        }
        private void tb_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;

            if (tb.Text == "Podaj imię" || tb.Text == "Podaj nazwisko")
            {
                tb.BorderBrush = SystemColors.ControlDarkBrush;
                tb.Text = "";
                tb.Foreground = Brushes.Black;
            }
        }

        private void tb_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb.Text == "")
            {
                if (tb.Name == "fn_tb") tb.Text = "Podaj imię";
                else tb.Text = "Podaj nazwisko";
                tb.BorderThickness = new Thickness(3);
                tb.Foreground = Brushes.Gray;
                tb.BorderBrush = Brushes.Red;
            }
            else
            {
                tb.BorderThickness = new Thickness(1);
                tb.BorderBrush = Brushes.Gray;

            }

        }
    }
}
