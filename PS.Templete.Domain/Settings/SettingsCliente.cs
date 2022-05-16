using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PS.Template.Domain.Models;

namespace PS.Template.Domain.Settings
{
    public class SettingsCliente
    {
        public SettingsCliente(EntityTypeBuilder<Cliente> BuilderCliente)
        {
            //Primary Key.
            BuilderCliente.HasKey(X => X.ClienteId);

            //Others Entitys.
            BuilderCliente.Property(X => X.DNI).HasMaxLength(10).IsRequired();
            BuilderCliente.Property(X => X.Nombre).HasMaxLength(45).IsRequired();
            BuilderCliente.Property(X => X.Apellido).HasMaxLength(45).IsRequired();
            BuilderCliente.Property(X => X.Email).HasMaxLength(45).IsRequired();

            //Foraing Key.
            //BuilderCliente.HasMany(X => X.Alquiler_C).WithOne(Z => Z.clientesId).HasForeignKey(X => X.Id);
            //Esto no se si esta del todo bien hecho.
        }
    }
}
