using System.Web.Mvc;

namespace HomepageDev.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        // mfcallahan-dev.com/adot
        public ActionResult ADOT()
        {
            return View();
        }
    }
}