using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Autor.Dtos;
using TiendaServicios.Api.Autor.Persistencia;

namespace TiendaServicios.Api.Autor.Aplicacion
{
    public class GetAuthors
    {
        public class Query : IRequest<List<AutorDto>>
        {

        }

        public class QueryHandler : IRequestHandler<Query, List<AutorDto>>
        {
            private readonly ContextoAutor contexto;
            private readonly IMapper mapper;

            public QueryHandler(ContextoAutor contexto, IMapper mapper)
            {
                this.contexto = contexto;
                this.mapper = mapper;
            }

            public async Task<List<AutorDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var autores = await contexto.AutorLibro.ToListAsync();
                return mapper.Map<List<AutorDto>>(autores);
            }
        }
    }
}
