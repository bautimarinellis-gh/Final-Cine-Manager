using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modelo.Migrations
{
    public partial class AddAtributeCantidadEntregada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cantidad",
                table: "DetallesOrdenesCompra",
                newName: "CantidadOrdenada");

            migrationBuilder.AddColumn<int>(
                name: "CantidadEntregada",
                table: "DetallesOrdenesCompra",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CantidadEntregada",
                table: "DetallesOrdenesCompra");

            migrationBuilder.RenameColumn(
                name: "CantidadOrdenada",
                table: "DetallesOrdenesCompra",
                newName: "Cantidad");
        }
    }
}
