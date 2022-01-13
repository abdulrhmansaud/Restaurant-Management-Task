using Microsoft.EntityFrameworkCore.Migrations;

namespace Restaurant_Management_Task.Migrations
{
    public partial class InitialAddUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reservations_menuTypes_MenuTypeId",
                table: "reservations");

            migrationBuilder.AlterColumn<int>(
                name: "MenuTypeId",
                table: "reservations",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "string",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "reservations",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_reservations_menuTypes_MenuTypeId",
                table: "reservations",
                column: "MenuTypeId",
                principalTable: "menuTypes",
                principalColumn: "MenuTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reservations_menuTypes_MenuTypeId",
                table: "reservations");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "reservations");

            migrationBuilder.AlterColumn<int>(
                name: "MenuTypeId",
                table: "reservations",
                type: "string",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_reservations_menuTypes_MenuTypeId",
                table: "reservations",
                column: "MenuTypeId",
                principalTable: "menuTypes",
                principalColumn: "MenuTypeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
