using System.Web.Mvc;

namespace HomepageDev.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Route("ADOT")]
        public ActionResult ADOT()
        {
            return View();
        }

        [Route("camping")]
        public ActionResult Camping()
        {
            return View();
        }

        [Route("MyGMRS")]
        public ActionResult MyGMRS()
        {
            return View();
        }
    }
}