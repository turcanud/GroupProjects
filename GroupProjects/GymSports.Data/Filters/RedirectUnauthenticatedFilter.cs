using System.Web.Mvc;

public class RedirectUnauthenticatedFilter : AuthorizeAttribute
{
     protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
     {
          if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
          {
               filterContext.Result = new RedirectResult("~/Start/Starting");
          }
          else
          {
               base.HandleUnauthorizedRequest(filterContext);
          }
     }
}