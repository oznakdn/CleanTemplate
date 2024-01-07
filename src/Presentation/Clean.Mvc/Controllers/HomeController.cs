using Clean.Mvc.ClientServices;
using Microsoft.AspNetCore.Mvc;

namespace Clean.Mvc.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            
            return View();
        }

    }
}