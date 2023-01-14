using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Libro.Dtos;
using TiendaServicios.Api.Libro.Persistencia;

namespace TiendaServicios.Api.Libro.Aplicacion
{
    public class GetBooks
    {
        public class Query : IRequest<List<LibroDto>>
        {
        }

        public class QueryHandler : IRequestHandler<Query, List<LibroDto>>
        {
            private readonly ContextoLibro contexto;
            private readonly IMapper mapper;

            public QueryHandler(ContextoLibro contexto, IMapper mapper)
            {
                this.contexto = contexto;
                this.mapper = mapper;
            }

            public async Task<List<LibroDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var libros = await contexto.Libros.ToListAsync();
                return mapper.Map<List<LibroDto>>(libros);
            }
        }
    }
}
