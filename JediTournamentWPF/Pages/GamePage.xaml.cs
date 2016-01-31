using EntitiesLayer;
using JediTournamentWPF.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace JediTournamentWPF.Pages {
    /// <summary>
    /// Logique d'interaction pour GamePage.xaml
    /// </summary>
    public partial class GamePage : Page {

        private bool m_manual;
        private Tournoi m_tournament;
        private int m_counter;
        private DispatcherTimer m_timer = null;
        private CountDownUserControl m_countDownControl;


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
            m_countDownControl = new CountDownUserControl();

            Container.Children.Clear();
            Container.Children.Add(m_countDownControl);


            // Create the timer
            m_counter = 5;
            m_timer = new DispatcherTimer();
            m_timer.Interval = new TimeSpan(0, 0, 1);                                 // will 'tick' once every second
            m_timer.Tick += new EventHandler(changeCountDown);
            m_timer.Start();
            
        }

        private void changeCountDown(object sender, EventArgs e) {
            if (m_counter >= 0) { 
                m_countDownControl.displayText.Text = m_counter.ToString();
                m_counter--;
            }    
            else {
                m_timer.Stop();
                // TODO : display results
            }
                
        }
        private void GoButton_Click(object sender, RoutedEventArgs e) {

        }
    }
}
