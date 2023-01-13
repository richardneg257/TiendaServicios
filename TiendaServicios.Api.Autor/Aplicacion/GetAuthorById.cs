using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Autor.Dtos;
using TiendaServicios.Api.Autor.Modelo;
using TiendaServicios.Api.Autor.Persistencia;

namespace TiendaServicios.Api.Autor.Aplicacion
{
    public class GetAuthorById
    {
        public class Query : IRequest<AutorDto>
        {
            public string? AutorLibroGuid { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, AutorDto>
        {
            private readonly ContextoAutor contexto;
            private readonly IMapper mapper;

            public QueryHandler(ContextoAutor contexto, IMapper mapper)
            {
                this.contexto = contexto;
                this.mapper = mapper;
            }

            public async Task<AutorDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var autor = await contexto.AutorLibro.FirstOrDefaultAsync(x => x.AutorLibroGuid == request.AutorLibroGuid);
                if (autor is null) throw new Exception("No se encontró el autor");

                return mapper.Map<AutorDto>(autor);
            }
        }
    }
}
