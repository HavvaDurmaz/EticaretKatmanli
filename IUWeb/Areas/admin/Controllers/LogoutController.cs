using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace IUWeb.Areas.admin.Controllers
{
    public class LogoutController : Controller
    {
        public IActionResult Index()
        {
            HttpContext.SignOutAsync();
            return Redirect("/admin/login");
        }
    }
}
