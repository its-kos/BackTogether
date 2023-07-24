using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackTogether.Migrations
{
    /// <inheritdoc />
    public partial class NameUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rewards_Project_ProjectId",
                table: "Rewards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rewards",
                table: "Rewards");

            migrationBuilder.RenameTable(
                name: "Rewards",
                newName: "Reward");

            migrationBuilder.RenameIndex(
                name: "IX_Rewards_ProjectId",
                table: "Reward",
                newName: "IX_Reward_ProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reward",
                table: "Reward",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reward_Project_ProjectId",
                table: "Reward",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reward_Project_ProjectId",
                table: "Reward");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reward",
                table: "Reward");

            migrationBuilder.RenameTable(
                name: "Reward",
                newName: "Rewards");

            migrationBuilder.RenameIndex(
                name: "IX_Reward_ProjectId",
                table: "Rewards",
                newName: "IX_Rewards_ProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rewards",
                table: "Rewards",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rewards_Project_ProjectId",
                table: "Rewards",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
