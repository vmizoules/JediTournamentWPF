using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiblioWPF.ViewModel;

namespace JediTournamentWPF.Models
{
    class NewTournamentModel : ViewModelBase
    {
        private String _random;

        public String Random
        {
            get { return _random; }
            set { _random = value; }
        }

        private RelayCommand _addCommand;
        public System.Windows.Input.ICommand AddCommand
        {
            get
            {
                if (_addCommand == null)
                {
                    _random = "teeeeee";
                }
                return _addCommand;
            }
        }
    }
}
