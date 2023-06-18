using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndAPI.Migrations
{
    public partial class FixedDonationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donation_Cases_CaseIDId",
                table: "Donation");

            migrationBuilder.DropForeignKey(
                name: "FK_Donation_Charities_CharityIDId",
                table: "Donation");

            migrationBuilder.DropForeignKey(
                name: "FK_Donation_Donatores_DonatorIDId",
                table: "Donation");

            migrationBuilder.RenameColumn(
                name: "DonatorIDId",
                table: "Donation",
                newName: "DonatorId");

            migrationBuilder.RenameColumn(
                name: "CharityIDId",
                table: "Donation",
                newName: "CharityId");

            migrationBuilder.RenameColumn(
                name: "CaseIDId",
                table: "Donation",
                newName: "CaseId");

            migrationBuilder.RenameIndex(
                name: "IX_Donation_DonatorIDId",
                table: "Donation",
                newName: "IX_Donation_DonatorId");

            migrationBuilder.RenameIndex(
                name: "IX_Donation_CharityIDId",
                table: "Donation",
                newName: "IX_Donation_CharityId");

            migrationBuilder.RenameIndex(
                name: "IX_Donation_CaseIDId",
                table: "Donation",
                newName: "IX_Donation_CaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Donation_Cases_CaseId",
                table: "Donation",
                column: "CaseId",
                principalTable: "Cases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Donation_Charities_CharityId",
                table: "Donation",
                column: "CharityId",
                principalTable: "Charities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Donation_Donatores_DonatorId",
                table: "Donation",
                column: "DonatorId",
                principalTable: "Donatores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donation_Cases_CaseId",
                table: "Donation");

            migrationBuilder.DropForeignKey(
                name: "FK_Donation_Charities_CharityId",
                table: "Donation");

            migrationBuilder.DropForeignKey(
                name: "FK_Donation_Donatores_DonatorId",
                table: "Donation");

            migrationBuilder.RenameColumn(
                name: "DonatorId",
                table: "Donation",
                newName: "DonatorIDId");

            migrationBuilder.RenameColumn(
                name: "CharityId",
                table: "Donation",
                newName: "CharityIDId");

            migrationBuilder.RenameColumn(
                name: "CaseId",
                table: "Donation",
                newName: "CaseIDId");

            migrationBuilder.RenameIndex(
                name: "IX_Donation_DonatorId",
                table: "Donation",
                newName: "IX_Donation_DonatorIDId");

            migrationBuilder.RenameIndex(
                name: "IX_Donation_CharityId",
                table: "Donation",
                newName: "IX_Donation_CharityIDId");

            migrationBuilder.RenameIndex(
                name: "IX_Donation_CaseId",
                table: "Donation",
                newName: "IX_Donation_CaseIDId");

            migrationBuilder.AddForeignKey(
                name: "FK_Donation_Cases_CaseIDId",
                table: "Donation",
                column: "CaseIDId",
                principalTable: "Cases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Donation_Charities_CharityIDId",
                table: "Donation",
                column: "CharityIDId",
                principalTable: "Charities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Donation_Donatores_DonatorIDId",
                table: "Donation",
                column: "DonatorIDId",
                principalTable: "Donatores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
