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
    /// Логика взаимодействия для Players_Window.xaml
    /// </summary>
    public partial class Players_Window : Window
    {
        public Players_Window()
        {
            InitializeComponent();
            DataGridTournaments.ItemsSource = OPBD_COURSEEntities.GetContext().Player.ToList();
            DataGridTournaments.ItemsSource = OPBD_COURSEEntities.GetContext().Player.OrderBy(x => x.PlayerID).ToList();
        }

        private void AddPlayer_Click(object sender, RoutedEventArgs e)
        {
            AddPlayers_Window addplayerss_Window = new AddPlayers_Window();
            addplayerss_Window.Show();
            this.Hide();
        }

        private void ChangePlayer_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridTournaments.SelectedItem != null)
            {
                var item = (Player)DataGridTournaments.SelectedItem;
                new EditPlayers_Window(item).Show();
                Close();
            }
            else
            {
                MessageBox.Show("Выберите запись для изменения!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DeletePlayer_Click(object sender, RoutedEventArgs e)
        {
            
            var playerRemoving = DataGridTournaments.SelectedItems.Cast<Player>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить этого игрока?", "!",
            MessageBoxButton.YesNo, MessageBoxImage.Question) !=
            MessageBoxResult.Yes) return;

            try
            {
                OPBD_COURSEEntities.GetContext().Player.RemoveRange(playerRemoving);
                OPBD_COURSEEntities.GetContext().SaveChanges();

                MessageBox.Show("Игрок успешно удален.");
                DataGridTournaments.ItemsSource = OPBD_COURSEEntities.GetContext().Player.OrderBy(x => x.PlayerID).ToList();
            } 
            catch
            {
                MessageBox.Show("Удаление прошло неудачно!","Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
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

