using FluentValidation;
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
        private readonly IValidator<AddNewAuthor.Command> validator;

        public AutoresController(IMediator mediator, IValidator<AddNewAuthor.Command> validator)
        {
            this.mediator = mediator;
            this.validator = validator;
        }

        [HttpGet]
        public async Task<ActionResult<List<AutorLibro>>> GetAutores()
        {
            return await mediator.Send(new GetAuthors.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AutorLibro>> GetById(string id)
        {
            return await mediator.Send(new GetAuthorById.Query() { AutorLibroGuid = id });
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear([FromBody] AddNewAuthor.Command command)
        {
            var result = await validator.ValidateAsync(command);
            if (!result.IsValid) throw new Exception("Los campos del Autor ingresado no son válidos");

            return await mediator.Send(command);
        }
    }
}
