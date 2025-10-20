using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.Factories;

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

            builder.OwnsOne(Pago => Pago.MontoPago, VoMontoPago =>
            {
                VoMontoPago.Property(p => p.Value).HasColumnName("Monto");
            }
            );

            builder.HasOne(Pago => Pago.Usuario)
                .WithMany(Usuario => Usuario.Pagos)
                .HasForeignKey(Pago => Pago.IDUsuario)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property("MetodoPago")
                .HasConversion(new ValueConverter<MetodoPago, string>(
                    v => v.ToString(), // Guardo en la base como string
                    v => new MetodoPagoFactory().Crear(v) // Obtengo de la base como un objeto
                    ))
                .HasColumnName("MetodoPago")
                .IsRequired();

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
