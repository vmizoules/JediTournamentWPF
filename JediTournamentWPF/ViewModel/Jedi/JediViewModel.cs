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

        private CaracteristiquesViewModel _caracs;
        private Jedi m_jedi;
        
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="jedi"></param>
        public JediViewModel(Jedi jedi) {
            m_jedi = jedi;
            _caracs = new CaracteristiquesViewModel(jedi.Caracteristiques);
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
        public CaracteristiquesViewModel Caracteristiques
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
            set {
                Jedi.IsSith = value;
                OnPropertyChanged("IsSith");
                OnPropertyChanged("IsNotSith");
            }
        }

        public Boolean IsNotSith
        {
            get { return ! Jedi.IsSith; }
            set {
                Jedi.IsSith = ! value;
                OnPropertyChanged("IsSith");
                OnPropertyChanged("IsNotSith");
            }
        }
    }
}
