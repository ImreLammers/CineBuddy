using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CinéBuddy.Models;

namespace CinéBuddy.Controllers
{
    public class GoldController : Controller
    {
        Films model = new Films();
        // GET: Gold
        public ActionResult Index()
        {
            ViewBag.User = model.returnHuidigeGebruiker();
            return View();
        }

        public ActionResult Annuleer()
        {
            if (model.AnnuleerAbonnement(model.returnHuidigeGebruiker().gebruikersNaam))
            {
                model.returnHuidigeGebruiker().gold = 0;
            }
            return RedirectToAction("Index", "Gold");
        }

        public ActionResult Abonneer()
        {
            if (model.AbonneerAbonnement(model.returnHuidigeGebruiker().gebruikersNaam))
            {
                model.returnHuidigeGebruiker().gold = 1;
            }
            return RedirectToAction("Index", "Gold");
        }
    }
}