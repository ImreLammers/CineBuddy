using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CinéBuddy.DB.Context;
using CinéBuddy.Models;
using CinéBuddy.Models.Types;

namespace CinéBuddy.DB.Local
{
    public class FilmContext : IFilm
    {
        private List<Film> AllFilms = new List<Film>
        {
            new Film(0, "Memento", "filepath", "Omschrijving van de film", 2, 1, DateTime.Now, 16, 120, "trailerlink"),
            new Film(1, "Finding Nemo", "filepath", "Omschrijving van de film", 2, 1, DateTime.Now, 16, 120, "trailerlink"),
            new Film(2, "Toy Story", "filepath", "Omschrijving van de film", 2, 1, DateTime.Now, 16, 120, "trailerlink")
        };

        public List<Film> GetAllFilms()
        {
            return AllFilms;
        }

        public List<Review> GetReviews(int id)
        {
            throw new NotImplementedException();
        }

        public Film HaalFilmOp(int id)
        {
            return AllFilms[id];
        }

        public List<DateTime> HaalFilmTijdenOp(int id)
        {
            throw new NotImplementedException();
        }

        public Film HaalSneakPreviewOp()
        {
            throw new NotImplementedException();
        }
    }
}