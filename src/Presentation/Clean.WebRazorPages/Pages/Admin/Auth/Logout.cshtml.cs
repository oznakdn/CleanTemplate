using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Clean.WebRazorPages.Pages.Admin.Auth;

public class LogoutModel : PageModel
{
    public IActionResult OnGet()
    {
        HttpContext.Response.Cookies.Delete("token");
        return RedirectToPage("/Admin/Auth/Login");
    }
}
