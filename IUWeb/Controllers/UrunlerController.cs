using BussinesLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace IUWeb.Controllers
{
    public class UrunlerController : Controller
    {
        public IProductsManager manager;
        public ICategoriesManager categoriesManager;

        public UrunlerController(IProductsManager _manager, ICategoriesManager _categoriesManager)
        {
            manager = _manager;
            categoriesManager = _categoriesManager;
        }
        public IActionResult Index()
        {
            ViewBag.Kategori = categoriesManager.GetList();
            return View(manager.GetList());
        }
    }
}
