using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndAPI.Migrations
{
    public partial class addingBaseModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CasePayments_Cases_CasesCaseId",
                table: "CasePayments");

            migrationBuilder.RenameColumn(
                name: "CaseId",
                table: "Cases",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CasesCaseId",
                table: "CasePayments",
                newName: "CasesId");

            migrationBuilder.RenameIndex(
                name: "IX_CasePayments_CasesCaseId",
                table: "CasePayments",
                newName: "IX_CasePayments_CasesId");

            migrationBuilder.AddForeignKey(
                name: "FK_CasePayments_Cases_CasesId",
                table: "CasePayments",
                column: "CasesId",
                principalTable: "Cases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CasePayments_Cases_CasesId",
                table: "CasePayments");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Cases",
                newName: "CaseId");

            migrationBuilder.RenameColumn(
                name: "CasesId",
                table: "CasePayments",
                newName: "CasesCaseId");

            migrationBuilder.RenameIndex(
                name: "IX_CasePayments_CasesId",
                table: "CasePayments",
                newName: "IX_CasePayments_CasesCaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_CasePayments_Cases_CasesCaseId",
                table: "CasePayments",
                column: "CasesCaseId",
                principalTable: "Cases",
                principalColumn: "CaseId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
