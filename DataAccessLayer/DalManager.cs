using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
namespace DataAccessLayer
{
    /// <summary>
    /// Access to the data in the SQL file
    /// Sealed prevents heritage
    /// Pattern Singleton used
    /// </summary>
    public sealed class DalManager{
        private static DalManager m_instance = null;
        private static readonly object padlock = new object();
        IBridge bd;
        /// <summary>
        /// Constructor of the Singleton DalManager
        /// </summary>
        /// <returns>
        /// DalManager instanciate or not
        /// </returns>
        public static DalManager Instance
        {
            get
            {
                if (m_instance == null) {
                    lock (padlock) {
                        if (m_instance == null) {
                            m_instance = new DalManager();
                        }
                    }
                }
                return m_instance;
            }
        }
        public DalManager()
        {
            string connection = "Data Source=reseaug5.database.windows.net;Initial Catalog=JediTournamentBDD;Integrated Security=False;User ID=Reseau;Password=JediTournamentEntities2016;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            bd = new SQLAccess(connection);
        }

        public List<Jedi> getJedis()
        {
            return bd.SelectAllJedis();
        }

        public List<Stade> getStades()
        {
            return bd.SelectAllStades();
        }

        public bool DeleteJedis(Jedi _jedi)
        {
            return bd.RemoveJedi(_jedi);
        }
        public int DeleteStades(Stade _stade)
        {
            return bd.RemoveStade(_stade);
        }
        public bool UpdateJedi(Jedi _jedi)
        {
            return bd.EditJedi(_jedi);
        }
        public int UpdateStade(Stade _stade)
        {
            return bd.EditStade(_stade);
        }
        public bool InsertJedi(Jedi _jedi)
        {
            return bd.InsertJedi(_jedi);
        }
        public int InsertStade(Stade _stade)
        {
            return bd.InsertStade(_stade);
        }


    }
}
