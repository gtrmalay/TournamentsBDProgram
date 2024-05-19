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

namespace TournamentsBDProgram
{
    /// <summary>
    /// Логика взаимодействия для AddTeams_Window.xaml
    /// </summary>
    public partial class AddTeams_Window : Window
    {
        private Team _currentteam = new Team();

        public AddTeams_Window()
        {
            InitializeComponent();

            DataContext = _currentteam;

        }
        private void BackToTeams_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Teams_Window teams = new Teams_Window();
            teams.Show();
        }

        private void EditTeam_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OPBD_COURSEEntities.GetContext().Team.Add(_currentteam);
                OPBD_COURSEEntities.GetContext().SaveChanges();

                MessageBox.Show("Команда добавлена.");
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    MessageBox.Show($"Ошибка при добавлении команды: {ex.InnerException.Message}");
                }
                else
                {
                    MessageBox.Show($"Ошибка при добавлении команды: {ex.Message}");
                }
            }
        }
    }
}

