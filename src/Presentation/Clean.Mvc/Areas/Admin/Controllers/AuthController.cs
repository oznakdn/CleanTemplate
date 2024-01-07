using Clean.Mvc.Areas.Admin.Models.AuthViewModels;
using Clean.Mvc.ClientServices;
using Microsoft.AspNetCore.Mvc;

namespace Clean.Mvc.Areas.Admin.Controllers;

[Area("Admin")]
public class AuthController : Controller
{
    public IActionResult Login()
    {
        return View();
    }


    [HttpPost]

    public async Task<IActionResult> Login([FromForm] LoginRequest login, [FromServices] AuthService authService)
    {
        var response = await authService.LoginAsync(login);
        if (login.RememberMe)
        {
            //HttpContext.Session.SetString("token", response.Value.AccessToken);
            HttpContext.Response.Cookies.Append("token", response.Value.AccessToken, new CookieOptions
            {
                HttpOnly = false,
                Expires = Convert.ToDateTime(response.Value.AccessExpire)
            });
        }
        return RedirectToAction("Index", "Dashboard");
    }

    public IActionResult Logout()
    {
        HttpContext.Response.Cookies.Delete("token");
        // get icin
        //var cookie = HttpContext.Request.Cookies["token"];
        return RedirectToAction(nameof(Login));
    }


}
