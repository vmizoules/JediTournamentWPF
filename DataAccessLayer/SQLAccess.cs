using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;

namespace DataAccessLayer
{
    class SQLAccess : IBridge
    {
        public enum Jedi_enum
        {
            IDJEDI = 0,
            NAME = 1,
            ISSITH = 2,
            PIC = 3
        }
        public enum Carac_enum// Cours 
        {
            IDCARAC = 0,
            IDJEDI = 1,
            IDSTADE = 2,
            DEFINITION = 3,
            NOM = 4,
            VALEUR = 5
        }
        public enum Stade_enum // soit des enums soit des constantes
        {
            IDSTADE = 0,
            NBPLACES = 1,
            PLANET = 2,
            PIC = 3
        }
        public enum Match_enum// Cours 
        {
            IDMATCH = 0,
            IDJEDI1 = 1,
            IDJEDI2 = 2,
            PHASETOURNOI = 3,
            IDSTADE = 4,
            IDVAINQUEUR = 5,
            IDTOURNOI = 6
        }
        private string m_connectionString = "";

        public SQLAccess(string connectionString)
        {
            m_connectionString = connectionString;
        }

        #region Gestion Caractéristiques
        public List<Caracteristique> SelectCaracsByJediID(int idJedi) {
            List<Caracteristique> _carac = new List<Caracteristique>();
            using (SqlConnection sqlConnection = new SqlConnection(m_connectionString)) {
                string req = "SELECT c.idCarac, c.idJedi, c.idStade, c.Definition, c.Nom, c.Valeur From Carac c WHERE c.idJedi=@idJedi;";
                SqlCommand sqlcommand = new SqlCommand(req, sqlConnection);
                sqlcommand.Parameters.AddWithValue("@idJedi", idJedi);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlcommand.ExecuteReader();
                while (sqlDataReader.Read()) {
                    _carac.Add(new Caracteristique(sqlDataReader.GetInt32((int)Carac_enum.IDCARAC),
                                            sqlDataReader.GetString((int)Carac_enum.NOM),
                                            sqlDataReader.GetInt32((int)Carac_enum.DEFINITION),
                                            ETypeCaracteristique.Jedi,
                                            sqlDataReader.GetInt32((int)Carac_enum.VALEUR))
                    );
                }
                sqlConnection.Close();
            }
            return _carac;
        }

        public List<Caracteristique> SelectCaracByStadeID(int idStade) {
            List<Caracteristique> _carac = new List<Caracteristique>();
            using (SqlConnection sqlConnection = new SqlConnection(m_connectionString)) {
                string req = "SELECT c.idCarac, c.idJedi, c.idStade, c.Definition, c.Nom, c.Valeur From Carac c WHERE c.idStade=@idStade;";
                SqlCommand sqlcommand = new SqlCommand(req, sqlConnection);
                sqlcommand.Parameters.AddWithValue("@idStade", idStade);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlcommand.ExecuteReader();
                while (sqlDataReader.Read()) {
                    _carac.Add(new Caracteristique(sqlDataReader.GetInt32((int)Carac_enum.IDCARAC),
                                            sqlDataReader.GetString((int)Carac_enum.NOM),
                                            sqlDataReader.GetInt32((int) Carac_enum.DEFINITION),
                                            ETypeCaracteristique.Stade,
                                            sqlDataReader.GetInt32((int)Carac_enum.VALEUR))
                    );
                }
                sqlConnection.Close();
            }
            return _carac;
        }

        public bool InsertJediCarac(Caracteristique carac, Jedi jedi) {
            bool flag = false;
            using (SqlConnection sqlConnection = new SqlConnection(m_connectionString)) {
                string req = "INSERT INTO Carac (idJedi, idStade, Definition, Nom, Valeur) VALUES (@idJedi, NULL, @Def, @Nom, @Valeur);";
                SqlCommand sqlcommand = new SqlCommand(req, sqlConnection);
                sqlcommand.Parameters.AddWithValue("@idJedi", jedi.ID);
                sqlcommand.Parameters.AddWithValue("@Def", (int) carac.Definition);
                sqlcommand.Parameters.AddWithValue("@Nom", carac.Nom);
                sqlcommand.Parameters.AddWithValue("@Valeur", carac.Valeur);
                sqlConnection.Open();
                sqlcommand.ExecuteNonQuery();
                sqlConnection.Close();
                flag = true;
            }
            return flag;
        }

