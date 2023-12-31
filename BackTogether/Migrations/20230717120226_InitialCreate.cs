﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackTogether.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Backings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    DateBacked = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Backings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CurrentFunding = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FinalGoal = table.Column<decimal>(type: "decimal(6,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResourceURL",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceURL", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResourceURL_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Rewards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    UnlockAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BackingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rewards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rewards_Backings_BackingId",
                        column: x => x.BackingId,
                        principalTable: "Backings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rewards_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageURLId = table.Column<int>(type: "int", nullable: true),
                    HasAdminPrivileges = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_ResourceURL_ImageURLId",
                        column: x => x.ImageURLId,
                        principalTable: "ResourceURL",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FullName", "HasAdminPrivileges", "ImageURLId", "Password", "Username" },
                values: new object[,]
                {
                    { 1, "example@email.com", null, true, null, "NZ#7eYB%", "aFEf4w4f" },
                    { 2, "example1@email.com", null, true, null, "6*%7rKNd", "fa4gfwff" },
                    { 3, "example2@email.com", null, false, null, "K^aB%s6T", "tejh56eu" },
                    { 4, "example3@email.com", null, false, null, "Fg75^U@j", "f34g34qg" },
                    { 5, "example4@email.com", null, false, null, "#VEGu3it", "fq34gqgf" },
                    { 6, "example5@email.com", null, false, null, "Cnk@XH23", "qf34gq3g" },
                    { 7, "example6@email.com", null, true, null, "HpKY6N%X", "f34qg4q3" },
                    { 8, "example7@email.com", null, false, null, "P6@%R6%a", "n4eh6wqw" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Backings_ProjectId",
                table: "Backings",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Backings_UserId",
                table: "Backings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_UserId",
                table: "Projects",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceURL_ProjectId",
                table: "ResourceURL",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Rewards_BackingId",
                table: "Rewards",
                column: "BackingId");

            migrationBuilder.CreateIndex(
                name: "IX_Rewards_ProjectId",
                table: "Rewards",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ImageURLId",
                table: "Users",
                column: "ImageURLId");

            migrationBuilder.AddForeignKey(
                name: "FK_Backings_Projects_ProjectId",
                table: "Backings",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Backings_Users_UserId",
                table: "Backings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Users_UserId",
                table: "Projects",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResourceURL_Projects_ProjectId",
                table: "ResourceURL");

            migrationBuilder.DropTable(
                name: "Rewards");

            migrationBuilder.DropTable(
                name: "Backings");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ResourceURL");
        }
    }
}
