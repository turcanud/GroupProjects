using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSports.Data.Identity
{
     public class ApplicationUserStore : UserStore<ApplicationUser>
     {
          public ApplicationUserStore(ApplicationDbContext dbContext) : base(dbContext)
          {
          }
     }
}
