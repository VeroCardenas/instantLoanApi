using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InstantLoan.DAL.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Client");

            migrationBuilder.AddColumn<DateTime>(
                name: "birthday",
                table: "Client",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "birthday",
                table: "Client");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Client",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
