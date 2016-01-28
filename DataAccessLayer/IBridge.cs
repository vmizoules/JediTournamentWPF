using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;

namespace DataAccessLayer {
    interface IBridge {

        public List<Match> getAllMatchs();

        public List<Stade> getAllStades();

        public List<Jedi> getAllJedis();

        public Utilisateur getUtilisateurByLogin();

    }
}
