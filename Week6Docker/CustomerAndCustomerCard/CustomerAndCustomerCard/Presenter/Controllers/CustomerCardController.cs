using System;
using System.Threading.Tasks;
using CustomerAndCustomerCard.Application.Models.Query;
using CustomerAndCustomerCard.Application.UseCases.CustomerCards;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CustomerCardAndCustomerCardCard.Presenter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerCardController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerCardController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<BaseDto<CustomerCardInput>>> Post([FromBody] BaseRequest<CustomerCardInput> payload)
        {
            return Ok(await _mediator.Send(payload));
        }

        [HttpGet]
        public async Task<ActionResult<BaseDto<CustomerCardInput>>> Get()
        {
            return Ok(await _mediator.Send(new GetCustomerCardsQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseDto<CustomerCardInput>>> GetbyId(int Id)
        {
            return Ok(await _mediator.Send(new GetCustomerCardQuery() { id = Id }));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BaseDto<CustomerCardInput>>> PutbyId(int Id, [FromBody] BaseRequest<CustomerCardInput> payload)
        {
            return Ok(await _mediator.Send(new UpdateCustomerCardCommand() { id = Id, data = payload.data }));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseDto<CustomerCardInput>>> DeletebyId(int Id)
        {
            return Ok(await _mediator.Send(new DeleteCustomerCardCommand() { id = Id }));
        }
    }
}
