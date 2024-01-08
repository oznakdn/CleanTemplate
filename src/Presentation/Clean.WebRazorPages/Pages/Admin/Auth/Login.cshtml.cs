using Clean.WebRazorPages.Pages.Admin.Auth.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Clean.WebRazorPages.Pages.Admin.Auth;

public class LoginModel : PageModel
{
    private readonly AuthService _authService;
    public LoginModel(AuthService authService)
    {
        _authService = authService;
    }

    [BindProperty]
    public LoginRequest LoginRequest { get; set; }
    public void OnGet()
    {

    }

    public async Task<IActionResult> OnPostLogin()
    {
        var result = await _authService.Login(LoginRequest);
        if (result.IsSuccess)
        {
            HttpContext.Response.Cookies.Append("token", result.Value.AccessToken, new CookieOptions
            {
                Expires = Convert.ToDateTime(result.Value.AccessExpire)
            });
            return RedirectToPage("/Admin/Dashboard/Index");
        }

        return Page();
    }


}
