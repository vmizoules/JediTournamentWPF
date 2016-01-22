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

        public MainWindow() {
            InitializeComponent();
            m_manager = new JediTournamentManager();
            Page homePage = new HomePage(m_manager);

            MainFrame.Navigate(homePage);
        }
    }
}
