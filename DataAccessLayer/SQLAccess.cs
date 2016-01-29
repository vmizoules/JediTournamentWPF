using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer {
    class SQLAccess : IBridge {

        private string m_connectionString = "";

        /// <summary>
        /// Constructeur
        /// </summary>
        SQLAccess(string connectionString) {
            m_connectionString = connectionString;
            using (SqlConnection sqlConnection = new SqlConnection(m_connectionString)) {
                sqlConnection.Open();
                
            }
        }

        
    }
}
