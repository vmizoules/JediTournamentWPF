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
using EntitiesLayer;
using BusinessLayer;

namespace JediTournamentWPF.Pages {
    /// <summary>
    /// Logique d'interaction pour GestionJediPage.xaml
    /// </summary>
    public partial class GestionJediPage : Page {

        private JediTournamentManager m_manager;
        public GestionJediPage(JediTournamentManager manager) 
        {
            m_manager = manager;
            InitializeComponent();
            JediList.ItemsSource = m_manager.getAllJedisNames();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void JediList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

    }
}
