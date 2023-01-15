namespace TiendaServicios.Api.CarritoCompra.RemoteModel
{
    public class LibroRemote
    {
        public Guid LibroId { get; set; }
        public string? Titulo { get; set; }
        public DateTime? FechaPublicacion { get; set; }
        public Guid? AutorLibroGuid { get; set; }
    }
}
