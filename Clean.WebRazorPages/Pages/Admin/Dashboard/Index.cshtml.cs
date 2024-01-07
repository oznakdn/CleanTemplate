using Clean.WebRazorPages.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Clean.WebRazorPages.Pages.Admin.Dashboard;


[AuthorizationFilter]
public class IndexModel : PageModel
{
    public void OnGet()
    {
    }
}
