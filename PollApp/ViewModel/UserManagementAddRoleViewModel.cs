using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using PollApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PollApp.ViewModel
{
    public class UserManagementAddRoleViewModel
    {
        public string UserId { get; set; }

        public string NewRole { get; set; }

        public IEnumerable<SelectListItem> Roles { get; set; }

        public string User { get; set; }
    }
}
