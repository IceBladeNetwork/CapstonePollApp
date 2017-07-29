using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PollApp.ViewModel
{
    public class NewCategoryViewModel
    {
        [Required]
        public string Category { get; set; }

        public NewCategoryViewModel()
        { }
    }
}
