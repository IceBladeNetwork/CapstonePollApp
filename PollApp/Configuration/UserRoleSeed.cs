using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using PollApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PollApp.Models;

namespace PollApp.Configuration
{
    public class UserRoleSeed
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<User> userManager;
        

        public UserRoleSeed(RoleManager<IdentityRole> roleManager, ApplicationDbContext dbContext, UserManager<User> userManager)
        {
            this.roleManager = roleManager;
            this.dbContext = dbContext;
            this.userManager = userManager;
            
        }

        public async void Seed()
        {
            if ((await roleManager.FindByNameAsync("Member")) == null)
            {
                await roleManager.CreateAsync(new IdentityRole { Name = "Member" });
            }

            if ((await roleManager.FindByNameAsync("Admin")) == null)
            {
                await roleManager.CreateAsync(new IdentityRole { Name = "Admin"});
            }

            if (await userManager.FindByNameAsync("icebladenetwork") == null) 
            {
                var user = new User { UserName = "IceBladeNetwork", Email = "theicebladenetwork@gmail.com" };
                await userManager.CreateAsync(user, "Passw0rd!");
                await userManager.AddToRoleAsync(user, "Admin");
            }

            if (!dbContext.Categories.Any(c => c.Category == "Programming")) 
            {
                Categories newCategories = new Categories
                {
                    Category = "Programming"
                };
                dbContext.Categories.Add(newCategories);
                dbContext.SaveChanges();
            }

            if (!dbContext.Categories.Any(c => c.Category == "Gaming")) 
            {
                Categories newCategories = new Categories
                {
                    Category = "Gaming"
                };
                dbContext.Categories.Add(newCategories);
                dbContext.SaveChanges();
            }

            if (!dbContext.Categories.Any(c => c.Category == "Movies")) 
            {
                Categories newCategories = new Categories
                {
                    Category = "Movies"
                };
                dbContext.Categories.Add(newCategories);
                dbContext.SaveChanges();
            }

            if (!dbContext.Categories.Any(c => c.Category == "TV")) 
            {
                Categories newCategories = new Categories
                {
                    Category = "TV"
                };
                dbContext.Categories.Add(newCategories);
                dbContext.SaveChanges();
            }

            if (!dbContext.Polls.Any(c => c.Title == "Best Programming languge for Desktop Apps")) 
            {
                Polls newPoll = new Polls 
                {
                    Title = "Best Programming languge for Desktop Apps",
                    Catagory = "Programming",
                    Creator = "IceBladeNetwork",
                    DateCreated = DateTime.Now,
                    Total = 0
                };
                dbContext.Polls.Add(newPoll);
                dbContext.SaveChanges();
                Polls currentPoll = dbContext.Polls.OrderByDescending(d => d.DateCreated).ToList()[0];
                string[] choices = 
                {
                    "C++",
                    "C#",
                    "Java",
                    "Electron",
                    "Python"
                };
                foreach (var item in choices) {
                    if (item != null)
                    {
                        Choices newChoice = new Choices
                        {
                            Choice = item,
                            PollID = currentPoll.ID,
                            Poll = currentPoll,
                            Votes = 0
                        };
                        dbContext.Choices.Add(newChoice);
                        dbContext.SaveChanges();
                    }
                }
            }

            if (!dbContext.Polls.Any(c => c.Title == "Best Programming languge for Web Apps")) 
            {
                Polls newPoll = new Polls 
                {
                    Title = "Best Programming languge for Web Apps",
                    Catagory = "Programming",
                    Creator = "IceBladeNetwork",
                    DateCreated = DateTime.Now,
                    Total = 0
                };
                dbContext.Polls.Add(newPoll);
                dbContext.SaveChanges();
                Polls currentPoll = dbContext.Polls.OrderByDescending(d => d.DateCreated).ToList()[0];
                string[] choices = 
                {
                    "PHP",
                    "C#",
                    "Java",
                    "Ruby",
                    "Javascript",
                    "Python"
                };
                foreach (var item in choices) {
                    if (item != null)
                    {
                        Choices newChoice = new Choices
                        {
                            Choice = item,
                            PollID = currentPoll.ID,
                            Poll = currentPoll,
                            Votes = 0
                        };
                        dbContext.Choices.Add(newChoice);
                        dbContext.SaveChanges();
                    }
                }
            }

            if (!dbContext.Polls.Any(c => c.Title == "Best Game of 2016")) 
            {
                Polls newPoll = new Polls 
                {
                    Title = "Best Game of 2016",
                    Catagory = "Gaming",
                    Creator = "IceBladeNetwork",
                    DateCreated = DateTime.Now,
                    Total = 0
                };
                dbContext.Polls.Add(newPoll);
                dbContext.SaveChanges();
                Polls currentPoll = dbContext.Polls.OrderByDescending(d => d.DateCreated).ToList()[0];
                string[] choices = 
                {
                    "Inside",
                    "Titanfall 2",
                    "Overwatch",
                    "Dark Souls III",
                    "Stardew Valley"
                };

                foreach (var item in choices) {
                    if (item != null)
                    {
                        Choices newChoice = new Choices
                        {
                            Choice = item,
                            PollID = currentPoll.ID,
                            Poll = currentPoll,
                            Votes = 0
                        };
                        dbContext.Choices.Add(newChoice);
                        dbContext.SaveChanges();
                    }
                }
            }

            if (!dbContext.Polls.Any(c => c.Title == "Best New TV Show of 2016")) 
            {
                Polls newPoll = new Polls 
                {
                    Title = "Best New TV Show of 2016",
                    Catagory = "TV",
                    Creator = "IceBladeNetwork",
                    DateCreated = DateTime.Now,
                    Total = 0
                };
                dbContext.Polls.Add(newPoll);
                dbContext.SaveChanges();
                Polls currentPoll = dbContext.Polls.OrderByDescending(d => d.DateCreated).ToList()[0];
                string[] choices = 
                {
                    "Trollhunters",
                    "Voltron",
                    "Stranger Things"
                };

                foreach (var item in choices) {
                    if (item != null)
                    {
                        Choices newChoice = new Choices
                        {
                            Choice = item,
                            PollID = currentPoll.ID,
                            Poll = currentPoll,
                            Votes = 0
                        };
                        dbContext.Choices.Add(newChoice);
                        dbContext.SaveChanges();
                    }
                }
            }

            if (!dbContext.Polls.Any(c => c.Title == "Best Movie of 2016")) 
            {
                Polls newPoll = new Polls 
                {
                    Title = "Best Movie of 2016",
                    Catagory = "Movies",
                    Creator = "IceBladeNetwork",
                    DateCreated = DateTime.Now,
                    Total = 0
                };
                dbContext.Polls.Add(newPoll);
                dbContext.SaveChanges();
                Polls currentPoll = dbContext.Polls.OrderByDescending(d => d.DateCreated).ToList()[0];
                string[] choices = 
                {
                    "Rouge One",
                    "Deadpool",
                    "Zootopia",
                    "Passengers",
                };

                foreach (var item in choices) {
                    if (item != null)
                    {
                        Choices newChoice = new Choices
                        {
                            Choice = item,
                            PollID = currentPoll.ID,
                            Poll = currentPoll,
                            Votes = 0
                        };
                        dbContext.Choices.Add(newChoice);
                        dbContext.SaveChanges();
                    }
                }
            }
        }
    }
}
