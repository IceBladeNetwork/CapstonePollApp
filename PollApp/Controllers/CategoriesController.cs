using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PollApp.Data;
using PollApp.ViewModel;
using PollApp.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PollApp.Controllers
{
    public class CategoriesController : Controller
    {
        private ApplicationDbContext context;

        public CategoriesController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.Categories = context.Categories.ToList();
            return View();
        }

        public IActionResult New()
        {
            NewCategoryViewModel newCategoryViewModel = new NewCategoryViewModel();
            return View(newCategoryViewModel);
        }

        [HttpPost]
        public IActionResult New(NewCategoryViewModel newCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                Categories newCategories = new Categories
                {
                    Category = newCategoryViewModel.Category
                };
                context.Categories.Add(newCategories);
                context.SaveChanges();
                return Redirect("/Categories");
            }
            return View();
        }
    }
}
