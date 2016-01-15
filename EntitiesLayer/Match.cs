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
        public int IdJediVainqueur { get; set; }
        public Jedi Jedi1 { get; }
        public Jedi Jedi2 { get; }
        public EPhaseTournoi PhaseTournoi { get; }
        public Stade Stade { get; }

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
