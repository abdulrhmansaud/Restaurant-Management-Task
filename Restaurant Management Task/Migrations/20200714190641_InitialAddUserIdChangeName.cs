using Microsoft.EntityFrameworkCore.Migrations;

namespace Restaurant_Management_Task.Migrations
{
    public partial class InitialAddUserIdChangeName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "reservations");

            migrationBuilder.AddColumn<string>(
                name: "UserIdforToken",
                table: "reservations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserIdforToken",
                table: "reservations");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "reservations",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
