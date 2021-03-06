﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PollApp.Data;
using PollApp.ViewModel;
using PollApp.Models;
using Microsoft.AspNetCore.Authorization;

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

        [Authorize(Roles = "Admin")]
        public IActionResult New()
        {
            NewCategoryViewModel newCategoryViewModel = new NewCategoryViewModel();
            return View(newCategoryViewModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult New(NewCategoryViewModel newCategoryViewModel)
        {
            if (ModelState.IsValid && newCategoryViewModel.Category.IndexOf("/") < 0)
            {
                Categories newCategories = new Categories
                {
                    Category = newCategoryViewModel.Category
                };
                context.Categories.Add(newCategories);
                context.SaveChanges();
                return Redirect("/Categories");
            }
            return View(newCategoryViewModel);
        }

        [Route("/Categories/C/{category}")]
        public IActionResult Category(string category)
        {
            ViewBag.items = context.Polls.Where(c => c.Catagory == category).OrderByDescending(d => d.DateCreated).ToList();
            return View();
        }
    }
}
