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
        public event EventHandler<EventArgs> CreateNotified;

        #region Fonctions relatives aux évènements
        protected void OnCancelNotified(EventArgs e) {
            this.CancelNotified(this, e);
        }

        protected void OnCreateNotified(EventArgs e) {
            this.CreateNotified(this, e);
        }
        #endregion

        // Model encapsulé dans le ViewModel

        // Attributs
        private Tournoi m_tournoi;
        private ObservableCollection<MatchViewModel> m_matchs;
        private bool m_mode;                                                // true = manual, false = auto

        /// <summary>
        /// Return the turnament. Only getter.
        /// </summary>
        public Tournoi Tournoi
        {
            get { return m_tournoi; }
        }

        /// <summary>
        /// Getter and setter for the game mode (automatic or manual).
        /// </summary>
        public bool Mode
        {
            get { return m_mode; }
            set
            {
                m_mode = value;
            }
        }

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
        public TournoiCreatorViewModel() {

            // TODO : à modifier pour avoir les matchs d'un tournoi

            //m_matchs = new ObservableCollection<MatchViewModel>();
            Random random = new Random();
            BusinessLayer.JediTournamentManager bm = new BusinessLayer.JediTournamentManager();

            m_tournoi = new Tournoi();

            List<Jedi> JediList = bm.getJedis();
            List<Jedi> SithList = bm.getSiths();
            List<Stade> StadeList = bm.getAllStades();

            for(int i = 0; i < 4; i++) {
                int indexJedi = random.Next(JediList.Count);
                int indexSith = random.Next(SithList.Count);
                int indexStade = random.Next(StadeList.Count);
                m_tournoi.Matchs.Add(new Match(i, JediList[indexJedi], SithList[indexSith], EPhaseTournoi.HuitiemeFinale, StadeList[indexStade]));
                JediList.Remove(JediList[indexJedi]);
                SithList.Remove(SithList[indexSith]);
                m_matchs.Add(new MatchViewModel(m_tournoi.Matchs[i]));
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

            OnCreateNotified(new EventArgs());
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
