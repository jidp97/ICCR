using Microsoft.EntityFrameworkCore.Migrations;

namespace LaugamaCorp.Server.Migrations
{
    public partial class EditadoManual : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SuplidorId",
                table: "Inventory",
                nullable: true,
                oldClrType: typeof(int),
                defaultValue: 0);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
