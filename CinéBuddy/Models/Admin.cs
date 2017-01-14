using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinéBuddy.Models.Types
{
    public class Admin
    {
        public string gebruikersNaam { get; set; }

        public Admin()
        {

        }

        public Admin(string gebruikersNaam)
        {
            this.gebruikersNaam = gebruikersNaam;
        }
    }
}