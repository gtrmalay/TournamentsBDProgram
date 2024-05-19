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
    /// Логика взаимодействия для Tournaments_Window.xaml
    /// </summary>
    public partial class Tournaments_Window : Window
    {
        public Tournaments_Window()
        {
            InitializeComponent();
            DataGridTournaments.ItemsSource = OPBD_COURSEEntities.GetContext().Tournaments.ToList();
            DataGridTournaments.ItemsSource = OPBD_COURSEEntities.GetContext().Tournaments.OrderBy(x => x.TournamentID).ToList();
        }

        private void AddTou_Click(object sender, RoutedEventArgs e)
        {
            AddTournaments_Window addtournaments_Window = new AddTournaments_Window();
            addtournaments_Window.Show();
            this.Hide();
        }

        private void ChangeTou_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridTournaments.SelectedItem != null)
            {
                var item = (Tournaments)DataGridTournaments.SelectedItem;
                new EditTournament_Window(item).Show();
                Close();
            }
            else
            {
                MessageBox.Show("Выберите запись для изменения!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DeleteTou_Click(object sender, RoutedEventArgs e)
        {
            var touRemoving = DataGridTournaments.SelectedItems.Cast<Tournaments>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить этот турнир?", "!",
            MessageBoxButton.YesNo, MessageBoxImage.Question) !=
            MessageBoxResult.Yes) return;

            try
            {
            OPBD_COURSEEntities.GetContext().Tournaments.RemoveRange(touRemoving);
            OPBD_COURSEEntities.GetContext().SaveChanges();

            MessageBox.Show("Турнир успешно удален.");
            DataGridTournaments.ItemsSource = OPBD_COURSEEntities.GetContext().Tournaments.OrderBy(x => x.TournamentID).ToList();
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
