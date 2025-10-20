using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.LogicaInfraestructura.AccesoDatos.EF.Config
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.OwnsOne(Usuario => Usuario.Nombre, VoNombre =>
            {
                VoNombre.Property(p => p.Value).HasColumnName("Nombre");
            });

            builder.OwnsOne(Usuario => Usuario.Apellido, VoApellido =>
            {
                VoApellido.Property(p => p.Value).HasColumnName("Apellido");
            }
            );

            builder.OwnsOne(Usuario => Usuario.Contrasena, VoContrasena =>
            {
                VoContrasena.Property(p => p.Value).HasColumnName("Contrasena");
            }
            );

            builder.OwnsOne(Usuario => Usuario.Email, VoEmail =>
            {
                VoEmail.Property(p => p.Value).HasColumnName("Email");
            }
            );

            builder.HasOne(Usuario => Usuario.Equipo)
                .WithMany(Equipo => Equipo.Usuarios)
                .HasForeignKey(Usuario => Usuario.IDEquipo)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasDiscriminator<string>("TipoUsuario")
                .HasValue<Usuario>("Usuario")
                .HasValue<Administrador>("Administrador")
                .HasValue<Gerente>("Gerente")
                .HasValue<Empleado>("Empleado");
        }
    }
}
