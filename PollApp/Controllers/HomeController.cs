using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using PollApp.Models;
using PollApp.ViewModel;
using PollApp.Data;


namespace PollApp.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext context;

        public HomeController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<Polls> items = context.Polls.OrderBy(d => d.DateCreated).ToList();
            ViewBag.items = items;
            return View();
        }
    }
}
