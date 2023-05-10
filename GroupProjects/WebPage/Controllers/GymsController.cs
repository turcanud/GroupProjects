using GymSports.Data.Models;
using GymSports.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebPage.Controllers
{
    public class GymsController : Controller
    {
          private readonly IGymsData db;
          public GymsController(IGymsData db) {
               this.db = db;
          }

          public ActionResult Index()
          {
               var model = db.GetAll();
               return View(model);
          }

          public ActionResult Details(int id)
          {
               var model = db.Get(id);
               if (model == null)
               {
                    return View("NotFound");
               }
               return View(model);
          }

          public ActionResult Create()
          {
               return View();
          }

          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Create(Gyms gyms)
          {
               if(ModelState.IsValid)
               {
                    db.Add(gyms);
                    return RedirectToAction("Details", new { id = gyms.Id });
               }
               return View();
          }

          [HttpGet]
          public ActionResult Edit(int id)
          {
               var model = db.Get(id);
               if(model == null)
               {
                    return HttpNotFound();
               }
               return View(model);
          }
          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Edit(Gyms gyms)
          {
               if (ModelState.IsValid)
               {
                    db.Update(gyms);
                    return RedirectToAction("Details", new { id = gyms.Id });
               }
               return View(gyms);
          }

          [HttpGet]
          public ActionResult Delete(int id)
          {
               var model = db.Get(id);
               if(model == null) {
                    return View("NotFound");
               }
               return View(model);
          }
          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Delete(int id, FormCollection form)
          {
               db.Delete(id);
               return RedirectToAction("Index");
          }
    }
}