using AutoMapper;
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
    public class CustomerController(IMediator _mediator, IMapper _mapper) : ControllerBase
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
        [ProducesResponseType(typeof(Customer), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
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
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] CustomerModel customerModel)
        {
            AddCustomerCommand command = _mapper.Map<AddCustomerCommand>(customerModel);
            var id = await _mediator.Send(command);
            if (!id.Equals(Guid.Empty))
            {
                return StatusCode(StatusCodes.Status201Created, id);
            }
            return BadRequest();
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Put([FromBody] CustomerModel customerModel)
        {

            UpdateCustomerCommand command = _mapper.Map<UpdateCustomerCommand>(customerModel);
            bool response = await _mediator.Send(command);
            if (response)
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }
            bool response = await _mediator.Send(new DeleteCustomerCommand(id));
            if (response)
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }
            return NotFound();
        }

    }
}
