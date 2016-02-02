using System.Collections.Generic;
using System.Linq;
using EntitiesLayer;

namespace StubDataAccessLayer
{
    public class DalManager
    {
        /// <summary>
        /// Permet d'obtenir la liste de tous les jedis connus.
        /// </summary>
        /// <returns>Liste des jedis.</returns>
        public List<Jedi> getAllJedis() 
        {
            List<Jedi> listJedi = new List<Jedi>();

            // Caractéristiques éventuelles des jedis
            List<Caracteristique> caracsAnakin = getAllCaracs().Where(c => c.Type == ETypeCaracteristique.Jedi && (c.ID == 2 || c.ID == 7 || c.ID == 11)).ToList();
            List<Caracteristique> caracsDarthMaul = getAllCaracs().Where(c => c.Type == ETypeCaracteristique.Jedi && (c.ID == 3 || c.ID == 10)).ToList();
            List<Caracteristique> caracsLukeS = getAllCaracs().Where(c => c.Type == ETypeCaracteristique.Jedi && (c.ID == 2 || c.ID == 4 || c.ID == 8)).ToList();
            List<Caracteristique> caracsYoda = getAllCaracs().Where(c => c.Type == ETypeCaracteristique.Jedi && (c.ID == 6 || c.ID == 9 || c.ID == 11)).ToList();
            List<Caracteristique> caracsObiwan = getAllCaracs().Where(c => c.Type == ETypeCaracteristique.Jedi && (c.ID == 5 || c.ID == 8)).ToList();

            // Crée la liste des jedis
            listJedi.Add(new Jedi(1, "Yoda", false, caracsYoda));   // Jedis
            listJedi.Add(new Jedi(2, "Qui-Gon Jinn", false, null));
            listJedi.Add(new Jedi(3, "Obi-Wan Kenobi", false, caracsObiwan));
            listJedi.Add(new Jedi(4, "Luke Skywalker", false, caracsLukeS));
            listJedi.Add(new Jedi(5, "Anakin Skywalker", true, caracsAnakin)); // Siths
            listJedi.Add(new Jedi(6, "Count Dooku", true, null));
            listJedi.Add(new Jedi(7, "Darth Maul", true, caracsDarthMaul));
            listJedi.Add(new Jedi(8, "Emperor Palpatine", true, null));


            return listJedi;
        }

        /// <summary>
        /// Permet d'obtenir la liste de toutes les caractéristiques enregistrées.
        /// </summary>
        /// <returns>Liste des caractéritiques.</returns>
        public List<Caracteristique> getAllCaracs()
        {
            List<Caracteristique> listCarac = new List<Caracteristique>();

            // Caracs de Jedis
            listCarac.Add(new Caracteristique(1, "Force", EDefCaracteristique.Force, ETypeCaracteristique.Jedi, 2));
            listCarac.Add(new Caracteristique(2, "Force Supérieure", EDefCaracteristique.Force, ETypeCaracteristique.Jedi, 4));
            listCarac.Add(new Caracteristique(3, "Force Herculéenne", EDefCaracteristique.Force, ETypeCaracteristique.Jedi, 6));
            listCarac.Add(new Caracteristique(4, "Defense Mineure", EDefCaracteristique.Defense, ETypeCaracteristique.Jedi, 2));
            listCarac.Add(new Caracteristique(5, "Defense Supérieure", EDefCaracteristique.Defense, ETypeCaracteristique.Jedi, 4));
            listCarac.Add(new Caracteristique(6, "Le Mur", EDefCaracteristique.Defense, ETypeCaracteristique.Jedi, 6));
            listCarac.Add(new Caracteristique(7, "Vie", EDefCaracteristique.Sante, ETypeCaracteristique.Jedi, 40));
            listCarac.Add(new Caracteristique(8, "Vie Supérieure", EDefCaracteristique.Sante, ETypeCaracteristique.Jedi, 51));
            listCarac.Add(new Caracteristique(9, "Sac à PV", EDefCaracteristique.Sante, ETypeCaracteristique.Jedi, 60));
            listCarac.Add(new Caracteristique(10, "Unlucky Boy", EDefCaracteristique.Chance, ETypeCaracteristique.Jedi, -7));
            listCarac.Add(new Caracteristique(11, "Lucky Boy", EDefCaracteristique.Chance, ETypeCaracteristique.Jedi, 7));

            // Caracs de stades
            listCarac.Add(new Caracteristique(12, "Froid Glaciale", EDefCaracteristique.Defense, ETypeCaracteristique.Stade, -2));
            listCarac.Add(new Caracteristique(13, "Désert", EDefCaracteristique.Force, ETypeCaracteristique.Stade, -2));
            listCarac.Add(new Caracteristique(14, "Ovation", EDefCaracteristique.Force, ETypeCaracteristique.Stade, 3));
  
            return listCarac;
        }

