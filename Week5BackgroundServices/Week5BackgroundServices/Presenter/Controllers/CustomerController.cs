using System;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Week5BackgroundServices.Application.Models.Query;
using Week5BackgroundServices.Application.UseCases.Customers;
using System.Threading.Tasks;
using Hangfire;

namespace Week5BackgroundServices.Presenter.Controllers
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
            var msg = "Post a Customer Data";
            BackgroundJob.Enqueue(() => Console.WriteLine(msg));
            EmailSender.SendEmail(msg);
            return Ok(await _mediator.Send(payload));
        }

        [HttpGet]
        public async Task<ActionResult<BaseDto<CustomerInput>>> Get()
        {
            var msg = "Get all Customer Data";
            BackgroundJob.Enqueue(() => Console.WriteLine(msg));
            EmailSender.SendEmail(msg);
            return Ok(await _mediator.Send(new GetCustomersQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseDto<CustomerInput>>> GetbyId(int Id)
        {
            var msg = "Get a Customer Data";
            BackgroundJob.Enqueue(() => Console.WriteLine(msg));
            EmailSender.SendEmail(msg);
            return Ok(await _mediator.Send(new GetCustomerQuery() { id = Id }));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BaseDto<CustomerInput>>> PutbyId(int Id, [FromBody] BaseRequest<CustomerInput> payload)
        {
            var msg = "Update a Customer Data";
            BackgroundJob.Enqueue(() => Console.WriteLine(msg));
            EmailSender.SendEmail(msg);
            return Ok(await _mediator.Send(new UpdateCustomerCommand() { id = Id, data = payload.data }));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseDto<CustomerInput>>> DeletebyId(int Id)
        {
            var msg = "Delete a Customer Data";
            BackgroundJob.Enqueue(() => Console.WriteLine(msg));
            EmailSender.SendEmail(msg);
            return Ok(await _mediator.Send(new DeleteCustomerCommand() { id = Id }));
        }
    }
}
