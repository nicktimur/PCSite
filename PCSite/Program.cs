using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PCSite.Models;
using System.Text.Json.Serialization;
using MySqlConnector; // MySQL baðlantýsý için gerekli kütüphane

var builder = WebApplication.CreateBuilder(args);

// Session yapýlandýrmasý
builder.Services.AddDistributedMemoryCache(); // Session için gerekli
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Session süresi
    options.Cookie.HttpOnly = true; // Cookie'nin sadece HTTP üzerinden eriþilebilir olmasýný saðlar
    options.Cookie.IsEssential = true; // GDPR ve diðer veri koruma düzenlemeleri için gerekli
});

builder.Services.AddEndpointsApiExplorer();

// MySQL baðlantý dizesi ve sunucu versiyonu
var connectionString = "Server=200.0.0.119;Port=3306;Database=satisdb;Uid=user;Pwd=1111;";
var serverVersion = new MySqlServerVersion(new Version(8, 0, 38));

// Veritabaný baðlamýnýn yapýlandýrýlmasý
builder.Services.AddDbContext<SatisdbContext>(options =>
    options.UseMySql(connectionString, serverVersion));

// Controller ve View'lar için hizmet ekleme
builder.Services.AddControllersWithViews();

// Cookie tabanlý kimlik doðrulama ekleme
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login"; // Giriþ yapýlmadýðýnda yönlendirilecek sayfa
        options.AccessDeniedPath = "/Account/AccessDenied"; // Eriþim reddedildiðinde yönlendirilecek sayfa
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // Çerez süresi
    });

// appsettings.json dosyasýný yapýlandýrmaya ekleme
builder.Configuration.AddJsonFile("appsettings.json");

var app = builder.Build();

// HTTP isteði hattýnýn yapýlandýrýlmasý
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error"); // Hata yönetimi
    app.UseHsts(); // HTTP Strict Transport Security
}

app.UseHttpsRedirection(); // HTTPS yönlendirmesi
app.UseStaticFiles(); // Statik dosyalar

app.UseRouting(); // Yönlendirme

app.UseAuthentication(); // Kimlik doðrulama
app.UseAuthorization(); // Yetkilendirme

app.UseSession(); // Session kullanýmý

// Varsayýlan rota yapýlandýrmasý
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{name?}");

app.MapControllers(); // Controller haritalama

app.Run(); // Uygulamayý çalýþtýrma
