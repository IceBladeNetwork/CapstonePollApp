using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PollApp.Migrations
{
    public partial class ReadyForMonday : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPoll_Polls_PollId",
                table: "UserPoll");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPoll_AspNetUsers_UserId1",
                table: "UserPoll");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserPoll",
                table: "UserPoll");

            migrationBuilder.RenameTable(
                name: "UserPoll",
                newName: "UserPolls");

            migrationBuilder.RenameIndex(
                name: "IX_UserPoll_UserId1",
                table: "UserPolls",
                newName: "IX_UserPolls_UserId1");

            migrationBuilder.AddColumn<int>(
                name: "Votes",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserPolls",
                table: "UserPolls",
                columns: new[] { "PollId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserPolls_Polls_PollId",
                table: "UserPolls",
                column: "PollId",
                principalTable: "Polls",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPolls_AspNetUsers_UserId1",
                table: "UserPolls",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPolls_Polls_PollId",
                table: "UserPolls");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPolls_AspNetUsers_UserId1",
                table: "UserPolls");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserPolls",
                table: "UserPolls");

            migrationBuilder.DropColumn(
                name: "Votes",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "UserPolls",
                newName: "UserPoll");

            migrationBuilder.RenameIndex(
                name: "IX_UserPolls_UserId1",
                table: "UserPoll",
                newName: "IX_UserPoll_UserId1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserPoll",
                table: "UserPoll",
                columns: new[] { "PollId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserPoll_Polls_PollId",
                table: "UserPoll",
                column: "PollId",
                principalTable: "Polls",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPoll_AspNetUsers_UserId1",
                table: "UserPoll",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
