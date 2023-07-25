using BussinesLayer.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;

namespace IUWeb.Controllers
{
    public class MusteriController : Controller
    {
        private readonly ICustomersManager manager;

        public MusteriController(ICustomersManager _manager)
        {
            manager = _manager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult KayitOl()
        {
            return View();
        }

        [HttpPost]

        public IActionResult KayitOl(Customers data)
        {
            data.Status = false;
            var Sonuc = manager.AddData(data);
            if (Sonuc[0] == "0")
            {
                MailGonder(data.Email);
                ViewBag.Message = "<div class=\"alert alert-success\" >Üyelik Başvurunuz Gerçekleşmiştir. Email Adresine Gelen Doğrulama Linkine Tıkladığınız Zaman Giriş Yapabilirsiniz. </div>";
            }
            else
            {
                ViewBag.Message = "<div class=\"alert alert-warning\" >" + Sonuc[1] + "</div>";
            }
            return View();
        }
        [NonAction]

        private bool MailGonder(string Email)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("noreply@gulerarslan.com", "Üyelik Doğrulama");
            mailMessage.Subject = "WebSite Üyelik Doğrulama";
            mailMessage.To.Add(Email);
         
            string body = "qwewqeq";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = body;
            SmtpClient smtp = new SmtpClient("mail.gulerarslan.com", 587);
            smtp.Credentials = new NetworkCredential("noreply@gulerarslan.com", "e~4ioV291");
            smtp.EnableSsl = false;
            smtp.Send(mailMessage);
            return true;
        }

        public IActionResult Giris()
        {
            return View();
        }
        [HttpPost]
        
        public IActionResult Giris(string email, string Sifre)
        {
            var data = manager.Login(email, Sifre);
            if (data != null)
            {
                if (data.Status)
                {
                    var claims = new List<Claim>
                    {
                         new Claim("id",data.Id.ToString()),
                         new Claim(ClaimTypes.Role,data.Roles),
                         new Claim(ClaimTypes.Name,data.NameSurName),
                    };
                    var UserIdentity = new ClaimsIdentity(claims, "UserClaims");
                    var principal = new ClaimsPrincipal(UserIdentity);
                    HttpContext.SignInAsync(principal);

                    if (data.Roles == "user")
                    {
                        return Redirect("/");
                    }
                    else
                    {
                        return Redirect("/admin/SiparisYonetim");
                    }
                }
                else
                {
                    MailGonder(data.Email);
                    ViewBag.Message = "<div class=\"alert alert-info\" >Üyeliğiniz Aktifleştirilmemiştir. Aktifleştirebilmeniz için Doğrulama Emaili Tekrar Gönderilmiştir.</div>";
                }
            }
            else
            {
                ViewBag.Message = "<div class=\"alert alert-danger\" >Email Adresiniz veya Şifreniz Yanlış.</div>";
            }
            return View();
        }

        public IActionResult Logout()
        {
            return Redirect("/");
        }
    }
}
