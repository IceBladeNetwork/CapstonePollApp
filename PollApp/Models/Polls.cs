using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PollApp.Models
{
    public class Polls
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public IList<Choices> Choices { get; set; }
        public int Total { get; set; }
        public int UserID { get; set; }
        public Users User { get; set; }
        public string Catagory { get; set; }
        public DateTime DateCreated { get; set; }
        public List<Users> CantVote { get; set; }
    }
}
