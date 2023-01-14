using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TiendaServicios.Api.Libro.Aplicacion;
using TiendaServicios.Api.Libro.Dtos;

namespace TiendaServicios.Api.Libro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IValidator<AddNewBook.Command> validator;

        public LibrosController(IMediator mediator, IValidator<AddNewBook.Command> validator)
        {
            this.mediator = mediator;
            this.validator = validator;
        }

        [HttpGet]
        public async Task<ActionResult<List<LibroDto>>> GetLibros()
        {
            return await mediator.Send(new GetBooks.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LibroDto>> GetLibroById(Guid id)
        {
            return await mediator.Send(new GetBookById.Query() { LibroId = id });
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear([FromBody] AddNewBook.Command command)
        {
            var result = await validator.ValidateAsync(command);
            if (!result.IsValid) throw new Exception("Los campos del Libro ingresado no son válidos");

            return await mediator.Send(command);
        }
    }
}
