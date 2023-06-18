using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndAPI.Migrations
{
    public partial class AddDonatorTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Donation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseIDId = table.Column<int>(type: "int", nullable: true),
                    CharityIDId = table.Column<int>(type: "int", nullable: true),
                    DonatorIDId = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Donation_Cases_CaseIDId",
                        column: x => x.CaseIDId,
                        principalTable: "Cases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Donation_Charities_CharityIDId",
                        column: x => x.CharityIDId,
                        principalTable: "Charities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Donation_Donatores_DonatorIDId",
                        column: x => x.DonatorIDId,
                        principalTable: "Donatores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Donation_CaseIDId",
                table: "Donation",
                column: "CaseIDId");

            migrationBuilder.CreateIndex(
                name: "IX_Donation_CharityIDId",
                table: "Donation",
                column: "CharityIDId");

            migrationBuilder.CreateIndex(
                name: "IX_Donation_DonatorIDId",
                table: "Donation",
                column: "DonatorIDId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Donation");
        }
    }
}
