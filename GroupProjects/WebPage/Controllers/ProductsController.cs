using GymSports.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebPage.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
               List<Product> products = new List<Product>()
               {
                    new Product(){ProductId = 1, ProductName = "Gum1", Rate = 4.9},
                    new Product(){ProductId = 2, ProductName = "Gum2", Rate = 4.2},
                    new Product(){ProductId = 3, ProductName = "Gum3", Rate = 4.5},
               };
            return View(products);
        }
          public ActionResult Details(int id)
          {
               List<Product> products = new List<Product>()
               {
                    new Product(){ProductId = 1, ProductName = "Gum1", Rate = 4.9},
                    new Product(){ProductId = 2, ProductName = "Gum2", Rate = 4.2},
                    new Product(){ProductId = 3, ProductName = "Gum3", Rate = 4.5},
               };
               ViewBag.Products = products;
               Product matchingProduct = null;
               foreach (var item in products)
               {
                    if (item.ProductId == id)
                    {
                         matchingProduct = item;
                    }
               }
               return View(matchingProduct);
          }

          public ActionResult Create()
          {
               return View();
          }

          [HttpPost]
          public ActionResult Create(int ProductId, string ProductName)
          {
               return View();
          }
     }
}