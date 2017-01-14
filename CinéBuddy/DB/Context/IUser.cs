using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinéBuddy.Models.Types;

namespace CinéBuddy.DB.Context
{
    public interface IUser
    {
        List<Gebruiker> GetAllUsers();
        Gebruiker GetUserByUserName(string username);
        bool CheckCredentials(string username, string password);
        bool AbonneerAbonnement(string username);
        bool AnnuleerAbonnement(string username);
        bool UpdateGegevens(Gebruiker user, string gebruikersNaam, string emailAdres, string naam, string woonplaats);
    }
}
