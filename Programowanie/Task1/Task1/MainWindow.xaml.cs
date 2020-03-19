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

namespace Task1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitComboBox();
        }

        private void InitComboBox()
        {
            for(int i = 10;i<=60;i++)
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

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (fn_tb.Text != "Podaj imię" && ln_tb.Text != "Podaj nazwisko")
            {
                player_l.Items.Add(new Player(fn_tb.Text, ln_tb.Text, (int)age_cb.SelectedItem, (double)MySlider.Value));
                ResetValue();
            }
        }

        private void ResetValue()
        {
            fn_tb.Text = "Podaj imię";
            fn_tb.Foreground = Brushes.Gray;
            ln_tb.Text = "Podaj nazwisko";
            ln_tb.Foreground = Brushes.Gray;
            age_cb.SelectedIndex = 0;
            MySlider.Value = MySlider.Minimum;

        }
        private void Mod_Click(object sender, RoutedEventArgs e)
        {
            if (player_l.SelectedItems.Count != 0)
            {
                Player p = player_l.SelectedItem as Player;
                player_l.Items.RemoveAt(player_l.SelectedIndex);
                fn_tb.Text = p.FirstName;
                fn_tb.Foreground = Brushes.Black;
                ln_tb.Text = p.LastName;
                ln_tb.Foreground = Brushes.Black;
                age_cb.SelectedIndex = p.Age;
                MySlider.Value = p.Weight;
            }
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            if (player_l.SelectedItems.Count != 0)
            {
                player_l.Items.RemoveAt(player_l.SelectedIndex);
            }
        }

    }
}
