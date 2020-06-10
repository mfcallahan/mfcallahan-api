using Microsoft.AspNetCore.Mvc;

namespace MfcallahanDev.API.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Home/Index.cshtml");
        }
    }
}
