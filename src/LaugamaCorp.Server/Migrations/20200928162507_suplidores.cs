using Microsoft.EntityFrameworkCore.Migrations;

namespace LaugamaCorp.Server.Migrations
{
    public partial class suplidores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Suplidor",
                table: "Inventory");

            migrationBuilder.AlterColumn<string>(
                name: "Articulo",
                table: "Inventory",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SuplidorId",
                table: "Inventory",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Suplidores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    RNC = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suplidores", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_SuplidorId",
                table: "Inventory",
                column: "SuplidorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Suplidores_SuplidorId",
                table: "Inventory",
                column: "SuplidorId",
                principalTable: "Suplidores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Suplidores_SuplidorId",
                table: "Inventory");

            migrationBuilder.DropTable(
                name: "Suplidores");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_SuplidorId",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "SuplidorId",
                table: "Inventory");

            migrationBuilder.AlterColumn<string>(
                name: "Articulo",
                table: "Inventory",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Suplidor",
                table: "Inventory",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
