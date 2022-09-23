using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InstantLoan.DAL.Migrations
{
    public partial class v112 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "birthday",
                table: "Client",
                newName: "Birthday");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Birthday",
                table: "Client",
                newName: "birthday");
        }
    }
}
