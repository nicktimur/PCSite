using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PCSite.Models;
using System.Text.Json.Serialization;
using MySqlConnector; // MySQL ba�lant�s� i�in gerekli k�t�phane

var builder = WebApplication.CreateBuilder(args);

// Session yap�land�rmas�
builder.Services.AddDistributedMemoryCache(); // Session i�in gerekli
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Session s�resi
    options.Cookie.HttpOnly = true; // Cookie'nin sadece HTTP �zerinden eri�ilebilir olmas�n� sa�lar
    options.Cookie.IsEssential = true; // GDPR ve di�er veri koruma d�zenlemeleri i�in gerekli
});

builder.Services.AddEndpointsApiExplorer();

// MySQL ba�lant� dizesi ve sunucu versiyonu
var connectionString = "Server=200.0.0.119;Port=3306;Database=satisdb;Uid=user;Pwd=1111;";
var serverVersion = new MySqlServerVersion(new Version(8, 0, 38));

// Veritaban� ba�lam�n�n yap�land�r�lmas�
builder.Services.AddDbContext<SatisdbContext>(options =>
    options.UseMySql(connectionString, serverVersion));

// Controller ve View'lar i�in hizmet ekleme
builder.Services.AddControllersWithViews();

// Cookie tabanl� kimlik do�rulama ekleme
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login"; // Giri� yap�lmad���nda y�nlendirilecek sayfa
        options.AccessDeniedPath = "/Account/AccessDenied"; // Eri�im reddedildi�inde y�nlendirilecek sayfa
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // �erez s�resi
    });

// appsettings.json dosyas�n� yap�land�rmaya ekleme
builder.Configuration.AddJsonFile("appsettings.json");

var app = builder.Build();

// HTTP iste�i hatt�n�n yap�land�r�lmas�
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error"); // Hata y�netimi
    app.UseHsts(); // HTTP Strict Transport Security
}

app.UseHttpsRedirection(); // HTTPS y�nlendirmesi
app.UseStaticFiles(); // Statik dosyalar

app.UseRouting(); // Y�nlendirme

app.UseAuthentication(); // Kimlik do�rulama
app.UseAuthorization(); // Yetkilendirme

app.UseSession(); // Session kullan�m�

// Varsay�lan rota yap�land�rmas�
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{name?}");

app.MapControllers(); // Controller haritalama

app.Run(); // Uygulamay� �al��t�rma
