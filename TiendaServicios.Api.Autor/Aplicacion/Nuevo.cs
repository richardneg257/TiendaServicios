using MediatR;
using TiendaServicios.Api.Autor.Modelo;
using TiendaServicios.Api.Autor.Persistencia;

namespace TiendaServicios.Api.Autor.Aplicacion
{
    public class Nuevo
    {
        public class Ejecuta : IRequest
        {
            public string? Nombre { get; set; }
            public string? Apellido { get; set; }
            public DateTime? FechaNacimiento { get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly ContextoAutor contexto;

            public Manejador(ContextoAutor contexto)
            {
                this.contexto = contexto;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var autorLibro = new AutorLibro()
                {
                    Nombre = request.Nombre,
                    Apellido = request.Apellido,
                    FechaNacimiento = request.FechaNacimiento,
                    AutorLibroGuid = Guid.NewGuid().ToString()
                };

                contexto.AutorLibro.Add(autorLibro);
                var valor = await contexto.SaveChangesAsync();

                if (valor > 0) return Unit.Value;

                throw new Exception("No se pudo insertar el Autor del libro");
            }
        }
    }
}
