using Microsoft.AspNetCore.Mvc;

namespace SupermarketWebApp.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult viewRegister()
        {
            return View("Register-Login/Register");
        }
    }
}
