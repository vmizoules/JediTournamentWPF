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
using JediTournamentWPF.ViewModel.Historique;

namespace JediTournamentWPF.Pages
{
    /// <summary>
    /// Logique d'interaction pour HistoriquePage.xaml
    /// </summary>
    public partial class HistoriquePage : Page
    {

        public HistoriquePage(JediTournamentManager manager) 
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e) {
            // Initialisation du viewModel
            HistoriqueViewModel hvm = new HistoriqueViewModel();
            this.DataContext = hvm;
            hvm.CancelNotified += onCancel;
        }

        private void onCancel(Object sender, EventArgs args) {
            this.NavigationService.GoBack();
        }
    }
}
