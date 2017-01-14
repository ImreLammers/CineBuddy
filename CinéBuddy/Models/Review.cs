using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CinéBuddy.Models.Types;
using CinéBuddy.DB.Repository;
using CinéBuddy.DB.MSSQL;

namespace CinéBuddy.Models
{
    public class Review
    {
        FilmRepository fr = new FilmRepository(new FilmSQL());
        UserRepository ur = new UserRepository(new UserSQL());
        public Gebruiker gebruiker { get; set; }
        public Film film { get; set; }
        public int cijfer { get; set; }
        public string omschrijving { get; set; }

        public Review()
        {

        }

        public Review(string gebruikersNaam, string filmTitel, int cijfer, string omschrijving)
        {
            foreach (Gebruiker b in ur.GetAllUsers())
            {
                if (b.gebruikersNaam == gebruikersNaam)
                {
                    this.gebruiker = b;
                }
            }
            foreach (Film a in fr.GetAllFilms())
            {
                if (a.titel == filmTitel)
                {
                    this.film = film;
                }
            }
            this.cijfer = cijfer;
            this.omschrijving = omschrijving;
        }
    }
}