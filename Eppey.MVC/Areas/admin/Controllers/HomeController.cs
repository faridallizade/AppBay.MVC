using Microsoft.AspNetCore.Mvc;

namespace Eppey.MVC.Areas.admin.Controllers
{
    public class HomeController : Controller
    {
        [Area("admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
