using PollApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PollApp.ViewModel
{
    public class PollVotingViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Choice { get; set; }
        public string Choice2 { get; set; }
        public string Choice3 { get; set; }
        public string Choice4 { get; set; }
        public string Category { get; set; }

        [Required]
        public string ChoiceSelected { get; set; }
        public DateTime DateCreated { get; set; }
        public PollVotingViewModel()
        {}

        public PollVotingViewModel(Polls poll)
        {
            ID = poll.ID;
            Title = poll.Title;
            Choice = poll.Choice;
            Choice2 = poll.Choice2;
            Choice3 = poll.Choice3;
            Choice4 = poll.Choice4;
            Category = poll.Catagory;
            DateCreated = poll.DateCreated;
        }
    }
}
