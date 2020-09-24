using Microsoft.EntityFrameworkCore.Migrations;

namespace LaugamaCorp.Server.Migrations
{
    public partial class codigo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Codigo",
                table: "Inventory",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "Inventory");
        }
    }
}
