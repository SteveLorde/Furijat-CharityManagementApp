using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndAPI.Migrations
{
    public partial class updateDataModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharityManagment_Creditor_CreditorID1_CreditorCaseID",
                table: "CharityManagment");

            migrationBuilder.DropForeignKey(
                name: "FK_CreditorCases_Creditor_CreditorID1_CreditorCaseID",
                table: "CreditorCases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CreditorCases",
                table: "CreditorCases");

            migrationBuilder.DropIndex(
                name: "IX_CreditorCases_CreditorID1_CreditorCaseID",
                table: "CreditorCases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CharityManagment",
                table: "CharityManagment");

            migrationBuilder.DropIndex(
                name: "IX_CharityManagment_CreditorID1_CreditorCaseID",
                table: "CharityManagment");

            migrationBuilder.RenameColumn(
                name: "CreditorID",
                table: "CreditorCases",
                newName: "CreditorId");

            migrationBuilder.RenameColumn(
                name: "CreditorID1",
                table: "CreditorCases",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CreditorID",
                table: "Creditor",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CreditorID",
                table: "CharityManagment",
                newName: "CreditorId");

            migrationBuilder.RenameColumn(
                name: "CreditorID1",
                table: "CharityManagment",
                newName: "CreditorID");

            migrationBuilder.AlterColumn<int>(
                name: "CreditorCaseID",
                table: "CreditorCases",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CreditorId",
                table: "CreditorCases",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CharityDonators",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CreditorCases",
                table: "CreditorCases",
                columns: new[] { "CaseID", "Id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CharityManagment",
                table: "CharityManagment",
                columns: new[] { "CaseID", "CharityID", "CreditorID" });

            migrationBuilder.CreateIndex(
                name: "IX_CreditorCases_CreditorId_CreditorCaseID",
                table: "CreditorCases",
                columns: new[] { "CreditorId", "CreditorCaseID" });

            migrationBuilder.CreateIndex(
                name: "IX_CharityManagment_CreditorId_CreditorCaseID",
                table: "CharityManagment",
                columns: new[] { "CreditorId", "CreditorCaseID" });

            migrationBuilder.AddForeignKey(
                name: "FK_CharityManagment_Creditor_CreditorId_CreditorCaseID",
                table: "CharityManagment",
                columns: new[] { "CreditorId", "CreditorCaseID" },
                principalTable: "Creditor",
                principalColumns: new[] { "Id", "CaseID" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CreditorCases_Creditor_CreditorId_CreditorCaseID",
                table: "CreditorCases",
                columns: new[] { "CreditorId", "CreditorCaseID" },
                principalTable: "Creditor",
                principalColumns: new[] { "Id", "CaseID" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharityManagment_Creditor_CreditorId_CreditorCaseID",
                table: "CharityManagment");

            migrationBuilder.DropForeignKey(
                name: "FK_CreditorCases_Creditor_CreditorId_CreditorCaseID",
                table: "CreditorCases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CreditorCases",
                table: "CreditorCases");

            migrationBuilder.DropIndex(
                name: "IX_CreditorCases_CreditorId_CreditorCaseID",
                table: "CreditorCases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CharityManagment",
                table: "CharityManagment");

            migrationBuilder.DropIndex(
                name: "IX_CharityManagment_CreditorId_CreditorCaseID",
                table: "CharityManagment");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CharityDonators");

            migrationBuilder.RenameColumn(
                name: "CreditorId",
                table: "CreditorCases",
                newName: "CreditorID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CreditorCases",
                newName: "CreditorID1");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Creditor",
                newName: "CreditorID");

            migrationBuilder.RenameColumn(
                name: "CreditorId",
                table: "CharityManagment",
                newName: "CreditorID");

            migrationBuilder.RenameColumn(
                name: "CreditorID",
                table: "CharityManagment",
                newName: "CreditorID1");

            migrationBuilder.AlterColumn<int>(
                name: "CreditorID",
                table: "CreditorCases",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreditorCaseID",
                table: "CreditorCases",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CreditorCases",
                table: "CreditorCases",
                columns: new[] { "CaseID", "CreditorID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CharityManagment",
                table: "CharityManagment",
                columns: new[] { "CaseID", "CharityID", "CreditorID" });

            migrationBuilder.CreateIndex(
                name: "IX_CreditorCases_CreditorID1_CreditorCaseID",
                table: "CreditorCases",
                columns: new[] { "CreditorID1", "CreditorCaseID" });

            migrationBuilder.CreateIndex(
                name: "IX_CharityManagment_CreditorID1_CreditorCaseID",
                table: "CharityManagment",
                columns: new[] { "CreditorID1", "CreditorCaseID" });

            migrationBuilder.AddForeignKey(
                name: "FK_CharityManagment_Creditor_CreditorID1_CreditorCaseID",
                table: "CharityManagment",
                columns: new[] { "CreditorID1", "CreditorCaseID" },
                principalTable: "Creditor",
                principalColumns: new[] { "CreditorID", "CaseID" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CreditorCases_Creditor_CreditorID1_CreditorCaseID",
                table: "CreditorCases",
                columns: new[] { "CreditorID1", "CreditorCaseID" },
                principalTable: "Creditor",
                principalColumns: new[] { "CreditorID", "CaseID" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
