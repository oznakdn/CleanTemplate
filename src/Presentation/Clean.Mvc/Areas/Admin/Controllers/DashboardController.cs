using Microsoft.AspNetCore.Mvc;

namespace Clean.Mvc.Areas.Admin.Controllers;

public class DashboardController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
