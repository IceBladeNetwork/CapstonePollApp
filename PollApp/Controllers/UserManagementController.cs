using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PollApp.Data;
using PollApp.ViewModel;
using Microsoft.AspNetCore.Identity;
using PollApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PollApp.Controllers
{
    public class UserManagementController : Controller
    {
        private ApplicationDbContext context;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserManagementController(ApplicationDbContext dbContext, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            context = dbContext;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var vm = new UserManagmentViewModel
            {
                Users = context.Users.OrderBy(u => u.UserName).ToList()
            };
            return View(vm);
        }

        public async Task<IActionResult> AddRole(string id)
        {
            var user = await GetUserById(id);
            var vm = new UserManagementAddRoleViewModel
            {
                User = user.UserName, 
                Roles = GetAllRoles(),
                UserId = id
            };
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> AddRole(UserManagementAddRoleViewModel rvm)
        {
            if (ModelState.IsValid)
            {
                var user = await GetUserById(rvm.UserId);
                var result = await userManager.AddToRoleAsync(user, rvm.NewRole);
                if (result.Succeeded)
                {
                    return Redirect("Index");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
            }
            rvm.Roles = GetAllRoles();
            return View(rvm);
        }

        private async Task<User> GetUserById(string id) => await userManager.FindByIdAsync(id);

        private SelectList GetAllRoles() => new SelectList(roleManager.Roles.OrderBy(r => r.Name));
    }
}
