using EntitiesLayer;
using JediTournamentWPF.UserControls;
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

        public GamePage() {
            InitializeComponent();
        }

        public GamePage(Tournoi t, bool b) {
            InitializeComponent();

            m_tournament = t;
            m_manual = b;

            if(m_manual) {
                // Change the handler of the Button
                GoButton.Click += GoButton_Click;

                // Make the explanations visible
                explanations.Visibility = Visibility.Visible;
            }
        }

        private void GoButton_Click(object sender, RoutedEventArgs e) {
            ManualGameUserControl countDownControl = new ManualGameUserControl();

            Container.Children.Clear();
            explanations.Visibility = Visibility.Hidden;
            Container.Children.Add(countDownControl);
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e) {
            this.NavigationService.GoBack();
        }
    }
}
