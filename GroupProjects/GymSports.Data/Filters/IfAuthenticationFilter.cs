using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace GymSports.Data.Filters
{
     public class IfAuthenticationFilter : FilterAttribute, IAuthenticationFilter
     {
          public void OnAuthentication(AuthenticationContext filterContext)
          {
               if (filterContext.HttpContext.User.Identity.IsAuthenticated == false)
               {
                    filterContext.Result = new HttpUnauthorizedResult();
               }
          }

          public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
          {
          }
     }
}
