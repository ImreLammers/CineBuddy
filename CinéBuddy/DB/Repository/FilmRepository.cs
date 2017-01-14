using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CinéBuddy.DB.Context;
using CinéBuddy.Models;
using CinéBuddy.Models.Types;

namespace CinéBuddy.DB.Repository
{
    public class FilmRepository
    {
        private IFilm context;

        public FilmRepository(IFilm context)
        {
            this.context = context;
        }

        public List<Film> GetAllFilms()
        {
            return context.GetAllFilms();
        }

        public List<Review> GetReviews(int id)
        {
            return context.GetReviews(id);
        }

        public List<DateTime> HaalFilmTijdenOp(int id)
        {
            return context.HaalFilmTijdenOp(id);
        }

        public Film HaalFilmOp(int id)
        {
            return context.HaalFilmOp(id);
        }

        public Film HaalSneakPreviewOp()
        {
            return context.HaalSneakPreviewOp();
        }
    }
}