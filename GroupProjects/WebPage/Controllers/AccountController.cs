using GymSports.Data.Identity;
using GymSports.Data.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using GymSports.Data.Filters;


namespace WebPage.Controllers
{
     public class AccountController : Controller
     {
          // GET: Account/Register
          public ActionResult Register()
          {
               return View();
          }

          // POST: Account/Register
          [HttpPost]
          public ActionResult Register(RegisterViewModel rvm)
          {
               if (ModelState.IsValid)
               {
                    //register
                    var appDbContext = new ApplicationDbContext();
                    var userStore = new ApplicationUserStore(appDbContext);
                    var userManager = new ApplicationUserManager(userStore);
                    var passwordHash = Crypto.HashPassword(rvm.Password);
                    var user = new ApplicationUser() { Email = rvm.Email, UserName = rvm.Username, PasswordHash = passwordHash };
                    IdentityResult result = userManager.Create(user);

                    if (result.Succeeded)
                    {
                         //role
                         userManager.AddToRole(user.Id, "Customer");

                         //login
                         var authenticationManager = HttpContext.GetOwinContext().Authentication;
                         var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                         authenticationManager.SignIn(new AuthenticationProperties(), userIdentity);
                    }
                    return RedirectToAction("Index", "Home");
               }
               else
               {
                    ModelState.AddModelError("My Error", "Invalid data");
                    return View();
               }
          }

          // GET: Account/Login
          public ActionResult Login()
          {
               return View();
          }

          // POST: Account/Login
          [HttpPost]
          public ActionResult Login(LoginViewModel lvm)
          {
               //login
               var appDbContext = new ApplicationDbContext();
               var userStore = new ApplicationUserStore(appDbContext);
               var userManager = new ApplicationUserManager(userStore);
               var user = userManager.Find(lvm.Username, lvm.Password);
               if (user != null)
               {
                    //login
                    var authenticationManager = HttpContext.GetOwinContext().Authentication;
                    var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    authenticationManager.SignIn(new AuthenticationProperties(), userIdentity);

                    if (userManager.IsInRole(user.Id, "Admin"))
                    {
                         return RedirectToAction("Index", "Home", new {area = "Admin"});
                    }
                    return RedirectToAction("Index", "Home");
               }
               else
               {
                    ModelState.AddModelError("myerror", "Invalid username or password");
                    return View();
               }
          }

          public ActionResult Logout()
          {
               var authenticationManager = HttpContext.GetOwinContext().Authentication;
               authenticationManager.SignOut();
               return RedirectToAction("Index", "Home");
          }

          public ActionResult MyProfile()
          {
               var appDbContext = new ApplicationDbContext();
               var userStore = new ApplicationUserStore(appDbContext);
               var userManager = new ApplicationUserManager(userStore);
               ApplicationUser appUser = userManager.FindById(User.Identity.GetUserId());
               return View(appUser);
          }
     }
}