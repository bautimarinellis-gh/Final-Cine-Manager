using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Modelo.Entidades;
using Modelo.Módulo_de_Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.EFCore
{
    public class Contexto: DbContext
    {
        private static Contexto instancia;
        public static Contexto Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new Contexto();
                }
                return instancia;
            }
        }

        public Contexto()
        {
        }


        public DbSet<Director> Directores { get; set; }
        public DbSet<GeneroCinematografico> GenerosCinematograficos{ get; set; }
        public DbSet<Actor> Actores{ get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<Cliente> Clientes {  get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<DetallePedido> DetallesPedidos { get; set; }
        public DbSet<DetalleAlquiler> DetallesAlquileres { get; set; }
        public DbSet<DetalleVenta> DetallesVentas { get; set; }
        public DbSet<PagoPedido> PagosPedidos { get; set; }
        public DbSet<DetalleOrdenCompra> DetallesOrdenesCompra { get; set; }
        public DbSet<OrdenCompra> OrdenesCompra { get; set; }
        public DbSet<MetodoPago> MetodosPago {  get; set; }


        //Modulo de Seguridad

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Accion> Acciones { get; set; }
        public DbSet<Formulario> Formularios {  get; set; }
        public DbSet<Modulo> Modulos { get; set; }
        public DbSet<EstadoUsuario> EstadosUsuario { get; set; }
        public DbSet<EstadoGrupo> EstadosGrupo { get; set; }



        //Auditoria

        public DbSet<Auditoria> Auditorias { get; set; }
        public DbSet<AuditoriaSesion> AuditoriasSesiones { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DBCineManager;
            Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;
            Application Intent=ReadWrite;Multi Subnet Failover=False");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PagoPedido>()
                .HasOne(pp => pp.MetodoPago) 
                .WithMany() 
                .HasForeignKey(pp => pp.MetodoPagoId) 
                .OnDelete(DeleteBehavior.Restrict); 


            modelBuilder.Entity<Grupo>().HasMany(g => g.Componentes).WithMany(c => c.Grupos).UsingEntity<Dictionary<string, object>>(
                "ComponenteGrupo",
                j => j
                    .HasOne<Componente>()
                    .WithMany()
                    .HasForeignKey("ComponentesId")
                    .OnDelete(DeleteBehavior.Restrict), 
                j => j
                    .HasOne<Grupo>()
                    .WithMany()
                    .HasForeignKey("GruposId")
                    .OnDelete(DeleteBehavior.Cascade)); 

            modelBuilder.Entity<Pelicula>()
                .HasMany(p => p.Proveedores)
                .WithMany(p => p.Peliculas)
                .UsingEntity(j => j.ToTable("Proveedores_Peliculas"));

            modelBuilder.Entity<Pelicula>()
                .HasMany(p => p.Reparto)
                .WithMany(a => a.ListaPeliculas)
                .UsingEntity(j => j.ToTable("Actores_Peliculas"));

        }
    }
}
