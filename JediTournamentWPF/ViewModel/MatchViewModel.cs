using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JediTournamentWPF.ViewModel {
    class MatchViewModel : ViewModelBase {

        // Attribute of the model
        private Match m_match;

        public MatchViewModel() {

        //    m_match = new Match(null, null, EPhaseTournoi.HuitiemeFinale, null);
            // TODO constructeur avec variables aléatoires
        }

        public MatchViewModel(Match m) {
            // displayed match
            m_match = m;

            // Initialiser m_jedi et m_sith

            //BusinessLayer.JediTournamentManager bm = new BusinessLayer.JediTournamentManager();
            //m_jedis = new ObservableCollection<JediViewModel>(bm.getAllJedis());

        }

        #region "Propriétés accessibles, mappables par la View"

        /// <summary>
        /// A "ToString" for a Match
        /// </summary>
        public string Descriptor
        {
            get { return m_match.Jedi1.Nom + " vs " + m_match.Jedi2.Nom; }
        }

        // List of Jedis
        private ObservableCollection<JediViewModel> m_jedis;

        /// <summary>
        /// Getters to have the list of Jedis
        /// </summary>
        public ObservableCollection<JediViewModel> Jedis
        {
            get { return m_jedis; }
        }

        // List of Siths
        private ObservableCollection<JediViewModel> m_siths;

        /// <summary>
        /// Getters to have the list of Siths
        /// </summary>
        public ObservableCollection<JediViewModel> Siths
        {
            get { return m_siths; }
        }

        // Jedi selected
        private JediViewModel m_selectedJedi;

        /// <summary>
        /// Getter and setter for selected Jedi
        /// </summary>
        public JediViewModel SelectedJedi
        {
            get { return m_selectedJedi; }
            set
            {
                m_selectedJedi = value;
                base.OnPropertyChanged("Jedi1");
            }
        }

        // Sith selected
        private JediViewModel m_selectedSith;

        /// <summary>
        /// Getter and setter for selected Jedi
        /// </summary>
        public JediViewModel SelectedSith
        {
            get { return m_selectedSith; }
            set
            {
                m_selectedSith = value;
                OnPropertyChanged("SelectedSith");
            }
        }

        private StadeViewModel m_selectedStade;

        public StadeViewModel SelectedStade
        {
            get { return m_selectedStade; }
            set
            {
                m_selectedStade = value;
                OnPropertyChanged("SelectedStade");
            }
        }

        /*
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
        */

        #endregion
    }
}
