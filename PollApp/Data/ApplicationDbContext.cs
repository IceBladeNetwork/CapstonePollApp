using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PollApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace PollApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Polls> Polls { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Choices> Choices { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }
    }
}
