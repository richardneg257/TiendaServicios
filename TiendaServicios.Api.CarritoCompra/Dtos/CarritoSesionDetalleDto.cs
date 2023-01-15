using TiendaServicios.Api.CarritoCompra.Modelo;

namespace TiendaServicios.Api.CarritoCompra.Dtos
{
    public class CarritoSesionDetalleDto
    {
        public Guid? LibroId { get; set; }
        public string? TituloLibro { get; set; }
        public string? AutorLibro { get; set; }
        public DateTime? FechaPublicacion { get; set; }
    }
}
