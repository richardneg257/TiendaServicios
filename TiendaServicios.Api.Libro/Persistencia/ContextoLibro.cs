using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Libro.Modelo;

namespace TiendaServicios.Api.Libro.Persistencia
{
    public class ContextoLibro : DbContext
    {
        public ContextoLibro()
        {

        }

        public ContextoLibro(DbContextOptions<ContextoLibro> options) : base(options)
        {
        }

        public virtual DbSet<LibroMaterial> Libros { get; set; }
    }
}
