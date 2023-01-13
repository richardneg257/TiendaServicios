using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Autor.Modelo;
using TiendaServicios.Api.Autor.Persistencia;

namespace TiendaServicios.Api.Autor.Aplicacion
{
    public class GetAuthors
    {
        public class Query : IRequest<List<AutorLibro>>
        {

        }

        public class QueryHandler : IRequestHandler<Query, List<AutorLibro>>
        {
            private readonly ContextoAutor contexto;

            public QueryHandler(ContextoAutor contexto)
            {
                this.contexto = contexto;
            }

            public async Task<List<AutorLibro>> Handle(Query request, CancellationToken cancellationToken)
            {
                var autores = await contexto.AutorLibro.ToListAsync();
                return autores;
            }
        }
    }
}
