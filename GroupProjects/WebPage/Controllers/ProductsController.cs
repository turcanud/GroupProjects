using GymSports.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GymSports.Data.Filters;
using GymSports.Data.Identity;
using System.Data.Entity;

namespace WebPage.Controllers
{
     [RedirectUnauthenticatedFilter]
     public class ProductsController : Controller
     {
          private ProductsDbContext db = new ProductsDbContext();

          public ActionResult Index(string searchTerm = "")
          {
               List<GymProduct> products = db.GymProducts.Where(temp => temp.Name.Contains(searchTerm)).ToList();
               ViewBag.SearchTerm = searchTerm;
               return View(products);
          }

          public ActionResult Details(int id)
          {
               var product = db.GymProducts.Find(id);
               return View(product);
          }

          public ActionResult AddToCart()
          {
               return View();
          }

          private Cart GetCartFromSession()
          {
               var cart = Session["Cart"] as Cart;

               if (cart == null)
               {
                    cart = db.Carts
                        .Include(c => c.CartItems)
                        .FirstOrDefault(c => c.UserID == User.Identity.Name);

                    if (cart == null)
                    {
                         cart = new Cart
                         {
                              CartID = Guid.NewGuid().ToString(),
                              UserID = User.Identity.Name,
                              CartItems = new List<CartItem>()
                         };

                         db.Carts.Add(cart);
                         db.SaveChanges();
                    }

                    SetCartToSession(cart);
               }

               return cart;
          }

          private void SetCartToSession(Cart cart)
          {
               Session["Cart"] = cart;
          }

          [HttpPost]
          public ActionResult AddToCart(int productId, int quantity)
          {
               var product = db.GymProducts.Find(productId);

               if (product != null)
               {
                    var cart = GetCartFromSession();

                    var existingCartItem = cart.CartItems.FirstOrDefault(item => item.ProductID == productId);

                    if (existingCartItem != null)
                    {
                         existingCartItem.Quantity += quantity;
                    }
                    else
                    {
                         var cartItem = new CartItem
                         {
                              ProductID = productId,
                              Quantity = quantity
                         };
                         cart.CartItems.Add(cartItem);
                    }

                    // Save the cart items to the database
                    db.SaveChanges();

                    SetCartToSession(cart);
               }

               return RedirectToAction("Cart");
          }

          public ActionResult Cart()
          {
               var cart = GetCartFromSession();

               return View(cart);
          }

          public ActionResult Checkout()
          {
               return View();
          }
     }
}
