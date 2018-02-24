using System.Web.Mvc;

namespace HomepageDev
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}