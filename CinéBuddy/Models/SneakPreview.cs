using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinéBuddy.Models.Classes
{
    public class SneakPreview
    {
        public Film film { get; set; }
        public DateTime datum { get; set; }

        public SneakPreview()
        {

        }

        public SneakPreview(Film film, DateTime datum)
        {
            this.film = film;
            this.datum = datum;
        }
    }
}