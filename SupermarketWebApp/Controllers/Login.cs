using Microsoft.AspNetCore.Mvc;

namespace SupermarketWebApp.Controllers
{
    public class Login : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
