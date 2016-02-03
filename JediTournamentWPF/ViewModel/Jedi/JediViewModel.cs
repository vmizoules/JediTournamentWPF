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

        private ObservableCollection<CaracteristiqueViewModel> _caracs;
        private CaracteristiqueViewModel _selectedCarac;
        private Jedi m_jedi;
        
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="jedi"></param>
        public JediViewModel(Jedi jedi) {
            m_jedi = jedi;
            _caracs = new ObservableCollection<CaracteristiqueViewModel>();

            // if not null
            if (m_jedi.Caracteristiques != null)
            {
                // fill carac in collection
                foreach (Caracteristique c in m_jedi.Caracteristiques)
                {
                    _caracs.Add(new CaracteristiqueViewModel(c));
                }
            }
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
                //OnPropertyChanged("Nom");
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
        public ObservableCollection<CaracteristiqueViewModel> Caracteristiques
        {
            get { return _caracs; }
            set {
                _caracs = value;
                OnPropertyChanged("Caracteristiques");
            }
        }

        public Boolean IsSith
        {
            get { return Jedi.IsSith; }
            set { Jedi.IsSith = value; }
        }

        public Boolean IsNotSith
        {
            get { return ! Jedi.IsSith; }
            set { Jedi.IsSith = ! value; }
        }

        public CaracteristiqueViewModel SelectedCarac
        {
            get { return _selectedCarac; }
            set { _selectedCarac = value; }
        }

    }
}
