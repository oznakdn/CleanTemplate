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
            context.Result = new RedirectToActionResult("Login", "Auth", context.Result);
        }
    }

}

