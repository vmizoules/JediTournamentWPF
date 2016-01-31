using EntitiesLayer;
using JediTournamentWPF.UserControls;
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

namespace JediTournamentWPF.Pages {
    /// <summary>
    /// Logique d'interaction pour GamePage.xaml
    /// </summary>
    public partial class GamePage : Page {

        private bool m_manual;
        private Tournoi m_tournament;
        public GamePage() {
            InitializeComponent();
        }

        public GamePage(Tournoi t, bool b) {
            InitializeComponent();

            m_tournament = t;
            m_manual = b;

            if(m_manual) {
                // Change the handler
                GoButton.Click -= GoButton_Click;
                GoButton.Click += countdown;

                // Make the explanations visible
                explanations.Visibility = Visibility.Visible;
            }
        }

        private void countdown(object sender, RoutedEventArgs e) {
            UIElementCollection oldElements = Container.Children;                   // Sauvegarde contexte
            UserControl uc = new UserControl();

            Container.Children.Clear();
            Container.Children.Add(uc);

            for(int i = 5; i >= 0; i--) {
                // TODO : chopper le texte et le décrémenter
            }
            // TODO : do the countdown
        }
        private void GoButton_Click(object sender, RoutedEventArgs e) {

        }
    }
}
