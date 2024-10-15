using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modelo.Migrations
{
    public partial class CambiosClassAuditoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auditorias_Directores_DirectorId",
                table: "Auditorias");

            migrationBuilder.DropForeignKey(
                name: "FK_Auditorias_Usuarios_Usuario_AudId",
                table: "Auditorias");

            migrationBuilder.DropIndex(
                name: "IX_Auditorias_DirectorId",
                table: "Auditorias");

            migrationBuilder.DropIndex(
                name: "IX_Auditorias_Usuario_AudId",
                table: "Auditorias");

            migrationBuilder.AddColumn<string>(
                name: "Apellido_Director",
                table: "Auditorias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nombre_Director",
                table: "Auditorias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Apellido_Director",
                table: "Auditorias");

            migrationBuilder.DropColumn(
                name: "Nombre_Director",
                table: "Auditorias");

            migrationBuilder.CreateIndex(
                name: "IX_Auditorias_DirectorId",
                table: "Auditorias",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Auditorias_Usuario_AudId",
                table: "Auditorias",
                column: "Usuario_AudId");

            migrationBuilder.AddForeignKey(
                name: "FK_Auditorias_Directores_DirectorId",
                table: "Auditorias",
                column: "DirectorId",
                principalTable: "Directores",
                principalColumn: "DirectorId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Auditorias_Usuarios_Usuario_AudId",
                table: "Auditorias",
                column: "Usuario_AudId",
                principalTable: "Usuarios",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
