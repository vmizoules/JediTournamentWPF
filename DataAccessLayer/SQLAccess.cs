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
            NOM = 3,
            VALEUR = 4
        }
        public enum Stade_enum // soit des enums soit des constantes
        {
            IDSTADE = 0,
            NBPLACES = 1,
            PLANET = 2,
            PIC = 3
        }
        private string m_connectionString = "";

        public SQLAccess(string connectionString)
        {
            m_connectionString = connectionString;
        }
        //  Block Gestion des Jedis ----------------------------------------------------------------------------------------------------------------------
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
                    List<Caracteristique> _carac = new List<Caracteristique>();
                    using (SqlConnection sqlConnection2 = new SqlConnection(m_connectionString))
                    {
                        string id = sqlDataReader.GetInt32((int)Jedi_enum.IDJEDI).ToString(); ;
                        string requete2 = "SELECT carac.idCarac, carac.idJedi, carac.idStade, carac.Nom ,carac.Valeur FROM Jedis jedi, Carac carac WHERE jedi.idJedi=" + id + " AND jedi.idJedi=carac.idJedi;";
                        SqlCommand sqlCommand2 = new SqlCommand(requete2, sqlConnection2);
                        sqlConnection2.Open();

                        SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();//creation d'une nouvelle sqlDataReader2
                        while (sqlDataReader2.Read())
                        {
                            _carac.Add(new Caracteristique(sqlDataReader2.GetInt32((int)Carac_enum.IDCARAC),
                                                          sqlDataReader2.GetString((int)Carac_enum.NOM),
                                                          sqlDataReader2.GetInt32((int)Carac_enum.VALEUR))
                              );
                        }
                        sqlConnection2.Close();
                        //jointure entre les 2 tables
                    }
                    // int id, string nom, bool isSith, List< Caracteristique > carac
                    _allJedis.Add(new Jedi(sqlDataReader.GetInt32((int)Jedi_enum.IDJEDI),
                                           sqlDataReader.GetString((int)Jedi_enum.NAME),
                                           sqlDataReader.GetBoolean((int)Jedi_enum.ISSITH),
                                           _carac,
                                           sqlDataReader.GetString((int)Jedi_enum.PIC)));
                }
                sqlConnection.Close();
            }
            return _allJedis;
        }

        public void InsertJedis(Jedi _jedi)
        {
            using (SqlConnection sqlConnection = new SqlConnection(m_connectionString))
            {
                string requete = "INSERT INTO Jedis (Name, IsSith, Pic) VALUES (@Name, @IsSith, @Pic)";
                SqlCommand sqlCommand = new SqlCommand(requete, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@Name", _jedi.Nom);
                sqlCommand.Parameters.AddWithValue("@IsSith", _jedi.IsSith);
                sqlCommand.Parameters.AddWithValue("@Pic", _jedi.Image);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();
            }
        }

        public int RemoveJedi(Jedi _jedi)
        {
            int val = 0;
            using (SqlConnection sqlConnection = new SqlConnection(m_connectionString))
            {
                string requete = "DELETE FROM Jedis WHERE idJedi='@idJedi'";
                SqlCommand sqlCommand = new SqlCommand(requete, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id", _jedi.ID);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                val = 1;
            }
            return val;
        }

        public int EditJedi(Jedi _jedi)
        {
            /*
            @ sert à indiquer que cette variable qui par exemple _jedi.Nom doit etre la meme que celle dans la table pour pouvoir la renomer 
            */
            /*command.Text = "UPDATE Student 
            SET Address = @add, City = @cit Where FirstName = @fn and LastName = @add";*/
            int val = 0;
            using (SqlConnection sqlConnection = new SqlConnection(m_connectionString))
            {
                string requete = "UPDATE Jedis SET Name=@name, IsSith=@Sith, Pic=@pic WHERE idJedi=@idjedi";
                SqlCommand sqlCommand = new SqlCommand(requete, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@idjedi", _jedi.ID);
                sqlCommand.Parameters.AddWithValue("@name", _jedi.Nom);
                sqlCommand.Parameters.AddWithValue("@Sith", _jedi.IsSith);
                sqlCommand.Parameters.AddWithValue("@pic", _jedi.Image);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                val = 1;
            }
            return val;
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------------
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
                    List<Caracteristique> _carac = new List<Caracteristique>();
                    using (SqlConnection sqlConnection2 = new SqlConnection(m_connectionString))
                    {
                        string id = sqlDataReader.GetInt32((int)Stade_enum.IDSTADE).ToString(); ;
                        string requete2 = "SELECT carac.idCarac, carac.idJedi, carac.idStade, carac.Nom ,carac.Valeur FROM Stade stade, Carac carac WHERE stade.idStade=" + id + " AND stade.idStade=carac.idStade;";
                        SqlCommand sqlCommand2 = new SqlCommand(requete2, sqlConnection2);
                        sqlConnection2.Open();
                        SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();//creation d'une nouvelle sqlDataReader2
                        while (sqlDataReader2.Read())
                        {
                            _carac.Add(new Caracteristique(sqlDataReader2.GetInt32((int)Carac_enum.IDCARAC),
                                                          sqlDataReader2.GetString((int)Carac_enum.NOM),
                                                          sqlDataReader2.GetInt32((int)Carac_enum.VALEUR));
                        }
                        sqlConnection2.Close();
                        _allStades.Add(new Stade(sqlDataReader.GetInt32((int)Stade_enum.IDSTADE),
                                           sqlDataReader.GetInt32((int)Stade_enum.NBPLACES),
                                           sqlDataReader.GetString((int)Stade_enum.PLANET),
                                           _carac,
                                           sqlDataReader.GetString((int)Stade_enum.PIC)));
                    }
                }
                sqlConnection.Close();
            }
            return _allStades;
        }

        public int InsertStades(Stade _stade)
        {
            int val = 0;
            using (SqlConnection sqlConnection = new SqlConnection(m_connectionString))
            {
                string requete = "INSERT INTO Stade (nbPlaces, planet, Pic) VALUES (@nbplaces, @planet, @pic)";
                SqlCommand sqlCommand = new SqlCommand(requete, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@nbplaces", _stade.NbPlaces);
                sqlCommand.Parameters.AddWithValue("@planet", _stade.Planete);
                sqlCommand.Parameters.AddWithValue("@pic", _stade.Image);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                val = 1;
            }
            return val;
        }

        public int RemoveStade(Stade _stade)
        {
            int val = 0;
            using (SqlConnection sqlConnection = new SqlConnection(m_connectionString))
            {
                string requete = "DELETE FROM Stade WHERE idStade='@idStade'";
                SqlCommand sqlCommand = new SqlCommand(requete, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@idStade", _stade.ID);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                val = 1;
            }
            return val;
        }

        public int EditStade(Stade _stade)
        {
            int val = 0;
            using (SqlConnection sqlConnection = new SqlConnection(m_connectionString))
            {
                string requete = "UPDATE Stade SET nbPlaces=@nbPlaces, planet=@planet, Pic=@pic WHERE idSade=@idStade";
                SqlCommand sqlCommand = new SqlCommand(requete, sqlConnection);

                sqlCommand.Parameters.AddWithValue("@idjedi", _stade.ID);
                sqlCommand.Parameters.AddWithValue("@nbPlaces", _stade.NbPlaces);
                sqlCommand.Parameters.AddWithValue("@planet", _stade.Planete);
                sqlCommand.Parameters.AddWithValue("@pic", _stade.Image);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                val = 1;
            }
            return val;
        }
    }
}

