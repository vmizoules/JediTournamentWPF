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

namespace JediTournamentWPF.UserControls {
    /// <summary>
    /// Logique d'interaction pour GameResultUserControl.xaml
    /// </summary>
    public partial class GameResultUserControl : UserControl {
        private Key m_key;
        public GameResultUserControl(Key k) {
            Uri key_uri = null;
            Uri symbol_uri = null;

            InitializeComponent();
            m_key = k;

            switch (m_key) {
                case (Key.Q):
                    key_uri = new Uri("JediTournamentWPF;Resources/keyboardPics/q_key.png");
                    symbol_uri = new Uri("JediTournamentWPF;Resources/gameSymbols/pierre.png");
                    break;
                case (Key.S):
                    key_uri = new Uri("JediTournamentWPF;Resources/keyboardPics/s_key.png");
                    symbol_uri = new Uri("JediTournamentWPF;Resources/gameSymbols/feuille.png");
                    break;
                case (Key.D):
                    key_uri = new Uri("JediTournamentWPF;Resources/keyboardPics/d_key.png");
                    symbol_uri = new Uri("JediTournamentWPF;Resources/gameSymbols/ciseaux.png");
                    break;
                case (Key.K):
                    key_uri = new Uri("JediTournamentWPF;Resources/keyboardPics/k_key.png");
                    symbol_uri = new Uri("JediTournamentWPF;Resources/gameSymbols/pierre.png");
                    break;
                case (Key.L):
                    key_uri = new Uri("JediTournamentWPF;Resources/keyboardPics/l_key.png");
                    symbol_uri = new Uri("JediTournamentWPF;Resources/gameSymbols/feuille.png");
                    break;
                case (Key.M):
                    key_uri = new Uri("JediTournamentWPF;Resources/keyboardPics/m_key.png");
                    symbol_uri = new Uri("JediTournamentWPF;Resources/gameSymbols/ciseaux.png");
                    break;
                    // TODO : ajouter un default pour mettre un picture not found ?
            }

            symbol.Source = new BitmapImage(symbol_uri);
            key.Source = new BitmapImage(key_uri);
        }
    }
}
