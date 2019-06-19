using Microsoft.EntityFrameworkCore.Migrations;

namespace AgentDB.Migrations
{
    public partial class Fifthmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "IdMainDB",
                table: "Accommodations",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdMainDB",
                table: "Accommodations");
        }
    }
}
