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

            #region Variables initialization
            m_counter = 5;

            m_timer = new DispatcherTimer();
            m_timer.Interval = new TimeSpan(0, 0, 1);                                 // will 'tick' once every second
            m_timer.Tick += new EventHandler(doGame);
            
            m_j1 = false;
            m_j2 = false;
            m_keyPressed = new List<Key>();
            #endregion

            m_timer.Start();
        }
        
        private void doGame(object sender, EventArgs e) {
            if (m_counter > 0) {
                this.displayText.Text = m_counter.ToString();
            }
            else if (m_counter == 0) {
                this.displayText.Text = "Play !";
                this.Focus();
                this.KeyUp += GetPlayersKeys;
            }
            else if (m_counter == -3) {
                this.KeyUp -= GetPlayersKeys;
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

        }

    }
}
