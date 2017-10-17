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
        public List<Choices> Choices { get; set; } = new List<Models.Choices>();
        public int Total { get; set; }
        public string Catagory { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
