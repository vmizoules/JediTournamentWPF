using System.Collections.Generic;

namespace EntitiesLayer
{
    public class Stade : EntityObject
    {
        public int NbPlaces { get; }
        public List<Caracteristique> Caracteristiques { get; set; }
        public string Planete { get; }

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
