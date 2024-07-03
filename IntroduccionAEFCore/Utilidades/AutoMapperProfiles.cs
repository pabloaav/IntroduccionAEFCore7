using AutoMapper;
using IntroduccionAEFCore.DTOs;
using IntroduccionAEFCore.Entidades;

namespace IntroduccionAEFCore.Utilidades
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<GeneroCreacionDTO, Genero>();
            CreateMap<ActorCreacionDTO, Actor>();
            CreateMap<Actor, ActorDTO>();
            CreateMap<ComentarioCreacionDTO, Comentario>();
            // para mapear una coleccion a una lista.
            // una lista tiene eneste caso enteros. por cada entero se crea una instancia de Genero. Esto se llama proyeccion
            CreateMap<PeliculaCreacionDTO, Pelicula>()
                .ForMember(ent => ent.Generos, dto => 
                dto.MapFrom(campo => campo.Generos.Select(id => new Genero { Id = id })));
            // como Pelicula es un objeto complejo, compuesto por otros objetos, internamente se van a mapear campos a objetos. Eso se debe explicitar:
            CreateMap<PeliculaActorCreacionDTO, PeliculaActor>();
        }
    }
}
