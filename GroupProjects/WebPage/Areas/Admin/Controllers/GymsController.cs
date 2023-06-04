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
          public ActionResult Index()
          {
               GymsDbContext db = new GymsDbContext();
               List<GymPlace> places = db.GymPlaces.ToList();

               return View(places);
          }
          public ActionResult Create()
          {
               return View();
          }

          [HttpPost]
          public ActionResult Create(GymPlace gp)
          {
               GymsDbContext db = new GymsDbContext();
               db.GymPlaces.Add(gp);
               db.SaveChanges();
               return RedirectToAction("Index");
          }
          public ActionResult Details(int id)
          {
               GymsDbContext db = new GymsDbContext();
               GymPlace place = db.GymPlaces.Find(id);
               return View(place);
          }
          public ActionResult Edit(int id)
          {
               using (var db = new GymsDbContext())
               {
                    var place = db.GymPlaces.Find(id);
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
          }
          [HttpPost]
          public ActionResult Edit(GymPlace gp)
          {
               using (var db = new GymsDbContext())
               {
                    var place = db.GymPlaces.Find(gp.GymID);
                    if (place != null)
                    {
                         place.Name = gp.Name;
                         place.Address = gp.Address;
                         place.Region = gp.Region;
                         db.SaveChanges();
                    }
               }

               return RedirectToAction("Index");
          }
          public ActionResult Delete(int? id)
          {
               using (var db = new GymsDbContext())
               {
                    var place = db.GymPlaces.Find(id);
                    return View(place);
               }
          }
          [HttpPost]
          public ActionResult Delete(int id)
          {
               using (var db = new GymsDbContext())
               {
                    var place = db.GymPlaces.Find(id);
                    db.GymPlaces.Remove(place);
                    db.SaveChanges();
               }
               return RedirectToAction("Index");
          }
     }
}