using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndAPI.Migrations
{
    public partial class updateUserclassandCaseclassv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Charities_CharityId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_CharityId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CharityId",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CharityId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_CharityId",
                table: "Users",
                column: "CharityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Charities_CharityId",
                table: "Users",
                column: "CharityId",
                principalTable: "Charities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
