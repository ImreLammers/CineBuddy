using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CinéBuddy.DB.Context;
using CinéBuddy.Models;
using CinéBuddy.Models.Types;
using CinéBuddy.Models.Classes;

namespace CinéBuddy.DB.Repository
{
    public class ReserveRepository
    {
        private IReserve context;

        public ReserveRepository(IReserve context)
        {
            this.context = context;
        }

        public Zaal HaalZaalOp(Film film, string filmTijd)
        {
            return context.HaalZaalOp(film, filmTijd);
        }

        public List<Stoel> HaalStoelenOp(Zaal zaal, string filmTijd)
        {
            return context.HaalStoelenOp(filmTijd, zaal);
        }

        public bool ReserveerStoel(Gebruiker gebruiker, Zaal zaal, string rijNummer, string stoelNummer, string filmTijd)
        {
            return context.ReserveStoel(gebruiker, context.HaalStoelOp(zaal, rijNummer, stoelNummer), filmTijd);
        }
    }
}