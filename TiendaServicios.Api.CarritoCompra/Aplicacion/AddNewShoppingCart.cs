using MediatR;
using TiendaServicios.Api.CarritoCompra.Modelo;
using TiendaServicios.Api.CarritoCompra.Persistencia;

namespace TiendaServicios.Api.CarritoCompra.Aplicacion
{
    public class AddNewShoppingCart
    {
        public class Command : IRequest
        {
            public Command()
            {
                ListaLibros = new List<string>();
            }

            public DateTime FechaCreacionSesion { get; set; }
            public List<string> ListaLibros { get; set; }
        }

        public class CommandHandler : IRequestHandler<Command>
        {
            private readonly ContextoCarrito contexto;

            public CommandHandler(ContextoCarrito contexto)
            {
                this.contexto = contexto;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var carritoSesion = new CarritoSesion()
                {
                    FechaCreacion = request.FechaCreacionSesion
                };
                contexto.CarritoSesion.Add(carritoSesion);
                var value = await contexto.SaveChangesAsync();
                if (value == 0) throw new Exception("Errores en la inserción del carrito de compras");

                int idSesion = carritoSesion.CarritoSesionId;
                foreach(var item in request.ListaLibros)
                {
                    var detalleSesion = new CarritoSesionDetalle()
                    {
                        FechaCreacion = DateTime.Now,
                        CarritoSesionId = idSesion,
                        LibroSeleccionado = item
                    };
                    contexto.CarritoSesionDetalle.Add(detalleSesion);
                }
                value = await contexto.SaveChangesAsync();
                if (value > 0) return Unit.Value;

                throw new Exception("No se pudo insertar el detalle del carrito de compras");
            }
        }
    }
}
