using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;

namespace DataAccessLayer {
    class SQLAccess : IBridge {
        public enum Champ_Jedi
        {
            IDJEDI = 0,
            NAME = 1,
            ISSITH = 2,
            PIC = 3
        }
        public enum Champ_Carac// Cours 
        {
            IDCARAC = 0,
            IDJEDI = 1,
            IDSTADE = 2,
            NOM = 3,
            VALEUR = 4
        }
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
                string requete = "SELECT idJedi, Name, isSith, Pic FROM Jedis;";
                SqlCommand sqlCommand = new SqlCommand(requete, sqlConnection);
                sqlConnection.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    List<Caracteristique> _carac = new List<Caracteristique>();
                    using (SqlConnection sqlConnection2 = new SqlConnection(m_connectionString))
                    {
                        String id = sqlDataReader.GetInt32((int)Champ_Jedi.IDJEDI).ToString(); ;
                        String requete2 = "SELECT carac.idCarac, carac.idJedi, carac.idStade, carac.Nom ,carac.Valeur FROM Jedis jedi, Carac carac WHERE jedi.idJedi=" + id + " AND jedi.id=carac.idjedi;";
                        SqlCommand sqlCommand2 = new SqlCommand(requete2, sqlConnection2);
                        sqlConnection2.Open();

                        SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();//creation d'une nouvelle sqlDataReader2
                        while (sqlDataReader2.Read())
                        {
                            _carac.Add(new Caracteristique(/*sqlDataReader2.GetInt32((int)Champ_Carac.IDCARAC),
                                                          sqlDataReader2.GetString((int)Champ_Carac.NOM),
                                                          sqlDataReader2.GetInt32((int)Champ_Carac.VALEUR)*/)
                              );
                        }
                        sqlConnection2.Close();
                        //jointure entre les 2 tables
                    }
                   // int id, string nom, bool isSith, List< Caracteristique > carac
                    _allJedis.Add(new Jedi(sqlDataReader.GetInt32((int)Champ_Jedi.IDJEDI),
                                           sqlDataReader.GetString((int)Champ_Jedi.NAME),
                                           sqlDataReader.GetBoolean((int)Champ_Jedi.ISSITH),
                                                _carac,
                                           sqlDataReader.GetString((int)Champ_Jedi.PIC)));
                }
                sqlDataReader.Close();
                sqlConnection.Close();
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
