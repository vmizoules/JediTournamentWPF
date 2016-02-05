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
        private CaracteristiquesViewModel _caracs;
        private Stade m_stades;
        
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="stade"></param>
        public StadeViewModel(Stade stade) {
            m_stades = stade;
            _caracs = new CaracteristiquesViewModel(stade.Caracteristiques);
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
        public CaracteristiquesViewModel Caracteristiques
        {
            get { return _caracs; }
            set { _caracs = value; }
        }

        /// <summary>
        /// Getter/setter pour la planete
        /// </summary>
        public string Planete
        {
            get { return m_stades.Planete; }
            private set
            {
                if (value == m_stades.Planete) return;
                m_stades.Planete = value;
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
                OnPropertyChanged("NbPlaces");
            }
        }
    }
}
