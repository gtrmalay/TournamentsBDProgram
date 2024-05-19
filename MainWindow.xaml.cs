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

namespace TournamentsBDProgram
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Players_click(object sender, RoutedEventArgs e)
        {
            Players_Window playersWindow = new Players_Window();
            playersWindow.Show();
            this.Hide();
        }

        private void Tournaments_click(object sender, RoutedEventArgs e)
        {
            Tournaments_Window tournaments_window = new Tournaments_Window();
            tournaments_window.Show();
            this.Hide();
        }

        private void Teams_click(object sender, RoutedEventArgs e)
        {
            Teams_Window teamsWindow = new Teams_Window();
            teamsWindow.Show();
            this.Hide();
        }
    }
}
