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
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PollApp.Controllers
{
    public class PollController : Controller
    {
        private ApplicationDbContext context;

        public PollController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult New()
        {
            if (context.Categories.ToList().Count > 0)
            {
                IEnumerable<Categories> cateList = context.Categories.ToList();
                NewPollViewModel newPollViewModel = new NewPollViewModel(cateList);
                return View(newPollViewModel);
            }
            return Redirect("/Categories/New");
        }

        [HttpPost]
        public IActionResult New(NewPollViewModel newPollViewModel)
        {
            if (ModelState.IsValid)
            {
                string category = context.Categories.Single(c => c.ID == newPollViewModel.CateId).Category;
                Polls newPoll = new Polls
                {
                    Title = newPollViewModel.Title,
                    Total = 0,
                    Catagory = category,
                    DateCreated = DateTime.Now
                };

                context.Polls.Add(newPoll);
                context.SaveChanges();

                int newId = context.Polls.OrderByDescending(d => d.DateCreated).ToList()[0].ID;
                return Redirect("/Poll/New/" + newId);
            }
            return View(newPollViewModel);
        }

        [Route("/Poll/ID/{id}")]
        public IActionResult Polls(int id)
        {
            Polls currentPoll = context.Polls.Single(c => c.ID == id);
            PollVotingViewModel pollVotingViewModel = new PollVotingViewModel(currentPoll);
            return View(pollVotingViewModel);
        }

        [HttpPost]
        [Route("/Poll/ID/{id}")]
        public IActionResult Polls(PollVotingViewModel pollVotingViewModel)
        {
            if (ModelState.IsValid)
            {
                Polls currentPoll = context.Polls.Single(c => c.ID == pollVotingViewModel.ID);
               
                return Redirect(pollVotingViewModel.ID.ToString());
            }
            return Redirect(pollVotingViewModel.ID.ToString());
        }

        [Route("/Poll/ID/{id}/Results")]
        public IActionResult Results(int id)
        {
            Polls currentPoll = context.Polls.Single(c => c.ID == id);
            ViewBag.currentPoll = currentPoll;
            return View();
        }
    }
}