        /// <summary>
        /// Permet d'obtenir la liste de tous les stades connus.
        /// </summary>
        /// <returns>Liste des stades.</returns>
        public List<Stade> getAllStades() 
        {
            List<Stade> listStades = new List<Stade>();

            // Caractéristiques éventuelles des stades
            List<Caracteristique> caracsTatooine = new List<Caracteristique>().Where(s => s.Type == ETypeCaracteristique.Stade && s.ID == 13).ToList();
            List<Caracteristique> caracsHoth = new List<Caracteristique>().Where(s => s.Type == ETypeCaracteristique.Stade && (s.ID == 12 || s.ID == 13)).ToList();
            List<Caracteristique> caracsCoruscant = new List<Caracteristique>().Where(s => s.Type == ETypeCaracteristique.Stade && s.ID == 14).ToList();

            // Crée la liste des stades
            listStades.Add(new Stade(1, 150, "Jakku", null));
            listStades.Add(new Stade(2, 2000, "Tatooine", caracsTatooine));
            listStades.Add(new Stade(3, 10000, "Hoth", caracsHoth));
            listStades.Add(new Stade(4, 110000, "Coruscant", caracsCoruscant));

            return listStades;
        }

        /// <summary>
        /// Permet d'obtenir la liste de tous les matchs connus.
        /// </summary>
        /// <returns>Liste des matchs.</returns>
        public List<Match> getAllMatchs()
        {
            List<Match> listMatch = new List<Match>();

            // Match sur Jakku
            listMatch.Add(new Match(1,
                                    getAllJedis().Where(j => j.ID == 3).First(),
                                    getAllJedis().Where(j => j.ID == 5).First(),
                                    EPhaseTournoi.HuitiemeFinale,
                                    getAllStades().Where(s => s.ID == 1).First()));

            // Match sur Tatooine
            listMatch.Add(new Match(2,
                                    getAllJedis().Where(j => j.ID == 1).First(),
                                    getAllJedis().Where(j => j.ID == 6).First(),
                                    EPhaseTournoi.HuitiemeFinale,
                                    getAllStades().Where(s => s.ID == 2).First()));

            listMatch.Add(new Match(3,
                                    getAllJedis().Where(j => j.ID == 2).First(),
                                    getAllJedis().Where(j => j.ID == 7).First(),
                                    EPhaseTournoi.HuitiemeFinale,
                                    getAllStades().Where(s => s.ID == 2).First()));

            // Matchs sur Hoth
            listMatch.Add(new Match(3,
                                    getAllJedis().Where(j => j.ID == 4).First(),
                                    getAllJedis().Where(j => j.ID == 8).First(),
                                    EPhaseTournoi.HuitiemeFinale,
                                    getAllStades().Where(s => s.ID == 3).First()));

            return listMatch;
        }
 
        /// <summary>
        /// Permet de récupérer un utilisateur par login.
        /// </summary>
        /// <param name="login">Login de l'utilisateur à récupérer.</param>
        /// <returns>Utilisateur correspondant.</returns>
        public Utilisateur getUtilisateurByLogin(string login)
        {
            List<Utilisateur> users = new List<Utilisateur>();
            users.Add(new Utilisateur("PIERREVAL", "Adrien", "AceNanter", "azerty"));
            users.Add(new Utilisateur("RABERIN", "Alexandre", "KeRNeLith", "qwerty"));
            users.Add(new Utilisateur("PASCAL", "Guillaume", "Gupascal", "azerty2"));
            users.Add(new Utilisateur("CHABALIER", "Nicolas", "Chabs", "azerty3"));
            users.Add(new Utilisateur("MIZOULES", "Vincent", "vincent", "vincent"));
            users.Add(new Utilisateur("AMRANI", "Oumaima", "ouma", "ouma"));
            return users.Where(u => u.Login == login).FirstOrDefault();
        }
    }
}
