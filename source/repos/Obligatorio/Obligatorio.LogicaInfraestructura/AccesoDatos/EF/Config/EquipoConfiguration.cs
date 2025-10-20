using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.LogicaInfraestructura.AccesoDatos.EF.Config
{
    public class EquipoConfiguration : IEntityTypeConfiguration<Equipo>
    {
        public void Configure(EntityTypeBuilder<Equipo> builder)
        {
            builder.OwnsOne(Equipo => Equipo.Nombre, VoNombreEquipo =>
            {
                VoNombreEquipo.Property(p => p.Value).HasColumnName("Nombre");
            }
            );
        }
    }
}
