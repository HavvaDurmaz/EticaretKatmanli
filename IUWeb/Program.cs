using BussinesLayer.AutoMapper;
using BussinesLayer.DependencyContainer;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc().AddFluentValidation(); // Fluent Validation'nun Görsel Tarafta Aktif ediyoruz.

builder.Services.Instance(); // BusinessLayer'daki Türetmeleri Buraya Aktarýyoruz.

builder.Services.AddAutoMapper(typeof(MapperProfile)); // AutoMapper Kütüphanesini Buraya Aktarýyoruz. 

builder.Services.AddAuthentication(x =>
{
    x.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(x =>
{
    x.AccessDeniedPath = "/DaniendPage";
    x.LoginPath = "/Musteri/Giris";
    x.LogoutPath = "/Musteri/Logout";
});

var app = builder.Build();

// Aktarmalarý yapmamýzýn nedeni, Bütün Katmanlarýn çalýþmasýný Bu Katmandýr. IUWEB katmaný internette gösterileceði için kullanýcýnýn IUWEB içerisinde sayfalarda gezdikçe herþey tek tek akitf olacaktýr.

app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication(); // Giriþ Makanizmasý
app.UseAuthorization(); // Giriþ Yapýldýktan sonra Yetkli Kontrolü
app.UseEndpoints(x => x.MapDefaultControllerRoute());
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Login}/{action=Index}/{id?}"
    );
});


app.Run();
