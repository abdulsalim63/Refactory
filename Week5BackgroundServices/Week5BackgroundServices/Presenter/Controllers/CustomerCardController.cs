using System;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Week5BackgroundServices.Application.Models.Query;
using Week5BackgroundServices.Application.UseCases.CustomerCards;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Hangfire;

namespace Week5BackgroundServices.Presenter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
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
            var msg = "Post a Customer Card Payment Data";
            BackgroundJob.Enqueue(() => Console.WriteLine(msg));
            EmailSender.SendEmail(msg);
            return Ok(await _mediator.Send(payload));
        }

        [HttpGet]
        public async Task<ActionResult<BaseDto<CustomerCardInput>>> Get()
        {
            var msg = "Get all Customer Card Payment Data";
            BackgroundJob.Enqueue(() => Console.WriteLine(msg));
            EmailSender.SendEmail(msg);
            return Ok(await _mediator.Send(new GetCustomerCardsQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseDto<CustomerCardInput>>> GetbyId(int Id)
        {
            var msg = "Get a Customer Card Payment Data";
            BackgroundJob.Enqueue(() => Console.WriteLine(msg));
            EmailSender.SendEmail(msg);
            return Ok(await _mediator.Send(new GetCustomerCardQuery() { id = Id }));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BaseDto<CustomerCardInput>>> PutbyId(int Id, [FromBody] BaseRequest<CustomerCardInput> payload)
        {
            var msg = "Update a Customer Card Payment Data";
            BackgroundJob.Enqueue(() => Console.WriteLine(msg));
            EmailSender.SendEmail(msg);
            return Ok(await _mediator.Send(new UpdateCustomerCardCommand() { id = Id, data = payload.data }));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseDto<CustomerCardInput>>> DeletebyId(int Id)
        {
            var msg = "Delete a Customer Card Payment Data";
            BackgroundJob.Enqueue(() => Console.WriteLine(msg));
            EmailSender.SendEmail(msg);
            return Ok(await _mediator.Send(new DeleteCustomerCardCommand() { id = Id }));
        }
    }
}
