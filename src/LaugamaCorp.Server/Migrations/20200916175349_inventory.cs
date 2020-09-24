using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LaugamaCorp.Server.Migrations
{
    public partial class inventory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
      
            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Articulo = table.Column<string>(nullable: true),
                    Categoria = table.Column<string>(nullable: true),
                    Suplidor = table.Column<string>(nullable: true),
                    Imagen = table.Column<string>(nullable: true),
                    Precio = table.Column<int>(nullable: false),
                    PrecioReposicion = table.Column<int>(nullable: false),
                    FechaRegistro = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventory");

          
        }
    }
}
