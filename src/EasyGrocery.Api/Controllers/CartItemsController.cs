using EasyGrocery.Application.Handlers.CartItemHandler.Commands;
using EasyGrocery.Application.Handlers.CartItemHandler.Queries;
using EasyGrocery.Application.Models;
using EasyGrocery.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EasyGrocery.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemsController(IMediator _mediator) : ControllerBase
    {
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CartItem), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(CartItem), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }
            var cartItems = await _mediator.Send(new GetCartItemsByCustomerIdQuery(id));
            if (cartItems is not null)
            {
                return Ok(cartItems);
            }
            return NotFound();
        }

        [HttpPost]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> Post([FromBody] CartItemModel cartItemModel)
        {
            AddCartItemCommand command = new(cartItemModel);
            var id = await _mediator.Send(command);
            return StatusCode(StatusCodes.Status201Created, id);
        }

        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Put(Guid id, [FromBody] CartItemModel cartItemModel)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }
            UpdateCartItemCommand command = new(cartItemModel);
            bool response = await _mediator.Send(command);
            if (response)
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }
            return NotFound();
        }

    }
}
