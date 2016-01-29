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
        public NewTournoiPage() {
            InitializeComponent();
        }
    
        private void Page_Loaded(object sender, RoutedEventArgs e) {
            // Initialisation du viewModel
            TournoiCreatorViewModel tmv = new TournoiCreatorViewModel();

            // Abonnement à l'évènement pour revenir en arrière
            this.DataContext = tmv;                     // On donne le contexte des données
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e) {
            this.NavigationService.GoBack();
        }
    }
}
