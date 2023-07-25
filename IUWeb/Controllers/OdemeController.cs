using BussinesLayer.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace IUWeb.Controllers
{
    public class OdemeController : Controller
    {

        private readonly IOrdersManager manager;
        private readonly ITemporaryManager temporaryManager;

        public OdemeController(IOrdersManager _manager, ITemporaryManager _temporaryManager)
        {
            manager = _manager;
            temporaryManager = _temporaryManager;
        }

        public IActionResult Index()
        {
            if (Request.Cookies["SepetCookies"] != null && User.Identity.IsAuthenticated)
            {
                int cookieSepet = int.Parse(Request.Cookies["SepetCookie"].ToString());
                return View(temporaryManager.GetList(cookieSepet));
            }
            else
            {
                return Redirect("/Musteri/Giris");
            }
        }
        [HttpPost]
        [HttpPost]
        public IActionResult Odeme(string OdemeTipi, OrderAddress Adres)
        {
            int SepetId = int.Parse(Request.Cookies["SepetCookie"].ToString());

            decimal ToplamTutar = 0;
            List<OrderDetails> Alinanlar = new List<OrderDetails>();

            foreach (var item in temporaryManager.GetList(SepetId))
            {
                Alinanlar.Add(new OrderDetails
                {
                    CookieId = item.CookieID,
                    Piece = item.Piece,
                    Price = item.Price,
                    ProductName = item.ProductName,
                    ProductsId = item.ProductsId,
                    ImagesHome = item.ImagesHome
                });
                ToplamTutar += item.Piece * item.Price;
            }
            Orders orders = new Orders();
            orders.CookieId = SepetId;
            orders.CustomersId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == "id").Value);
            orders.OrderStatus = "Onay Bekliyor";
            orders.PaymentDate = DateTime.Now;
            orders.PaymentType = OdemeTipi;
            orders.TotalPrice = ToplamTutar;
            Adres.CustomersId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == "id").Value);

            var Sonuc = manager.AddData(orders, Alinanlar, Adres);

            if (Sonuc[0] == "0")
            {
                TempData["Message"] = "<div class=\"alert alert-success\" >" + SepetId + " Numaralı Siparişiniz Alınmıştır . </div>";
                return Redirect("/Odeme/Basarili");
            }
            else
            {
                TempData["Message"] = "<div class=\"alert alert-warning\" >" + SepetId + " Numaralı Siparişiniz Alınamadı . </div>";
                return Redirect("/Odeme/Basarisiz");
            }

            return View();
        }

        public IActionResult Basarili()
        {
            if (Request.Cookies["SepetCookies"] != null && User.Identity.IsAuthenticated)
            {
                int cookieSepet = int.Parse(Request.Cookies["SepetCookie"].ToString());
                foreach (var item in temporaryManager.GetList(cookieSepet))
                {
                    temporaryManager.DeleteData(item);
                }
                var BulunanCookie = Request.Cookies["SepetCookie"];
                Response.Cookies.Delete(BulunanCookie);
            }
            return View();
        }

        public IActionResult Basarisiz()
        {
            return View();
        }
    }  
}
