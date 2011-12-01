using System.Web.Mvc;

namespace SharpLiteTest.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index() {
            return View();
        }
    }
}
