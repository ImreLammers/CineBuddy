using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CinéBuddy.Models.Types;
using CinéBuddy.Models;

namespace CinéBuddy.Controllers
{
    public class LogInController : Controller
    {
        Films model = new Films();
        

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(string username, string password)
        {
            if (model.CheckCredentials(username, password))
            {
                Session["User"] = model.GetUserByUserName(username);
                Session["Username"] = username;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                Response.Write("<script>alert('Inloggegevens zijn onjuist.');</script>");
                return View("Index");
            }
        }
    }
}