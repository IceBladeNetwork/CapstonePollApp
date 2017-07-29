using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PollApp.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Polls",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Catagory = table.Column<string>(nullable: true),
                    Choic2eVotes = table.Column<int>(nullable: false),
                    Choice = table.Column<string>(nullable: true),
                    Choice2 = table.Column<string>(nullable: true),
                    Choice3 = table.Column<string>(nullable: true),
                    Choice3Votes = table.Column<int>(nullable: false),
                    Choice4 = table.Column<string>(nullable: true),
                    Choice4Votes = table.Column<int>(nullable: false),
                    ChoiceVotes = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Total = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polls", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Polls");
        }
    }
}
