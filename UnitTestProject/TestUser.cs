using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CinéBuddy.DB.Local;
using CinéBuddy.DB.Repository;
using CinéBuddy.Models.Types;
using CinéBuddy.Models.Classes;

namespace UnitTestProject
{
    [TestClass]
    public class TestUser
    {
        UserRepository ur = new UserRepository(new UserContext());

        [TestMethod]
        public void UserTest()
        {
            List<Gebruiker> allUsers = new List<Gebruiker>();
            allUsers = ur.GetAllUsers();
            Assert.IsTrue(allUsers.Count == 3);

            Assert.IsNotNull(ur.GetUserByUserName("Job"));
            Assert.IsNull(ur.GetUserByUserName("Banaan"));

            Gebruiker testGebruiker = ur.GetUserByUserName("Imre");
            Assert.IsTrue(ur.AnnuleerAbonnement(testGebruiker.gebruikersNaam));
            Assert.AreEqual(testGebruiker.gold, 0);
            Assert.IsTrue(ur.AbonneerAbonnement(testGebruiker.gebruikersNaam));
            Assert.AreEqual(testGebruiker.gold, 1);
        }
    }
}
