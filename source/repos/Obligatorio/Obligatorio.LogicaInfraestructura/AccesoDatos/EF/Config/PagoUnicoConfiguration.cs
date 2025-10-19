using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.LogicaInfraestructura.AccesoDatos.EF.Config
{
    public class PagoUnicoConfiguration : IEntityTypeConfiguration<PagoUnico>
    {
        public void Configure(EntityTypeBuilder<PagoUnico> builder)
        {
            builder.Property(PagoUnico => PagoUnico.FechaPago)
                .HasColumnName("FechaPago")
                .HasColumnType("datetime");

            builder.OwnsOne(PagoUnico => PagoUnico.NumeroRecibo, VoNumeroRecibo =>
            {
                VoNumeroRecibo.Property(p => p.Value).HasColumnName("NumeroRecibo");
            }
            );
        }
    }
}
