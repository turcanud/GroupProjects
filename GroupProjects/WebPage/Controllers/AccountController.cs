﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebPage.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login(string Username, string Password)
        {
            if(Username == "admin" && Password == "admin123")
               {
                    return RedirectToAction("Dashboard", "Admin");
               }
            return RedirectToAction("InvalidLogin");
        }
          public ActionResult InvalidLogin()
          {
               return View();
          }
     }
}