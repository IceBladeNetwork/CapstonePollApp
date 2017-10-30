using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using PollApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PollApp.Configuration
{
    public class UserRoleSeed
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public UserRoleSeed(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
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
        }
    }
}
