using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modelo.Migrations
{
    public partial class AddAtributePagosPedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MetodoPagoId",
                table: "PagosPedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MetodosPago",
                columns: table => new
                {
                    MetodoPagoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetodosPago", x => x.MetodoPagoId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PagosPedidos_MetodoPagoId",
                table: "PagosPedidos",
                column: "MetodoPagoId");

            migrationBuilder.AddForeignKey(
                name: "FK_PagosPedidos_MetodosPago_MetodoPagoId",
                table: "PagosPedidos",
                column: "MetodoPagoId",
                principalTable: "MetodosPago",
                principalColumn: "MetodoPagoId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PagosPedidos_MetodosPago_MetodoPagoId",
                table: "PagosPedidos");

            migrationBuilder.DropTable(
                name: "MetodosPago");

            migrationBuilder.DropIndex(
                name: "IX_PagosPedidos_MetodoPagoId",
                table: "PagosPedidos");

            migrationBuilder.DropColumn(
                name: "MetodoPagoId",
                table: "PagosPedidos");
        }
    }
}
