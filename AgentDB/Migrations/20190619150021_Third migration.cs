using Microsoft.EntityFrameworkCore.Migrations;

namespace AgentDB.Migrations
{
    public partial class Thirdmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accommodations_Agents_AgentID",
                table: "Accommodations");

            migrationBuilder.RenameColumn(
                name: "AgentID",
                table: "Accommodations",
                newName: "AgentId");

            migrationBuilder.RenameIndex(
                name: "IX_Accommodations_AgentID",
                table: "Accommodations",
                newName: "IX_Accommodations_AgentId");

            migrationBuilder.AlterColumn<long>(
                name: "AgentId",
                table: "Accommodations",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_Accommodations_Agents_AgentId",
                table: "Accommodations",
                column: "AgentId",
                principalTable: "Agents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accommodations_Agents_AgentId",
                table: "Accommodations");

            migrationBuilder.RenameColumn(
                name: "AgentId",
                table: "Accommodations",
                newName: "AgentID");

            migrationBuilder.RenameIndex(
                name: "IX_Accommodations_AgentId",
                table: "Accommodations",
                newName: "IX_Accommodations_AgentID");

            migrationBuilder.AlterColumn<long>(
                name: "AgentID",
                table: "Accommodations",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Accommodations_Agents_AgentID",
                table: "Accommodations",
                column: "AgentID",
                principalTable: "Agents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
