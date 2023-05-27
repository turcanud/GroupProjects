using GymSports.Data.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebPage.Areas.Admin.Controllers
{
     [AdminAuthorization]
     public class HomeController : Controller
     {
          public ActionResult Index()
          {
               return View();
          }
          public ActionResult Logout()
          {
               var authenticationManager = HttpContext.GetOwinContext().Authentication;
               authenticationManager.SignOut();
               return RedirectToAction("Index", "Home");
          }
     }
}