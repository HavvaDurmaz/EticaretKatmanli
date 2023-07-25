using BussinesLayer.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace IUWeb.Areas.admin.Controllers
{
    [Authorize(Roles = "admin")]
    [Area("admin")]
    public class MusteriYonetimController : Controller
    {
        private readonly ICustomersManager manager;

        public MusteriYonetimController(ICustomersManager _manager)
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
        public IActionResult Insert(Customers data)
        {
            var Sonuc = manager.AddData(data);
            if (Sonuc[0] == "0")
            {
                ViewBag.Message = "<div class=\"alert alert-success\">" + Sonuc[1] + "</div>";
            }
            else
            {
                ViewBag.Message = "<div class=\"alert alert-warning\">" + Sonuc[1] + "</div>";
            }
            return View();
        }

        [Route("/admin/MusteriYonetim/Update/{id}")]

        public IActionResult Update(int id )
        {
            return View(manager.GetById(id));
        }

        [HttpPost]
        [Route("/admin/MusteriYonetim/Update/{id}")]
        public IActionResult Update(int id, Customers data)
        {
            var Sonuc = manager.UpdateData(data);
            if (Sonuc[0] == "0")
            {
                ViewBag.Message = "<div class=\"alert alert-success\">" + Sonuc[1] + "</div>";
            }
            else
            {
                ViewBag.Message = "<div class=\"alert alert-warning\">" + Sonuc[1] + "</div>";
            }
            return View(manager.GetById(id));
        }

        [Route("/admin/MusteriYonetim/Delete/{id}")]

        public IActionResult Delete(int id)
        {
            var Sonuc = manager.DeleteData(manager.GetById(id));
            if (Sonuc[0] == "0")
            {
                TempData["Message"] = "<div class=\"alert alert-success\">" + Sonuc[1] + "</div>";
            }
            else
            {
                TempData["Message"] = "<div class=\"alert alert-warning\">" + Sonuc[1] + "</div>";
            }
            return Redirect("/admin/MusteriYonetim");
            
        }

    }
}
