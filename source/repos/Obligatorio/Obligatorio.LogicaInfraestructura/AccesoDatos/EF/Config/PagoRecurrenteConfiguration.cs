using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.LogicaInfraestructura.AccesoDatos.EF.Config
{
    public class PagoRecurrenteConfiguration : IEntityTypeConfiguration<PagoRecurrente>
    {
        public void Configure(EntityTypeBuilder<PagoRecurrente> builder)
        {
            builder.Property(PagoRecurrente => PagoRecurrente.FechaInicio)
                .HasColumnName("FechaInicio")
                .HasColumnType("datetime");

            builder.Property(PagoRecurrente => PagoRecurrente.FechaFin)
                .HasColumnName("FechaFin")
                .HasColumnType("datetime");
        }
    }
}
