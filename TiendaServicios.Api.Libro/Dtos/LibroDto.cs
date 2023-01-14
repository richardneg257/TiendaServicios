namespace TiendaServicios.Api.Libro.Dtos
{
    public class LibroDto
    {
        public Guid LibroId { get; set; }
        public string? Titulo { get; set; }
        public DateTime? FechaPublicacion { get; set; }
        public Guid? AutorLibroGuid { get; set; }
    }
}
