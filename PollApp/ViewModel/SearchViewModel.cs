using PollApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PollApp.ViewModel
{
    public class SearchViewModel
    {
        public List<Polls> Polls { get; set; } = new List<Models.Polls>();

        public string Column { get; set; } = "All";

        public string Value { get; set; }

        public SearchViewModel()
        { }
    }
}
