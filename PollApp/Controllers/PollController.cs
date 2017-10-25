using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PollApp.Models;
using PollApp.ViewModel;
using PollApp.Data;
using Microsoft.AspNetCore.Authorization;

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
                    Catagory = category,
                    DateCreated = DateTime.Now,
                    Total = 0
                };
                context.Polls.Add(newPoll);
                context.SaveChanges();
                Polls currentPoll = context.Polls.OrderByDescending(d => d.DateCreated).ToList()[0];
                foreach (var item in newPollViewModel.Choices) {
                    if (item != "")
                    {
                        Choices newChoice = new Choices
                        {
                            Choice = item,
                            PollID = currentPoll.ID,
                            Poll = currentPoll,
                            Votes = 0
                        };
                        context.Choices.Add(newChoice);
                        context.SaveChanges();
                    }
                }

                List<Choices> currentPollChoices = context.Choices.Where(p => p.PollID == currentPoll.ID).ToList();
                foreach (Choices choice in currentPollChoices)
                {
                    currentPoll.Choices.Add(choice);
                    context.SaveChanges();
                }
                           
                
                return Redirect("/Poll/ID/" + currentPoll.ID + "/Results");
            }
            return View(newPollViewModel);
        }

        [Route("/Poll/ID/{id}")]
        public IActionResult Polls(int id)
        {
            Polls currentPoll = context.Polls.Single(c => c.ID == id);
            List<Choices> currentChoices = context.Choices.Where(d => d.PollID == id).ToList();
            PollVotingViewModel pollVotingViewModel = new PollVotingViewModel(currentPoll, currentChoices);
            return View(pollVotingViewModel);
        }

        [HttpPost]
        [Route("/Poll/ID/{id}")]
        public IActionResult Polls(PollVotingViewModel pollVotingViewModel)
        {
            if (ModelState.IsValid)
            {
                Polls currentPoll = context.Polls.Single(c => c.ID == pollVotingViewModel.ID);
                List<Choices> currentChoices = context.Choices.Where(d => d.PollID == pollVotingViewModel.ID).ToList();
                for (int i = 0; i <= currentChoices.Count; i++)
                {
                    if (pollVotingViewModel.ChoiceSelected == i.ToString())
                    {
                        currentChoices[i].Votes++;
                        currentPoll.Total++;
                        context.SaveChanges();
                        break;
                    }
                }
                return Redirect("/Poll/ID/" + pollVotingViewModel.ID + "/Results");
            }
            return Redirect("/Poll/ID/" + pollVotingViewModel.ID);
        }

        [Route("/Poll/ID/{id}/Results")]
        public IActionResult Results(int id)
        {
            Polls currentPoll = context.Polls.Single(c => c.ID == id);
            ViewBag.currentPoll = currentPoll;
            List<Choices> currentChoices = context.Choices.Where(d => d.PollID == id).ToList();
            ViewBag.currentChoices = new Dictionary<Choices, float>();
            foreach (var vote in currentChoices)
            {
                ViewBag.currentChoices.Add(vote, (float)vote.Votes / currentPoll.Total * 100);
            }
            return View();
        }
    }
}
