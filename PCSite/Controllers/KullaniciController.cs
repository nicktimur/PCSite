using Microsoft.AspNetCore.Mvc;
using PCSite.Models;
using Newtonsoft.Json;

namespace PCSite.Controllers
{
    public class KullaniciController : Controller
    {

        private readonly SatisdbContext _db;

        public KullaniciController(SatisdbContext db)
        {
            _db = db;
        }

        public IActionResult Logout()
        {
            var userJson = HttpContext.Session.GetString("user");
            var userdata = JsonConvert.DeserializeObject<Kullanici>(userJson);
            var user = _db.Kullanicis.Where(x => x.Email == userdata.Email).FirstOrDefault();
            _db.SaveChanges();
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Index()
        {
            return View();
        }

        [SessionAuthorize(false)]
        public IActionResult Kayit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Kayit(KullaniciAddingModel kullanici)
        {
            if (kullanici is not null)
            {
                Kullanici yeniKullanici = new Kullanici();
                yeniKullanici.Ad = kullanici.Ad;
                yeniKullanici.Soyad = kullanici.Soyad;
                yeniKullanici.Email = kullanici.Email;
                yeniKullanici.Sifre = kullanici.Sifre;
                yeniKullanici.KullaniciTipi = 0;
                yeniKullanici.KayitTarihi = DateTime.Now;
                yeniKullanici.TelefonNumarasi = kullanici.TelefonNumarasi;
                try
                {
                    _db.Kullanicis.Add(yeniKullanici);
                    _db.SaveChanges();

                    var user = _db.Kullanicis.Where(x => x.Email == kullanici.Email && x.Sifre == kullanici.Sifre).FirstOrDefault();

                    if (user != null)
                    {
                        var userJson = JsonConvert.SerializeObject(user);
                        HttpContext.Session.SetString("user", userJson);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        // Kullanıcı bilgileri ile giriş yapılamazsa hata mesajı
                        ViewBag.Error = "Giriş işlemi lütfen manuel olarak deneyiniz.";
                        return View(kullanici);
                    }

                }
                catch
                {
                    ViewBag.Error = "Lütfen kullanılmayan bir mail giriniz.";
                    return View(kullanici);
                }

                return View();
            }
            else
                return View(kullanici);
        }

        [SessionAuthorize(false)]
        public IActionResult Giris()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Giris(KullaniciLoginModel kullanici)
        {
            if (kullanici is not null)
            {
                var user = _db.Kullanicis.Where(x => x.Email == kullanici.Email).FirstOrDefault();
                if(user is not null)
                {
                    if (user.Sifre == kullanici.Sifre)
                    {
                        var userJson = JsonConvert.SerializeObject(user);
                        HttpContext.Session.SetString("user", userJson);
                        if (user.KullaniciTipi == 0)
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            return RedirectToAction("Index", "Admin");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı.");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Böyle bir kullanıcı bulunmamakta!");
                }
            }
            return View();
        }
    }
}
