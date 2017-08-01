using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using PollApp.Data;

namespace PollApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PollApp.Models.Categories", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Category");

                    b.HasKey("ID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("PollApp.Models.Polls", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Catagory");

                    b.Property<string>("Choice");

                    b.Property<string>("Choice2");

                    b.Property<int>("Choice2Votes");

                    b.Property<string>("Choice3");

                    b.Property<int>("Choice3Votes");

                    b.Property<string>("Choice4");

                    b.Property<int>("Choice4Votes");

                    b.Property<int>("ChoiceVotes");

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Title");

                    b.Property<int>("Total");

                    b.HasKey("ID");

                    b.ToTable("Polls");
                });
        }
    }
}
