using Microsoft.EntityFrameworkCore;
using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.LogicaInfraestructura.AccesoDatos.EF
{
    public class ObligatorioContext : DbContext
    {
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<TipoGasto> TiposGasto { get; set; }

        public ObligatorioContext(DbContextOptions<ObligatorioContext> options) : base(options) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseSqlServer(@"SERVER=(localdb)\MSSQLLocalDb;Initial Catalog=Obligatorio339429;Integrated Security=true;");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // fluentApi

            //Equipo

            modelBuilder.Entity<Equipo>()
                .OwnsOne(Equipo => Equipo.Nombre, VoNombreEquipo => { VoNombreEquipo.Property(p => p.Value).HasColumnName("Nombre"); });

            // Usuario

            modelBuilder.Entity<Usuario>()
                .OwnsOne(Usuario => Usuario.Nombre, VoNombre => { VoNombre.Property(p => p.Value).HasColumnName("Nombre"); })
                .OwnsOne(Usuario => Usuario.Apellido, VoApellido => { VoApellido.Property(p => p.Value).HasColumnName("Apellido"); })
                .OwnsOne(Usuario => Usuario.Contrasena, VoContrasena => { VoContrasena.Property(p => p.Value).HasColumnName("Contrasena"); })
                .OwnsOne(Usuario => Usuario.Email, VoEmail => { VoEmail.Property(p => p.Value).HasColumnName("Email"); })
                .HasOne(Usuario => Usuario.Equipo)
                .WithMany(Equipo => Equipo.Usuarios)
                .HasForeignKey(Usuario => Usuario.IDEquipo)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Usuario>()
                .HasDiscriminator<string>("TipoUsuario")
                .HasValue<Usuario>("Usuario")
                .HasValue<Administrador>("Administrador")
                .HasValue<Gerente>("Gerente")
                .HasValue<Empleado>("Empleado");

            //TipoPago

            modelBuilder.Entity<TipoGasto>()
                .OwnsOne(TipoGasto => TipoGasto.NombreGasto, VoNombreGasto => { VoNombreGasto.Property(p => p.Value).HasColumnName("Nombre"); })
                .OwnsOne(TipoGasto => TipoGasto.Descripcion, VoDescripcion => { VoDescripcion.Property(p => p.Value).HasColumnName("Descripcion"); });

        }
    }
}

