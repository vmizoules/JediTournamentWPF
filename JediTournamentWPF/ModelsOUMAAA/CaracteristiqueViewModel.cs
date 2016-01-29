using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JediTournamentWPF.Models
{
    class CaracteristiqueViewModel : ViewModelBase
    {
        private EntitiesLayer.Caracteristique _carac;

        public EntitiesLayer.Caracteristique Carac
        {
            get { return _carac; }
            private set
            {
                _carac = value;
            }
        }
        public string Nom
        {

            get { return Carac.Nom; }
            set {
                if (value == Carac.Nom) return;
                    Carac.Nom = value;
                OnPropertyChanged("Nom");
            }
        }

        public int Valeur
        {

            get { return Carac.Valeur; }
            set {
                if (value == Carac.Valeur) return;
                Carac.Valeur = value;
                OnPropertyChanged("Nom");
                 }
        }
        public CaracteristiqueViewModel(EntitiesLayer.Caracteristique caract){
            Carac = caract;
        }
    }
}
