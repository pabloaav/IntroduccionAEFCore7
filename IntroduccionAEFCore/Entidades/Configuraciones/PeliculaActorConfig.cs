using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntroduccionAEFCore.Entidades.Configuraciones
{
    public class PeliculaActorConfig : IEntityTypeConfiguration<PeliculaActor>
    {
        public void Configure(EntityTypeBuilder<PeliculaActor> builder)
        {
            // llave primaria compuesta para la tabla intermedia entre Peliculas y Actores
            builder.HasKey(pa => new { pa.ActorId, pa.PeliculaId });
        }
    }
}
