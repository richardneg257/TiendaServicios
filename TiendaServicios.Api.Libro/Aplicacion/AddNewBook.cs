using AutoMapper;
using FluentValidation;
using MediatR;
using TiendaServicios.Api.Libro.Modelo;
using TiendaServicios.Api.Libro.Persistencia;

namespace TiendaServicios.Api.Libro.Aplicacion
{
    public class AddNewBook
    {
        public class Command : IRequest
        {
            public string? Titulo { get; set; }
            public DateTime? FechaPublicacion { get; set; }
            public Guid? AutorLibroGuid { get; set; }
        }

        public class CommandValidation : AbstractValidator<Command>
        {
            public CommandValidation()
            {
                RuleFor(x => x.Titulo).NotNull().NotEmpty();
                RuleFor(x => x.FechaPublicacion).NotNull().NotEmpty();
                RuleFor(x => x.AutorLibroGuid).NotNull().NotEmpty();
            }
        }

        public class CommandHandler : IRequestHandler<Command>
        {
            private readonly ContextoLibro contexto;

            public CommandHandler(ContextoLibro contexto)
            {
                this.contexto = contexto;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var libro = new LibroMaterial()
                {
                    Titulo = request.Titulo,
                    FechaPublicacion = request.FechaPublicacion,
                    AutorLibroGuid = request.AutorLibroGuid
                };

                contexto.Libros.Add(libro);
                var value = await contexto.SaveChangesAsync();

                if (value > 0) return Unit.Value;

                throw new Exception("No se pudo guardar el libro");
            }
        }
    }
}
