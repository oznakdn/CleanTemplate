using Clean.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Clean.Mvc.Areas.Admin.Controllers;


[Area("Admin")]
[AuthorizationFilter]
public class DashboardController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
