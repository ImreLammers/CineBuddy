using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CinéBuddy.DB.Context;
using CinéBuddy.Models;
using CinéBuddy.Models.Types;

namespace CinéBuddy.DB.Local
{
    public class UserContext : IUser
    {
        public bool AbonneerAbonnement(string username)
        {
            throw new NotImplementedException();
        }

        public bool AnnuleerAbonnement(string username)
        {
            throw new NotImplementedException();
        }

        public bool CheckCredentials(string username, string password)
        {
            throw new NotImplementedException();
        }

        public List<Gebruiker> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Gebruiker GetUserByUserName(string username)
        {
            throw new NotImplementedException();
        }

        public bool UpdateGegevens(Gebruiker user, string gebruikersNaam, string emailAdres, string naam, string woonplaats)
        {
            throw new NotImplementedException();
        }
    }
}