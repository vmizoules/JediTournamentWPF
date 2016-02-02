using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;

namespace JediTournamentWPF.ViewModel {

    /// <summary>
    /// ViewModel pour les Jedis
    /// </summary>
    class JediViewModel : ViewModelBase {
        private ObservableCollection<CaracteristiqueViewModel> _carac;
        private Jedi m_jedi;
        
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="jedi"></param>
        public JediViewModel(Jedi jedi) {
            m_jedi = jedi;
            _carac = new ObservableCollection<CaracteristiqueViewModel>();
            // TODO : voir pour les caractéristiques : initialisation
            /*foreach(Caracteristique c in m_jedi.Caracteristiques) {
                _carac.Add(new CaracteristiqueViewModel(c));
            }*/
        }

        /// <summary>
        /// Getter/Setter pour le nom
        /// </summary>
        public string Name
        {

            get { return m_jedi.Nom; }
            set {
                m_jedi.Nom = value;
                OnPropertyChanged("Name");
            }
        }

        /// <summary>
        /// Getter/Setter pour le Jedi
        /// </summary>
        public Jedi Jedi
        {
            get { return m_jedi; }
            set { m_jedi = value; }
        }

        /// <summary>
        /// Getter/setter pour les caractéristiques
        /// </summary>
        private ObservableCollection<CaracteristiqueViewModel> Carac
        {
            get { return _carac; }
            set {
                _carac = value;
                OnPropertyChanged("Carac");
            }
        }

    }
}
