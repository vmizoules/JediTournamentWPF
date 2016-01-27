using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JediTournamentWPF.ViewModel {
    class TournoiCreatorViewModel : ViewModelBase {

        // Event destiné à réclamer la fermeture du conteneur;
        public event EventHandler<EventArgs> CancelNotified;
        protected void OnCancelNotified(EventArgs e) {
            this.CancelNotified(this, e);
        }

        // Model encapsulé dans le ViewModel

        // Liste des matchs
        private ObservableCollection<MatchViewModel> m_matchs;

        /// <summary>
        /// Liste des matchs : Getter/Setter
        /// </summary>
        public ObservableCollection<MatchViewModel> Matchs
        {
            get { return m_matchs; }
            private set
            {
                m_matchs = value;
                OnPropertyChanged("Matchs");
            }
        }

        // Match sélectionné
        private MatchViewModel m_selectedItem;

        /// <summary>
        /// Match sélectionné : match sélectionné getter/setter
        /// </summary>
        public MatchViewModel SelectedItem
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
        /// <param name="artistesModel"></param>
        public TournoiCreatorViewModel() {
            m_matchs = new ObservableCollection<MatchViewModel>();

            // Création de 8 Matchs
            for(int i = 0; i < 8; i++) {
                m_matchs.Add(new MatchViewModel());
            }
        }

        #region "Commandes du formulaire"

        // Commande pour créer un nouveau tournoi
        private RelayCommand m_CreateCommande;                              // Déclaration de la commande
        /// <summary>
        /// Initialisation du bouton
        /// </summary>
        public System.Windows.Input.ICommand CreateCommand
        {
            get
            {
                if (m_CreateCommande == null) {
                    m_CreateCommande = new RelayCommand(
                        () => this.Create(),
                        () => this.CanCreate()
                        );                                                  // Instanciation de la commande
                }
                return m_CreateCommande;
            }
        }

        /// <summary>
        /// Définit si on peut utiliser le bouton ou pas
        /// </summary>
        /// <returns></returns>
        private bool CanCreate() {
            // TODO : vérifier que les 8 matchs sont OK
            return true;
        }

        private void Create() {
            // TODO : finaliser et passer à la vue suivante

            /*
            EntitiesLayer.Artiste a = new EntitiesLayer.Artiste("<New>",
                                                                "<New>",
                                                                new DateTime(1901, 01, 01),
                                                                new DateTime(1901, 01, 01));

            this.SelectedItem = new ArtisteViewModel(a);
            Artistes.Add(this.SelectedItem);*/
        }
        
        // Commande Close
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
            OnCancelNotified(new EventArgs());
        }

        #endregion
    }
}
