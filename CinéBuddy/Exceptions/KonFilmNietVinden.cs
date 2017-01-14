using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinéBuddy.Exceptions
{
    public class KonFilmNietVinden : Exception
    {
        public KonFilmNietVinden(string message):base(message)
        {

        }
    }
}