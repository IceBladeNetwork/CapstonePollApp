using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PollApp.Models
{
    public class Choices
    {
        public int ID { get; set; }
        public string Choice { get; set; }
        public int PollID { get; set; }
    }
}
