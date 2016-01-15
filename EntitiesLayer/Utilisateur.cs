using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Utilisateur
    {
        public string Nom { get; }
        public string Prenom { get; }
        public string Login { get; }
        public string Password { get; }

        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="nom">Nom de l'utilisateur.</param>
        /// <param name="prenom">Prenom de l'utilisateur.</param>
        /// <param name="login">Login de l'utilisateur.</param>
        /// <param name="passwd">Mot de passe de l'utilisateur.</param>
        public Utilisateur(string nom, string prenom, string login, string passwd)
        {
            Nom = nom;
            Prenom = prenom;
            Login = login;
            Password = passwd;
        }
    }
}
