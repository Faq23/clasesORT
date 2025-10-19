using Microsoft.EntityFrameworkCore;
using Obligatorio.LogicaInfraestructura.AccesoDatos.EF.Config;
using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.LogicaInfraestructura.AccesoDatos.EF
{
    public class ObligatorioContext : DbContext
    {
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<TipoGasto> TiposGasto { get; set; }

        public DbSet<Pago> Pagos { get; set; }

        public ObligatorioContext(DbContextOptions<ObligatorioContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // fluentApi

            modelBuilder.ApplyConfiguration(new EquipoConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new TipoGastoConfiguration());
            modelBuilder.ApplyConfiguration(new PagoConfiguration());
            modelBuilder.ApplyConfiguration(new PagoUnicoConfiguration());
            modelBuilder.ApplyConfiguration(new PagoRecurrenteConfiguration());
        }
    }
}

