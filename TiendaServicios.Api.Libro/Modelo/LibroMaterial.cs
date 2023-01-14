using System.ComponentModel.DataAnnotations;

namespace TiendaServicios.Api.Libro.Modelo
{
    public class LibroMaterial
    {
        [Key]
        public Guid LibroId { get; set; }
        public string? Titulo { get; set; }
        public DateTime? FechaPublicacion { get; set; }
        public Guid? AutorLibroGuid { get; set; }
    }
}
