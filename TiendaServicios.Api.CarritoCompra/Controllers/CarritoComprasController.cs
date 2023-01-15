using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiendaServicios.Api.CarritoCompra.Aplicacion;
using TiendaServicios.Api.CarritoCompra.Dtos;

namespace TiendaServicios.Api.CarritoCompra.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarritoComprasController : ControllerBase
    {
        private readonly IMediator mediator;

        public CarritoComprasController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<CarritoSesionDto>> GetCarrito(int id)
        {
            return await mediator.Send(new GetShoppingCart.Query() { CarritoSesionId = id });
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear([FromBody] AddNewShoppingCart.Command command)
        {
            return await mediator.Send(command);
        }
    }
}
