using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace CinéBuddy.DB
{
    public class DatabaseConnection
    {
        private const string connectionString = "Data Source=DESKTOP-SA3RDHR;Initial Catalog=CinéBuddy;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private static DatabaseConnection _dbConnectionInstance;
        private SqlConnection connection;
        private SqlDataReader lastReader;

        public static DatabaseConnection dbConnectionInstance
        {
            get
            {
                if (_dbConnectionInstance == null)
                {
                    _dbConnectionInstance = new DatabaseConnection();
                }
                return _dbConnectionInstance;
            }
        }

        private SqlConnection GetConnection()
        {
            try
            {
                if (connection == null || connection.State != System.Data.ConnectionState.Open)
                {
                    connection = new SqlConnection(connectionString);
                    connection.Open();
                }

                if (lastReader != null && !lastReader.IsClosed)
                {
                    lastReader.Close();
                }
            }
            catch (Exceptions.KonNietMetDeDatabaseVerbinden ex)
            {
                throw ex;
            }
            return connection;
        }

        public SqlDataReader ExecuteQueryReader(SqlCommand command)
        {
            command.Connection = GetConnection();
            var reader = command.ExecuteReader();
            lastReader = reader;
            return reader;
        }
    }
}