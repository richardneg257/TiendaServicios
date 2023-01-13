using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiendaServicios.Api.Autor.Aplicacion;
using TiendaServicios.Api.Autor.Modelo;

namespace TiendaServicios.Api.Autor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        private readonly IMediator mediator;

        public AutoresController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<AutorLibro>>> GetAutores()
        {
            return await mediator.Send(new GetAuthors.Query());
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear([FromBody] AddNewAuthor.Command command)
        {
            return await mediator.Send(command);
        }
    }
}
