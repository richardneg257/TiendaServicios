using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Autor.Modelo;
using TiendaServicios.Api.Autor.Persistencia;

namespace TiendaServicios.Api.Autor.Aplicacion
{
    public class GetAuthorById
    {
        public class Query : IRequest<AutorLibro>
        {
            public string? AutorLibroGuid { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, AutorLibro>
        {
            private readonly ContextoAutor contexto;

            public QueryHandler(ContextoAutor contexto)
            {
                this.contexto = contexto;
            }

            public async Task<AutorLibro> Handle(Query request, CancellationToken cancellationToken)
            {
                var autor = await contexto.AutorLibro.FirstOrDefaultAsync(x => x.AutorLibroGuid == request.AutorLibroGuid);
                if (autor is null) throw new Exception("No se encontró el autor");

                return autor;
            }
        }
    }
}
