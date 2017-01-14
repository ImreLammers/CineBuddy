using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinéBuddy.Models.Classes
{
    public class Zaal
    {
        public enum Soort
        {
            twee = 1,
            drie = 2
        }

        public int ID { get; set; }
        public Soort Functionaliteit { get; set; }
        public int AantalStoelen { get; set; }
        public int AantalVIPStoelen { get; set; }

        public Zaal()
        {

        }

        public Zaal(int ID, Soort functionaliteit, int aantalStoelen, int aantalVIPStoelen)
        {
            this.ID = ID;
            this.Functionaliteit = functionaliteit;
            this.AantalStoelen = aantalStoelen;
            this.AantalVIPStoelen = AantalVIPStoelen;
        }
    }
}