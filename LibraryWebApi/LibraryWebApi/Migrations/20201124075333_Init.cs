using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryWebApi.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthorizationLevelsTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorizationLevelsTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoriesTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriesTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountsTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorizationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountsTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountsTable_AuthorizationLevelsTable_AuthorizationId",
                        column: x => x.AuthorizationId,
                        principalTable: "AuthorizationLevelsTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BooksTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WhenLent = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BooksTable_AccountsTable_AccountId",
                        column: x => x.AccountId,
                        principalTable: "AccountsTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategorizationEventsTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    When = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WhatId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorizationEventsTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategorizationEventsTable_BooksTable_WhatId",
                        column: x => x.WhatId,
                        principalTable: "BooksTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategorizationEventsTable_CategoriesTable_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CategoriesTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountsTable_AuthorizationId",
                table: "AccountsTable",
                column: "AuthorizationId");

            migrationBuilder.CreateIndex(
                name: "IX_BooksTable_AccountId",
                table: "BooksTable",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_CategorizationEventsTable_CategoryId",
                table: "CategorizationEventsTable",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategorizationEventsTable_WhatId",
                table: "CategorizationEventsTable",
                column: "WhatId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategorizationEventsTable");

            migrationBuilder.DropTable(
                name: "BooksTable");

            migrationBuilder.DropTable(
                name: "CategoriesTable");

            migrationBuilder.DropTable(
                name: "AccountsTable");

            migrationBuilder.DropTable(
                name: "AuthorizationLevelsTable");
        }
    }
}
