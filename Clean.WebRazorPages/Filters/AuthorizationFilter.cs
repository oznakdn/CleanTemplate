using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Clean.WebRazorPages.Filters;

public class AuthorizationFilter : ActionFilterAttribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    
    {
        string token = context.HttpContext.Request.Cookies["token"]!;

        if(string.IsNullOrEmpty(token))
        {
            context.Result = new RedirectToPageResult("/Admin/Auth/Login");
        }
    }
}
