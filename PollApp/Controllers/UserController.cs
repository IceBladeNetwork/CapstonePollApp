using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using PollApp.Data;
using PollApp.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PollApp.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext context;
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;

        public UserController(ApplicationDbContext dbContext, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            context = dbContext;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.polls = context.Polls.Where(c => c.Creator == HttpContext.User.Identity.Name);
            return View();
        }

        public IActionResult Del()
        {
            return View();
        }
    }
}
