namespace EntitiesLayer
{
    /// <summary>
    /// Énumération des différentes phases possible lors d'un tournoi.
    /// </summary>
    public enum EPhaseTournoi
    {
        QuartFinale,
        HuitiemeFinale,
        DemiFinale,
        Finale
    }

    public class Match : EntityObject
    {
        private int _idJediVainqueur;

        public int IdJediVainqueur
        {
            get { return _idJediVainqueur; }
            set { _idJediVainqueur = value; }
        }
        private Jedi _jedi1;

        public Jedi Jedi1
        {
            get { return _jedi1; }
            set { _jedi1 = value; }
        }

        private Jedi _jedi2;

        public Jedi Jedi2
        {
            get { return _jedi2; }
            set { _jedi2 = value; }
        }

        private EPhaseTournoi _phaseTournoi;

        public EPhaseTournoi PhaseTournoi
        {
            get { return _phaseTournoi; }
            set { _phaseTournoi = value; }
        }
        private Stade _stade;

        public Stade Stade
        {
            get { return _stade; }
            set { _stade = value; }
        }


        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="id">Id du match.</param>
        /// <param name="jedi1">Premier jedi concurrent.</param>
        /// <param name="jedi2">Second jedi concurrent.</param>
        /// <param name="phase">Phase lors de laquelle se déroule le match.</param>
        /// <param name="stade">Stade dans lequel se déroule le match.</param>
        public Match(int id, Jedi jedi1, Jedi jedi2, EPhaseTournoi phase, Stade stade) 
            : base(id)
        {
            Jedi1 = jedi1;
            Jedi2 = jedi2;
            PhaseTournoi = phase;
            Stade = stade;
            IdJediVainqueur = -1;   // Initialisation de l'ID à -1 => vainqueur non déterminé
        }
    }
}
