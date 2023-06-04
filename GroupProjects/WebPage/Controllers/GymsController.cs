using GymSports.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GymSports.Data.Filters;

namespace WebPage.Controllers
{
     [RedirectUnauthenticatedFilter]
     public class GymsController : Controller
    {
          // GET: Gyms
          public ActionResult Index()
          {
               GymsDbContext db = new GymsDbContext();
               List<GymPlace> places = db.GymPlaces.ToList();

               return View(places);
          }
          public ActionResult Details(int id)
          {
               GymsDbContext db = new GymsDbContext();
               GymPlace place = db.GymPlaces.Find(id);
               return View(place);
          }
     }
}