using GymSports.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GymSports.Data.Filters;

namespace WebPage.Controllers
{
     [IfAuthenticationFilter]
     [CustomerAuthorization]
    public class GymsController : Controller
    {
          // GET: Gyms
          public ActionResult Index()
          {
               GymDbContext db = new GymDbContext();
               List<GymPlace> places = db.GymPlaces.ToList();

               return View(places);
          }
          public ActionResult Details(int id)
          {
               GymDbContext db = new GymDbContext();
               GymPlace place = db.GymPlaces.Find(id);
               return View(place);
          }
     }
}