using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Clean.Mvc.Filters;

public class AuthorizationFilter :ActionFilterAttribute, IAuthorizationFilter
{
   
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        string cookie = context.HttpContext.Request.Cookies["token"]!;
        if(string.IsNullOrEmpty(cookie))
        {
            new RedirectToActionResult(actionName: "Login", controllerName: "Auth",new {});
        }
    }

}

