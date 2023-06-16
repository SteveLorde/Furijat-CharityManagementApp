using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndAPI.Migrations
{
    public partial class Intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Creditor",
                columns: table => new
                {
                    CreditorID = table.Column<int>(type: "int", nullable: false),
                    CaseID = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Payment_Account = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deserves_Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Creditor", x => new { x.CreditorID, x.CaseID });
                });

            migrationBuilder.CreateTable(
                name: "Charities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Bank_Account = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Charities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastNaame = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CharityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Charities_CharityId",
                        column: x => x.CharityId,
                        principalTable: "Charities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admin_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MarriageStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cases_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Donatores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaidAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donatores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Donatores_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateTable(
                name: "CharityDonators",
                columns: table => new
                {
                    CharityID = table.Column<int>(type: "int", nullable: false),
                    DonatorID = table.Column<int>(type: "int", nullable: false),
                    PaidAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharityDonators", x => new { x.DonatorID, x.CharityID });
                    table.ForeignKey(
                        name: "FK_CharityDonators_Charities_CharityID",
                        column: x => x.CharityID,
                        principalTable: "Charities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharityDonators_Donatores_DonatorID",
                        column: x => x.DonatorID,
                        principalTable: "Donatores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharityDonators_CharityID",
                table: "CharityDonators",
                column: "CharityID");

            migrationBuilder.CreateIndex(
                name: "IX_CharityManagment_CharityID",
                table: "CharityManagment",
                column: "CharityID");

            migrationBuilder.CreateIndex(
                name: "IX_CharityManagment_CreditorID1_CreditorCaseID",
                table: "CharityManagment",
                columns: new[] { "CreditorID1", "CreditorCaseID" });

            migrationBuilder.CreateIndex(
                name: "IX_CreditorCases_CreditorID1_CreditorCaseID",
                table: "CreditorCases",
                columns: new[] { "CreditorID1", "CreditorCaseID" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_CharityId",
                table: "Users",
                column: "CharityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Charities_Admin_Id",
                table: "Charities",
                column: "Id",
                principalTable: "Admin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admin_Users_Id",
                table: "Admin");

            migrationBuilder.DropTable(
                name: "CharityDonators");

            migrationBuilder.DropTable(
                name: "CharityManagment");

            migrationBuilder.DropTable(
                name: "CreditorCases");

            migrationBuilder.DropTable(
                name: "Donatores");

            migrationBuilder.DropTable(
                name: "Cases");

            migrationBuilder.DropTable(
                name: "Creditor");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Charities");

            migrationBuilder.DropTable(
                name: "Admin");
        }
    }
}
