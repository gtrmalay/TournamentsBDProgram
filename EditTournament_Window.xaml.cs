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
    public partial class EditTournament_Window : Window
    {
        private Tournaments currenttou = new Tournaments();
        OPBD_COURSEEntities bd = new OPBD_COURSEEntities();
        public EditTournament_Window(Tournaments selecttou)
        {
            InitializeComponent();
            if (selecttou == null) return;
            currenttou = selecttou;
            DataContext = currenttou;

        }

        private void BackToTou_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Tournaments_Window to = new Tournaments_Window();
            to.Show();
        }

        private void EditTou_Click(object sender, RoutedEventArgs e)
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