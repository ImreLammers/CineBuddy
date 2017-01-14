using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CinéBuddy.DB.Repository;
using CinéBuddy.DB.MSSQL;
using CinéBuddy.Models.Types;
using CinéBuddy.Models.Classes;

namespace CinéBuddy.Models
{
    public class Films
    {

        FilmRepository fr = new FilmRepository(new FilmSQL());
        UserRepository ur = new UserRepository(new UserSQL());
        ReserveRepository rr = new ReserveRepository(new ReserveSQL());

        public List<Film> haalFilmsOp()
        {
            return fr.GetAllFilms();
        }

        public List<Review> haalReviewsOp(int id)
        {
            return fr.GetReviews(id);
        }

        public List<DateTime> haalFilmTijdenOp(int id)
        {
            return fr.HaalFilmTijdenOp(id);
        }

        public Film haalFilmOp(int id)
        {
            return fr.HaalFilmOp(id); 
        }

        public Film haalSneakPreviewOp()
        {
            return fr.HaalSneakPreviewOp();
        }

        public bool CheckCredentials(string username, string password)
        {
            return ur.CheckCredentials(username, password);
        }

        public Gebruiker GetUserByUserName(string username)
        {
            return ur.GetUserByUserName(username);
        }

        public bool AbonneerAbonnement(string username)
        {
            return ur.AbonneerAbonnement(username);
        }

        public bool AnnuleerAbonnement(string username)
        {
            return ur.AnnuleerAbonnement(username);
        }

        public Gebruiker returnHuidigeGebruiker()
        {
            Gebruiker gebruiker = (Gebruiker)HttpContext.Current.Session["User"];
            return gebruiker;
        }

        public bool UpdateGegevens(string gebruikersNaam, string emailAdres, string naam, string woonplaats)
        {
            Gebruiker user = returnHuidigeGebruiker();
            return ur.UpdateGegevens(user, gebruikersNaam, emailAdres, naam, woonplaats);
        }

        public Zaal HaalZaalOp(Film film, DateTime filmTijd)
        {
            return rr.HaalZaalOp(film, filmTijd.ToString(("yyyy-MM-dd H:mm:ss")));
        }

        public List<Stoel> HaalStoelenOp(DateTime filmTijd, Zaal zaal)
        {
            return rr.HaalStoelenOp(zaal, filmTijd.ToString(("yyyy-MM-dd H:mm:ss")));
        }

        public bool Reserveer(Zaal zaal, string rijNummer, string stoelNummer, DateTime filmTijd)
        {
            return rr.ReserveerStoel(returnHuidigeGebruiker(), zaal, rijNummer, stoelNummer, filmTijd.ToString(("yyyy-MM-dd H:mm:ss")));
        }
    }
}