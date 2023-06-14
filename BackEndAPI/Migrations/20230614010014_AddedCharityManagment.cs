using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndAPI.Migrations
{
    public partial class AddedCharityManagment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Creditor_Cases_CaseID",
                table: "Creditor");

            migrationBuilder.DropIndex(
                name: "IX_Creditor_CaseID",
                table: "Creditor");

            migrationBuilder.CreateTable(
                name: "CharityManagment",
                columns: table => new
                {
                    CreditorID = table.Column<int>(type: "int", nullable: false),
                    CharityID = table.Column<int>(type: "int", nullable: false),
                    CaseID = table.Column<int>(type: "int", nullable: false),
                    Deserves_Debt = table.Column<int>(type: "int", nullable: false),
                    PaidAmount = table.Column<int>(type: "int", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreditorCaseID = table.Column<int>(type: "int", nullable: false),
                    CreditorID1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharityManagment", x => new { x.CaseID, x.CharityID, x.CreditorID });
                    table.ForeignKey(
                        name: "FK_CharityManagment_Cases_CaseID",
                        column: x => x.CaseID,
                        principalTable: "Cases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharityManagment_Charities_CharityID",
                        column: x => x.CharityID,
                        principalTable: "Charities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharityManagment_Creditor_CreditorID1_CreditorCaseID",
                        columns: x => new { x.CreditorID1, x.CreditorCaseID },
                        principalTable: "Creditor",
                        principalColumns: new[] { "CreditorID", "CaseID" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharityManagment_CharityID",
                table: "CharityManagment",
                column: "CharityID");

            migrationBuilder.CreateIndex(
                name: "IX_CharityManagment_CreditorID1_CreditorCaseID",
                table: "CharityManagment",
                columns: new[] { "CreditorID1", "CreditorCaseID" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharityManagment");

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
    }
}
