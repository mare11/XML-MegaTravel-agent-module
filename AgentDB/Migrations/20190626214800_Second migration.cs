using Microsoft.EntityFrameworkCore.Migrations;

namespace AgentDB.Migrations
{
    public partial class Secondmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdditionalServicesOnlies",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    AdditionalServiceName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalServicesOnlies", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdditionalServicesOnlies");
        }
    }
}
