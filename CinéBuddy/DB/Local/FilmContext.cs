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
        public List<Film> GetAllFilms()
        {
            throw new NotImplementedException();
        }

        public List<Review> GetReviews(int id)
        {
            throw new NotImplementedException();
        }

        public Film HaalFilmOp(int id)
        {
            throw new NotImplementedException();
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