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
        public List<string> PollChoices { get; set; }
        public string Category { get; set; }
        public string Creator { get; set; }

        [Required]
        public String ChoiceSelected { get; set; }
        public DateTime DateCreated { get; set; }
        public PollVotingViewModel()
        {}

        public PollVotingViewModel(Polls poll, List<Choices> choices)
        {
            ID = poll.ID;
            Title = poll.Title;
            Category = poll.Catagory;
            DateCreated = poll.DateCreated;
            PollChoices = new List<string>();
            foreach (Choices choice in choices)
            {
                PollChoices.Add(choice.Choice);
            }
        }
    }
}
