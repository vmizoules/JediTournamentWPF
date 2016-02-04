using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StubDataAccessLayer;          // TODO : échanger avec le DataAccessLayer
using EntitiesLayer;
using System.IO;
using System.Xml.Serialization;

namespace BusinessLayer
{
    public class JediTournamentManager
    {
        private DalManager m_data;    /// Gestionnaire d'interactions avec la base de données.

        /// <summary>
        /// Constructeur.
        /// </summary>
        public JediTournamentManager()
        {
            m_data = new DalManager();
        }

        #region Getters
        /// <summary>
        /// Donne la liste de l'ensemble des objets matchs.
        /// </summary>
        /// <returns>Liste des objets matchs.</returns>
        public List<Match> getAllMatchs()
        {
            return m_data.getAllMatchs();
        }

        /// <summary>
        /// Donne la liste des stades disponibles.
        /// </summary>
        /// <returns>Liste des noms des stades.</returns>
        public List<string> getStadesNames()
        {
            return m_data.getAllStades().Select(s => s.Planete).ToList();
        }

        /// <summary>
        /// Donne la liste des noms de tous les jedis.
        /// </summary>
        /// <returns>Liste des noms de tous les jedis.</returns>
        public List<string> getAllJedisNames()
        {
            return m_data.getAllJedis().Select(j => j.Nom).ToList();
        }

        /// <summary>
        /// Donne la liste des noms des jedis siths.
        /// </summary>
        /// <returns>Liste des noms des jedis siths.</returns>
        public List<string> getSithsNames()
        {
            return m_data.getAllJedis().Where(j => j.IsSith).Select(j => j.Nom).ToList();
        }

        public List<string> getJedisNames() {
            return m_data.getAllJedis().Where(j => !j.IsSith).Select(j => j.Nom).ToList();
        }
        /// <summary>
        /// Donne la liste des jedis ayant plus de 3 points de Force et 50 points de vie.
        /// </summary>
        /// <returns>Liste des noms des jedis avec plus de 3 points de Force et 50 points de vie.</returns>
        public List<string> getJedis3F50PV()
        {
            return m_data.getAllJedis().Where(j => j.Caracteristiques != null
                                                && j.Caracteristiques.Any(c => c.Type == ETypeCaracteristique.Jedi && c.Definition == EDefCaracteristique.Force && c.Valeur > 3)
                                                && j.Caracteristiques.Any(c => c.Type == ETypeCaracteristique.Jedi && c.Definition == EDefCaracteristique.Sante && c.Valeur > 50)
                                              ).Select(j => j.Nom).ToList();
        }

        /// <summary>
        /// Donne la liste de tous les combattants.
        /// </summary>
        /// <returns>Liste de tous les combattants.</returns>
        public List<Jedi> getAllJedis()
        {
            return m_data.getAllJedis();
        }

        /// <summary>
        /// Donne la liste de tous les jedis.
        /// </summary>
        /// <returns>Liste de tous les jedis.</returns>
        public List<Jedi> getSiths() {
            return m_data.getAllJedis().Where(j => j.IsSith).ToList();
        }
        
        /// <summary>
        /// Donne la liste de tous les siths.
        /// </summary>
        /// <returns>Liste de tous les siths.</returns>
        public List<Jedi> getJedis() {
            return m_data.getAllJedis().Where(j => !j.IsSith).ToList();
        }

        /// <summary>
        /// Donne la liste de tous les stades.
        /// </summary>
        /// <returns>Liste de tous les stades.</returns>
        public List<Stade> getAllStades()
        {
            return m_data.getAllStades();
        }

        /// <summary>
        /// Donne la liste des matchs qui ont eu lieu dans un stade de plus de 200 places et ou deux Siths se sont affrontés.
        /// </summary>
        /// <returns>Liste des matchs qui ont eu lieu dans un stade de plus de 200 places et ou deux Siths se sont affrontés.</returns>
        public List<Match> getMatch200P2S()
        {
            List<Match> list = m_data.getAllMatchs().Where(m => m.Stade.NbPlaces > 200 && m.Jedi1.IsSith && m.Jedi2.IsSith).ToList();
            return new HashSet<Match>(list).ToList();   // Rend unique
        }

        #endregion

        #region Updaters
        public int updateJedis(List<Jedi> old_list, List<Jedi> new_list) {
            int value = 0;

            // TODO : to implement

            return value;
        }

        public int updateStades(List<Stade> old_stades, List<Stade> new_stades) {
            int value = 0;

            // TODO : to implement

            return value;
        }

        public int updateMatch(Match m) {
            int value = 0;

            // TODO : to implement

            return value;
        }

        public bool updateTournoi(Tournoi t) {
            bool flag = true;

            // TODO : to implement

            return flag;
        }

        #endregion

        #region Insert
        public bool insertTournament(Tournoi t) {
            bool flag = true;

            // TODO : to implement

            return flag;
        }

        #endregion

        //public int updateTournament()

        /// <summary>
        /// Vérifie que le mot de passe correspond au login entré.
        /// </summary>
        /// <param name="login">Login de l'utilisateur.</param>
        /// <param name="passwd">Mot de passe à vérifier.</param>
        /// <returns>Vrai si le mot de passe correspond, sinon faux.</returns>
        public bool checkConnexionUser(string login, string passwd)
        {
            Utilisateur user = m_data.getUtilisateurByLogin(login);
            return user != null && user.Password == passwd;
        }

        public void serializeJedis(string path)
        {
            // La sérialization peut être placé soit dans BusinessLayer, Presentation ou DataAccessLayer (Jamais dans EntityLayer)
            // Il peut être préférable de le placer dans la couche métier (Business Layer)
            StreamWriter stream = new StreamWriter(path);
            XmlSerializer serializer = new XmlSerializer(typeof(Jedi));
            foreach (Jedi j in m_data.getAllJedis())
                serializer.Serialize(stream, j);

            stream.Close();
        }
    }
}
