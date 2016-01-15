namespace EntitiesLayer
{
    public class Joueur : EntityObject
    {
        private string _nom;

        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        private int _score;

        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }

        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="id">Id du joueur.</param>
        /// <param name="nom">Nom du joueur.</param>
        public Joueur(int id, string nom) 
            : base(id)
        {
            Nom = nom;
            Score = 0;
        }
    }
}
