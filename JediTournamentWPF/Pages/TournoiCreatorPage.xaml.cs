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
using JediTournamentWPF.ViewModel;

namespace JediTournamentWPF.Pages {
    /// <summary>
    /// Logique d'interaction pour NewTournoiPage.xaml
    /// </summary>
    public partial class NewTournoiPage : Page {

        private TournoiCreatorViewModel m_tmv;
        public NewTournoiPage() {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e) {
            // Initialisation du viewModel
            m_tmv = new TournoiCreatorViewModel();

            // Abonnement à l'évènement pour revenir en arrière
            DataContext = m_tmv;                     // On donne le contexte des données
            m_tmv.CancelNotified += onCancel;
            m_tmv.CreateNotified += onCreate;
        }

        private void onCancel(Object sender, EventArgs args) {
            NavigationService.GoBack();
        }

        private void onCreate(Object sender, EventArgs args) {
            // TODO : to modify
            GamePage nextPage = new GamePage(m_tmv.Tournoi, true);
            this.NavigationService.Navigate(nextPage);
        }
    }
}
