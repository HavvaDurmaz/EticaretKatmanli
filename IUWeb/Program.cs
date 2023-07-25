using BussinesLayer.AutoMapper;
using BussinesLayer.DependencyContainer;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc().AddFluentValidation(); // Fluent Validation'nun G�rsel Tarafta Aktif ediyoruz.

builder.Services.Instance(); // BusinessLayer'daki T�retmeleri Buraya Aktar�yoruz.

builder.Services.AddAutoMapper(typeof(MapperProfile)); // AutoMapper K�t�phanesini Buraya Aktar�yoruz. 

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

// Aktarmalar� yapmam�z�n nedeni, B�t�n Katmanlar�n �al��mas�n� Bu Katmand�r. IUWEB katman� internette g�sterilece�i i�in kullan�c�n�n IUWEB i�erisinde sayfalarda gezdik�e her�ey tek tek akitf olacakt�r.

app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication(); // Giri� Makanizmas�
app.UseAuthorization(); // Giri� Yap�ld�ktan sonra Yetkli Kontrol�
app.UseEndpoints(x => x.MapDefaultControllerRoute());
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Login}/{action=Index}/{id?}"
    );
});


app.Run();
