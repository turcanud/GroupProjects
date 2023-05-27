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
     public class ProductsController : Controller
    {
          // GET: Products

          public ActionResult Index()
          {
               var db = new GymDbContext();
               List<GymProduct> products = db.GymProducts.ToList();
               return View(products);
          }

          public ActionResult Details(int id)
          {
               var db = new GymDbContext();
               var products = db.GymProducts.Find(id);
               return View(products);
          }
     }
}