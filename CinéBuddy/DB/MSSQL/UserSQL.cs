using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CinéBuddy.DB.Context;
using CinéBuddy.Models.Types;
using System.Data.SqlClient;

namespace CinéBuddy.DB.MSSQL
{
    public class UserSQL : IUser
    {
        public List<Gebruiker> GetAllUsers()
        {
            const string query = "SELECT * FROM Account";
            var command = new SqlCommand(query);
            SqlDataReader reader = DatabaseConnection.dbConnectionInstance.ExecuteQueryReader(command);
            List<Gebruiker> listOfUsersToReturn = new List<Gebruiker>();
            while (reader.Read())
            {
                listOfUsersToReturn.Add(new Gebruiker(reader.GetString(1),
                    reader.GetString(3),
                    reader.GetString(4),
                    reader.GetDateTime(5),
                    reader.GetString(6),
                    reader.GetInt32(7)));
            }
            return listOfUsersToReturn;
        }

        public Gebruiker GetUserByUserName(string username)
        {
            string query = "SELECT * FROM Account WHERE Gebruikersnaam = @username";
            var command = new SqlCommand(query);
            command.Parameters.AddWithValue("@username", username);
            SqlDataReader reader = DatabaseConnection.dbConnectionInstance.ExecuteQueryReader(command);
            while (reader.Read())
            {
                Gebruiker gebruiker = new Gebruiker(reader.GetString(1),
                    reader.GetString(3),
                    reader.GetString(4),
                    reader.GetDateTime(5),
                    reader.GetString(6),
                    reader.GetInt32(7));
                return gebruiker;
            }
            return null;
        }

        public bool CheckCredentials(string username, string password)
        {
            string query = "SELECT Gebruikersnaam, Wachtwoord FROM ACCOUNT WHERE Gebruikersnaam = @username";
            var command = new SqlCommand(query);
            command.Parameters.AddWithValue("@username", username);
            SqlDataReader reader = DatabaseConnection.dbConnectionInstance.ExecuteQueryReader(command);
            while (reader.Read())
            {
                if (reader.GetString(0) == username && reader.GetString(1) == password)
                {
                    return true;
                }
            }
            return false;
        }

        public bool AnnuleerAbonnement(string username)
        {
            try
            {
                string query = "UPDATE ACCOUNT SET GOLD = 0 WHERE GEBRUIKERSNAAM = @username";
                var command = new SqlCommand(query);
                command.Parameters.AddWithValue("@username", username);
                DatabaseConnection.dbConnectionInstance.ExecuteQueryReader(command);

                command = new SqlCommand("spEndAbonnement");
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@GebruikersNaam", username));
                DatabaseConnection.dbConnectionInstance.ExecuteQueryReader(command);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool AbonneerAbonnement(string username)
        {
            try
            {
                string query = "UPDATE ACCOUNT SET GOLD = 1 WHERE GEBRUIKERSNAAM = @username";
                var command = new SqlCommand(query);
                command.Parameters.AddWithValue("@username", username);
                DatabaseConnection.dbConnectionInstance.ExecuteQueryReader(command);

                command = new SqlCommand("spAddAbonnement");
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@GebruikersNaam", username));
                DatabaseConnection.dbConnectionInstance.ExecuteQueryReader(command);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateGegevens(Gebruiker user, string gebruikersNaam, string emailAdres, string naam, string woonplaats)
        {
            try
            {
                string query = $"UPDATE ACCOUNT SET GEBRUIKERSNAAM = '{gebruikersNaam}', EMAILADRES = '{emailAdres}', NAAM = '{naam}', WOONPLAATS = '{woonplaats}' WHERE GEBRUIKERSNAAM = '{user.gebruikersNaam}'";
                var command = new SqlCommand(query);
                DatabaseConnection.dbConnectionInstance.ExecuteQueryReader(command);
                user.gebruikersNaam = gebruikersNaam;
                user.emailAdres = emailAdres;
                user.naam = naam;
                user.woonplaats = woonplaats;
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}