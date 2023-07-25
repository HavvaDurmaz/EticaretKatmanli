using BussinesLayer.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IUWeb.Areas.admin.Controllers
{
    [Authorize(Roles = "admin")] // Müşteri Tablosundaki Role Sütununda admin olan bu sayfayı açabilsin. 
    [Area("admin")]
    public class KategoriYonetimController : Controller
    {

        private readonly ICategoriesManager manager;
        public KategoriYonetimController(ICategoriesManager _manager)
        {
            manager = _manager;
        }
        public IActionResult Index()
        {
            return View(manager.GetList());
        }
        public IActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Insert(Categories categories)
        {
            var Sonuc = manager.AddData(categories);
            if (Sonuc[0] == "0")
            {
                ViewBag.Message = "<div class=\"alert alert-success\" >" + Sonuc[1] + "</div>";
            }
            else
            {
                ViewBag.Message = "<div class=\"alert alert-warning\" >" + Sonuc[1] + "</div>";
            }
            return View();
        }
        [Route("/admin/KategoriYonetim/Update/{id}")]
        public IActionResult Update(int id)
        {
            return View(manager.GetById(id));
        }
        [HttpPost]
        [Route("/admin/KategoriYonetim/Update/{id}")]
        public IActionResult Update(Categories categories, int id)
        {
            var Sonuc = manager.UpdateData(categories);
            if (Sonuc[0] == "0")
            {
                ViewBag.Message = "<div class=\"alert alert-success\" >" + Sonuc[1] + "</div>";
            }
            else
            {
                ViewBag.Message = "<div class=\"alert alert-warning\" >" + Sonuc[1] + "</div>";
            }
            return View(manager.GetById(id));
        }
        [Route("/admin/KategoriYonetim/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var Sonuc = manager.DeleteData(manager.GetById(id));
            if (Sonuc[0] == "0")
            {
                TempData["Message"] = "<div class=\"alert alert-success\" >" + Sonuc[1] + "</div>";
            }
            else
            {
                TempData["Message"] = "<div class=\"alert alert-warning\" >" + Sonuc[1] + "</div>";
            }
            return Redirect("/admin/KategoriYonetim");
        }
    }
}