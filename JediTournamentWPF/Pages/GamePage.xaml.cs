using EntitiesLayer;
using JediTournamentWPF.UserControls;
using JediTournamentWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace JediTournamentWPF.Pages {
    /// <summary>
    /// Logique d'interaction pour GamePage.xaml
    /// </summary>
    public partial class GamePage : Page {

        private bool m_manual;
        private Tournoi m_tournament;
        private int m_current_match;
        private EPhaseTournoi m_current_phase;

        public GamePage() {
            InitializeComponent();
        }

        public GamePage(Tournoi t, bool b) {
            InitializeComponent();

            m_tournament = t;
            m_manual = b;
            m_current_match = 0;
            m_current_phase = EPhaseTournoi.HuitiemeFinale;

            currentMatch.DataContext = new MatchViewModel(m_tournament.Matchs[m_current_match]);

            if(m_manual) {
                // Change the handler of the Button
                GoButton.Click += GoButton_Click;

                // Make the explanations visible
                explanations.Visibility = Visibility.Visible;
            }
            else {
                explanations.Visibility = Visibility.Hidden;
            }
        }

        private void GoButton_Click(object sender, RoutedEventArgs e) {
            Match current_match = m_tournament.Matchs[m_current_match];
            ManualGameUserControl countDownControl = new ManualGameUserControl(current_match.Jedi1, current_match.Jedi2);

            Container.Children.Clear();
            explanations.Visibility = Visibility.Hidden;
            Container.Children.Add(countDownControl);
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e) {
            this.NavigationService.GoBack();
        }
    }
}
