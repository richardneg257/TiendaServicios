using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Libro.Modelo;

namespace TiendaServicios.Api.Libro.Persistencia
{
    public class ContextoLibro : DbContext
    {
        public ContextoLibro(DbContextOptions<ContextoLibro> options) : base(options)
        {
        }

        public DbSet<LibroMaterial> Libros { get; set; }
    }
}
