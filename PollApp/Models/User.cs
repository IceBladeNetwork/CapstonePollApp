using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PollApp.Models
{
    public class User
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Votes { get; set; }
        public bool IsCreator { get; set; }
        public bool IsAdmin { get; set; }
        public List<Polls> Polls { get; set; }
    }
}
