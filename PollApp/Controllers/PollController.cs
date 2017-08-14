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
                string category = context.Categories.Single(c => c.ID == newPollViewModel.CateID).Category;
                Polls newPoll = new Polls
                {
                    Title = newPollViewModel.Title,
                    Choice = newPollViewModel.Choice,
                    Choice2 = newPollViewModel.Choice2,
                    Choice3 = newPollViewModel.Choice3,
                    Choice4 = newPollViewModel.Choice4,
                    ChoiceVotes = 0,
                    Choice2Votes = 0,
                    Choice3Votes = 0,
                    Choice4Votes = 0,
                    Total = 0,
                    Catagory = category,
                    DateCreated = DateTime.Now
                };

                context.Polls.Add(newPoll);
                context.SaveChanges();

                int newId = context.Polls.OrderByDescending(d => d.DateCreated).ToList()[0].ID;
                return Redirect("/Poll/ID/" + newId + "/Results");
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
                if (pollVotingViewModel.ChoiceSelected == "1")
                {
                    
                    currentPoll.ChoiceVotes++;
                    currentPoll.Total++;
                    context.SaveChanges();
                    return Redirect("/Poll/ID/" + pollVotingViewModel.ID + "/Results");
                }
                if (pollVotingViewModel.ChoiceSelected == "2")
                {
                    
                    currentPoll.Choice2Votes++;
                    currentPoll.Total++;
                    context.SaveChanges();
                    return Redirect("/Poll/ID/" + pollVotingViewModel.ID + "/Results");
                }
                if (pollVotingViewModel.ChoiceSelected == "3")
                {
                    
                    currentPoll.Choice3Votes++;
                    currentPoll.Total++;
                    context.SaveChanges();
                    return Redirect("/Poll/ID/" + pollVotingViewModel.ID + "/Results");
                }
                if (pollVotingViewModel.ChoiceSelected == "4")
                {
                    
                    currentPoll.Choice4Votes++;
                    currentPoll.Total++;
                    context.SaveChanges();
                    return Redirect("/Poll/ID/" + pollVotingViewModel.ID + "/Results");
                }
                return Redirect(pollVotingViewModel.ID.ToString());
            }
            return Redirect(pollVotingViewModel.ID.ToString());
        }

        [Route("/Poll/ID/{id}/Results")]
        public IActionResult Results(int id)
        {
            Polls currentPoll = context.Polls.Single(c => c.ID == id);
            ViewBag.currentPoll = currentPoll;
            List<float> percent = new List<float>
            {
                (currentPoll.ChoiceVotes / (float)currentPoll.Total) * 100,
                (currentPoll.Choice2Votes / (float)currentPoll.Total) * 100,
                (currentPoll.Choice3Votes / (float)currentPoll.Total) * 100,
                (currentPoll.Choice4Votes / (float)currentPoll.Total) * 100
            };
            ViewBag.percent = percent;
            return View();
        }
    }
}
