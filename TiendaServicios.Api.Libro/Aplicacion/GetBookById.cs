using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Libro.Dtos;
using TiendaServicios.Api.Libro.Persistencia;

namespace TiendaServicios.Api.Libro.Aplicacion
{
    public class GetBookById
    {
        public class Query : IRequest<LibroDto>
        {
            public Guid? LibroId { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, LibroDto>
        {
            private readonly ContextoLibro contexto;
            private readonly IMapper mapper;

            public QueryHandler(ContextoLibro contexto, IMapper mapper)
            {
                this.contexto = contexto;
                this.mapper = mapper;
            }

            public async Task<LibroDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var libro = await contexto.Libros.FirstOrDefaultAsync(x => x.LibroId == request.LibroId);
                if (libro is null) throw new Exception("No se encontró el Libro");

                return mapper.Map<LibroDto>(libro);
            }
        }
    }
}
