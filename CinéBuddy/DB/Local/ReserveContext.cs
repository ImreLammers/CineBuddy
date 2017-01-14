using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CinéBuddy.DB.Context;
using CinéBuddy.Models;
using CinéBuddy.Models.Classes;
using CinéBuddy.Models.Types;

namespace CinéBuddy.DB.Local
{
    public class ReserveContext : IReserve
    {
        public List<Stoel> HaalStoelenOp(string filmTijd, Zaal zaal)
        {
            throw new NotImplementedException();
        }

        public Stoel HaalStoelOp(Zaal zaal, string rijNummer, string stoelNummer)
        {
            throw new NotImplementedException();
        }

        public Zaal HaalZaalOp(Film film, string filmTijd)
        {
            throw new NotImplementedException();
        }

        public bool ReserveStoel(Gebruiker gebruiker, Stoel stoel, string filmTijd)
        {
            throw new NotImplementedException();
        }
    }
}