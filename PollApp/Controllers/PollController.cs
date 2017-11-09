using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PollApp.Models;
using PollApp.ViewModel;
using PollApp.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PollApp.Controllers
{
    [Authorize]
    public class PollController : Controller
    {
        private ApplicationDbContext context;
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;

        public PollController(ApplicationDbContext dbContext, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            context = dbContext;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Member, Admin")]
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
            if (ModelState.IsValid && (newPollViewModel.Choices[0] != null && newPollViewModel.Choices[1] != null))
            {
                string category = context.Categories.Single(c => c.ID == newPollViewModel.CateId).Category;
                Polls newPoll = new Polls
                {
                    Title = newPollViewModel.Title,
                    Catagory = category,
                    Creator = HttpContext.User.Identity.Name,
                    DateCreated = DateTime.Now,
                    Total = 0
                };
                context.Polls.Add(newPoll);
                context.SaveChanges();
                Polls currentPoll = context.Polls.OrderByDescending(d => d.DateCreated).ToList()[0];
                foreach (var item in newPollViewModel.Choices) {
                    if (item != null)
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
            foreach (var field in context.Categories.ToList())
            {
                newPollViewModel.CategoriesList.Add(new SelectListItem
                {
                    Value = field.ID.ToString(),
                    Text = field.Category
                });
            }
            if (newPollViewModel.Choices[0] == null || newPollViewModel.Choices[1] == null)
            {
                ModelState.AddModelError("", "You need atleast 2 choices!");
            }
            return View(newPollViewModel);
        }

        [Route("/Poll/ID/{id}")]
        public async Task<IActionResult> Polls(int id)
        {
            var cantVote = context.UserPolls.Where(p => p.PollId == id).Select(u => u.UserId).ToList();
            var currentUser = await GetUserByName(HttpContext.User.Identity.Name);
            if (!cantVote.Contains(currentUser.Id))
            {
                Polls currentPoll = context.Polls.Single(c => c.ID == id);
                List<Choices> currentChoices = context.Choices.Where(d => d.PollID == id).ToList();
                PollVotingViewModel pollVotingViewModel = new PollVotingViewModel(currentPoll, currentChoices);
                pollVotingViewModel.Creator = currentPoll.Creator;
                return View(pollVotingViewModel);
            }
            return Redirect("/Poll/ID/" + id + "/Results");
        }

        [HttpPost]
        [Route("/Poll/ID/{id}")]
        public async Task<IActionResult> Polls(PollVotingViewModel pollVotingViewModel)
        {
            if (ModelState.IsValid)
            {
                var currentUser = await GetUserByName(HttpContext.User.Identity.Name);
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

                var newUserPoll = new UserPoll
                {
                    UserId = currentUser.Id,
                    User = currentUser,
                    PollId = pollVotingViewModel.ID,
                    Poll = currentPoll

                };
                context.UserPolls.Add(newUserPoll);
                var user = context.Users.Single(c => c.UserName == HttpContext.User.Identity.Name);
                user.Votes++;
                context.SaveChanges();
                if (currentUser.Votes == 5)
                {
                    await userManager.AddToRoleAsync(currentUser, "Member");
                }
                
                return Redirect("/Poll/ID/" + pollVotingViewModel.ID + "/Results");
            }
            return Redirect("/Poll/ID/" + pollVotingViewModel.ID);
        }

        [AllowAnonymous]
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

        private async Task<User> GetUserByName(string name) => await userManager.FindByNameAsync(name);

    }
}
