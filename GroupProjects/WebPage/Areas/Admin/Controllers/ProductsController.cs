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
     public class ProductsController : Controller
     {
          public ActionResult Index()
          {
               var db = new ProductsDbContext();
               List<GymProduct> products = db.GymProducts.ToList();
               return View(products);
          }
          public ActionResult Create()
          {
               return View();
          }
          [HttpPost]
          public ActionResult Create(GymProduct gp)
          {
               var db = new ProductsDbContext();
               db.GymProducts.Add(gp);
               db.SaveChanges();
               return RedirectToAction("Index");
          }

          public ActionResult Details(int id)
          {
               var db = new ProductsDbContext();
               var products = db.GymProducts.Find(id);
               return View(products);
          }
          public ActionResult Edit(int id)
          {
               using (var db = new ProductsDbContext())
               {
                    var products = db.GymProducts.Find(id);
                    if (products != null)
                    {
                         return View(products);
                    }
                    else
                    {
                         // Handle the case where the gym with the specified ID is not found
                         return RedirectToAction("Index");
                    }
               }
          }

          [HttpPost]
          public ActionResult Edit(GymProduct gp)
          {
               using (var db = new ProductsDbContext())
               {
                    var products = db.GymProducts.Find(gp.ProductID);
                    if (products != null)
                    {
                         products.Name = gp.Name;
                         products.Category = gp.Category;
                         products.Price = gp.Price;
                         products.AvailabilityStatus = gp.AvailabilityStatus;
                         products.Brand = gp.Brand;
                         db.SaveChanges();
                    }
               }

               return RedirectToAction("Index");
          }
          public ActionResult Delete(int? id)
          {
               using (var db = new ProductsDbContext())
               {
                    var products = db.GymProducts.Find(id);
                    return View(products);
               }
          }

          [HttpPost]
          public ActionResult Delete(int id)
          {
               using (var db = new ProductsDbContext())
               {
                    var products = db.GymProducts.Find(id);
                    db.GymProducts.Remove(products);
                    db.SaveChanges();
               }
               return RedirectToAction("Index");
          }
     }
}