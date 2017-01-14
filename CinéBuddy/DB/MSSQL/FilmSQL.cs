using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CinéBuddy.DB.Context;
using CinéBuddy.Models;
using CinéBuddy.Models.Types;
using System.Data.SqlClient;

namespace CinéBuddy.DB.MSSQL
{
    public class FilmSQL : IFilm
    {
        public List<Film> GetAllFilms()
        {
            const string query = "SELECT * FROM FILM ORDER BY OpeningsDatum ASC";
            var command = new SqlCommand(query);
            SqlDataReader reader = DatabaseConnection.dbConnectionInstance.ExecuteQueryReader(command);
            List<Film> listOfFilmsToReturn = new List<Film>();
            while (reader.Read())
            {
                listOfFilmsToReturn.Add(new Film(reader.GetFieldValue<int>(0),
                    reader.GetFieldValue<string>(1),
                    reader.GetFieldValue<string>(2),
                    reader.GetFieldValue<string>(3),
                    reader.GetFieldValue<int>(4),
                    reader.GetFieldValue<int>(5),
                    reader.GetFieldValue<DateTime>(6),
                    reader.GetFieldValue<int>(7),
                    reader.GetFieldValue<int>(8),
                    reader.GetFieldValue<string>(9)));
            }
            return listOfFilmsToReturn;
        }

        public List<Review> GetReviews(int id)
        {
            try
            {
                string query = "SELECT a.Gebruikersnaam, f.Titel, r.Cijfer, r.Omschrijving FROM Review r Inner join account a ON a.ID = r.AccountID Inner join film f ON f.ID = r.FilmID WHERE f.ID = @id;";
                var command = new SqlCommand(query);
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = DatabaseConnection.dbConnectionInstance.ExecuteQueryReader(command);
                List<Review> listOfReviewsToReturn = new List<Review>();
                while (!reader.IsClosed && reader.Read())
                {
                    listOfReviewsToReturn.Add(new Review(reader.GetFieldValue<string>(0),
                        reader.GetFieldValue<string>(1),
                        reader.GetFieldValue<int>(2),
                        reader.GetFieldValue<string>(3)));
                }
                return listOfReviewsToReturn;
            }
            catch (Exceptions.KonFilmNietVinden ex)
            {
                throw ex;
            }
            
        }

        public Film HaalFilmOp(int id)
        {
            try
            {
                string query = "SELECT * FROM FILM WHERE ID = @id;";
                var command = new SqlCommand(query);
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = DatabaseConnection.dbConnectionInstance.ExecuteQueryReader(command);
                while (reader.Read())
                {
                    Film a = new Film(reader.GetFieldValue<int>(0),
                        reader.GetFieldValue<string>(1),
                        reader.GetFieldValue<string>(2),
                        reader.GetFieldValue<string>(3),
                        reader.GetFieldValue<int>(4),
                        reader.GetFieldValue<int>(5),
                        reader.GetFieldValue<DateTime>(6),
                        reader.GetFieldValue<int>(7),
                        reader.GetFieldValue<int>(8),
                        reader.GetFieldValue<string>(9));
                    return a;
                }
            }
            catch (Exceptions.KonFilmNietVinden ex)
            {
                throw ex;
            }
            return null;
        }

        public List<DateTime> HaalFilmTijdenOp(int id)
        {
            try
            {
                string query = "SELECT * FROM FilmTijd WHERE FilmID = @id ORDER BY StartTijd ASC;";
                var command = new SqlCommand(query);
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = DatabaseConnection.dbConnectionInstance.ExecuteQueryReader(command);
                List<DateTime> listOfTimesToReturn = new List<DateTime>();
                while (reader.Read())
                {
                    listOfTimesToReturn.Add(reader.GetDateTime(3));
                }
                return listOfTimesToReturn;
            }
            catch (Exceptions.KonFilmNietVinden ex)
            {
                throw ex;
            }
        }

        public Film HaalSneakPreviewOp()
        {
            try
            {
                string query = $"SELECT * FROM FILM f JOIN SneakPreview s ON f.ID = s.FilmID WHERE s.Datum = (SELECT TOP 1 datum FROM SneakPreview WHERE datum >= @datum);";
                var command = new SqlCommand(query);
                command.Parameters.AddWithValue("@datum", DateTime.Now.ToString("yyyy-MM-dd"));
                SqlDataReader reader = DatabaseConnection.dbConnectionInstance.ExecuteQueryReader(command);
                while (reader.Read())
                {
                    Film a = new Film(reader.GetFieldValue<int>(0),
                        reader.GetFieldValue<string>(1),
                        reader.GetFieldValue<string>(2),
                        reader.GetFieldValue<string>(3),
                        reader.GetFieldValue<int>(4),
                        reader.GetFieldValue<int>(5),
                        reader.GetFieldValue<DateTime>(6),
                        reader.GetFieldValue<int>(7),
                        reader.GetFieldValue<int>(8),
                        reader.GetFieldValue<string>(9));
                    return a;
                }
            }
            catch (Exceptions.KonFilmNietVinden ex)
            {
                throw ex;
            }
            return null;
        }
    }
}