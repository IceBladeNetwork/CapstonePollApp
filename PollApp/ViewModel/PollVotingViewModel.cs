using PollApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PollApp.ViewModel
{
    public class PollVotingViewModel
    {
        public string Title { get; set; }
        public string Choice { get; set; }
        public string Choice2 { get; set; }
        public string Choice3 { get; set; }
        public string Choice4 { get; set; }
        public string Catagory { get; set; }
        public bool ChoiceSelected { get; set; }
        public bool Choice2Selected { get; set; }
        public bool Choice3Selected { get; set; }
        public bool Choice4Selected { get; set; }
        public PollVotingViewModel()
        {}

        public PollVotingViewModel(Polls poll)
        {
            Title = poll.Title;
            Choice = poll.Choice;
            Choice2 = poll.Choice2;
            Choice3 = poll.Choice3;
            Choice4 = poll.Choice4;
            Catagory = poll.Catagory;
        }
    }
}
