﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GymSports.Data.Identity
{
     public class ApplicationUserManager : UserManager<ApplicationUser>
     {
          public ApplicationUserManager(IUserStore<ApplicationUser> store) : base(store)
          {
          }
     }
}
