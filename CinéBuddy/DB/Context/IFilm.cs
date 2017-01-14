using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinéBuddy.Models;

namespace CinéBuddy.DB.Context
{
    public interface IFilm
    {
        List<Film> GetAllFilms();
        List<Review> GetReviews(int id);
        List<DateTime> HaalFilmTijdenOp(int id);
        Film HaalFilmOp(int id);
        Film HaalSneakPreviewOp();
    }
}
