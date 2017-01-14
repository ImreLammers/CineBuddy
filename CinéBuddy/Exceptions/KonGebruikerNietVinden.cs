using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinéBuddy.Exceptions
{
    public class KonGebruikerNietVinden : Exception
    {
        public KonGebruikerNietVinden(string message):base(message)
        {

        }
    }
}