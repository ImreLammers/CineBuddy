using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CinéBuddy.Models.Types;

namespace CinéBuddy.Models.Classes
{
    public class Abonnement
    {
        public Gebruiker gebruiker { get; set; }
        public DateTime datumVan { get; set; }
        public DateTime datumTot { get; set; }

        public Abonnement()
        {

        }

        public Abonnement(Gebruiker gebruiker, DateTime datumVan, DateTime datumTot)
        {
            this.gebruiker = gebruiker;
            this.datumVan = datumVan;
            this.datumTot = datumTot;
        }
    }
}