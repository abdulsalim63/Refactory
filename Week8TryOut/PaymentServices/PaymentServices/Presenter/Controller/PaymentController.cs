using System;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;
using PaymentServices.Application.UseCases.Payments;

namespace PaymentServices.Presenter.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PaymentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreatePaymentCommand payload)
        {
            return Ok(await _mediator.Send(payload));
        }

        [HttpPost("midtrans/push")]
        public IActionResult PostMidtrans()
        {
            return Ok(new { message = "this section isn't finished"});
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetPaymentsQuery()));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetbyId(int Id)
        {
            return Ok(await _mediator.Send(new GetPaymentQuery() { id = Id}));
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdatebyId(int Id, [FromBody] CreatePaymentCommand payload)
        {
            return Ok(await _mediator.Send(new UpdatePaymentCommand() { id = Id, data = payload.data}));
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeletebyId(int Id)
        {
            return Ok(await _mediator.Send(new DeletePaymentCommand() { id = Id}));
        }
    }
}
