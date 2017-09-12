using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PollApp.Models;
using PollApp.ViewModel;
using PollApp.Data;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PollApp.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext context;

        public UserController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            AddUserViewModel addUserViewModel = new AddUserViewModel();
            return View(addUserViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddUserViewModel addUserViewModel)
        {
            if (ModelState.IsValid)
            {
                 
                if (context.Users.Single(c => c.UserName == addUserViewModel.UserName) == null)
                {
                    User newUser = new User
                    {
                        UserName = addUserViewModel.UserName,
                        Password = addUserViewModel.Password
                    };
                    if (addUserViewModel.Email.Length > 0)
                    { 
                        if (context.Users.Single(c => c.Email == addUserViewModel.Email) == null)
                        {
                            newUser.Email = addUserViewModel.Email;
                        }
                        return View(addUserViewModel);
                    }
                    context.Users.Add(newUser);
                    context.SaveChanges();
                    return Redirect("/User/u/" + addUserViewModel.UserName);
                }
            }
            return View(addUserViewModel);
        }

        [Route("/User/u/{username}")]
        public IActionResult Users(string username)
        {
            ViewBag.User = context.Users.Single(x => x.UserName == username);
            return View();
        }
    }
}
