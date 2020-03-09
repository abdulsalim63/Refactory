using System;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Week5BackgroundServices.Application.Models.Query;
using Week5BackgroundServices.Application.UseCases.Merchants;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Hangfire;

namespace Week5BackgroundServices.Presenter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class MerchantController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MerchantController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<BaseDto<MerchantInput>>> Post([FromBody] BaseRequest<MerchantInput> payload)
        {
            var msg = "Post a Merchant Data";
            BackgroundJob.Enqueue(() => Console.WriteLine(msg));
            EmailSender.SendEmail(msg);
            return Ok(await _mediator.Send(payload));
        }

        [HttpGet]
        public async Task<ActionResult<BaseDto<MerchantInput>>> Get()
        {
            var msg = "Get all Merchant Data";
            BackgroundJob.Enqueue(() => Console.WriteLine(msg));
            EmailSender.SendEmail(msg);
            return Ok(await _mediator.Send(new GetMerchantsQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseDto<MerchantInput>>> GetbyId(int Id)
        {
            var msg = "Get a Merchant Data";
            BackgroundJob.Enqueue(() => Console.WriteLine(msg));
            EmailSender.SendEmail(msg);
            return Ok(await _mediator.Send(new GetMerchantQuery() { id = Id }));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BaseDto<MerchantInput>>> PutbyId(int Id, [FromBody] BaseRequest<MerchantInput> payload)
        {
            var msg = "Update a Merchant Data";
            BackgroundJob.Enqueue(() => Console.WriteLine(msg));
            EmailSender.SendEmail(msg);
            return Ok(await _mediator.Send(new UpdateMerchantCommand() { id = Id, data = payload.data }));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseDto<MerchantInput>>> DeletebyId(int Id)
        {
            var msg = "Delete a Merchant Data";
            BackgroundJob.Enqueue(() => Console.WriteLine(msg));
            EmailSender.SendEmail(msg);
            return Ok(await _mediator.Send(new DeleteMerchantCommand() { id = Id }));
        }
    }
}
