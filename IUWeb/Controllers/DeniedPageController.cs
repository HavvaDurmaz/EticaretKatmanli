using Microsoft.AspNetCore.Mvc;

namespace IUWeb.Controllers
{
    public class DeniedPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
