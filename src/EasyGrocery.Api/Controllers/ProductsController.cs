using EasyGrocery.Application.Handlers.ProductHandler.Commands;
using EasyGrocery.Application.Handlers.ProductHandler.Queries;
using EasyGrocery.Application.Models;
using EasyGrocery.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EasyGrocery.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> Get()
        {
            var response = await _mediator.Send(new GetAllProductsQuery());
            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }
            Product? product = await _mediator.Send(new GetProductByIdQuery(id));
            if (product is not null)
            {
                return Ok(product);
            }
            return NotFound();
        }

        [HttpPost]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> Post([FromBody] ProductModel productModel)
        {
            AddProductCommand command = new(productModel);
            var id = await _mediator.Send(command);
            return StatusCode(StatusCodes.Status201Created, id);
        }

        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Put(Guid id, [FromBody] ProductModel productModel)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }
            UpdateProductCommand command = new(productModel);
            bool response = await _mediator.Send(command);
            if (response)
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }
            bool response = await _mediator.Send(new DeleteProductCommand(id));
            if (response)
            {
                return StatusCode(StatusCodes.Status200OK);
            }
            return NotFound("Product doesn't exist.");
        }

    }
}
