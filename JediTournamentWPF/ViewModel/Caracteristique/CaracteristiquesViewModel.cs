using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JediTournamentWPF.ViewModel
{
    class CaracteristiquesViewModel : ViewModelBase
    {
        private ObservableCollection<CaracteristiqueViewModel> _caracs;
        private CaracteristiqueViewModel _selectedCarac;

        // CONSTRUCTEUR
        public CaracteristiquesViewModel(List<EntitiesLayer.Caracteristique> c) {
            _caracs = new ObservableCollection<CaracteristiqueViewModel>();

            // if not null
            if (c != null)
            {
                // fill carac in collection
                foreach (EntitiesLayer.Caracteristique oneCarac in c)
                {
                    _caracs.Add(new CaracteristiqueViewModel(oneCarac));
                }
            }
        }

        public ObservableCollection<CaracteristiqueViewModel> CaracteristiquesList
        {
            get { return _caracs; }
            set { _caracs = value; }
        }

        public CaracteristiqueViewModel SelectedCarac
        {
            get { return _selectedCarac; }
            set { 
                _selectedCarac = value;
                base.OnPropertyChanged("SelectedCarac");
            }
        }
    }
}