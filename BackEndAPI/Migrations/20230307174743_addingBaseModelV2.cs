using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndAPI.Migrations
{
    public partial class addingBaseModelV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserTypeId",
                table: "UserType",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CharityId",
                table: "Charities",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CasePaymentId",
                table: "CasePayments",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserType",
                newName: "UserTypeId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Charities",
                newName: "CharityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CasePayments",
                newName: "CasePaymentId");
        }
    }
}
