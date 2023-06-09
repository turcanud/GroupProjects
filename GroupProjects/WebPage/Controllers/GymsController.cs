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
          public ActionResult Details(int id)
          {
               GymPlace place = _dbContext.GymPlaces.Find(id);
               return View(place);
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
     }
}