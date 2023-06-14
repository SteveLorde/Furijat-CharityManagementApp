using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndAPI.Migrations
{
    public partial class AddedCharityDonators : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharityDonators");
        }
    }
}