        public bool InsertStadeCarac(Caracteristique carac, Stade stade) {
            bool flag = false;
            using (SqlConnection sqlConnection = new SqlConnection(m_connectionString)) {
                string req = "INSERT INTO Carac (idJedi, idStade, Definition, Nom, Valeur) VALUES (NULL, @idStade, @Def, @Nom, @Valeur);";
                SqlCommand sqlcommand = new SqlCommand(req, sqlConnection);
                sqlcommand.Parameters.AddWithValue("@idStade", stade.ID);
                sqlcommand.Parameters.AddWithValue("@Def", (int)carac.Definition);
                sqlcommand.Parameters.AddWithValue("@Nom", carac.Nom);
                sqlcommand.Parameters.AddWithValue("@Valeur", carac.Valeur);
                sqlConnection.Open();
                sqlcommand.ExecuteNonQuery();
                sqlConnection.Close();
                flag = true;
            }
            return flag;
        }

        public bool RemoveCaracByID(int ID) {
            bool flag = false;
            using (SqlConnection sqlConnection = new SqlConnection(m_connectionString)) {
                string requete = "DELETE FROM Carac WHERE idCarac='@ID'";
                SqlCommand sqlCommand = new SqlCommand(requete, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@ID", ID);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();
                flag = true;
            }
            return flag;
        }

        public bool RemoveJediCaracs(Jedi jedi) {
            bool flag = false;
            using (SqlConnection sqlConnection = new SqlConnection(m_connectionString)) {
                string requete = "DELETE FROM Carac WHERE idJedi='@idJedi'";
                SqlCommand sqlCommand = new SqlCommand(requete, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@idJedi", jedi.ID);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();
                flag = true;
            }
            return flag;
        }

        public bool RemoveStadeCaracs(Stade stade) {
            bool flag = false;
            using (SqlConnection sqlConnection = new SqlConnection(m_connectionString)) {
                string requete = "DELETE FROM Carac WHERE idStade='@idStade'";
                SqlCommand sqlCommand = new SqlCommand(requete, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@idJedi", stade.ID);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();
                flag = true;
            }
            return flag;
        }

        public bool EditCarac(Caracteristique c) {
            bool flag = false;
            using (SqlConnection sqlConnection = new SqlConnection(m_connectionString)) {
                string requete = "UPDATE Carac SET Definition=@Def, Nom=@Nom, Valeur=@Valeur WHERE idCarac=@idCarac";
                SqlCommand sqlCommand = new SqlCommand(requete, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@Def", (int) c.Definition);
                sqlCommand.Parameters.AddWithValue("@Nom", c.Nom);
                sqlCommand.Parameters.AddWithValue("@Valeur", c.Valeur);
                sqlCommand.Parameters.AddWithValue("@idCarac", c.ID);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();

                flag = true;
            }
            return flag;
        }

        public bool EditJediCaracs(Jedi j) {
            /*
            @ sert à indiquer que cette variable qui par exemple _jedi.Nom doit etre la meme que celle dans la table pour pouvoir la renomer 
            */
            /*command.Text = "UPDATE Student 
            SET Address = @add, City = @cit Where FirstName = @fn and LastName = @add";*/
            bool flag = false;
            using (SqlConnection sqlConnection = new SqlConnection(m_connectionString)) {
                string requete = "UPDATE Jedis SET Name=@name, IsSith=@Sith, Pic=@pic WHERE idJedi=@idjedi";
                SqlCommand sqlCommand = new SqlCommand(requete, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@idjedi", _jedi.ID);
                sqlCommand.Parameters.AddWithValue("@name", _jedi.Nom);
                sqlCommand.Parameters.AddWithValue("@Sith", _jedi.IsSith);
                sqlCommand.Parameters.AddWithValue("@pic", _jedi.Photo);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();

                flag = true;
            }
            return flag;
        }
        #endregion

        #region Gestion jedis
        public Jedi SelectJediById(int idJedi)
        {
            Jedi _jedi = null;
            using (SqlConnection sqlConnection = new SqlConnection(m_connectionString))
            {
                string requete = "SELECT idJedi, Name, IsSith, Pic From Jedis WHERE idJedi =@idJedi;";
                SqlCommand sqlcommand = new SqlCommand(requete, sqlConnection);
                sqlcommand.Parameters.AddWithValue("@idJedi", idJedi);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlcommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    List<Caracteristique> _carac = SelectCaracsByJediID((int)Jedi_enum.IDJEDI);
                        
                    _jedi = new Jedi(sqlDataReader.GetInt32((int)Jedi_enum.IDJEDI),
                                    sqlDataReader.GetString((int)Jedi_enum.NAME),
                                    sqlDataReader.GetBoolean((int)Jedi_enum.ISSITH),
                                    _carac);
                    //int id, string nom, bool isSith, List<Caracteristique> carac
                }
                    
                sqlConnection.Close();
            }
            return _jedi;
        }
        public List<Jedi> SelectAllJedis()
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
                    List<Caracteristique> _carac = SelectCaracsByJediID((int)Jedi_enum.IDJEDI);
                    // int id, string nom, bool isSith, List< Caracteristique > carac
                    _allJedis.Add(new Jedi(sqlDataReader.GetInt32((int)Jedi_enum.IDJEDI),
                                        sqlDataReader.GetString((int)Jedi_enum.NAME),
                                        sqlDataReader.GetBoolean((int)Jedi_enum.ISSITH),
                                        _carac,
                                        (sqlDataReader[(int)Jedi_enum.PIC] != DBNull.Value)? sqlDataReader.GetString((int)Jedi_enum.PIC) : ""));
                }
                sqlConnection.Close();
            }
            return _allJedis;
        }

        public bool InsertJedi(Jedi _jedi)
        {
            bool flag = false;
            using (SqlConnection sqlConnection = new SqlConnection(m_connectionString))
            {
             
                string requete = "INSERT INTO Jedis (Name, IsSith, Pic) VALUES (@Name, @IsSith, @Pic)";
                SqlCommand sqlCommand = new SqlCommand(requete, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@Name", _jedi.Nom);
                sqlCommand.Parameters.AddWithValue("@IsSith", _jedi.IsSith);
                if (!string.IsNullOrEmpty(_jedi.Photo)) { 
                    sqlCommand.Parameters.AddWithValue("@Pic", _jedi.Photo);
                }
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                
                sqlConnection.Close();
                flag = true;
            }

            return flag;
        }

        public bool RemoveJedi(Jedi _jedi)
        {
            bool flag = false;
            using (SqlConnection sqlConnection = new SqlConnection(m_connectionString))
            {
                string requete = "DELETE FROM Jedis WHERE idJedi='@idJedi'";
                SqlCommand sqlCommand = new SqlCommand(requete, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id", _jedi.ID);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();
                flag = true;
            }
            return flag;
        }

        public bool EditJedi(Jedi _jedi)
        {
            /*
            @ sert à indiquer que cette variable qui par exemple _jedi.Nom doit etre la meme que celle dans la table pour pouvoir la renomer 
            */
            /*command.Text = "UPDATE Student 
            SET Address = @add, City = @cit Where FirstName = @fn and LastName = @add";*/
            bool flag = false;
            using (SqlConnection sqlConnection = new SqlConnection(m_connectionString))
            {
                string requete = "UPDATE Jedis SET Name=@name, IsSith=@Sith, Pic=@pic WHERE idJedi=@idjedi";
                SqlCommand sqlCommand = new SqlCommand(requete, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@idjedi", _jedi.ID);
                sqlCommand.Parameters.AddWithValue("@name", _jedi.Nom);
                sqlCommand.Parameters.AddWithValue("@Sith", _jedi.IsSith);
                sqlCommand.Parameters.AddWithValue("@pic", _jedi.Photo);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();

                flag = true;
            }
            return flag;
        }
        #endregion
        #region Gestion des stades
        public List<Stade> SelectAllStades()
        {
            List<Stade> _allStades = new List<Stade>();
            using (SqlConnection sqlConnection = new SqlConnection(m_connectionString))
            {
                string requete = "SELECT idStade, nbPlaces, planet, Pic FROM Stade;";
                SqlCommand sqlCommand = new SqlCommand(requete, sqlConnection);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    List<Caracteristique> _carac = SelectCaracByStadeID((int)Stade_enum.IDSTADE);
                    _allStades.Add(new Stade(sqlDataReader.GetInt32((int)Stade_enum.IDSTADE),
                                        sqlDataReader.GetInt32((int)Stade_enum.NBPLACES),
                                        sqlDataReader.GetString((int)Stade_enum.PLANET),
                                        _carac,
                                        (sqlDataReader[(int)Stade_enum.PIC] != DBNull.Value) ? sqlDataReader.GetString((int)Stade_enum.PIC) : ""));
                }
                sqlConnection.Close();
            }
            return _allStades;
        }

        public int InsertStade(Stade _stade)
        {
            int val = 0;
            using (SqlConnection sqlConnection = new SqlConnection(m_connectionString))
            {   //idStade = auto_increment
                try {
                    string requete = "INSERT INTO Stade (nbPlaces, planet, Pic) VALUES (@nbplaces, @planet, @pic)";
                    SqlCommand sqlCommand = new SqlCommand(requete, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@nbplaces", _stade.NbPlaces);
                    sqlCommand.Parameters.AddWithValue("@planet", _stade.Planete);
                    sqlCommand.Parameters.AddWithValue("@pic", _stade.Photo);
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    string s = e.Message;
                }
                finally
                {
                    sqlConnection.Close();
                }
                val = 1;
            }
            return val;
        }

        public int RemoveStade(Stade _stade)
        {
            int val = 0;
            using (SqlConnection sqlConnection = new SqlConnection(m_connectionString))
            {
                try { 
                    string requete = "DELETE FROM Stade WHERE idStade='@idStade'";
                    SqlCommand sqlCommand = new SqlCommand(requete, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@idStade", _stade.ID);
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
                catch (SqlException e) {
                    string s = e.Message;
                }
                 finally
                {
                    sqlConnection.Close();
                }
                val = 1;
            }
            return val;
        }

        public int EditStade(Stade _stade)
        {
            int val = 0;
            using (SqlConnection sqlConnection = new SqlConnection(m_connectionString))
            {
                try { 
                    string requete = "UPDATE Stade SET nbPlaces=@nbPlaces, planet=@planet, Pic=@pic WHERE idSade=@idStade";
                    SqlCommand sqlCommand = new SqlCommand(requete, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@idjedi", _stade.ID);
                    sqlCommand.Parameters.AddWithValue("@nbPlaces", _stade.NbPlaces);
                    sqlCommand.Parameters.AddWithValue("@planet", _stade.Planete);
                    sqlCommand.Parameters.AddWithValue("@pic", _stade.Photo);
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    string s = e.Message;
                }
                finally
                {
                    sqlConnection.Close();
                }
            val = 1;
            }
            return val;
        }

        public Stade selectStadeById(int idStade)
        {
            Stade _stade = null;
            using (SqlConnection sqlConnection = new SqlConnection(m_connectionString))
            {
                try { 
                    string requete = "SELECT idStade, nbPlaces, planet, Pic From Stade WHERE idStade =@idStade;";
                    SqlCommand sqlcommand = new SqlCommand(requete, sqlConnection);
                    sqlcommand.Parameters.AddWithValue("@idStade", Stade_enum.IDSTADE);
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlcommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        List<Caracteristique> _carac = new List<Caracteristique>();
                        using (SqlConnection sqlConnection2 = new SqlConnection(m_connectionString))
                        {
                            try { 
                            string requete2 = "SELECT c.idCarac, c.idJedi, c.idStade, c.Nom, c.Valeur From Carac c WHERE c.idStade=@idStade;";
                            SqlCommand sqlcommand2 = new SqlCommand(requete2, sqlConnection);
                            sqlcommand2.Parameters.AddWithValue("@idStade", Carac_enum.IDSTADE);
                            sqlConnection2.Open();
                            SqlDataReader sqlDataReader2 = sqlcommand2.ExecuteReader();
                            while (sqlDataReader2.Read())
                            {
                                _carac.Add(new Caracteristique(sqlDataReader2.GetInt32((int)Carac_enum.IDCARAC),
                                                              sqlDataReader2.GetString((int)Carac_enum.NOM),
                                                              sqlDataReader2.GetInt32((int)Carac_enum.VALEUR))
                                    );
                            }
                            }
                            catch (SqlException e)
                            {
                                string s = e.Message;
                            }
                            finally
                            {
                                sqlConnection2.Close();
                            }
                        }
                        //int id, int nbPlaces, string planete, List<Caracteristique> carac
                        _stade = new Stade(sqlDataReader.GetInt32((int)Stade_enum.IDSTADE), 
                                           sqlDataReader.GetInt32((int)Stade_enum.NBPLACES), 
                                           sqlDataReader.GetString((int)Stade_enum.PLANET),
                                           _carac);
                    }
                }catch (SqlException e)
                {
                    string s = e.Message;
                }
                finally
                {
                    sqlConnection.Close();
                }
        }
            return _stade;
        }
        #endregion

        #region Tournois
        public Tournoi selectTournoiById()
        {
            throw new NotImplementedException();
        }

        public int InsertTournoi(Tournoi _tournoi)
        {
            int val=0;
            using (SqlConnection sqlConnection = new SqlConnection(m_connectionString))
            {
                try
                { 
                    string requete = "INSERT INTO Tournoi (Nom) VALUES (@Nom)";
                    SqlCommand sqlCommand = new SqlCommand(requete, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@Nom",_tournoi.Nom);
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }catch (SqlException e)
                {
                    string s = e.Message;
                }
                finally
                {
                sqlConnection.Close();
                }
        } 
            return val;
          }

        public int RemoveTournoi(Tournoi _tournoi)
        {
            int val = 0;
            using (SqlConnection sqlConnection = new SqlConnection(m_connectionString))
            { //reste les Matchs à supprimer 
                try {
                    string requete = "DELETE FROM Tournoi WHERE idTournoi=@idtournoi";
                    SqlCommand sqlCommand = new SqlCommand(requete, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@idtournoi", _tournoi.ID);
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                    val = 1;
                }catch (SqlException e)
                {
                    string s = e.Message;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
            return val;
        }

        public int EditTournoi(Tournoi _tournoi)
        {
            int val = 0;
            using (SqlConnection sqlConnection = new SqlConnection(m_connectionString))
            { //reste les Matchs à supprimer 
                try
                {
                    string query = "UPDATE Tournoi SET Nom=@nom WHERE idTournoi=@idTournoi";
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@nom", _tournoi.Nom);
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    val = 1;
                }
                catch (SqlException e)
                {
                    string s = e.Message;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
            return val;
        }
        #endregion

        #region Matchs
        public List<Match> SelectAllMatchs() {
            List<Match> _allMatchs = new List<Match>();
            using (SqlConnection sqlConnection = new SqlConnection(m_connectionString)) {
                try {
                    string requete = "SELECT idMatch, idJedi1, idJedi2, phaseTournoi, idStade, idVainqueur, idTournoi;";
                    SqlCommand sqlCommand = new SqlCommand(requete, sqlConnection);
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read()) {
                        Jedi jedi1 = SelectJediById(sqlDataReader.GetInt32((int)Jedi_enum.IDJEDI));
                        using (SqlConnection sqlConnection2 = new SqlConnection(m_connectionString)) {
                            try {
                                string id = sqlDataReader.GetInt32((int)Stade_enum.IDSTADE).ToString(); ;
                                string requete2 = "SELECT carac.idCarac, carac.idJedi, carac.idStade, carac.Nom ,carac.Valeur FROM Stade stade, Carac carac WHERE stade.idStade=" + id + " AND stade.idStade=carac.idStade;";
                                SqlCommand sqlCommand2 = new SqlCommand(requete2, sqlConnection2);
                                sqlConnection2.Open();
                                SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();//creation d'une nouvelle sqlDataReader2
                                while (sqlDataReader2.Read()) {
                                    /*_carac.Add(new Caracteristique(sqlDataReader2.GetInt32((int)Carac_enum.IDCARAC),
                                                                  sqlDataReader2.GetString((int)Carac_enum.NOM),
                                                                  sqlDataReader2.GetInt32((int)Carac_enum.VALEUR)));*/
                                }
                            }
                            catch (SqlException e) {
                                string s = e.Message;
                            }
                            finally {
                                sqlConnection2.Close();
                            }
                            /*_allMatchs.Add(new Stade(sqlDataReader.GetInt32((int)Stade_enum.IDSTADE),
                                               sqlDataReader.GetInt32((int)Stade_enum.NBPLACES),
                                               sqlDataReader.GetString((int)Stade_enum.PLANET),
                                               _carac,
                                               (sqlDataReader[(int)Stade_enum.PIC] != DBNull.Value) ? sqlDataReader.GetString((int)Stade_enum.PIC) : ""));*/
                        }
                    }
                }
                catch (SqlException e) {
                    string s = e.Message;
                }
                finally {
                    sqlConnection.Close();
                }
            }
            return _allMatchs;
        }
        #endregion

    }
}

