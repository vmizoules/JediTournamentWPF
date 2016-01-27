using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JediTournamentWPF.ViewModel {
    class MatchViewModel : ViewModelBase {

        private Match m_match;

        public Match Match
        {
            get { return m_match; }
            private set{ m_match = value; }
        }

        public MatchViewModel() {

        //    m_match = new Match(null, null, EPhaseTournoi.HuitiemeFinale, null);
            // TODO constructeur avec variables aléatoires
        }

        public MatchViewModel(Match m) {
            m_match = m;
        }

        #region "Propriétés accessibles, mappables par la View"

        public string Descriptor
        {
            get { return m_match.Jedi1.Nom + " vs " + m_match.Jedi2.Nom; }
        }

        /// <summary>
        /// First Jedi in the match
        /// Must be a jedi
        /// </summary>
        public Jedi Jedi1
        {
            get { return m_match.Jedi1; }
            set
            {
                if (value == m_match.Jedi1 || (value.IsSith)) return;
                m_match.Jedi1 = value;
                base.OnPropertyChanged("Jedi1");
            }
        }

        /// <summary>
        /// Second Jedi in the match
        /// Must be a sith
        /// </summary>
        public Jedi Jedi2
        {
            get { return m_match.Jedi2; }
            set
            {
                if (value == m_match.Jedi2 || !(value.IsSith)) return;
                m_match.Jedi2 = value;
                base.OnPropertyChanged("Jedi2");
            }
        }

        public Stade Stade
        {
            get { return m_match.Stade; }
            set
            {
                if (value == m_match.Stade) return;
                m_match.Stade = value;
                base.OnPropertyChanged("Stade");
            }
        }

        #endregion
    }
}
