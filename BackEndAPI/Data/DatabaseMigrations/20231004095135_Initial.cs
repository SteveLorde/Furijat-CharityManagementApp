using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackEndAPI.Data.DatabaseMigrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    date = table.Column<string>(type: "TEXT", nullable: false),
                    title = table.Column<string>(type: "TEXT", nullable: false),
                    subtitle = table.Column<string>(type: "TEXT", nullable: false),
                    body = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    username = table.Column<string>(type: "TEXT", nullable: false),
                    email = table.Column<string>(type: "TEXT", nullable: false),
                    passwordhash = table.Column<string>(type: "TEXT", nullable: false),
                    usertype = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AdminId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admins_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Charities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CharityId = table.Column<int>(type: "INTEGER", nullable: false),
                    charityname = table.Column<string>(type: "TEXT", nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: false),
                    phonenumber = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Charities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Charities_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Donators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DonatorId = table.Column<int>(type: "INTEGER", nullable: false),
                    paymenttype = table.Column<string>(type: "TEXT", nullable: false),
                    phonenumber = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Donators_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CaseId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    currentdonations = table.Column<int>(type: "INTEGER", nullable: false),
                    Totalneeded = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    CharityId = table.Column<int>(type: "INTEGER", nullable: false),
                    DonatorId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cases_Charities_CharityId",
                        column: x => x.CharityId,
                        principalTable: "Charities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cases_Donators_DonatorId",
                        column: x => x.DonatorId,
                        principalTable: "Donators",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cases_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "body", "date", "subtitle", "title" },
                values: new object[,]
                {
                    { 8, " LOL ", "2-12-2023", "Subtitle 1", "Title 1" },
                    { 9, " LOL ", "3-12-2023", "Subtitle 2", "Title 2" },
                    { 10, " LOL ", "4-12-2023", "Subtitle 3", "Title 3" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "email", "passwordhash", "username", "usertype" },
                values: new object[,]
                {
                    { 1, "Charity1@gmail.com", "$2y$10$GG7BIOY/0GdsliwsztYf7OSfjtitqXM57rNe0d.vpI4FBbl54FN4C", "charity1", "charity" },
                    { 2, "Charity2@gmail.com", "$2y$10$GG7BIOY/0GdsliwsztYf7OSfjtitqXM57rNe0d.vpI4FBbl54FN4C", "charity2", "charity" },
                    { 3, "Charity3@gmail.com", "$2y$10$GG7BIOY/0GdsliwsztYf7OSfjtitqXM57rNe0d.vpI4FBbl54FN4C", "charity3", "charity" },
                    { 4, "ahmed@gmail.com", "$2y$10$GG7BIOY/0GdsliwsztYf7OSfjtitqXM57rNe0d.vpI4FBbl54FN4C", "ahmedtest", "case" },
                    { 5, "engy@gmail.com", "$2y$10$GG7BIOY/0GdsliwsztYf7OSfjtitqXM57rNe0d.vpI4FBbl54FN4C", "engy", "case" },
                    { 6, "Omar@gmail.com", "$2y$10$GG7BIOY/0GdsliwsztYf7OSfjtitqXM57rNe0d.vpI4FBbl54FN4C", "omar", "case" },
                    { 7, "donator@gmail.com", "$2y$10$GG7BIOY/0GdsliwsztYf7OSfjtitqXM57rNe0d.vpI4FBbl54FN4C", "donatortest", "donator" }
                });

            migrationBuilder.InsertData(
                table: "Charities",
                columns: new[] { "Id", "CharityId", "charityname", "description", "phonenumber" },
                values: new object[,]
                {
                    { 1, 1, "5er Masr", "Charity Description 1", 1110746800 },
                    { 2, 2, "2ed fe 2ed", "Charity Description 2", 1110746800 },
                    { 3, 3, "Charity 3", "Charity Description 3", 1110746800 }
                });

            migrationBuilder.InsertData(
                table: "Donators",
                columns: new[] { "Id", "DonatorId", "paymenttype", "phonenumber" },
                values: new object[] { 7, 1, "null", 1110746800 });

            migrationBuilder.InsertData(
                table: "Cases",
                columns: new[] { "Id", "Address", "CaseId", "CharityId", "DonatorId", "Name", "Status", "Totalneeded", "currentdonations", "description" },
                values: new object[,]
                {
                    { 4, "Address Test", 1, 1, null, "Ahmed", "active", 5000, 0, "Debted for furniture" },
                    { 5, "Address Test", 2, 1, null, "Engy", "active", 5000, 0, "Case Description 2" },
                    { 6, "Address Test", 3, 2, null, "Omar", "active", 5000, 0, "Debted for Appliances" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cases_CharityId",
                table: "Cases",
                column: "CharityId");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_DonatorId",
                table: "Cases",
                column: "DonatorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Cases");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Charities");

            migrationBuilder.DropTable(
                name: "Donators");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
