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

namespace Calculator
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Calculation cal;
        public MainWindow()
        {
            InitializeComponent();
            cal = new Calculation();
        }

        private void But1_Click(object sender, RoutedEventArgs e)
        {
            diplayWindow.Text = cal.AddNumber('1');
        }

        private void But2_Click(object sender, RoutedEventArgs e)
        {
            diplayWindow.Text = cal.AddNumber('2');
        }

        private void But3_Click(object sender, RoutedEventArgs e)
        {
            diplayWindow.Text = cal.AddNumber('3');
        }

        private void But4_Click(object sender, RoutedEventArgs e)
        {
            diplayWindow.Text = cal.AddNumber('4');
        }

        private void But5_Click(object sender, RoutedEventArgs e)
        {
            diplayWindow.Text = cal.AddNumber('5');
        }

        private void But6_Click(object sender, RoutedEventArgs e)
        {
            diplayWindow.Text = cal.AddNumber('6');
        }

        private void But7_Click(object sender, RoutedEventArgs e)
        {
            diplayWindow.Text = cal.AddNumber('7');
        }

        private void But8_Click(object sender, RoutedEventArgs e)
        {
            diplayWindow.Text = cal.AddNumber('8');
        }

        private void But9_Click(object sender, RoutedEventArgs e)
        {
            diplayWindow.Text = cal.AddNumber('9');
        }

        private void But0_Click(object sender, RoutedEventArgs e)
        {
            diplayWindow.Text = cal.AddNumber('0');
        }

        private void Eqs_Click(object sender, RoutedEventArgs e)
        {
            diplayWindow.Text = cal.Equals();
        }

        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            cal.Action('+');
        }
        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            cal.Action('-');
        }

        private void Multiply_Click(object sender, RoutedEventArgs e)
        {
            cal.Action('*');
        }

        private void Divide_Click(object sender, RoutedEventArgs e)
        {
            cal.Action('/');
        }

        private void Bck_Click(object sender, RoutedEventArgs e)
        {
            diplayWindow.Text = cal.DeleteNum();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            diplayWindow.Text = cal.Clear();
        }

        private void Ce_Click(object sender, RoutedEventArgs e)
        {
            diplayWindow.Text = cal.ClearAll();
        }

        private void Sign_Click(object sender, RoutedEventArgs e)
        {
            diplayWindow.Text = cal.ChangeSign();
        }

        private void Coma_Click(object sender, RoutedEventArgs e)
        {
            diplayWindow.Text = cal.AddNumber(',');
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            string str ="";
            if (e.Key == Key.NumPad1) str = cal.AddNumber('1');
            else if (e.Key == Key.NumPad2) str = cal.AddNumber('2');
            else if (e.Key == Key.NumPad3) str = cal.AddNumber('3');
            else if (e.Key == Key.NumPad4) str = cal.AddNumber('4');
            else if (e.Key == Key.NumPad5) str = cal.AddNumber('5');
            else if (e.Key == Key.NumPad6) str = cal.AddNumber('6');
            else if (e.Key == Key.NumPad7) str = cal.AddNumber('7');
            else if (e.Key == Key.NumPad8) str = cal.AddNumber('8');
            else if (e.Key == Key.NumPad9) str = cal.AddNumber('9');
            else if (e.Key == Key.NumPad0) str = cal.AddNumber('0');
            else if (e.Key == Key.Decimal) str = cal.AddNumber(',');
            if (str != "") {
                diplayWindow.Text = str;
                return;
            }
            
            if (e.Key == Key.Multiply) cal.Action('*');
            else if (e.Key == Key.Divide) cal.Action('/');
            else if (e.Key == Key.Add) cal.Action('+');
            else if (e.Key == Key.Subtract) cal.Action('-');
            if (e.Key == Key.Enter) diplayWindow.Text = cal.Equals();
        }
    }
}
