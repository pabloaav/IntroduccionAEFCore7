namespace IntroduccionAEFCore.Entidades
{
    public class Pelicula
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public bool EnCines { get; set; }
        public DateTime FechaEstreno { get; set; }
        public HashSet<Comentario> Comentarios { get; set; } = new HashSet<Comentario>(); // relacion: una pelicula puede tener varios comentarios
        public HashSet<Genero> Generos { get; set; } = new HashSet<Genero>(); // muchoas peliculas pueden tener varios generos
        public List<PeliculaActor> PeliculasActores { get; set; } = new List<PeliculaActor>(); // enlace a la entidad intermedia. Es List porque queremos los resultados ordenados
    }
}
