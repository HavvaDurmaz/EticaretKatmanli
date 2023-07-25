using BussinesLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace IUWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsManager manager;  

        public HomeController(IProductsManager _manager)
        {
            manager = _manager;
        }
        public IActionResult Index()
        {
            return View(manager.GetList());
        }
        [Route("/Urun/Detay/{id}")]

        public IActionResult Detay(int id)
        {
            return View(manager.GetById(id));
        }
    }
}
