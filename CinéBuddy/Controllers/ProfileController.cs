using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CinéBuddy.Models;

namespace CinéBuddy.Controllers
{
    public class ProfileController : Controller
    {
        Films model = new Films();
        // GET: Profile
        public ActionResult Index()
        {
            ViewBag.User = model.returnHuidigeGebruiker();
            return View();
        }

        public ActionResult Update(string gebruikersNaam, string emailAdres, string naam, string woonplaats)
        {
            model.UpdateGegevens(gebruikersNaam, emailAdres, naam, woonplaats);
            return RedirectToAction("Index", "Profile");
        }
    }
}
