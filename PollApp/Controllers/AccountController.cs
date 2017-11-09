using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PollApp.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using PollApp.Data;
using PollApp.Models;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PollApp.Controllers
{
    public class AccountController : Controller
    {
        public ApplicationDbContext context;
        public readonly UserManager<User> _userManager;
        public readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ApplicationDbContext dbContext)
        {
            _userManager = userManager;
            context = dbContext;
            _signInManager = signInManager;
        }

        // GET: /<controller>/
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginViewModel.Username, loginViewModel.Password, loginViewModel.RememberMe, false);

                if (result.Succeeded)
                {
                    return Redirect("/");
                }
                ModelState.AddModelError("", "Username or password is incorrect!");
            }
            return View(loginViewModel);
        }

        public IActionResult Register()
        {
            RegisterViewModel registerViewModel = new RegisterViewModel();
            return View(registerViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new User { UserName = registerViewModel.Username, Email = registerViewModel.Email };
                var result = await _userManager.CreateAsync(user, registerViewModel.Password);

                if (result.Succeeded)
                {
                    if (user.Email.ToLower() == "theicebladenetwork@gmail.com")
                    {
                        await _userManager.AddToRoleAsync(user, "Admin");
                    }
                    await _signInManager.SignInAsync(user, false);
                    return Redirect("/");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(registerViewModel);

                }
            }
            else
            {
                return View(registerViewModel);
            }

        }
    }
}
