using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CinéBuddy.DB.Context;
using CinéBuddy.Models;
using CinéBuddy.Models.Types;
using CinéBuddy.Models.Classes;
using System.Data.SqlClient;

namespace CinéBuddy.DB.MSSQL
{
    public class ReserveSQL : IReserve 
    {
        public Zaal HaalZaalOp(Film film, string filmTijd)
        {
                string query = $"SELECT * FROM Zaal z JOIN FilmTijd f ON f.FilmzaalID = z.ID WHERE f.StartTijd = '{filmTijd}' AND f.FilmID = {film.ID} ";
                var command = new SqlCommand(query);
                SqlDataReader reader = DatabaseConnection.dbConnectionInstance.ExecuteQueryReader(command);
                Zaal zaal = null;
                while (reader.Read())
                {
                    zaal = new Zaal(reader.GetInt32(0), (CinéBuddy.Models.Classes.Zaal.Soort)reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3));
                }
                return zaal;
        }

        public List<Stoel> HaalStoelenOp(string filmTijd, Zaal zaal)
        {
            string query = $"SELECT * FROM Reservering r JOIN Stoel s ON r.StoelID = s.ID JOIN Zaal z ON z.ID = s.FilmZaalID JOIN FilmTijd ft ON ft.ID = r.FilmTijdID WHERE z.ID = {zaal.ID} AND ft.StartTijd = '{filmTijd}'";
            var command = new SqlCommand(query);
            SqlDataReader reader = DatabaseConnection.dbConnectionInstance.ExecuteQueryReader(command);
            List <Stoel> listVanStoelenOmTeReturnen = new List<Stoel>();
            while (reader.Read())
            {
                listVanStoelenOmTeReturnen.Add(new Stoel(zaal, reader.GetInt32(6), reader.GetInt32(7), reader.GetInt32(8)));
            }
            return listVanStoelenOmTeReturnen;
        }

        public Stoel HaalStoelOp(Zaal zaal, string rijNummer, string stoelNummer)
        {
            string query = "SELECT * FROM STOEL WHERE FilmZaalID = @FilmZaalID AND RijNummer = @rijNummer AND Nummer = @stoelNummer";
            var command = new SqlCommand(query);
            command.Parameters.AddWithValue("@FilmZaalID", zaal.ID);
            command.Parameters.AddWithValue("@rijNummer", rijNummer);
            command.Parameters.AddWithValue("@stoelNummer", stoelNummer);
            SqlDataReader reader = DatabaseConnection.dbConnectionInstance.ExecuteQueryReader(command);
            while (reader.Read())
            {
                return new Stoel(zaal, reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4));
            }
            return null;
        }

        public bool ReserveStoel(Gebruiker gebruiker, Stoel stoel, string filmTijd)
        {
            try
            {
                string query = $"INSERT INTO Reservering VALUES((SELECT ID FROM Account WHERE Gebruikersnaam = '{gebruiker.gebruikersNaam}'), (SELECT ID FROM Stoel WHERE RijNummer = {stoel.rijNummer} AND Nummer = {stoel.stoelNummer} AND FilmZaalID = {stoel.zaal.ID}), (SELECT ID FROM FilmTijd WHERE StartTijd = '{filmTijd}' AND FilmZaalID = {stoel.zaal.ID}));";
                var command = new SqlCommand(query);
                SqlDataReader reader = DatabaseConnection.dbConnectionInstance.ExecuteQueryReader(command);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}