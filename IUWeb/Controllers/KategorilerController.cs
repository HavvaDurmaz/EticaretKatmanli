using BussinesLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace IUWeb.Controllers
{
    public class KategorilerController : Controller
    {
        private readonly ICategoriesManager manager;

        public KategorilerController(ICategoriesManager _manager)
        {
            manager = _manager;
        }

        [Route("/Kategoriler/{KategoriAdi}-{Id}")]
        public IActionResult Index(string KategoriAdi, int Id)
        {
            return View(manager.GetCategoriesProducts(Id));
        }
    }
}
