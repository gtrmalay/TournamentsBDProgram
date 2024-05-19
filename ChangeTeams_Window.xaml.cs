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
    /// Логика взаимодействия для ChangeTeams_Window.xaml
    /// </summary>
    public partial class ChangeTeams_Window : Window
    {
        private Team currentTeam = new Team();
        OPBD_COURSEEntities bd = new OPBD_COURSEEntities();
        public ChangeTeams_Window(Team selectTeam)
        {
            InitializeComponent();
            if (selectTeam == null) return;
            currentTeam = selectTeam;
            DataContext = currentTeam;

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
                OPBD_COURSEEntities.GetContext().SaveChanges();
                MessageBox.Show("Изменение прошло успешно.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Изменение прошло неудачно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

