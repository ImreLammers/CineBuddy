using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CinéBuddy.DB.Context;
using CinéBuddy.Models.Types;

namespace CinéBuddy.DB.Repository
{
    public class UserRepository
    {
        private IUser context;

        public UserRepository(IUser context)
        {
            this.context = context;
        }

        public Gebruiker GetUserByUserName(string gebruikersNaam)
        {
            return context.GetUserByUserName(gebruikersNaam);
        }

        public List<Gebruiker> GetAllUsers()
        {
            return context.GetAllUsers();
        }

        public bool CheckCredentials(string username, string password)
        {
            return context.CheckCredentials(username, password);
        }

        public bool AbonneerAbonnement(string username)
        {
            return context.AbonneerAbonnement(username);
        }

        public bool AnnuleerAbonnement(string username)
        {
            return context.AnnuleerAbonnement(username);
        }

        public bool UpdateGegevens(Gebruiker user, string gebruikersNaam, string emailAdres, string naam, string woonplaats)
        {
            return context.UpdateGegevens(user, gebruikersNaam, emailAdres, naam, woonplaats);
        }
    }
}