using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndAPI.Migrations
{
    public partial class addFKindonator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Donators",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Donators_UserId",
                table: "Donators",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Donators_Users_UserId",
                table: "Donators",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donators_Users_UserId",
                table: "Donators");

            migrationBuilder.DropIndex(
                name: "IX_Donators_UserId",
                table: "Donators");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Donators");
        }
    }
}
