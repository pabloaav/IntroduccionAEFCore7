using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace IntroduccionAEFCore.Entidades.Configuraciones
{
    // se implementa una interfaz que tiene un metodo para configurar la api fleunte de una entidad
    public class ActorConfig : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.Property(a => a.FechaNacimiento).HasColumnType("date");
            builder.Property(a => a.Fortuna).HasPrecision(18, 2);
        }
    }
}
