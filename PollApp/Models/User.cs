using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PollApp.Models
{
    public class User : IdentityUser
    {
        public List<UserPoll> CantVoteIn { get; set; } = new List<UserPoll>();
        
        public int Votes { get; set; }
    }
}
