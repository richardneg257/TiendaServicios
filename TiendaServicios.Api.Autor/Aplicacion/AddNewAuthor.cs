using FluentValidation;
using MediatR;
using TiendaServicios.Api.Autor.Modelo;
using TiendaServicios.Api.Autor.Persistencia;

namespace TiendaServicios.Api.Autor.Aplicacion
{
    public class AddNewAuthor
    {
        public class Command : IRequest
        {
            public string? Nombre { get; set; }
            public string? Apellido { get; set; }
            public DateTime? FechaNacimiento { get; set; }
        }

        public class CommandValidation : AbstractValidator<Command>
        {
            public CommandValidation()
            {
                RuleFor(x => x.Nombre).NotNull().NotEmpty().MaximumLength(3);
                RuleFor(x => x.Apellido).NotNull().NotEmpty().MaximumLength(3);
            }
        }

        public class CommandHandler : IRequestHandler<Command>
        {
            private readonly ContextoAutor contexto;

            public CommandHandler(ContextoAutor contexto)
            {
                this.contexto = contexto;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
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
