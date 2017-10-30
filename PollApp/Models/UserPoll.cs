using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PollApp.Models
{
    public class UserPoll {
        public int PollId { get; set; }
        public Polls Poll { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}
