using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace JediTournamentWPF.Models
{
    class JediViewModel
    {
       private ObservableCollection<CaracteristiqueViewModel> _carac;
       private EntitiesLayer.Jedi _jedi;
        public string Nom
        {

            get { return Jedi.Nom; }
            set { Jedi.Nom = value;  }
        }
        public EntitiesLayer.Jedi Jedi
        {
            get { return _jedi; }
            private set { _jedi = value; }
        }
        private ObservableCollection<CaracteristiqueViewModel> Carac
        {
            get { return _carac; }
            set { _carac = value; }
        }
        public JediViewModel(EntitiesLayer.Jedi _jedi) {
            Jedi = _jedi;
        }
    }
}
