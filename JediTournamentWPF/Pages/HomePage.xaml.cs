using BusinessLayer;
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
using System.Windows.Forms;
using JediTournamentWPF.Pages;

namespace JediTournamentWPF {
    /// <summary>
    /// Logique d'interaction pour HomePage.xaml
    /// </summary>

    public partial class HomePage : Page {

        /// <summary>
        /// Business manager
        /// </summary>
        private JediTournamentManager m_manager;
        public HomePage(JediTournamentManager manager) {
            InitializeComponent();
            m_manager = manager;
        }

       /* private void ExportJedi_Click(object sender, RoutedEventArgs e) {
            SaveFileDialog dialog = new SaveFileDialog();
            // Configure la boite de dialogue
            dialog.InitialDirectory = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            dialog.DefaultExt = ".xml";
            dialog.Filter = "Fichier XML (*.xml)|*.xml";

            // Boite de dialogue de sauvegarde
            DialogResult result = dialog.ShowDialog();

            // Sauvegarde
            if (result.ToString() == "OK") {
                m_manager.serializeJedis(dialog.FileName);
            }
        }*/

        private void buttonJedis_Click(object sender, RoutedEventArgs e) {
            GestionJediPage nextpage = new GestionJediPage();
            NavigationService.Navigate(nextpage);

            /*displayPanel.Children.Clear();

            List<Jedi> jedis = m_manager.getAllJedis();
            foreach (Jedi j in jedis) {
                TextBlock tb = new TextBlock();
                DockPanel.SetDock(tb, Dock.Left);
                tb.Text = j.Nom + " (" + (j.IsSith ? "Sith" : "Non Sith") + ")\n";
                tb.Foreground = new SolidColorBrush(Colors.White);

                displayPanel.Children.Add(tb);
            }*/
        }
        private void buttonMatch_Click(object sender, RoutedEventArgs e) {
            MatchCreator nextpage = new MatchCreator(m_manager);
            NavigationService.Navigate(nextpage);
        }

        private void buttonTournoi_Click(object sender, RoutedEventArgs e) {

        }

        private void buttonStades_Click(object sender, RoutedEventArgs e) {
            GestionStadePage nextpage = new GestionStadePage();
            NavigationService.Navigate(nextpage);
        }
    }
}
