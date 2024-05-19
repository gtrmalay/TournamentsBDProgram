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
    /// Логика взаимодействия для EditPlayers_Window.xaml
    /// </summary>
    public partial class EditPlayers_Window : Window
    {
        private Player currentpl = new Player();
        OPBD_COURSEEntities bd = new OPBD_COURSEEntities();
        public EditPlayers_Window(Player selectplayer)
        {
            InitializeComponent();
            if (selectplayer == null) return;
            currentpl = selectplayer;
            DataContext = currentpl;

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
