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
                    key_uri = new Uri(@"/Resources/keyboardPics/q_key.png", UriKind.Relative);
                    symbol_uri = new Uri(@"/Resources/gameSymbols/pierre.png", UriKind.Relative);
                    break;
                case (Key.S):
                    key_uri = new Uri(@"/Resources/keyboardPics/s_key.png", UriKind.Relative);
                    symbol_uri = new Uri(@"/Resources/gameSymbols/feuille.png", UriKind.Relative);
                    break;
                case (Key.D):
                    key_uri = new Uri(@"/Resources/keyboardPics/d_key.png", UriKind.Relative);
                    symbol_uri = new Uri(@"/Resources/gameSymbols/ciseaux.png", UriKind.Relative);
                    break;
                case (Key.K):
                    key_uri = new Uri(@"/Resources/keyboardPics/k_key.png", UriKind.Relative);
                    symbol_uri = new Uri(@"/Resources/gameSymbols/pierre.png", UriKind.Relative);
                    break;
                case (Key.L):
                    key_uri = new Uri(@"/Resources/keyboardPics/l_key.png", UriKind.Relative);
                    symbol_uri = new Uri(@"/Resources/gameSymbols/feuille.png", UriKind.Relative);
                    break;
                case (Key.M):
                    key_uri = new Uri(@"/Resources/keyboardPics/m_key.png", UriKind.Relative);
                    symbol_uri = new Uri(@"/Resources/gameSymbols/ciseaux.png", UriKind.Relative);
                    break;
                    // TODO : ajouter un default pour mettre un picture not found ?
            }

            symbol.Source = new BitmapImage(symbol_uri);
            key.Source = new BitmapImage(key_uri);
        }
    }
}
