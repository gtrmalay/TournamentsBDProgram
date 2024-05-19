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
    /// Логика взаимодействия для Teams_Window.xaml
    /// </summary>
    public partial class Teams_Window : Window
    {
        public Teams_Window()
        {
            InitializeComponent();
            DataGridTournaments.ItemsSource = OPBD_COURSEEntities.GetContext().Team.ToList();
            DataGridTournaments.ItemsSource = OPBD_COURSEEntities.GetContext().Team.OrderBy(x => x.TeamID).ToList();
        }

        private void AddPlayer_Click(object sender, RoutedEventArgs e)
        {
            AddTeams_Window addTeams_Window = new AddTeams_Window();
            addTeams_Window.Show();
            this.Hide();
        }

        private void ChangePlayer_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridTournaments.SelectedItem != null)
            {
                var item = (Team)DataGridTournaments.SelectedItem;
                new ChangeTeams_Window(item).Show();
                Close();
            }
            else
            {
                MessageBox.Show("Выберите запись для изменения!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DeletePlayer_Click(object sender, RoutedEventArgs e)
        {
            var teamRemoving = DataGridTournaments.SelectedItems.Cast<Team>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить эту команду?", "!",
            MessageBoxButton.YesNo, MessageBoxImage.Question) !=
            MessageBoxResult.Yes) return;

            try
            {
            OPBD_COURSEEntities.GetContext().Team.RemoveRange(teamRemoving);
            OPBD_COURSEEntities.GetContext().SaveChanges();

            MessageBox.Show("Команда успешно удалена.");
            DataGridTournaments.ItemsSource = OPBD_COURSEEntities.GetContext().Team.OrderBy(x => x.TeamID).ToList();
            }
            catch
            {
                MessageBox.Show("Удаление прошло неудачно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ToMain_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
        }
    }
}
