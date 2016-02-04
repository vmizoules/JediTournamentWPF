using System.Collections.Generic;

namespace EntitiesLayer
{
    public class Tournoi : EntityObject
    {
        private List<Match> _matchs;

        public List<Match> Matchs
        {
            get { return _matchs; }
            set { _matchs = value; }
        }
        private string _nom;

        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        public Tournoi() : base(0) {
            Nom = "Nouveau tournoi";
            Matchs = new List<Match>();
        }

        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="id">Id du tournoi.</param>
        /// <param name="nom">Nom du tournoi.</param>
        /// <param name="matchs">Match qui ont eu ou auront lieu pendant le tournoi.</param>
        public Tournoi(int id, string nom, List<Match> matchs) 
            : base(id)
        {
            Nom = nom;
            Matchs = matchs;
        }
    }
}
