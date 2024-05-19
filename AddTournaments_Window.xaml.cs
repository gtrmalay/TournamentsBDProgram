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
using System.Windows.Shapes;
using TournamentsBDProgram;

namespace TournamentsBDProgram
{
    /// <summary>
    /// Логика взаимодействия для AddTournaments_Window.xaml
    /// </summary>
    public partial class AddTournaments_Window : Window
    {
        private Tournaments _currenttou = new Tournaments();

        public AddTournaments_Window()
        {
            InitializeComponent();

            DataContext = _currenttou;

        }

        private void BackToTou_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Tournaments_Window tou = new Tournaments_Window();
            tou.Show();
        }

        private void EditTou_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OPBD_COURSEEntities.GetContext().Tournaments.Add(_currenttou);
                OPBD_COURSEEntities.GetContext().SaveChanges();

                MessageBox.Show("Турнир добавлен.");
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    MessageBox.Show($"Ошибка при добавлении турнира: {ex.InnerException.Message}");
                }
                else
                {
                    MessageBox.Show($"Ошибка при добавлении турнира: {ex.Message}");
                }
            }
        }
    }
}