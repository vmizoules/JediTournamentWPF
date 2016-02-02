using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
namespace DataAccessLayer {
    interface IBridge {
        List<Jedi> GetAllJedis();
        List<Stade> GetAllStades();
        List<Match> GetAllMatchs();
        List<Caracteristique> GetAllCaracteristiques();
        List<Tournoi> GetAllTournois();
        int UpdateListJedis(List<Jedi> _listeJedi);
        int UpdateListStades(List<Stade> _listStade);
        int UpdateListMatches(List<Match> _listMatch);
        int UpdateListCaracteristiques(List<Caracteristique> _listCarac);
        int UpdateListTournois(List<Tournoi> _listTournoi);
        int RemoveListJedis(List<Jedi> _listeJedi);
        int RemoveListStades(List<Stade> _listStade);
        int RemoveListMatches(List<Match> _listMatch);
        int RemoveListCaracteristiques(List<Caracteristique> _listCarac);
        int RemoveListTournois(List<Tournoi> _listTournoi);
    }
}
