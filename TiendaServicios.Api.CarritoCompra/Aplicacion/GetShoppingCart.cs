using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.CarritoCompra.Dtos;
using TiendaServicios.Api.CarritoCompra.Persistencia;
using TiendaServicios.Api.CarritoCompra.RemoteInterface;

namespace TiendaServicios.Api.CarritoCompra.Aplicacion
{
    public class GetShoppingCart
    {
        public class Query : IRequest<CarritoSesionDto>
        {
            public int CarritoSesionId { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, CarritoSesionDto>
        {
            private readonly ContextoCarrito contexto;
            private readonly ILibrosService librosService;

            public QueryHandler(ContextoCarrito contexto, ILibrosService librosService)
            {
                this.contexto = contexto;
                this.librosService = librosService;
            }

            public async Task<CarritoSesionDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var carritoSesion = await contexto.CarritoSesion.FirstOrDefaultAsync(x => x.CarritoSesionId == request.CarritoSesionId);
                var carritoSesionDetalle = await contexto.CarritoSesionDetalle.Where(x => x.CarritoSesionId == request.CarritoSesionId).ToListAsync();
                var listaCarritoDetalleDto = new List<CarritoSesionDetalleDto>();
                
                foreach(var item in carritoSesionDetalle)
                {
                    var response = await librosService.GetLibro(new Guid(item.LibroSeleccionado));
                    if (response.resultado)
                    {
                        var objetoLibro = response.libro;
                        var carritoDetalle = new CarritoSesionDetalleDto()
                        {
                            TituloLibro = objetoLibro?.Titulo,
                            FechaPublicacion = objetoLibro?.FechaPublicacion,
                            LibroId = objetoLibro?.LibroId,
                        };
                        listaCarritoDetalleDto.Add(carritoDetalle);
                    }
                }

                var carritoSesionDto = new CarritoSesionDto()
                {
                    CarritoId = carritoSesion.CarritoSesionId,
                    FechaCreacionSesion = carritoSesion?.FechaCreacion,
                    ListaProductos = listaCarritoDetalleDto
                };

                return carritoSesionDto;
            }
        }
    }
}
