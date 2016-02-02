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

        private ObservableCollection<JediViewModel> m_jedis;
        private ObservableCollection<JediViewModel> m_siths;
        private ObservableCollection<StadeViewModel> m_stades;
        private JediViewModel m_selectedJedi;
        private JediViewModel m_selectedSith;

        public MatchViewModel() {
            // TODO
            // init empty match
        }

        public MatchViewModel(Match m) {
            // register match
            m_match = m;

            // init list vars
            m_jedis = new ObservableCollection<JediViewModel>();
            m_siths = new ObservableCollection<JediViewModel>();
            m_stades = new ObservableCollection<StadeViewModel>();

            // get all stades
            BusinessLayer.JediTournamentManager bm = new BusinessLayer.JediTournamentManager();
            List<Stade> listStades = bm.getAllStades();
            // insert in first
            m_stades.Add(new StadeViewModel(Stade));
            // for all stades
            foreach (Stade oneStade in listStades)
            {
                if (oneStade.ID != Stade.ID)
                {
                    m_stades.Add(new StadeViewModel(oneStade));
                }
            }
            SelectedStade = Stades[0];

            // get all jedis & all siths
            List<Jedi> listJedis = bm.getAllJedis();
            // insert Jedi1 first in jedis list
            m_jedis.Add(new JediViewModel(Jedi1));
            // insert Jedi2 first in siths list
            m_siths.Add(new JediViewModel(Jedi2));

            // for all Jedis
            foreach(Jedi oneJedi in listJedis) {
                // if Jedi AND is not Jedi1
                if (!oneJedi.IsSith && oneJedi.ID != Jedi1.ID) {
                    // fill in jedis collection
                    m_jedis.Add(new JediViewModel(oneJedi));
                }
                // if Sith AND is not Jedi2
                if (oneJedi.IsSith && oneJedi.ID != Jedi2.ID)
                {
                    // fill in siths collection
                    m_siths.Add(new JediViewModel(oneJedi));
                }
            }

            // init selected jedi & sith
            SelectedJedi = Jedis[0];
            SelectedSith = Siths[0];
        }

        #region "Propriétés accessibles, mappables par la View"

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

        /// <summary>
        /// A "ToString" for a Match
        /// </summary>
        public string Descriptor
        {
            get { return m_match.Jedi1.Nom + " vs " + m_match.Jedi2.Nom; }
        }

        /// <summary>
        /// Getters to have the list of Jedis
        /// </summary>
        public ObservableCollection<JediViewModel> Jedis
        {
            get { return m_jedis; }
        }

        /// <summary>
        /// Getters to have the list of Siths
        /// </summary>
        public ObservableCollection<JediViewModel> Siths
        {
            get { return m_siths; }
        }

        public ObservableCollection<StadeViewModel> Stades
        {
            get { return m_stades; }
        }

        /// <summary>
        /// Getter and setter for selected Jedi
        /// </summary>
        public JediViewModel SelectedJedi
        {
            get { return m_selectedJedi; }
            set
            {
                // update SelectedJedi
                m_selectedJedi = value;
                // update m_match.Jedi1
                Jedi1 = value.Jedi;
                
                // refresh descriptor in view
                base.OnPropertyChanged("Descriptor");
                base.OnPropertyChanged("SelectedJedi");
            }
        }

        /// <summary>
        /// Getter and setter for selected Jedi
        /// </summary>
        public JediViewModel SelectedSith
        {
            get { return m_selectedSith; }
            set
            {
                // update SelectedSith
                m_selectedSith = value;
                // update m_match.Jedi2
                Jedi2 = value.Jedi;

                // refresh descriptor in view
                base.OnPropertyChanged("SelectedSith");
                base.OnPropertyChanged("Descriptor");
            }
        }

        private StadeViewModel m_selectedStade;

        public StadeViewModel SelectedStade
        {
            get { return m_selectedStade; }
            set
            {
                // update SelectedStade
                m_selectedStade = value;
                // update m_match.Stade
                Stade = value.Stade;

                // refresh view
                base.OnPropertyChanged("SelectedStade");
                base.OnPropertyChanged("Stade");
            }
        }

        #endregion
    }
}
