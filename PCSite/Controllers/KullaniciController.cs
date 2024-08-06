using Microsoft.AspNetCore.Mvc;

namespace PCSite.Controllers
{
    public class KullaniciController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Kayit()
        {
            return View();
        }
        public IActionResult Giris()
        {
            return View();
        }
    }
}
