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

namespace JediTournamentWPF {
    /// <summary>
    /// Création de nouveaux matchs
    /// </summary>
    public partial class MatchCreator : Page {

        private JediTournamentManager m_manager;
        public MatchCreator(JediTournamentManager manager) {
            InitializeComponent();
            m_manager = manager;
            comboJedi1.ItemsSource = m_manager.getNoSithsName();
            comboJedi2.ItemsSource = m_manager.getSithsNames();

        }

        private void cancelButton_Click(object sender, RoutedEventArgs e) {
            this.NavigationService.GoBack();
        }
    }
}
