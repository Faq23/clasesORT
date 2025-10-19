using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.LogicaInfraestructura.AccesoDatos.EF.Config
{
    public class TipoGastoConfiguration : IEntityTypeConfiguration<TipoGasto>
    {
        public void Configure(EntityTypeBuilder<TipoGasto> builder)
        {
            builder.OwnsOne(TipoGasto => TipoGasto.NombreGasto, VoNombreGasto =>
            {
                VoNombreGasto.Property(p => p.Value).HasColumnName("Nombre");
            }
            );

            builder.OwnsOne(TipoGasto => TipoGasto.Descripcion, VoDescripcion =>
            {
                VoDescripcion.Property(p => p.Value).HasColumnName("Descripcion");
            }
            );
        }
    }
}
