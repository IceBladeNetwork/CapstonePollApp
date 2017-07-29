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
        public string Choice { get; set; }
        public int ChoiceVotes { get; set; }
        public string Choice2 { get; set; }
        public int Choic2eVotes { get; set; }
        public string Choice3 { get; set; }
        public int Choice3Votes { get; set; }
        public string Choice4 { get; set; }
        public int Choice4Votes { get; set; }
        public int Total { get; set; }
        public string Catagory { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
