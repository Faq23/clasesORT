using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.LogicaInfraestructura.AccesoDatos.EF.Config
{
    public class PagoConfiguration : IEntityTypeConfiguration<Pago>
    {
        public void Configure(EntityTypeBuilder<Pago> builder)
        {
            builder.OwnsOne(Pago => Pago.DescripcionPago, VoDescripcionPago =>
            {
                VoDescripcionPago.Property(p => p.Value).HasColumnName("Descripcion");
            }
            );

            builder.HasOne(Pago => Pago.Usuario)
                .WithMany(Usuario => Usuario.Pagos)
                .HasForeignKey(Pago => Pago.IDUsuario)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.OwnsOne(Pago => Pago.MetodoPago, TipoMetodoPago =>
            {
                TipoMetodoPago.Property<string>("TipoMetodoPago")
                .HasColumnName("MetodoPago")
                .IsRequired();
            }
            );

            builder.HasOne(Pago => Pago.TipoGastoAsociado)
                .WithMany(TipoGasto => TipoGasto.Pagos)
                .HasForeignKey(Pago => Pago.IDTipoGasto)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasDiscriminator<string>("TipoPago")
                .HasValue<Pago>("Pago")
                .HasValue<PagoRecurrente>("Pago Recurrente")
                .HasValue<PagoUnico>("Pago Unico");
        }
    }
}
