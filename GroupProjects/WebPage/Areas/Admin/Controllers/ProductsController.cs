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

               if (Request.Files.Count >= 1)
               {
                    var file = Request.Files[0];
                    var imgBytes = new byte[file.ContentLength];
                    file.InputStream.Read(imgBytes, 0, file.ContentLength);
                    var base64String = Convert.ToBase64String(imgBytes, 0, imgBytes.Length);
                    gp.Photo = base64String;
               }

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
          public ActionResult Edit(GymProduct gp, HttpPostedFileBase photo)
          {
               using (var db = new ProductsDbContext())
               {
                    var product = db.GymProducts.Find(gp.ProductID);
                    if (product != null)
                    {
                         product.Name = gp.Name;
                         product.Category = gp.Category;
                         product.Price = gp.Price;
                         product.AvailabilityStatus = gp.AvailabilityStatus;
                         product.Brand = gp.Brand;

                         if (photo != null && photo.ContentLength > 0)
                         {
                              var imgBytes = new byte[photo.ContentLength];
                              photo.InputStream.Read(imgBytes, 0, photo.ContentLength);
                              var base64String = Convert.ToBase64String(imgBytes, 0, imgBytes.Length);
                              product.Photo = base64String;
                         }

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