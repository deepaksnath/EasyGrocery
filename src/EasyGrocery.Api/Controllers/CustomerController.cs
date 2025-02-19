using EasyGrocery.Api.Models;
using EasyGrocery.Api.Validators;
using EasyGrocery.Application.Handlers.CustomerHandler.Commands;
using EasyGrocery.Application.Handlers.CustomerHandler.Queries;
using EasyGrocery.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EasyGrocery.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController(IMediator _mediator) : ControllerBase
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
        [ProducesResponseType(typeof(Customer), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Customer), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] CustomerModel customerModel)
        {
            var validator = new CustomerModelValidator();
            var valResult = validator.Validate(customerModel);
            if (!valResult.IsValid)
            {
                return BadRequest(valResult.Errors);
            }

            AddCustomerCommand command = new()
            {
                Name = customerModel.Name,
                Email = customerModel.Email,
                Phone = customerModel.Phone,
                HasLoyaltyMembership = customerModel.HasLoyaltyMembership
            };
            var newCustomer = await _mediator.Send(command);
            if (newCustomer is not null)
            {
                return Ok(newCustomer);
            }
            return BadRequest();
        }

        [HttpPut]
        [ProducesResponseType(typeof(Customer), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Customer), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Customer), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Put([FromBody] CustomerModel customerModel)
        {
            var validator = new CustomerModelValidator();
            var valResult = validator.Validate(customerModel);
            if (!valResult.IsValid)
            {
                return BadRequest(valResult.Errors);
            }

            UpdateCustomerCommand command = new()
            {
                Id = customerModel.Id,
                Name = customerModel.Name,
                Email = customerModel.Email,
                Phone = customerModel.Phone,
                HasLoyaltyMembership = customerModel.HasLoyaltyMembership
            };
            Customer? newCustomer = await _mediator.Send(command);
            if (newCustomer is not null)
            {
                return Ok(newCustomer);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Customer), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Customer), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Customer), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }
            Customer? customer = await _mediator.Send(new DeleteCustomerCommand(id));
            if (customer is not null)
            {
                return Ok(customer);
            }
            return NotFound();
        }

    }
}
