using System.Collections.Generic;

namespace EntitiesLayer
{
    public class Stade : EntityObject
    {
        private int _nbPlaces;

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
        private string Planete;

        public string Planete1
        {
            get { return Planete; }
            set { Planete = value; }
        }

        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="id">Id du stade.</param>
        /// <param name="nbPlaces">Nombre de places du stade.</param>
        /// <param name="planete">Nom de la planète sur laquelle se situe le stade.</param>
        /// <param name="carac">Caractéritiques associées au stade.</param>
        public Stade(int id, int nbPlaces, string planete, List<Caracteristique> carac) 
            : base(id)
        {
            NbPlaces = nbPlaces;
            Planete = planete;
            Caracteristiques = carac;
        }
    }
}
