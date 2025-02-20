using EasyGrocery.Application.Handlers.CustomerHandler.Commands;
using EasyGrocery.Application.Handlers.CustomerHandler.Queries;
using EasyGrocery.Application.Models;
using EasyGrocery.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EasyGrocery.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Customer>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> Get()
        {
            var response = await _mediator.Send(new GetAllCustomersQuery());
            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Customer), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Customer), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }
            Customer? customer = await _mediator.Send(new GetCustomerByIdQuery(id));
            if (customer is not null)
            {
                return Ok(customer);
            }
            return NotFound();
        }

        [HttpPost]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> Post([FromBody] CustomerModel customerModel)
        {
            AddCustomerCommand command = new(customerModel);
            var id = await _mediator.Send(command);
            return StatusCode(StatusCodes.Status201Created, id);
        }

        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Put(Guid id, [FromBody] CustomerModel customerModel)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }
            UpdateCustomerCommand command = new(customerModel);
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
            bool response = await _mediator.Send(new DeleteCustomerCommand(id));
            if (response)
            {
                return StatusCode(StatusCodes.Status200OK);
            }
            return NotFound("Customer doesn't exist.");
        }

    }
}
