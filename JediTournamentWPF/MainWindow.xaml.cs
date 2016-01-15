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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Reflection;
using System.Windows.Shapes;
using EntitiesLayer;

namespace JediTournamentWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Business manager.
        /// </summary>
        private JediTournamentManager m_manager;

        public MainWindow()
        {
            InitializeComponent();

            m_manager = new JediTournamentManager();
        }

        private void ExportJedi_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            // Configure la boite de dialogue
            dialog.InitialDirectory = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            dialog.DefaultExt = ".xml";
            dialog.Filter = "Fichier XML (*.xml)|*.xml";
            
            // Boite de dialogue de sauvegarde
            DialogResult result = dialog.ShowDialog();

            // Sauvegarde
            if (result.ToString() == "OK")
            {
                m_manager.serializeJedis(dialog.FileName);
            }
        }

        private void buttonJedis_Click(object sender, RoutedEventArgs e)
        {
            displayPanel.Children.Clear();

            List<Jedi> jedis = m_manager.getAllJedis();
            foreach(Jedi j in jedis)
            {
                TextBlock tb = new TextBlock();
                DockPanel.SetDock(tb, Dock.Left);
                tb.Text = j.Nom + " (" + (j.IsSith ? "Sith" : "Non Sith" ) + ")\n";
                tb.Foreground = new SolidColorBrush(Colors.White);

                displayPanel.Children.Add(tb);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Login win = new Login();
            win.Show();
        }
    }
}
