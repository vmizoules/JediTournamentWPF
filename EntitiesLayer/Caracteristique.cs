using System;

namespace EntitiesLayer
{
    /// <summary>
    /// Énumération des différentes caractéristiques possibles.
    /// </summary>
    public enum EDefCaracteristique
    {
        Force,
        Defense,
        Sante,
        Chance
    }

    /// <summary>
    /// Énumération des différents types de caractéristiques possibles.
    /// </summary>
    public enum ETypeCaracteristique
    {
        Jedi,
        Stade
    }

    [Serializable]
    public class Caracteristique : EntityObject
    {
        public EDefCaracteristique Definition { get; set; }
        public string Nom { get; set; }
        public ETypeCaracteristique Type { get; set; }
        public int Valeur { get; set; }

        /// <summary>
        /// Constructeur par défaut.
        /// </summary>
        public Caracteristique()
            : base(0)
        {
            Nom = "Default Name";
            Valeur = 0;
            Type = ETypeCaracteristique.Jedi;
            Definition = EDefCaracteristique.Chance;
        }

        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="id">Id de la caractéristique.</param>
        /// <param name="nom">Nom de la caractéristique.</param>
        /// <param name="definition">Caractéristique concernée.</param>
        /// <param name="type">Type de la caractéristique.</param>
        /// <param name="valeur">Valeur affectée à la caractéristique.</param>
        public Caracteristique(int id, string nom, EDefCaracteristique definition, ETypeCaracteristique type, int valeur) 
            : base(id)
        {
            Nom = nom;
            Definition = definition;
            Type = type;
            Valeur = valeur;
        }
    }
}
