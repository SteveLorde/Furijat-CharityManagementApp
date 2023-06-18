using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndAPI.Migrations
{
    public partial class addedadmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                newName: "DonatorID");

            migrationBuilder.RenameColumn(
                name: "CharityId",
                table: "Donation",
                newName: "CharityID");

            migrationBuilder.RenameColumn(
                name: "CaseId",
                table: "Donation",
                newName: "CaseID");

            migrationBuilder.RenameIndex(
                name: "IX_Donation_DonatorId",
                table: "Donation",
                newName: "IX_Donation_DonatorID");

            migrationBuilder.RenameIndex(
                name: "IX_Donation_CharityId",
                table: "Donation",
                newName: "IX_Donation_CharityID");

            migrationBuilder.RenameIndex(
                name: "IX_Donation_CaseId",
                table: "Donation",
                newName: "IX_Donation_CaseID");

            migrationBuilder.AlterColumn<int>(
                name: "DonatorID",
                table: "Donation",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CharityID",
                table: "Donation",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CaseID",
                table: "Donation",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Donation_Cases_CaseID",
                table: "Donation",
                column: "CaseID",
                principalTable: "Cases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Donation_Charities_CharityID",
                table: "Donation",
                column: "CharityID",
                principalTable: "Charities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Donation_Donatores_DonatorID",
                table: "Donation",
                column: "DonatorID",
                principalTable: "Donatores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donation_Cases_CaseID",
                table: "Donation");

            migrationBuilder.DropForeignKey(
                name: "FK_Donation_Charities_CharityID",
                table: "Donation");

            migrationBuilder.DropForeignKey(
                name: "FK_Donation_Donatores_DonatorID",
                table: "Donation");

            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.RenameColumn(
                name: "DonatorID",
                table: "Donation",
                newName: "DonatorId");

            migrationBuilder.RenameColumn(
                name: "CharityID",
                table: "Donation",
                newName: "CharityId");

            migrationBuilder.RenameColumn(
                name: "CaseID",
                table: "Donation",
                newName: "CaseId");

            migrationBuilder.RenameIndex(
                name: "IX_Donation_DonatorID",
                table: "Donation",
                newName: "IX_Donation_DonatorId");

            migrationBuilder.RenameIndex(
                name: "IX_Donation_CharityID",
                table: "Donation",
                newName: "IX_Donation_CharityId");

            migrationBuilder.RenameIndex(
                name: "IX_Donation_CaseID",
                table: "Donation",
                newName: "IX_Donation_CaseId");

            migrationBuilder.AlterColumn<int>(
                name: "DonatorId",
                table: "Donation",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CharityId",
                table: "Donation",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CaseId",
                table: "Donation",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
    }
}
