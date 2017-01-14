using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinéBuddy.Models.Classes
{
    public class Stoel
    {
        public int rijNummer { get; set; }
        public int stoelNummer { get; set; }
        public int stoelSoort { get; set; }
        public Zaal zaal { get; set; }

        public Stoel()
        {

        }

        public Stoel(Zaal zaal, int stoelNummer, int rijNummer, int stoelSoort)
        {
            this.zaal = zaal;
            this.rijNummer = rijNummer;
            this.stoelNummer = stoelNummer;
            this.stoelSoort = stoelSoort;
        }
    }
}