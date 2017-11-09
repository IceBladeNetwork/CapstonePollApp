using Microsoft.AspNetCore.Mvc.Rendering;
using PollApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PollApp.ViewModel
{
    public class NewPollViewModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public List<string> Choices { get; set; }

        [Display(Name = "Category")]
        public int CateId { get; set; }

        public List<SelectListItem> CategoriesList { get; set; } = new List<SelectListItem>();

        public NewPollViewModel()
        { }

        public NewPollViewModel(IEnumerable<Categories> cateList)
        {
            foreach (var field in cateList)
            {
                CategoriesList.Add(new SelectListItem
                {
                    Value = field.ID.ToString(),
                    Text = field.Category
                });
            }
        }
    }
}