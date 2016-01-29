using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JediTournamentWPF.ViewModel {
    class StadeViewModel : ViewModelBase {

        //planete nbrplace carac 
        private EntitiesLayer.Stade _stade;
        private ObservableCollection<CaracteristiqueViewModel> _carac;
        public EntitiesLayer.Stade Stade
        {
            get { return _stade; }
            private set { _stade = value; }
        }

        public string planete
        {
            get { return _stade.Planete1; }
            private set
            {
                if (value == _stade.Planete1) return;
                _stade.Planete1 = value;
                OnPropertyChanged("Planete");
            }
        }
        public int NbPlaces
        {
            get { return _stade.NbPlaces; }
            private set
            {
                if (value == _stade.NbPlaces) return;
                _stade.NbPlaces = value;
                OnPropertyChanged("Nombre de places");
            }
        }
        private StadeViewModel(EntitiesLayer.Stade _stade) {
            Stade = _stade;
        }
    }
}
