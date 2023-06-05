using GymSports.Data.Filters;
using GymSports.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebPage.Areas.Admin.Controllers
{
     [AdminAuthorization]
     public class GymsController : Controller
     {
          private readonly GymsDbContext _dbContext;

          public GymsController()
          {
               _dbContext = new GymsDbContext();
          }

          public ActionResult Index()
          {
               List<GymPlace> places = _dbContext.GymPlaces.ToList();
               return View(places);
          }

          public ActionResult Create()
          {
               return View();
          }

          [HttpPost]
          public ActionResult Create(GymPlace gp)
          {
               _dbContext.GymPlaces.Add(gp);
               _dbContext.SaveChanges();
               return RedirectToAction("Index");
          }

          public ActionResult Details(int id)
          {
               GymPlace place = _dbContext.GymPlaces.Find(id);
               return View(place);
          }

          public ActionResult Edit(int id)
          {
               var place = _dbContext.GymPlaces.Find(id);
               if (place != null)
               {
                    return View(place);
               }
               else
               {
                    // Handle the case where the gym with the specified ID is not found
                    return RedirectToAction("Index");
               }
          }

          [HttpPost]
          public ActionResult Edit(GymPlace gp)
          {
               var place = _dbContext.GymPlaces.Find(gp.GymID);
               if (place != null)
               {
                    place.NameSurname = gp.NameSurname;
                    place.Region = gp.Region;
                    place.Time = gp.Time;
                    place.Date = gp.Date;
                    _dbContext.SaveChanges();
               }

               return RedirectToAction("Index");
          }

          public ActionResult Delete(int? id)
          {
               var place = _dbContext.GymPlaces.Find(id);
               return View(place);
          }

          [HttpPost]
          public ActionResult Delete(int id)
          {
               var place = _dbContext.GymPlaces.Find(id);
               _dbContext.GymPlaces.Remove(place);
               _dbContext.SaveChanges();

               return RedirectToAction("Index");
          }

          protected override void Dispose(bool disposing)
          {
               if (disposing)
               {
                    _dbContext.Dispose();
               }
               base.Dispose(disposing);
          }
     }
}
