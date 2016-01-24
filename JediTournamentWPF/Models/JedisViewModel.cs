using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace JediTournamentWPF.Models
{
    class JedisViewModel : ViewModelBase
    {
      //  private EntitiesLayer.Jedi _jedis;
        private ObservableCollection<JediViewModel> _jedis;
        //private ObservableCollection<CaracteristiqueViewModel> _carac;
        public ObservableCollection<JediViewModel> Jedis
        {
            get { return _jedis; }
            private set
            {
                _jedis = value;
                OnPropertyChanged("Jedis");
            }
        }
        private JediViewModel _selectedItem;
        public JediViewModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                //OnPropertyChanged("SelectedItem");
            }
        }

        public JedisViewModel(IList<EntitiesLayer.Jedi> artistesModel)
        {
            _jedis = new ObservableCollection<JediViewModel>();
            foreach (EntitiesLayer.Jedi a in artistesModel)
            {
                _jedis.Add(new JediViewModel(a));
            }
        }
    }
}
