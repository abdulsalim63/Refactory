using System;
using System.Threading.Tasks;
using CustomerAndCustomerCard.Application.Models.Query;
using CustomerAndCustomerCard.Application.UseCases.Customers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CustomerAndCustomerCard.Presenter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<BaseDto<CustomerInput>>> Post([FromBody] BaseRequest<CustomerInput> payload)
        {
            return Ok(await _mediator.Send(payload));
        }

        [HttpGet]
        public async Task<ActionResult<BaseDto<CustomerInput>>> Get()
        {
            return Ok(await _mediator.Send(new GetCustomersQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseDto<CustomerInput>>> GetbyId(int Id)
        {
            return Ok(await _mediator.Send(new GetCustomerQuery() { id = Id }));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BaseDto<CustomerInput>>> PutbyId(int Id, [FromBody] BaseRequest<CustomerInput> payload)
        {
            return Ok(await _mediator.Send(new UpdateCustomerCommand() { id = Id, data = payload.data }));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseDto<CustomerInput>>> DeletebyId(int Id)
        {
            return Ok(await _mediator.Send(new DeleteCustomerCommand() { id = Id }));
        }
    }
}
