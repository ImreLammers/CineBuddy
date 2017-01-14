using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CinéBuddy.Models;
using System.Web.Mvc;

namespace CinéBuddy.Controllers
{
    public class SneakPreviewController : Controller
    {
        Films model = new Films();
        // GET: SneakPreview
        public ActionResult Index()
        {
            ViewBag.Film = model.haalSneakPreviewOp();
            ViewBag.User = model.returnHuidigeGebruiker(); 
            return View();
        }
    }
}