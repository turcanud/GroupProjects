using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace GymSports.Data.Filters
{
     public class CustomerAuthorization : FilterAttribute, IAuthorizationFilter
     {
          public void OnAuthorization(AuthorizationContext filterContext)
          {
               if (filterContext.HttpContext.User.IsInRole("Customer") == false)
               {
                    filterContext.Result = new HttpUnauthorizedResult();
               }
          }
     }
}
