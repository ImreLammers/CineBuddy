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
using CinéBuddy.Models;

namespace UnitTestProject
{
    [TestClass]
    public class TestFilm
    {
        private FilmRepository fr = new FilmRepository(new FilmContext());

        [TestMethod]
        public void FilmTest()
        {
            List<Film> allFilms = new List<Film>();
            allFilms = fr.GetAllFilms();
            Assert.IsTrue(allFilms.Count == 3);

            Assert.IsNotNull(fr.HaalFilmOp(1));
            Assert.IsNull(fr.HaalFilmOp(5));

            Film testFilm = fr.HaalFilmOp(0);
            Assert.AreEqual(testFilm.titel, "Memento");

            Assert.AreNotEqual(fr.HaalFilmOp(1), fr.HaalFilmOp(2));
        }
    }
}
