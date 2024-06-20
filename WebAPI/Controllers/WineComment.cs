using Microsoft.AspNetCore.Mvc;

namespace ESOF.WebApp.WebAPI.Controllers;

public class WineComment : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}