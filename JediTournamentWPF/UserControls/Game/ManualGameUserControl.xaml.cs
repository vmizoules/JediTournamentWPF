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
using System.Windows.Threading;

namespace JediTournamentWPF.UserControls {
    /// <summary>
    /// Logique d'interaction pour ManualGameUserControl.xaml
    /// </summary>
    public partial class ManualGameUserControl : UserControl {

        private int m_counter;
        private DispatcherTimer m_timer = null;

        private bool m_j1;
        private bool m_j2;
        private List<Key> m_keyPressed;

        public ManualGameUserControl() {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e) {
            initializeAndLaunch();
        }

        private void initializeAndLaunch() {
            m_counter = 5;

            m_timer = new DispatcherTimer();
            m_timer.Interval = new TimeSpan(0, 0, 1);                                 // will 'tick' once every second
            m_timer.Tick += new EventHandler(doGame);

            m_j1 = false;
            m_j2 = false;
            m_keyPressed = new List<Key>();

            m_timer.Start();
        }
        
        private void doGame(object sender, EventArgs e) {
            if (m_counter > 0) {
                this.displayText.Text = m_counter.ToString();
            }
            else if (m_counter == 0) {
                displayText.Text = "Play !";
                Window.GetWindow(this).Focus();
                Window.GetWindow(this).KeyDown += GetPlayersKeys;
            }
            else if (m_counter == -3) {
                Window.GetWindow(this).KeyDown -= GetPlayersKeys;
                m_timer.Stop();

                displayResults();
            }
            if (m_j1 && m_j2)
                m_counter = -3; 
            else
                m_counter--;
        }

        /// <summary>
        /// Get what key player have pressed
        /// </summary>
        /// <param name="sender">Control which send the event</param>
        /// <param name="e">Contains the key pressed</param>
        private void GetPlayersKeys(object sender, KeyEventArgs e) {
            if (!m_keyPressed.Contains(e.Key) && (!(m_j1) || !(m_j2))) {
                if ((!m_j1) && (e.Key == Key.Q || e.Key == Key.S || e.Key == Key.D)) {
                    m_j1 = true;
                    m_keyPressed.Add(e.Key);
                }
                else if ((!m_j2) && (e.Key == Key.K || e.Key == Key.L || e.Key == Key.M)) {
                    m_j2 = true;
                    m_keyPressed.Add(e.Key);
                }
            }
        }

        private void displayResults() {

            // TODO : plus de gestion de cas : si un joueur n'a pas joué ? Si juste deux touches ? Si plus de deux touches, etc...

            if (m_keyPressed.Count < 2) {                   // Need to launch again
                MessageBox.Show("Il y a eu une erreur, ou les deux joueurs n'ont pas joué, nous allons recommencer !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                this.displayText.Text = "5";
                initializeAndLaunch();                      // Relaunch
            }
            else {                                          // Define only one key for each player
                int i = 0;
                // We don't use the boolean anymore, let's reuse them
                Key joueur1_key = Key.A, joueur2_key = Key.A;   // Compilator oblige to initialize
                m_j1 = false; m_j2 = false;
                while (!(m_j1 && m_j2) && i < m_keyPressed.Count) {
                    if (m_keyPressed[i] == Key.Q || m_keyPressed[i] == Key.S || m_keyPressed[i] == Key.D) {
                        joueur1_key = m_keyPressed[i];
                        m_j1 = true;
                    }
                    else if (m_keyPressed[i] == Key.K || m_keyPressed[i] == Key.L || m_keyPressed[i] == Key.M) {
                        joueur2_key = m_keyPressed[i];
                        m_j2 = true;
                    }
                    i++;
                }   // End while

                if (!(m_j1 && m_j2)) {                      // If one of the players didn't play
                    MessageBox.Show("Il y a eu une erreur (2), ou les deux joueurs n'ont pas joué, nous allons recommencer !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    this.displayText.Text = "5";
                    initializeAndLaunch();                  // Relaunch
                }
                else {                                      // All is ok, go to results
                    viewbox.Visibility = Visibility.Hidden;
                    resultsGrid.Visibility = Visibility.Visible;

                    GameResultUserControl joueur1_UserControl = new GameResultUserControl(joueur1_key);
                    GameResultUserControl joueur2_UserControl = new GameResultUserControl(joueur2_key);

                    resultsGrid.Children.Add(joueur1_UserControl);
                    resultsGrid.Children.Add(joueur2_UserControl);

                    joueur1_UserControl.SetValue(Grid.RowProperty, 2);
                    joueur2_UserControl.SetValue(Grid.RowProperty, 2);

                    joueur1_UserControl.SetValue(Grid.ColumnProperty, 2);
                    joueur1_UserControl.SetValue(Grid.ColumnProperty, 3);
                }
            }


        }

    }
}
