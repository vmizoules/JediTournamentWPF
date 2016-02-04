using BusinessLayer;
using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JediTournamentWPF.ViewModel.Historique
{
    class HistoriqueViewModel : ViewModelBase
    {
        // Event destiné à réclamer la fermeture du conteneur;
        public event EventHandler<EventArgs> CancelNotified;
        protected void OnCancelNotified(EventArgs e)
        {
            this.CancelNotified(this, e);
        }

        public HistoriqueViewModel()
        {
        }

        private bool CanCancel()
        {
            return true;
        }

        // Commande Cancel/Return
        private RelayCommand m_cancelButton;
        public System.Windows.Input.ICommand CancelCommand
        {
            get
            {
                if (m_cancelButton == null)
                {
                    m_cancelButton = new RelayCommand(
                        () => this.Cancel(),
                        () => this.CanCancel()
                        );
                }
                return m_cancelButton;
            }
        }

        /// <summary>
        /// Action cancel
        /// </summary>
        private void Cancel()
        {
            // TODO : mettre la BDD à jour ??
            OnCancelNotified(new EventArgs());
        }
    }
}
