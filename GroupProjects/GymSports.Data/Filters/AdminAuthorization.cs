using System.Web.Mvc;

namespace GymSports.Data.Filters
{
     public class AdminAuthorizationAttribute : AuthorizeAttribute
     {
          public override void OnAuthorization(AuthorizationContext filterContext)
          {
               if (!filterContext.HttpContext.User.IsInRole("Admin"))
               {
                    filterContext.Result = new HttpUnauthorizedResult();
               }
          }
     }
}
