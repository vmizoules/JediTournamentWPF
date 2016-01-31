using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JediTournamentWPF.ViewModel
{
    class TournamentHistoryViewModel : ViewModelBase
    {
        // constructeur
        public TournamentHistoryViewModel()
        {
            Teeext = "aaaaaaaaaaaaaaaaa";
        }

        private JediGestionViewModel m_jedi;

        internal JediGestionViewModel Jedi
        {
            get { return m_jedi; }
        }

        private String _teeext = "abc";

        public String Teeext
        {
            get { return _teeext; }
            set { _teeext = value; }
        }


        
    }
}
