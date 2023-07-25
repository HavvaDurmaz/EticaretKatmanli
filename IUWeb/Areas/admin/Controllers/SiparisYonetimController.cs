using BussinesLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace IUWeb.Areas.admin.Controllers
{
    [Authorize(Roles = "admin")]
    [Area("admin")]
    public class SiparisYonetimController : Controller
    {
        private readonly IOrdersManager manager;

        public SiparisYonetimController(IOrdersManager _manager)
        {
            manager = _manager;
        }
        public IActionResult Index()
        {
            return View(manager.GetList());
        }

        [Route("/admin/SiparisYonetim/Detay/{id}")]
        public IActionResult Detay(int id)
        {
            return View(manager.GetByID(id));
        }
    }
}
