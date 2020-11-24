using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LBS2.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthorizationLevelsTbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorizationLevelsTbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BooksTbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksTbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoriesTbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriesTbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountsTbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorizationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountsTbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountsTbl_AuthorizationLevelsTbl_AuthorizationId",
                        column: x => x.AuthorizationId,
                        principalTable: "AuthorizationLevelsTbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookCategoriesTbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    When = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WhoId = table.Column<int>(type: "int", nullable: true),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCategoriesTbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookCategoriesTbl_AccountsTbl_WhoId",
                        column: x => x.WhoId,
                        principalTable: "AccountsTbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookCategoriesTbl_BooksTbl_BookId",
                        column: x => x.BookId,
                        principalTable: "BooksTbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookCategoriesTbl_CategoriesTbl_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CategoriesTbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BorrowingsTbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WhenBorrowed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorrowingsTbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BorrowingsTbl_AccountsTbl_AccountId",
                        column: x => x.AccountId,
                        principalTable: "AccountsTbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BorrowingsTbl_BooksTbl_BookId",
                        column: x => x.BookId,
                        principalTable: "BooksTbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountsTbl_AuthorizationId",
                table: "AccountsTbl",
                column: "AuthorizationId");

            migrationBuilder.CreateIndex(
                name: "IX_BookCategoriesTbl_BookId",
                table: "BookCategoriesTbl",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookCategoriesTbl_CategoryId",
                table: "BookCategoriesTbl",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BookCategoriesTbl_WhoId",
                table: "BookCategoriesTbl",
                column: "WhoId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowingsTbl_AccountId",
                table: "BorrowingsTbl",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowingsTbl_BookId",
                table: "BorrowingsTbl",
                column: "BookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookCategoriesTbl");

            migrationBuilder.DropTable(
                name: "BorrowingsTbl");

            migrationBuilder.DropTable(
                name: "CategoriesTbl");

            migrationBuilder.DropTable(
                name: "AccountsTbl");

            migrationBuilder.DropTable(
                name: "BooksTbl");

            migrationBuilder.DropTable(
                name: "AuthorizationLevelsTbl");
        }
    }
}
