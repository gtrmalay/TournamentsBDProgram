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
    /// Логика взаимодействия для AddPlayers_Window.xaml
    /// </summary>
    public partial class AddPlayers_Window : Window
    {
        private Player _currentpl = new Player();

        public AddPlayers_Window()
        {
            InitializeComponent();

            DataContext = _currentpl;

        }

        private void BackToPlayers_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Players_Window pl = new Players_Window();
            pl.Show();
        }

        private void EditPlayer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OPBD_COURSEEntities.GetContext().Player.Add(_currentpl);
                OPBD_COURSEEntities.GetContext().SaveChanges();

                MessageBox.Show("Игрок добавлен.");
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    MessageBox.Show($"Ошибка при добавлении игрок: {ex.InnerException.Message}");
                }
                else
                {
                    MessageBox.Show($"Ошибка при добавлении игрока: {ex.Message}");
                }
            }
        }
    }
}
