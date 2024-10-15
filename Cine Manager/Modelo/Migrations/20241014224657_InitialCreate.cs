using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modelo.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actores",
                columns: table => new
                {
                    ActorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actores", x => x.ActorId);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DNI = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Directores",
                columns: table => new
                {
                    DirectorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directores", x => x.DirectorId);
                });

            migrationBuilder.CreateTable(
                name: "EstadosGrupo",
                columns: table => new
                {
                    EstadoGrupoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoGrupoNombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosGrupo", x => x.EstadoGrupoId);
                });

            migrationBuilder.CreateTable(
                name: "EstadosUsuario",
                columns: table => new
                {
                    EstadoUsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoUsuarioNombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosUsuario", x => x.EstadoUsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "GenerosCinematograficos",
                columns: table => new
                {
                    GeneroCinematograficoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenerosCinematograficos", x => x.GeneroCinematograficoId);
                });

            migrationBuilder.CreateTable(
                name: "Modulos",
                columns: table => new
                {
                    ModuloId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreModulo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modulos", x => x.ModuloId);
                });

            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    ProveedorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cuit = table.Column<long>(type: "bigint", nullable: false),
                    RazonSocial = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.ProveedorId);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    PedidoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    Recargo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.PedidoId);
                    table.ForeignKey(
                        name: "FK_Pedidos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Clave = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoUsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "FK_Usuarios_EstadosUsuario_EstadoUsuarioId",
                        column: x => x.EstadoUsuarioId,
                        principalTable: "EstadosUsuario",
                        principalColumn: "EstadoUsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Peliculas",
                columns: table => new
                {
                    PeliculaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<int>(type: "int", nullable: false),
                    DirectorId = table.Column<int>(type: "int", nullable: false),
                    GeneroCinematograficoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peliculas", x => x.PeliculaId);
                    table.ForeignKey(
                        name: "FK_Peliculas_Directores_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Directores",
                        principalColumn: "DirectorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Peliculas_GenerosCinematograficos_GeneroCinematograficoId",
                        column: x => x.GeneroCinematograficoId,
                        principalTable: "GenerosCinematograficos",
                        principalColumn: "GeneroCinematograficoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Formularios",
                columns: table => new
                {
                    FormularioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreFormulario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModuloId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formularios", x => x.FormularioId);
                    table.ForeignKey(
                        name: "FK_Formularios_Modulos_ModuloId",
                        column: x => x.ModuloId,
                        principalTable: "Modulos",
                        principalColumn: "ModuloId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdenesCompra",
                columns: table => new
                {
                    OrdenCompraId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProveedorId = table.Column<int>(type: "int", nullable: false),
                    FechaOrden = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                name: "PagosPedidos",
                columns: table => new
                {
                    PagoPedidoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PedidoId = table.Column<int>(type: "int", nullable: false),
                    FechaPago = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagosPedidos", x => x.PagoPedidoId);
                    table.ForeignKey(
                        name: "FK_PagosPedidos_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "PedidoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Auditorias",
                columns: table => new
                {
                    AuditoriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DirectorId = table.Column<int>(type: "int", nullable: false),
                    Codigo_Director = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Usuario_AudId = table.Column<int>(type: "int", nullable: false),
                    Fecha_Aud = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoMovimiento_Aud = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auditorias", x => x.AuditoriaId);
                    table.ForeignKey(
                        name: "FK_Auditorias_Directores_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Directores",
                        principalColumn: "DirectorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Auditorias_Usuarios_Usuario_AudId",
                        column: x => x.Usuario_AudId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Actores_Peliculas",
                columns: table => new
                {
                    ListaPeliculasPeliculaId = table.Column<int>(type: "int", nullable: false),
                    RepartoActorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actores_Peliculas", x => new { x.ListaPeliculasPeliculaId, x.RepartoActorId });
                    table.ForeignKey(
                        name: "FK_Actores_Peliculas_Actores_RepartoActorId",
                        column: x => x.RepartoActorId,
                        principalTable: "Actores",
                        principalColumn: "ActorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Actores_Peliculas_Peliculas_ListaPeliculasPeliculaId",
                        column: x => x.ListaPeliculasPeliculaId,
                        principalTable: "Peliculas",
                        principalColumn: "PeliculaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetallesPedidos",
                columns: table => new
                {
                    DetallePedidoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PeliculaId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PedidoId = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DetalleAlquilerId = table.Column<int>(type: "int", nullable: true),
                    FechaDevolucion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Devuelto = table.Column<bool>(type: "bit", nullable: true),
                    DetalleVentaId = table.Column<int>(type: "int", nullable: true),
                    Garantia = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesPedidos", x => x.DetallePedidoId);
                    table.ForeignKey(
                        name: "FK_DetallesPedidos_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "PedidoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetallesPedidos_Peliculas_PeliculaId",
                        column: x => x.PeliculaId,
                        principalTable: "Peliculas",
                        principalColumn: "PeliculaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Proveedores_Peliculas",
                columns: table => new
                {
                    PeliculasPeliculaId = table.Column<int>(type: "int", nullable: false),
                    ProveedoresProveedorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores_Peliculas", x => new { x.PeliculasPeliculaId, x.ProveedoresProveedorId });
                    table.ForeignKey(
                        name: "FK_Proveedores_Peliculas_Peliculas_PeliculasPeliculaId",
                        column: x => x.PeliculasPeliculaId,
                        principalTable: "Peliculas",
                        principalColumn: "PeliculaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Proveedores_Peliculas_Proveedores_ProveedoresProveedorId",
                        column: x => x.ProveedoresProveedorId,
                        principalTable: "Proveedores",
                        principalColumn: "ProveedorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Componente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FormularioId = table.Column<int>(type: "int", nullable: true),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescripcionGrupo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoGrupoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Componente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Componente_EstadosGrupo_EstadoGrupoId",
                        column: x => x.EstadoGrupoId,
                        principalTable: "EstadosGrupo",
                        principalColumn: "EstadoGrupoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Componente_Formularios_FormularioId",
                        column: x => x.FormularioId,
                        principalTable: "Formularios",
                        principalColumn: "FormularioId",
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
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    OrdenCompraId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesOrdenesCompra", x => x.DetalleOrdenCompraId);
                    table.ForeignKey(
                        name: "FK_DetallesOrdenesCompra_OrdenesCompra_OrdenCompraId",
                        column: x => x.OrdenCompraId,
                        principalTable: "OrdenesCompra",
                        principalColumn: "OrdenCompraId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetallesOrdenesCompra_Peliculas_PeliculaId",
                        column: x => x.PeliculaId,
                        principalTable: "Peliculas",
                        principalColumn: "PeliculaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComponenteGrupo",
                columns: table => new
                {
                    ComponentesId = table.Column<int>(type: "int", nullable: false),
                    GruposId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponenteGrupo", x => new { x.ComponentesId, x.GruposId });
                    table.ForeignKey(
                        name: "FK_ComponenteGrupo_Componente_ComponentesId",
                        column: x => x.ComponentesId,
                        principalTable: "Componente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComponenteGrupo_Componente_GruposId",
                        column: x => x.GruposId,
                        principalTable: "Componente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComponenteUsuario",
                columns: table => new
                {
                    ComponentesId = table.Column<int>(type: "int", nullable: false),
                    UsuariosUsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponenteUsuario", x => new { x.ComponentesId, x.UsuariosUsuarioId });
                    table.ForeignKey(
                        name: "FK_ComponenteUsuario_Componente_ComponentesId",
                        column: x => x.ComponentesId,
                        principalTable: "Componente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComponenteUsuario_Usuarios_UsuariosUsuarioId",
                        column: x => x.UsuariosUsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actores_Peliculas_RepartoActorId",
                table: "Actores_Peliculas",
                column: "RepartoActorId");

            migrationBuilder.CreateIndex(
                name: "IX_Auditorias_DirectorId",
                table: "Auditorias",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Auditorias_Usuario_AudId",
                table: "Auditorias",
                column: "Usuario_AudId");

            migrationBuilder.CreateIndex(
                name: "IX_Componente_EstadoGrupoId",
                table: "Componente",
                column: "EstadoGrupoId");

            migrationBuilder.CreateIndex(
                name: "IX_Componente_FormularioId",
                table: "Componente",
                column: "FormularioId");

            migrationBuilder.CreateIndex(
                name: "IX_ComponenteGrupo_GruposId",
                table: "ComponenteGrupo",
                column: "GruposId");

            migrationBuilder.CreateIndex(
                name: "IX_ComponenteUsuario_UsuariosUsuarioId",
                table: "ComponenteUsuario",
                column: "UsuariosUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesOrdenesCompra_OrdenCompraId",
                table: "DetallesOrdenesCompra",
                column: "OrdenCompraId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesOrdenesCompra_PeliculaId",
                table: "DetallesOrdenesCompra",
                column: "PeliculaId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesPedidos_PedidoId",
                table: "DetallesPedidos",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesPedidos_PeliculaId",
                table: "DetallesPedidos",
                column: "PeliculaId");

            migrationBuilder.CreateIndex(
                name: "IX_Formularios_ModuloId",
                table: "Formularios",
                column: "ModuloId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesCompra_ProveedorId",
                table: "OrdenesCompra",
                column: "ProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_PagosPedidos_PedidoId",
                table: "PagosPedidos",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ClienteId",
                table: "Pedidos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Peliculas_DirectorId",
                table: "Peliculas",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Peliculas_GeneroCinematograficoId",
                table: "Peliculas",
                column: "GeneroCinematograficoId");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedores_Peliculas_ProveedoresProveedorId",
                table: "Proveedores_Peliculas",
                column: "ProveedoresProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_EstadoUsuarioId",
                table: "Usuarios",
                column: "EstadoUsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Actores_Peliculas");

            migrationBuilder.DropTable(
                name: "Auditorias");

            migrationBuilder.DropTable(
                name: "ComponenteGrupo");

            migrationBuilder.DropTable(
                name: "ComponenteUsuario");

            migrationBuilder.DropTable(
                name: "DetallesOrdenesCompra");

            migrationBuilder.DropTable(
                name: "DetallesPedidos");

            migrationBuilder.DropTable(
                name: "PagosPedidos");

            migrationBuilder.DropTable(
                name: "Proveedores_Peliculas");

            migrationBuilder.DropTable(
                name: "Actores");

            migrationBuilder.DropTable(
                name: "Componente");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "OrdenesCompra");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Peliculas");

            migrationBuilder.DropTable(
                name: "EstadosGrupo");

            migrationBuilder.DropTable(
                name: "Formularios");

            migrationBuilder.DropTable(
                name: "EstadosUsuario");

            migrationBuilder.DropTable(
                name: "Proveedores");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Directores");

            migrationBuilder.DropTable(
                name: "GenerosCinematograficos");

            migrationBuilder.DropTable(
                name: "Modulos");
        }
    }
}
