namespace EntitiesLayer
{
    /// <summary>
    /// Classe mère de toutes les classes.
    /// </summary>
    public abstract class EntityObject
    {
        /// <summary>
        /// ID de l'instance.
        /// </summary>
        public int ID { get; }

        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="id">ID associé à l'instance.</param>
        public EntityObject(int id)
        {
            ID = id;
        }
    }
    
}
