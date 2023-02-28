using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndAPI.Migrations
{
    public partial class updatingForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CasePayments_Cases_CaseId",
                table: "CasePayments");

            migrationBuilder.DropForeignKey(
                name: "FK_Cases_Charities_CharityId",
                table: "Cases");

            migrationBuilder.DropForeignKey(
                name: "FK_Charities_Users_UserID",
                table: "Charities");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserType_UserTypeID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_CasePayments_CaseId",
                table: "CasePayments");

            migrationBuilder.DropColumn(
                name: "UType",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CaseId",
                table: "CasePayments");

            migrationBuilder.RenameColumn(
                name: "UserTypeID",
                table: "Users",
                newName: "UserTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_UserTypeID",
                table: "Users",
                newName: "IX_Users_UserTypeId");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Charities",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Charities_UserID",
                table: "Charities",
                newName: "IX_Charities_UserId");

            migrationBuilder.AlterColumn<int>(
                name: "UserTypeId",
                table: "Users",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Charities",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "CharityId",
                table: "Cases",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "CasesCaseId",
                table: "CasePayments",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CasePayments_CasesCaseId",
                table: "CasePayments",
                column: "CasesCaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_CasePayments_Cases_CasesCaseId",
                table: "CasePayments",
                column: "CasesCaseId",
                principalTable: "Cases",
                principalColumn: "CaseId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Charities_CharityId",
                table: "Cases",
                column: "CharityId",
                principalTable: "Charities",
                principalColumn: "CharityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Charities_Users_UserId",
                table: "Charities",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserType_UserTypeId",
                table: "Users",
                column: "UserTypeId",
                principalTable: "UserType",
                principalColumn: "UserTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CasePayments_Cases_CasesCaseId",
                table: "CasePayments");

            migrationBuilder.DropForeignKey(
                name: "FK_Cases_Charities_CharityId",
                table: "Cases");

            migrationBuilder.DropForeignKey(
                name: "FK_Charities_Users_UserId",
                table: "Charities");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserType_UserTypeId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_CasePayments_CasesCaseId",
                table: "CasePayments");

            migrationBuilder.DropColumn(
                name: "CasesCaseId",
                table: "CasePayments");

            migrationBuilder.RenameColumn(
                name: "UserTypeId",
                table: "Users",
                newName: "UserTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_Users_UserTypeId",
                table: "Users",
                newName: "IX_Users_UserTypeID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Charities",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Charities_UserId",
                table: "Charities",
                newName: "IX_Charities_UserID");

            migrationBuilder.AlterColumn<int>(
                name: "UserTypeID",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UType",
                table: "Users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Charities",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CharityId",
                table: "Cases",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CaseId",
                table: "CasePayments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CasePayments_CaseId",
                table: "CasePayments",
                column: "CaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_CasePayments_Cases_CaseId",
                table: "CasePayments",
                column: "CaseId",
                principalTable: "Cases",
                principalColumn: "CaseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Charities_CharityId",
                table: "Cases",
                column: "CharityId",
                principalTable: "Charities",
                principalColumn: "CharityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Charities_Users_UserID",
                table: "Charities",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserType_UserTypeID",
                table: "Users",
                column: "UserTypeID",
                principalTable: "UserType",
                principalColumn: "UserTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
