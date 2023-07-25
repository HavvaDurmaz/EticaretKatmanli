using BussinesLayer.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IUWeb.Areas.admin.Controllers
{
    [Authorize(Roles = "admin")]
    [Area("admin")]
    public class UrunYonetimController : Controller
    {

        private readonly IProductsManager manager;
        private readonly ICategoriesManager categoriesManager;
        public UrunYonetimController(IProductsManager _manager, ICategoriesManager _categoriesManager)
        {
            manager = _manager;
            categoriesManager = _categoriesManager;
        }
        public IActionResult Index()
        {
            return View(manager.GetList());
        }
        public IActionResult Insert()
        {
            ViewBag.Kategoriler = categoriesManager.GetList();
            return View();
        }
        [HttpPost]
        public IActionResult Insert(Products products, IFormFile Resim1, IFormFile Resim2, IFormFile Resim3, IFormFile Resim4)
        {

            if (Resim1 != null && Resim2 != null && Resim3 != null && Resim4 != null)
            {
                products.ImagesHome = Helpers.FileUploads.Upload(Resim1);
                products.ImagesDetail = Helpers.FileUploads.Upload(Resim2);
                products.ImagesDetail2 = Helpers.FileUploads.Upload(Resim3);
                products.ImagesDetail3 = Helpers.FileUploads.Upload(Resim4);

                var Sonuc = manager.AddData(products);
                if (Sonuc[0] == "0")
                {
                    ViewBag.Message = "<div class=\"alert alert-success\" >" + Sonuc[1] + "</div>";
                }
                else
                {
                    ViewBag.Message = "<div class=\"alert alert-warning\" >" + Sonuc[1] + "</div>";
                }
            }
            else
            {
                ViewBag.Message = "<div class=\"alert alert-success\" >4 Resimdem Biri Seçilmedi. Tekrar Deneyiniz.</div>";
            }
            ViewBag.Kategoriler = categoriesManager.GetList();
            return View();
        }


        [Route("/admin/UrunYonetim/Update/{id}")]
        public IActionResult Update(int id)
        {

            return View(manager.GetById(id));
        }
        [HttpPost]
        [Route("/admin/UrunYonetim/Update/{id}")]
        public IActionResult Update(int id, Products products, IFormFile Resim1, IFormFile Resim2, IFormFile Resim3, IFormFile Resim4)
        {

            var BulunanVeri = manager.GetById(id);

            string ResimAdi1 = (Resim1 != null ? Helpers.FileUploads.Upload(Resim1) : "0");
            if (ResimAdi1 != "0") { BulunanVeri.ImagesHome = ResimAdi1; }

            string ResimAdi2 = (Resim2 != null ? Helpers.FileUploads.Upload(Resim2) : "0");
            if (ResimAdi2 != "0") { BulunanVeri.ImagesDetail = ResimAdi2; }

            string ResimAdi3 = (Resim3 != null ? Helpers.FileUploads.Upload(Resim3) : "0");
            if (ResimAdi3 != "0") { BulunanVeri.ImagesDetail2 = ResimAdi3; }

            string ResimAdi4 = (Resim4 != null ? Helpers.FileUploads.Upload(Resim4) : "0");
            if (ResimAdi4 != "0") { BulunanVeri.ImagesDetail3 = ResimAdi4; }

            BulunanVeri.ProductsName = products.ProductsName;
            BulunanVeri.Stock = products.Stock;
            BulunanVeri.Price = products.Price;
            BulunanVeri.Explanation = products.Explanation;
            BulunanVeri.CategoriesId = products.CategoriesId;

            var Sonuc = manager.UpdateData(BulunanVeri);
            if (Sonuc[0] == "0")
            {
                ViewBag.Message = "<div class=\"alert alert-success\" >" + Sonuc[1] + "</div>";
            }
            else
            {
                ViewBag.Message = "<div class=\"alert alert-warning\" >" + Sonuc[1] + "</div>";
            }

            ViewBag.Kategoriler = categoriesManager.GetList();
            return View(manager.GetById(id));
        }
        [Route("/admin/UrunYonetim/Update/{id}")]
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
            return Redirect("/admin/UrunYonetim");
        }
    }
}
