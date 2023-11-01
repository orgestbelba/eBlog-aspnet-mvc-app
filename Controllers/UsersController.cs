using eBlog.Data;
using eBlog.Data.Static;
using eBlog.Models;
using eBlog.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBlog.Controllers
{
    public class UsersController : Controller
    {
        // injecting the AppDbContext to the controller
        private readonly AppDbContext _context;

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;


        public UsersController(AppDbContext context
            , UserManager<User> userManager
            , SignInManager<User> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _context.Users.ToListAsync();
            return View();
        }

        public IActionResult LogIn()
        {
            var data = new LogInViewModel();
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LogInViewModel LogInData)
        {
            if (!ModelState.IsValid)
            {
                return View(LogInData);
            }

            var user = await _userManager.FindByEmailAsync(LogInData.EmailAddress);
            if (user != null)
            {
                var validationCheck = await _userManager.CheckPasswordAsync(user, LogInData.Password);
                if (validationCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, LogInData.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Posts");
                    }
                }
                TempData["Error"] = "Please check you credentials again!";
                return View(LogInData);
            }

            TempData["Error"] = "Please check you credentials again!";
            return View(LogInData);
        }

        public IActionResult SignUp()
        {
            var data = new SignUpViewModel();
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel RegisterData)
        {
            if (!ModelState.IsValid)
                return View(RegisterData);
      
            var user = await _userManager.FindByEmailAsync(RegisterData.EmailAddress);
            if (user != null)
            {
                TempData["Error"] = "This email is already in use!";
                return View(RegisterData);
            }
            var newUser = new User()
            {
                FirstName = RegisterData.FirstName,
                LastName = RegisterData.LastName,
                UserName = RegisterData.UserName,
                Email = RegisterData.EmailAddress
            };

            var newUserResponse = await _userManager.CreateAsync(newUser, RegisterData.Password);

            if (newUserResponse.Succeeded)
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);

            return View("RegistrationCompleted");
        }

        public async Task <IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Posts");
        }
    }
}
