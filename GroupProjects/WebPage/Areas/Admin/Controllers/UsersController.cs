using GymSports.Data.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebPage.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
          private readonly ApplicationDbContext _context;

          public UsersController()
          {
               _context = new ApplicationDbContext();
          }

          public ActionResult Index()
          {
               var users = _context.Users
                   .Where(u => u.UserName != "manager" && u.UserName != "admin")
                   .ToList();

               return View(users);
          }

          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Delete(string id)
          {
               var user = _context.Users.Find(id);
               if (user != null)
               {
                    _context.Users.Remove(user);
                    _context.SaveChanges();
               }

               return RedirectToAction("Index");
          }
     }
}