using Microsoft.AspNetCore.Mvc;
using SupermarketWebApp.Models;
using SupermarketWebApp.Data;

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
    }
}
