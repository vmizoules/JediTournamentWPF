using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JediTournamentWPF.ViewModel
{
    public class CaracteristiquesViewModel : ViewModelBase
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

        #region "Commandes du formulaire"

        // ADD COMMAND
        private RelayCommand _addCommand;
        public System.Windows.Input.ICommand AddCommand
        {
            get
            {
                if (_addCommand == null)
                {
                    _addCommand = new RelayCommand(
                        () => this.Add(),
                        () => this.CanAdd()
                        );
                }
                return _addCommand;
            }
        }

        private bool CanAdd()
        {
            return true;
        }

        private void Add()
        {
            EntitiesLayer.Caracteristique newOne = new EntitiesLayer.Caracteristique();
            SelectedCarac = new CaracteristiqueViewModel(newOne);
            _caracs.Add(SelectedCarac);
        }
        // /ADD COMMAND

        // REMOVE COMMAND
        private RelayCommand _removeCommand;
        public System.Windows.Input.ICommand RemoveCommand
        {
            get
            {
                if (_removeCommand == null)
                {
                    _removeCommand = new RelayCommand(
                        () => this.Remove(),
                        () => this.CanRemove
                        );
                }
                return _removeCommand;
            }
        }

        public bool CanRemove
        {
            get { return (this.SelectedCarac != null); }
            set { }
        }

        private void Remove()
        {
            if (this.SelectedCarac != null) CaracteristiquesList.Remove(this.SelectedCarac);
        }
        // /REMOVE COMMAND

        // VALID COMMAND
        private RelayCommand _validCommand;
        public System.Windows.Input.ICommand ValidCommand
        {
            get
            {
                if (_validCommand == null)
                {
                    _validCommand = new RelayCommand(
                        () => SelectedCarac = null,
                        () => SelectedCarac != null);
                }
                return _validCommand;
            }
        }
        // END VALID

        #endregion

        #region "Attributs"
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
                base.OnPropertyChanged("CanRemove");
            }
        }

        #endregion
    }
}