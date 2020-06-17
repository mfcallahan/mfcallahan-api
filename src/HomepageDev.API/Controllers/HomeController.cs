using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace HomepageDev.API.Controllers
{
    [ExcludeFromCodeCoverage]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Home/Index.cshtml");
        }
    }
}
