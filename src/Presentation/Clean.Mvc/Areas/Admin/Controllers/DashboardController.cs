﻿using Microsoft.AspNetCore.Mvc;

namespace Clean.Mvc.Areas.Admin.Controllers;

[Area("Admin")]
public class DashboardController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
