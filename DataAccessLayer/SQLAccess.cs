using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;

namespace DataAccessLayer {
    class SQLAccess : IBridge {

        private string m_connectionString = "";

         public SQLAccess(string connectionString) {
            m_connectionString = connectionString;
            using (SqlConnection sqlConnection = new SqlConnection(m_connectionString)) {
                //sqlConnection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(new SqlCommand("SELECT idJedi, Name, isSith, Pic FROM Jedis;", sqlConnection));
                
            }
        }

        public List<Caracteristique> GetAllCaracteristiques()
        {
            List<Caracteristique> _allCarac = new List<Caracteristique>();
            using (SqlConnection sqlConnection = new SqlConnection(m_connectionString))
            {
                //throw new NotImplementedException();
            }

            return _allCarac;
        }

        public List<Jedi> GetAllJedis()
        {
            List<Jedi> _allJedis = new List<Jedi>();
            using (SqlConnection sqlConnection = new SqlConnection(m_connectionString))
            {
                //throw new NotImplementedException();
            }

            return _allJedis;
        }
        public List<Match> GetAllMatchs()
        {
            List<Match> _allMatchs = new List<Match>();
            using (SqlConnection sqlConnection = new SqlConnection(m_connectionString))
            {
                //throw new NotImplementedException();
            }

            return _allMatchs;
        }

        public List<Stade> GetAllStades()
        {
            List<Stade> _allStade = new List<Stade>();
            using (SqlConnection sqlConnection = new SqlConnection(m_connectionString))
            {
                //throw new NotImplementedException();
            }

            return _allStade;
        }

        public List<Tournoi> GetAllTournois()
        {
            List<Tournoi> _allTournoi = new List<Tournoi>();
            using (SqlConnection sqlConnection = new SqlConnection(m_connectionString))
            {
                //throw new NotImplementedException();
            }

            return _allTournoi;
        }

       
        public int RemoveListCaracteristiques(List<Caracteristique> _listCarac)
        {
            throw new NotImplementedException();
        }

        public int RemoveListJedis(List<Jedi> _listeJedi)
        {
            throw new NotImplementedException();
        }

        public int RemoveListMatches(List<Match> _listMatch)
        {
            throw new NotImplementedException();
        }

        public int RemoveListStades(List<Stade> _listStade)
        {
            throw new NotImplementedException();
        }

        public int RemoveListTournois(List<Tournoi> _listTournoi)
        {
            throw new NotImplementedException();
        }

        public int UpdateListCaracteristiques(List<Caracteristique> _listCarac)
        {
            throw new NotImplementedException();
        }

        public int UpdateListJedis(List<Jedi> _listeJedi)
        {
            throw new NotImplementedException();
        }

        public int UpdateListMatches(List<Match> _listMatch)
        {
            throw new NotImplementedException();
        }

        public int UpdateListStades(List<Stade> _listStade)
        {
            throw new NotImplementedException();
        }

        public int UpdateListTournois(List<Tournoi> _listTournoi)
        {
            throw new NotImplementedException();
        }
    }
}
