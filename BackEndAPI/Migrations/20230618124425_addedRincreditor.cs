using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndAPI.Migrations
{
    public partial class addedRincreditor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Creditor_CaseID",
                table: "Creditor",
                column: "CaseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Creditor_Cases_CaseID",
                table: "Creditor",
                column: "CaseID",
                principalTable: "Cases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Creditor_Cases_CaseID",
                table: "Creditor");

            migrationBuilder.DropIndex(
                name: "IX_Creditor_CaseID",
                table: "Creditor");
        }
    }
}
