namespace TiendaServicios.Api.CarritoCompra.Dtos
{
    public class CarritoSesionDto
    {
        public CarritoSesionDto()
        {
            ListaProductos = new List<CarritoSesionDetalleDto>();
        }

        public int CarritoId { get; set; }
        public DateTime? FechaCreacionSesion { get; set; }
        public List<CarritoSesionDetalleDto> ListaProductos { get; set; }
    }
}
