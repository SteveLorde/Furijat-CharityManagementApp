using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndAPI.Migrations
{
    public partial class AddedCreditorCases : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CreditorCases",
                columns: table => new
                {
                    CreditorID = table.Column<int>(type: "int", nullable: false),
                    CaseID = table.Column<int>(type: "int", nullable: false),
                    Deserves_Debt = table.Column<int>(type: "int", nullable: false),
                    CreditorCaseID = table.Column<int>(type: "int", nullable: false),
                    CreditorID1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditorCases", x => new { x.CaseID, x.CreditorID });
                    table.ForeignKey(
                        name: "FK_CreditorCases_Cases_CaseID",
                        column: x => x.CaseID,
                        principalTable: "Cases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CreditorCases_Creditor_CreditorID1_CreditorCaseID",
                        columns: x => new { x.CreditorID1, x.CreditorCaseID },
                        principalTable: "Creditor",
                        principalColumns: new[] { "CreditorID", "CaseID" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CreditorCases_CreditorID1_CreditorCaseID",
                table: "CreditorCases",
                columns: new[] { "CreditorID1", "CreditorCaseID" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreditorCases");
        }
    }
}
