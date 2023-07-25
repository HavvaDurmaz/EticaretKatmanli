using BussinesLayer.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace IUWeb.Controllers
{
    public class SepetController : Controller
    {

        private readonly IProductsManager productsManager;
        private readonly ITemporaryManager temporaryManager;

        public SepetController(IProductsManager _productsManager, ITemporaryManager _temporaryManager)
        {
            productsManager = _productsManager;
            temporaryManager = _temporaryManager;
        }
        public IActionResult Index()
        {
            if (Request.Cookies["SepetCookie"] != null)
            {
                int cookieSepet = int.Parse(Request.Cookies["SepetCookie"].ToString());
                return View(temporaryManager.GetList(cookieSepet));
            }
            else
            {
                return View(temporaryManager.GetList(0));
            }          
        }
        public JsonResult AdetEkleCikar(int TemporaryId, bool ArttirmaEksiltme)
        {
            var Sonuc = temporaryManager.UpdateData(TemporaryId, ArttirmaEksiltme);
            if (Sonuc[0] == "0")
            {
                return Json("İşlem Başarılı");
            }
            else
            {
                return Json("İşlem Başarısız");
            }
        }

        public IActionResult SepetListele()
        {
            if (Request.Cookies["SepetCookie"] != null)
            {
                int cookieSepet = int.Parse(Request.Cookies["SepetCookie"].ToString());
                return PartialView("/Views/_Shared/PartialSepetListele.cshtml", temporaryManager.GetList(cookieSepet));
            }
            else
            {
                return PartialView("/Views/_Shared/PartialSepetListele.cshtml", temporaryManager.GetList(0));
            }

        }

        // JavaScript yapıları JSON tipleri veri gönderiri, JSON tipinde veri alır. 

        public JsonResult SepeteEkle(int ProductId)
        {
            var BulunanUrun = productsManager.GetById(ProductId);
            string CookieSepet = "";         
            if (Request.Cookies["SepetCookie"]== null)
            {
                CookieOptions cookie = new CookieOptions();
                cookie.Expires = DateTime.Now.AddDays(2);
                Random rnd = new Random();
                CookieSepet = rnd.Next(0, 9899999).ToString();

                // Tarayıcı Açılıp Kapandığında Cookie Kaybolmaması için yapılan ayar.

                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.UtcNow.AddDays(2);

                Response.Cookies.Append("SepetCookie", CookieSepet, options);
            }
            else
            {
                CookieSepet = Request.Cookies["SepetCookie"];
            }
            TemporaryBasket basket = new TemporaryBasket();
            basket.CookieID = int.Parse(CookieSepet);
            basket.ImagesHome = BulunanUrun.ImagesHome;
            basket.Price = BulunanUrun.Price;
            basket.Piece = 1;
            basket.ProductsId = BulunanUrun.Id;
            basket.ProductName = BulunanUrun.ProductsName;
            
            var Sonuc = temporaryManager.AddData(basket);

            if (Sonuc[0] == "0") 
            {
                return Json("Ürün Sepet'e Eklenmiştir.");
            }
            else
            {
                return Json("Ürün Sepet'e Eklenememiştir.");
            }
        }
        public IActionResult SepettekiUrunSayisi()
        {
            int UrunSayisi = 0;
            if (Request.Cookies["SepetCookie"] != null)
            {
                int cookieSepet = int.Parse(Request.Cookies["SepetCookie"].ToString());
                UrunSayisi = temporaryManager.GetList(cookieSepet).Count();
                return PartialView("/Views/_Shared/PartialKismi/PartialSepettekiAdet.cshtml", UrunSayisi);
            }
            else
            {
                return PartialView("/Views/_Shared/PartialKismi/PartialSepettekiAdet.cshtml", UrunSayisi);
            }
        }
    }
}
