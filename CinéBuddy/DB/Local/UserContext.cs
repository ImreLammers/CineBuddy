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
        private List<Gebruiker> AllUsers = new List<Gebruiker>
        {
            new Gebruiker("Imre", "imrelammers@gmail.com", "Imre", DateTime.Now, "Nuenen", 1),
            new Gebruiker("Job", "jobputters@gmail.com", "Job", DateTime.Now, "Veldhoven", 1),
            new Gebruiker("Bart", "bartdeman@gmail.com", "Bart", DateTime.Now, "Weert", 0)
        };

        public bool AbonneerAbonnement(string username)
        {
            foreach (Gebruiker gebruiker in AllUsers)
            {
                if (gebruiker.gebruikersNaam == username)
                {
                    gebruiker.gold = 1;
                    return true;
                }
            }
            return false;
        }

        public bool AnnuleerAbonnement(string username)
        {
            foreach (Gebruiker gebruiker in AllUsers)
            {
                if (gebruiker.gebruikersNaam == username)
                {
                    gebruiker.gold = 0;
                    return true;
                }
            }
            return false;
        }

        public bool CheckCredentials(string username, string password)
        {
            throw new NotImplementedException();
        }

        public List<Gebruiker> GetAllUsers()
        {
            return AllUsers;
        }

        public Gebruiker GetUserByUserName(string username)
        {
            foreach (Gebruiker gebruiker in AllUsers)
            {
                if (gebruiker.gebruikersNaam == username)
                {
                    return gebruiker;
                }
            }
            return null;
        }

        public bool UpdateGegevens(Gebruiker user, string gebruikersNaam, string emailAdres, string naam, string woonplaats)
        {
            throw new NotImplementedException();
        }
    }
}