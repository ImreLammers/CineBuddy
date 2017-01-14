using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CinéBuddy.Models.Classes;

namespace CinéBuddy.Models.Types
{
    public class Gebruiker
    {
        public string gebruikersNaam { get; set; }
        public string emailAdres { get; set; }
        public string naam { get; set; }
        public DateTime geboorteDatum { get; set; }
        public string woonplaats { get; set; }
        public int gold { get; set; }

        public Gebruiker()
        {

        }

        public Gebruiker(string gebruikersNaam, string emailAdres, string naam, DateTime geboorteDatum, string woonplaats, int gold)
        {
            this.gebruikersNaam = gebruikersNaam;
            this.emailAdres = emailAdres;
            this.naam = naam;
            this.geboorteDatum = geboorteDatum;
            this.woonplaats = woonplaats;
            this.gold = gold;
        }
    }
}