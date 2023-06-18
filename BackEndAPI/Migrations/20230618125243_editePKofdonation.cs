using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndAPI.Migrations
{
    public partial class editePKofdonation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Donation",
                table: "Donation");

            migrationBuilder.DropIndex(
                name: "IX_Donation_CaseID",
                table: "Donation");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Donation");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Donation",
                table: "Donation",
                columns: new[] { "CaseID", "DonatorID", "CharityID" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Donation",
                table: "Donation");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Donation",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Donation",
                table: "Donation",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Donation_CaseID",
                table: "Donation",
                column: "CaseID");
        }
    }
}
