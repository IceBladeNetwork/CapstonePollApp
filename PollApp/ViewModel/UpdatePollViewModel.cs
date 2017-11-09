using PollApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PollApp.ViewModel
{
    public class UpdatePollViewModel : NewPollViewModel
    {
        public Polls CurrentPoll { get; set; }

        public List<String> CurrentChoices { get; set; }

        [Required]
        public int PollId { get; set; }
    }
}
