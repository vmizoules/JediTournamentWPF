using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
namespace DataAccessLayer {
    interface IBridge {
        Jedi SelectJediById(int idJedi);
        List<Jedi> SelectAllJedis();
        void InsertJedi(Jedi _jedi);
        int RemoveJedi(Jedi _jedi);
        int EditJedi(Jedi _jedi);
        //----------------------------------------------------
        Stade selectStadeById(int idStade);
        List<Stade> SelectAllStades();
        int InsertStade(Stade _stade);
        int RemoveStade(Stade _stade);
        int EditStade(Stade _stade);
        //----------------------------------------------------
        Tournoi selectTournoiById();
        int InsertTournoi(Tournoi _tournoi);
        // List<Stade> SelectAllMatchs();
    }
}
