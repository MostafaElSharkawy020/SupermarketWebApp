using Microsoft.AspNetCore.Mvc;
using SupermarketWebApp.Models;
using SupermarketWebApp.Data;
using SupermarketWebApp.ViewModels;

namespace SupermarketWebApp.Controllers
{
    
    public class LoginController : Controller
    {
        private readonly AppDbContext context = new AppDbContext();
        public IActionResult RegisterPage()
        {
            return View("Register");
        }

        public IActionResult Register(User user) 
        {
            Console.WriteLine(user.phoneNumber);
            context.Users.Add(user);
            context.SaveChanges();
            Console.WriteLine(user.firstName + " " + user.lastName);
            return View("Login");
        }

        public IActionResult LoginPage()
        {
            return View("Login");
        }

        public IActionResult Login(LoginViewModel model) 
        {
            var user = context.Users.FirstOrDefault(c => c.email == model.email && c.password ==  model.password);
            if (user == null)
            {
                return RedirectToAction("loginpage");
            }
            return RedirectToAction("AllProducts", "Products");

        }
    }
}
