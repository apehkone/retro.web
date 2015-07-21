using System.Web.Mvc;

namespace Retro.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index() {
            return View();
        }
    }
}