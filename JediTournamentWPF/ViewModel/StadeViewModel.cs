using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;

namespace JediTournamentWPF.ViewModel {

    /// <summary>
    /// ViewModel pour les Stades
    /// </summary>
    class StadeViewModel : ViewModelBase 
    {
       private ObservableCollection<CaracteristiqueViewModel> _carac;
        private Stade m_stades;
        
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="stade"></param>
        public StadeViewModel(Stade stade) {
            m_stades = stade;
            _carac = new ObservableCollection<CaracteristiqueViewModel>();
            // TODO : voir pour les caractéristiques : initialisation
            /*foreach(Caracteristique c in m_stades.Caracteristiques) {
                _carac.Add(new CaracteristiqueViewModel(c));
            }*/
        }


        /// <summary>
        /// Getter/Setter pour le Stade
        /// </summary>
        public Stade Stade
        {
            get { return m_stades; }
            set { m_stades = value; }
        }

        /// <summary>
        /// Getter/setter pour les caractéristiques
        /// </summary>
        private ObservableCollection<CaracteristiqueViewModel> Carac
        {
            get { return _carac; }
            set { _carac = value; }
        }

        /// <summary>
        /// Getter/setter pour la planete
        /// </summary>
        public string planete
        {
            get { return m_stades.Planete1; }
            private set
            {
                if (value == m_stades.Planete1) return;
                m_stades.Planete1 = value;
                OnPropertyChanged("Planete");
            }
        }

        /// <summary>
        /// Getter/setter pour le nombre de places
        /// </summary>
        public int NbPlaces
        {
            get { return m_stades.NbPlaces; }
            private set
            {
                if (value == m_stades.NbPlaces) return;
                m_stades.NbPlaces = value;
                OnPropertyChanged("Nombre de places");
            }
        }
    }
}
