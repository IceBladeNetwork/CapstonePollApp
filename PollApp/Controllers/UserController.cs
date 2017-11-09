using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using PollApp.Data;
using PollApp.Models;
using Microsoft.AspNetCore.Authorization;
using PollApp.ViewModel;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PollApp.Controllers
{   
    [Authorize]
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
            var vm = new ManagePollViewModel
            {
                Polls = context.Polls.Where(c => c.Creator == HttpContext.User.Identity.Name.ToString()).ToList()
            };
            return View(vm);
        }

        public IActionResult Del(string id)
        {
            var poll = GetPollById(id);
            var vm = new ManagePollViewModel
            {
                Polls = context.Polls.Where(c => c.Creator == HttpContext.User.Identity.Name.ToString()).ToList()
            };
            if (poll.Creator == HttpContext.User.Identity.Name)
            {
                context.Polls.Remove(poll);
                context.SaveChanges();
                ModelState.AddModelError("", "Success!");
            }
            return Redirect("/User");
        }

        public IActionResult Update(string id)
        {
            var poll = GetPollById(id);
            if (poll.Creator == HttpContext.User.Identity.Name)
            {
                var vm = new UpdatePollViewModel
                {
                    CurrentChoices = GetChoicesByPollId(id),
                    CurrentPoll = poll
                };
                return View(vm);
            }
                return View("Index");
        }

        [HttpPost]
        public IActionResult Update(UpdatePollViewModel vm)
        {
            if (ModelState.IsValid && vm.Choices[0] != null)
            {
                var currentPoll = GetPollById(vm.PollId.ToString());
                foreach (var item in vm.Choices)
                {
                    if (item != null)
                    {
                        Choices newChoice = new Choices
                        {
                            Choice = item,
                            PollID = vm.PollId,
                            Poll = currentPoll,
                            Votes = 0
                        };
                        context.Choices.Add(newChoice);
                        context.SaveChanges();
                    }
                }
                return Redirect("/Poll/ID/" + vm.PollId + "/Results");
            }
            if (vm.Choices[0] == null)
            {
                ModelState.AddModelError("", "The first box is empty! D:");
            }
            vm.CurrentChoices = GetChoicesByPollId(vm.PollId.ToString());
            vm.CurrentPoll = GetPollById(vm.PollId.ToString());
            return View("Update", vm);
        }

        public Polls GetPollById(string id) => context.Polls.Single(c => c.ID == Int32.Parse(id));

        public List<string> GetChoicesByPollId(string id) => context.Choices.Where(d => d.PollID == Int32.Parse(id)).Select(c => c.Choice).ToList();
    }
}
