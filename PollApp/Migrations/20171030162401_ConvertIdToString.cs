using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PollApp.Migrations
{
    public partial class ConvertIdToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPolls_AspNetUsers_UserId1",
                table: "UserPolls");

            migrationBuilder.DropIndex(
                name: "IX_UserPolls_UserId1",
                table: "UserPolls");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserPolls");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserPolls",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_UserPolls_UserId",
                table: "UserPolls",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPolls_AspNetUsers_UserId",
                table: "UserPolls",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPolls_AspNetUsers_UserId",
                table: "UserPolls");

            migrationBuilder.DropIndex(
                name: "IX_UserPolls_UserId",
                table: "UserPolls");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserPolls",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "UserPolls",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserPolls_UserId1",
                table: "UserPolls",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPolls_AspNetUsers_UserId1",
                table: "UserPolls",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
