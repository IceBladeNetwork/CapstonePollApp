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
    public class SearchController : Controller
    {
        private ApplicationDbContext context;

        public SearchController(ApplicationDbContext dbContext)
        {

            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            SearchViewModel searchViewModel = new SearchViewModel();
            ViewBag.Title = "Search";
            return View(searchViewModel);
        }

        public IActionResult Results(SearchViewModel searchViewModel)
        {
            if (searchViewModel.Value != null)
            {
                List<Polls> pollList = context.Polls.ToList();
                List<int> idList = new List<int>();
                if (searchViewModel.Column.ToLower() == "Title".ToLower() || searchViewModel.Column.ToLower() == "Category".ToLower() || searchViewModel.Column.ToLower() == "All".ToLower())
                {
                    foreach (Polls poll in pollList)
                    {
                        if (poll.Title.ToLower().Contains(searchViewModel.Value.ToLower()))
                        {
                            searchViewModel.Polls.Add(poll);
                            idList.Add(poll.ID);
                        }
                        else if (poll.Catagory.ToLower().Contains(searchViewModel.Value.ToLower()))
                        {
                            searchViewModel.Polls.Add(poll);
                            idList.Add(poll.ID);
                        }
                        else if (poll.Creator.ToLower().Contains(searchViewModel.Value.ToLower()))
                        {
                            searchViewModel.Polls.Add(poll);
                            idList.Add(poll.ID);
                        }
                    }
                }
                if (searchViewModel.Column.ToLower() == "All".ToLower() || searchViewModel.Column.ToLower() == "Choice".ToLower())
                {
                    List<Choices> choiceList = context.Choices.ToList();
                    foreach (Choices choice in choiceList)
                    {
                        if (choice.Choice.ToLower().Contains(searchViewModel.Value.ToLower()) && !idList.Contains(choice.PollID))
                        {
                            searchViewModel.Polls.Add(pollList.Single(c => c.ID == choice.ID));
                            idList.Add(choice.PollID);

                        }
                    }
                }
                return View("Index", searchViewModel);
            }
            return Redirect("/search");
        }
    }
}
