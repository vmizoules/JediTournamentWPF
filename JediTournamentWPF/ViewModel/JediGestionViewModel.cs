using BusinessLayer;
using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JediTournamentWPF.ViewModel {
    class JediGestionViewModel : ViewModelBase {
        // Event destiné à réclamer la fermeture du conteneur;
        public event EventHandler<EventArgs> CancelNotified;
        protected void OnCancelNotified(EventArgs e) {
            this.CancelNotified(this, e);
        }

        // Model encapsulé dans le ViewModel

        // Liste des matchs
        private ObservableCollection<JediViewModel> m_jedis;

        /// <summary>
        /// Liste des matchs : Getter/Setter
        /// </summary>
        public ObservableCollection<JediViewModel> Jedis
        {
            get { return m_jedis; }
            private set
            {
                m_jedis = value;
                OnPropertyChanged("Jedis");
            }
        }

        // Match sélectionné
        private JediViewModel m_selectedItem;

        /// <summary>
        /// Match sélectionné : match sélectionné getter/setter
        /// </summary>
        public JediViewModel SelectedItem
        {
            get { return m_selectedItem; }
            set
            {
                m_selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        /// <summary>
        /// Constructeur du ViewModel
        /// </summary>
        public JediGestionViewModel() {
            m_jedis = new ObservableCollection<JediViewModel>();

            JediTournamentManager manager = new JediTournamentManager();
            IList<Jedi> list = manager.getAllJedis();

            foreach (Jedi j in list)
                m_jedis.Add(new JediViewModel(j));

            /*    
            // Création de 8 Matchs
            for (int i = 0; i < 8; i++) {
                m_matchs.Add(new MatchViewModel());
            }*/
        }

        #region "Commandes du formulaire"

        // Commande pour ajouter un nouveau Jedi
        private RelayCommand m_AddCommand;                                  // Déclaration de la commande
        /// <summary>
        /// Initialisation du bouton
        /// </summary>
        public System.Windows.Input.ICommand AddCommand
        {
            get
            {
                if (m_AddCommand == null) {
                    m_AddCommand = new RelayCommand(
                        () => this.Add(),
                        () => this.CanAdd()
                        );                                                  // Instanciation de la commande
                }
                return m_AddCommand;
            }
        }

        /// <summary>
        /// Définit si on peut utiliser le bouton ou pas
        /// </summary>
        /// <returns></returns>
        private bool CanAdd() {
            return true;
        }

        private void Add() {
            Jedi j = new Jedi();                // TODO : voir pour passer des paramètres ?
            this.SelectedItem = new JediViewModel(j);
            m_jedis.Add(this.SelectedItem);
        }

        // Commande pour supprimer un Jedi
        private RelayCommand m_RemoveCommand;                               // Déclaration de la commande
        /// <summary>
        /// Initialisation du bouton
        /// </summary>
        public System.Windows.Input.ICommand RemoveCommand
        {
            get
            {
                if (m_RemoveCommand == null) {
                    m_RemoveCommand = new RelayCommand(
                        () => this.Remove(),
                        () => this.CanRemove()
                        );                                                  // Instanciation de la commande
                }
                return m_RemoveCommand;
            }
        }

        /// <summary>
        /// Définit si on peut utiliser le bouton ou pas
        /// </summary>
        /// <returns></returns>
        private bool CanRemove() {
            return true;
        }

        /// <summary>
        /// Supprime un jedi de la liste des jedis
        /// </summary>
        private void Remove() {
            m_jedis.Remove(this.SelectedItem);
        }
        
        // Commande Cancel/Return
        private RelayCommand m_cancelButton;
        public System.Windows.Input.ICommand CancelCommand
        {
            get
            {
                if (m_cancelButton == null) {
                    m_cancelButton = new RelayCommand(
                        () => this.Cancel(),
                        () => this.CanCancel()
                        );
                }
                return m_cancelButton;
            }
        }

        /// <summary>
        /// Define if it is possible to go back to home page
        /// </summary>
        /// <returns></returns>
        private bool CanCancel() {
            return true;
        }

        /// <summary>
        /// Action cancel
        /// </summary>
        private void Cancel() {
            // TODO : mettre la BDD à jour ??
            OnCancelNotified(new EventArgs());
        }

        #endregion
    }

}
}
