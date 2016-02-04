using BusinessLayer;
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

        private Random m_random;

        private bool m_manual;
        private Tournoi m_tournament;
        private int m_current_match;
        private EPhaseTournoi m_currentPhase;
        private JediTournamentManager m_manager;
        private List<Match> m_nextPhase;

        public GamePage() {
            InitializeComponent();
        }

        public GamePage(Tournoi t, bool b) {
            InitializeComponent();

            m_tournament = t;
            m_manual = b;
            m_current_match = 0;
            m_currentPhase = EPhaseTournoi.HuitiemeFinale;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e) {
            m_random = new Random();
            m_manager = new JediTournamentManager();

            recap.DataContext = new MatchViewModel(m_tournament.Matchs[m_current_match]);

            if (m_manual) {
                // Change the handler of the Button
                GoButton.Click += LaunchManualGame;

                // Make the explanations visible
                explanations.Visibility = Visibility.Visible;
            }
            else {
                GoButton.Content = "Résultat";
                GoButton.Click += LaunchAutoGame;
                explanations.Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// Launch the game in mode manual
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LaunchManualGame(object sender, RoutedEventArgs e) {
            Match current_match = m_tournament.Matchs[m_current_match];
            ManualGameUserControl countDownControl = new ManualGameUserControl(current_match.Jedi1, current_match.Jedi2);

            Container.Children.Clear();
            explanations.Visibility = Visibility.Hidden;
            Container.Children.Add(countDownControl);
        }

        /// <summary>
        /// Launch the game in mode automatic
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LaunchAutoGame(object sender, RoutedEventArgs e) {
            Jedi current_winner = null;

            GoButton.Content = "Match suivant";

            if(m_current_match >= m_tournament.Matchs.Count) {
                GoButton.Click -= LaunchAutoGame;                           // Désactivation du bouton
                GoButton.Visibility = Visibility.Hidden;                    // On cache le bouton
                if(!m_manager.updateTournoi(m_tournament))
                    MessageBox.Show("Problème lors de la mise à jour du tournoi dans la base de données !",
                            Assembly.GetExecutingAssembly().GetName().Name,
                            MessageBoxButton.OK,
                            MessageBoxImage.Error);
            }
            else {
                Match current_match = m_tournament.Matchs[m_current_match];

                ContainerAuto.Visibility = Visibility.Visible;
                recap.Visibility = Visibility.Hidden;

                if (Convert.ToBoolean(m_random.Next() % 2)) {
                    current_match.IdJediVainqueur = current_match.Jedi1.ID;
                    current_winner = current_match.Jedi1;
                    winner.DataContext = current_winner;
                    winnerText.Text = current_winner.Nom + " gagne !";
                }
                else {
                    current_match.IdJediVainqueur = current_match.Jedi2.ID;
                    current_winner = current_match.Jedi2;
                    winner.DataContext = current_winner;
                    winnerText.Text = current_winner.Nom + " gagne !";
                }

                if (m_manager.updateMatch(current_match) < 0) {
                    throw new Exception("Problème lors de la mise à jour des données !");
                }

                m_current_match++;
            }
            
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e) {
            NavigationService.GoBack();
        }

        
    }
}
