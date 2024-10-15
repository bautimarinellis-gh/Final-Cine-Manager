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


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DBCineManager;
            Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;
            Application Intent=ReadWrite;Multi Subnet Failover=False");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            /*modelBuilder.Entity<Auditoria>()
                .HasOne(a => a.Director)
                .WithMany() 
                .HasForeignKey(a => a.DirectorId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Auditoria>()
                .HasOne(a => a.Usuario)
                .WithMany() 
                .HasForeignKey(a => a.Usuario_AudId)
                .OnDelete(DeleteBehavior.Restrict); */

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
        


        // Métodos para la gestión de Usuarios
        public List<Usuario> GetAllUsuarios() //Obtiene todos los usuarios.
        {
            return Usuarios.ToList();
        }


        public Usuario GetUsuarioByID(int id) //Obtiene un usuario por ID.
        {
            return Usuarios.Find(id);
        }

        public bool AddUsuario(Usuario usuario) //Añade un nuevo usuario.
        {
            Usuarios.Add(usuario);
            return SaveChanges() > 0;
        }

        public bool SaveUsuario(Usuario usuario) //Actualiza un usuario existente.
        {
            Usuarios.Update(usuario);
            return SaveChanges() > 0;
        }

        public bool DeleteUsuario(Usuario usuario) // Elimina un usuario.
        {
            Usuarios.Remove(usuario);
            return SaveChanges() > 0;
        }

        // Métodos para la gestión de Grupos
        public List<Grupo> GetAllGrupos() //Obtiene todos los grupos.
        {
            return Grupos.ToList();
        }

        public List<Grupo> GetAllGrupos(string nombre, string estado) //Filtra grupos por nombre y estado.
        {
            return Grupos
                .Where(g => g.Nombre.Contains(nombre) && g.EstadoGrupo.EstadoGrupoNombre == estado)
                .ToList();
        }

        public Grupo GetGrupoByID(int id) //Obtiene un grupo por ID.
        {
            return Grupos.Find(id);
        }

        public bool AddGrupo(Grupo grupo) // Añade un nuevo grupo.
        {
            Grupos.Add(grupo);
            return SaveChanges() > 0;
        }

        public bool SaveGrupo(Grupo grupo) //Actualiza un grupo existente.
        {
            Grupos.Update(grupo);
            return SaveChanges() > 0;
        }

        public bool DeleteGrupo(Grupo grupo) //Elimina un grupo.
        {
            Grupos.Remove(grupo);
            return SaveChanges() > 0;
        }

    }
}
