using System.Collections.Generic;

namespace EntitiesLayer
{
    public class Stade : EntityObject {
        private int _nbPlaces;

        /// <summary>
        /// Constructeur par défaut.
        /// </summary>
        public Stade()
            : base(0) {
            NbPlaces = 0;
            _Planete = "Default Name";
            Caracteristiques = null;
            Photo = null;
        }

        public int NbPlaces
        {
            get { return _nbPlaces; }
            set { _nbPlaces = value; }
        }

        private List<Caracteristique> _caracteristiques;

        public List<Caracteristique> Caracteristiques
        {
            get { return _caracteristiques; }
            set { _caracteristiques = value; }
        }

        private string _Planete;
        public string Planete
        {
            get { return _Planete; }
            set { _Planete = value; }
        }

        public string Photo { get; set; }
        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="id">Id du stade.</param>
        /// <param name="nbPlaces">Nombre de places du stade.</param>
        /// <param name="planete">Nom de la planète sur laquelle se situe le stade.</param>
        /// <param name="carac">Caractéritiques associées au stade.</param>
        /// <param name="source">Source de la photo associée au stade.</param>
        public Stade(int id, int nbPlaces, string planete, List<Caracteristique> carac)
            : base(id) {
            NbPlaces = nbPlaces;
            Planete = planete;
            Caracteristiques = carac;
            Photo = null;
        }
        public Stade(int id, int nbPlaces, string planete, List<Caracteristique> carac, string source)
          : base(id) {
            NbPlaces = nbPlaces;
            Planete = planete;
            Caracteristiques = carac;
            Photo = source;
        }
    }
}
