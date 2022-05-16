using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PS.Template.Domain.Models;

namespace PS.Template.Domain.Settings
{
    public class SettingsAlquileres
    {
        public SettingsAlquileres(EntityTypeBuilder<Alquileres> BuilderAlq)
        {
            //Primary Key.
            BuilderAlq.HasKey(X => X.Id);

            //Others Entitys.
            BuilderAlq.Property(X => X.FechaAlquiler);
            BuilderAlq.Property(X => X.FechaDevolucion);
            BuilderAlq.Property(X => X.FechaReserva);

        }
    }
}
