using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CinéBuddy.Models;
using System.Web.Mvc;

namespace CinéBuddy.Controllers
{
    public class HomeController : Controller
    {
        Films model = new Films();
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.AlleFilms = model.haalFilmsOp();
            return View(model);
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.Film = model.haalFilmOp(id);
            ViewBag.StartTijden = model.haalFilmTijdenOp(id);
            ViewBag.Reviews = model.haalReviewsOp(id);
            return View();
        }

        public ActionResult Actueel()
        {
            ViewBag.AlleFilms = model.haalFilmsOp();
            return View();
        }

        public ActionResult Verwacht()
        {
            ViewBag.AlleFilms = model.haalFilmsOp();
            return View(model);
        }

        public ActionResult Reserve(int id, string filmTijd)
        {
            ViewBag.Film = model.haalFilmOp(id);
            ViewBag.FilmTijd = filmTijd;
            ViewBag.Zaal = model.HaalZaalOp(ViewBag.Film, Convert.ToDateTime(filmTijd));
            ViewBag.Stoelen = model.HaalStoelenOp(Convert.ToDateTime(filmTijd), model.HaalZaalOp(ViewBag.Film, Convert.ToDateTime(filmTijd)));
            return View();
        }

        public ActionResult ReserveSeat(string stoel, string filmTijd, int film)
        {
            string rijNummer = stoel.Substring(0, 1);
            string stoelNummer = stoel.Substring(stoel.IndexOf("_") + 1);
            if (model.Reserveer(model.HaalZaalOp(model.haalFilmOp(film), Convert.ToDateTime(filmTijd)), rijNummer, stoelNummer, Convert.ToDateTime(filmTijd)))
            {
                Response.Write("<script>alert('Stoel is gereserveerd.');</script>");
            }
            else
            {
                Response.Write("<script>alert('Niet gelukt te reserveren.');</script>");
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session["user"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}
