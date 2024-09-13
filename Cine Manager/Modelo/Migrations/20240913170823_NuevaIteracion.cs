using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modelo.Migrations
{
    public partial class NuevaIteracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proveedores_Peliculas_Peliculas_ListaPeliculasPeliculaId",
                table: "Proveedores_Peliculas");

            migrationBuilder.RenameColumn(
                name: "ListaPeliculasPeliculaId",
                table: "Proveedores_Peliculas",
                newName: "PeliculasPeliculaId");

            migrationBuilder.CreateTable(
                name: "OrdenesCompra",
                columns: table => new
                {
                    OrdenCompraId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProveedorId = table.Column<int>(type: "int", nullable: false),
                    FechaOrden = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenesCompra", x => x.OrdenCompraId);
                    table.ForeignKey(
                        name: "FK_OrdenesCompra_Proveedores_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "Proveedores",
                        principalColumn: "ProveedorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetallesOrdenesCompra",
                columns: table => new
                {
                    DetalleOrdenCompraId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PeliculaId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrdenCompraId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesOrdenesCompra", x => x.DetalleOrdenCompraId);
                    table.ForeignKey(
                        name: "FK_DetallesOrdenesCompra_OrdenesCompra_OrdenCompraId",
                        column: x => x.OrdenCompraId,
                        principalTable: "OrdenesCompra",
                        principalColumn: "OrdenCompraId");
                    table.ForeignKey(
                        name: "FK_DetallesOrdenesCompra_Peliculas_PeliculaId",
                        column: x => x.PeliculaId,
                        principalTable: "Peliculas",
                        principalColumn: "PeliculaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetallesOrdenesCompra_OrdenCompraId",
                table: "DetallesOrdenesCompra",
                column: "OrdenCompraId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesOrdenesCompra_PeliculaId",
                table: "DetallesOrdenesCompra",
                column: "PeliculaId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesCompra_ProveedorId",
                table: "OrdenesCompra",
                column: "ProveedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Proveedores_Peliculas_Peliculas_PeliculasPeliculaId",
                table: "Proveedores_Peliculas",
                column: "PeliculasPeliculaId",
                principalTable: "Peliculas",
                principalColumn: "PeliculaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proveedores_Peliculas_Peliculas_PeliculasPeliculaId",
                table: "Proveedores_Peliculas");

            migrationBuilder.DropTable(
                name: "DetallesOrdenesCompra");

            migrationBuilder.DropTable(
                name: "OrdenesCompra");

            migrationBuilder.RenameColumn(
                name: "PeliculasPeliculaId",
                table: "Proveedores_Peliculas",
                newName: "ListaPeliculasPeliculaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Proveedores_Peliculas_Peliculas_ListaPeliculasPeliculaId",
                table: "Proveedores_Peliculas",
                column: "ListaPeliculasPeliculaId",
                principalTable: "Peliculas",
                principalColumn: "PeliculaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
