using EasyGrocery.Application.Handlers.OrderHandler.Commands;
using EasyGrocery.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EasyGrocery.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController(IMediator _mediator) : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Post([FromBody] OrderModel orderModel)
        {
            AddOrderCommand command = new(orderModel);
            var id = await _mediator.Send(command);
            if(id == Guid.Empty)
            {
                return NotFound();
            }
            else
            {
                return StatusCode(StatusCodes.Status201Created, id);
            }
        }
    }
}
