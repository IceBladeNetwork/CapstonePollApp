using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using PollApp.Data;

namespace PollApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20171026084855_NewInstall")]
    partial class NewInstall
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PollApp.Models.Categories", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Category");

                    b.HasKey("ID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("PollApp.Models.Choices", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Choice");

                    b.Property<int>("PollID");

                    b.Property<int>("Votes");

                    b.HasKey("ID");

                    b.HasIndex("PollID");

                    b.ToTable("Choices");
                });

            modelBuilder.Entity("PollApp.Models.Polls", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Catagory");

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Title");

                    b.Property<int>("Total");

                    b.HasKey("ID");

                    b.ToTable("Polls");
                });

            modelBuilder.Entity("PollApp.Models.Choices", b =>
                {
                    b.HasOne("PollApp.Models.Polls", "Poll")
                        .WithMany("Choices")
                        .HasForeignKey("PollID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
