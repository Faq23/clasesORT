using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.LogicaInfraestructura.AccesoDatos.EF.Config
{
    public class AuditoriaConfiguration : IEntityTypeConfiguration<Auditoria>
    {
        public void Configure(EntityTypeBuilder<Auditoria> builder)
        {
            builder.OwnsOne(Auditoria => Auditoria.Descripcion, VoDescripcionAuditoria =>
            {
                VoDescripcionAuditoria.Property(p => p.Value).HasColumnName("Descripcion");
            }
            );

            builder.OwnsOne(Auditoria => Auditoria.NombreUsuario, VoNombreUsuarioAuditoria =>
            {
                VoNombreUsuarioAuditoria.Property(p => p.Value).HasColumnName("NombreUsuario");
            }
            );
        }
    }
}
