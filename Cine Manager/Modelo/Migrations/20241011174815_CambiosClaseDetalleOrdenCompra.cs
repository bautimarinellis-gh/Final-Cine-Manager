using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modelo.Migrations
{
    public partial class CambiosClaseDetalleOrdenCompra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetallesOrdenesCompra_OrdenesCompra_OrdenCompraId",
                table: "DetallesOrdenesCompra");

            migrationBuilder.AlterColumn<int>(
                name: "OrdenCompraId",
                table: "DetallesOrdenesCompra",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Estado",
                table: "DetallesOrdenesCompra",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_DetallesOrdenesCompra_OrdenesCompra_OrdenCompraId",
                table: "DetallesOrdenesCompra",
                column: "OrdenCompraId",
                principalTable: "OrdenesCompra",
                principalColumn: "OrdenCompraId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetallesOrdenesCompra_OrdenesCompra_OrdenCompraId",
                table: "DetallesOrdenesCompra");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "DetallesOrdenesCompra");

            migrationBuilder.AlterColumn<int>(
                name: "OrdenCompraId",
                table: "DetallesOrdenesCompra",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_DetallesOrdenesCompra_OrdenesCompra_OrdenCompraId",
                table: "DetallesOrdenesCompra",
                column: "OrdenCompraId",
                principalTable: "OrdenesCompra",
                principalColumn: "OrdenCompraId");
        }
    }
}
