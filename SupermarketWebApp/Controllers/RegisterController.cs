using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupermarketWebApp.Data;
using SupermarketWebApp.Models;
using System;

namespace SupermarketWebApp.Controllers
{
    public class RegisterController : Controller
    {
        AppDbContext context=new AppDbContext();
        public IActionResult viewRegister()
        {
            return View("Register");
        }
        [HttpGet]
        [HttpPost]
        
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var hasher = new PasswordHasher<User>();

                var user = new User
                {
                    firstName = model.firstName,
                    lastName = model.lastName,
                    email = model.email,
                    phoneNumber = model.phoneNumber,
                    address = model.address,
                    //  save hash password
                    password = hasher.HashPassword(null, model.password)
                };
                context.Users.Add(user);
                context.SaveChanges();
               

                return View("Login");
            }

            return View(model);
        }

    }






}
