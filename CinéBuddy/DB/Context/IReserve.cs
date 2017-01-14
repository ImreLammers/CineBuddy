using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinéBuddy.Models;
using CinéBuddy.Models.Classes;
using CinéBuddy.Models.Types;

namespace CinéBuddy.DB.Context
{
    public interface IReserve
    {
        Zaal HaalZaalOp(Film film, string filmTijd);
        List<Stoel> HaalStoelenOp(string filmTijd, Zaal zaal);
        Stoel HaalStoelOp(Zaal zaal, string rijNummer, string stoelNummer);
        bool ReserveStoel(Gebruiker gebruiker, Stoel stoel, string filmTijd);
    }
}
