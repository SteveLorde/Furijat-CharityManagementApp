using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndAPI.Migrations
{
    public partial class updatingUsertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CasePayment_Cases_CasesId",
                table: "CasePayment");

            migrationBuilder.DropForeignKey(
                name: "FK_Cases_Charity_CharityId",
                table: "Cases");

            migrationBuilder.DropForeignKey(
                name: "FK_Charity_User_UserID",
                table: "Charity");

            migrationBuilder.DropForeignKey(
                name: "FK_User_UserType_UserTypeID",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Charity",
                table: "Charity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CasePayment",
                table: "CasePayment");

            migrationBuilder.DropIndex(
                name: "IX_CasePayment_CasesId",
                table: "CasePayment");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CasesId",
                table: "CasePayment");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Charity",
                newName: "Charities");

            migrationBuilder.RenameTable(
                name: "CasePayment",
                newName: "CasePayments");

            migrationBuilder.RenameColumn(
                name: "CasesId",
                table: "Cases",
                newName: "CaseId");

            migrationBuilder.RenameIndex(
                name: "IX_User_UserTypeID",
                table: "Users",
                newName: "IX_Users_UserTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_Charity_UserID",
                table: "Charities",
                newName: "IX_Charities_UserID");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "Users",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "Users",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Charities",
                table: "Charities",
                column: "CharityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CasePayments",
                table: "CasePayments",
                column: "CasePaymentId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Charities",
                table: "Charities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CasePayments",
                table: "CasePayments");

            migrationBuilder.DropIndex(
                name: "IX_CasePayments_CaseId",
                table: "CasePayments");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Charities",
                newName: "Charity");

            migrationBuilder.RenameTable(
                name: "CasePayments",
                newName: "CasePayment");

            migrationBuilder.RenameColumn(
                name: "CaseId",
                table: "Cases",
                newName: "CasesId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_UserTypeID",
                table: "User",
                newName: "IX_User_UserTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_Charities_UserID",
                table: "Charity",
                newName: "IX_Charity_UserID");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CasesId",
                table: "CasePayment",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Charity",
                table: "Charity",
                column: "CharityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CasePayment",
                table: "CasePayment",
                column: "CasePaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_CasePayment_CasesId",
                table: "CasePayment",
                column: "CasesId");

            migrationBuilder.AddForeignKey(
                name: "FK_CasePayment_Cases_CasesId",
                table: "CasePayment",
                column: "CasesId",
                principalTable: "Cases",
                principalColumn: "CasesId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Charity_CharityId",
                table: "Cases",
                column: "CharityId",
                principalTable: "Charity",
                principalColumn: "CharityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Charity_User_UserID",
                table: "Charity",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_UserType_UserTypeID",
                table: "User",
                column: "UserTypeID",
                principalTable: "UserType",
                principalColumn: "UserTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
