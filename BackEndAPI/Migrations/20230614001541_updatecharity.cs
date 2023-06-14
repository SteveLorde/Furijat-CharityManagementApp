using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndAPI.Migrations
{
    public partial class updatecharity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdminID",
                table: "Charities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Bank_Account",
                table: "Charities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "Charities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Charities_AdminID",
                table: "Charities",
                column: "AdminID");

            migrationBuilder.AddForeignKey(
                name: "FK_Charities_Admin_AdminID",
                table: "Charities",
                column: "AdminID",
                principalTable: "Admin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Charities_Admin_AdminID",
                table: "Charities");

            migrationBuilder.DropIndex(
                name: "IX_Charities_AdminID",
                table: "Charities");

            migrationBuilder.DropColumn(
                name: "AdminID",
                table: "Charities");

            migrationBuilder.DropColumn(
                name: "Bank_Account",
                table: "Charities");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "Charities");
        }
    }
}
