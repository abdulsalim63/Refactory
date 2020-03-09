using System;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Week5BackgroundServices.Application.Models.Query;
using Week5BackgroundServices.Application.UseCases.Products;
using System.Threading.Tasks;
using Hangfire;

namespace Week5BackgroundServices.Presenter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<BaseDto<ProductInput>>> Post([FromBody] BaseRequest<ProductInput> payload)
        {
            var msg = "Post a Product Data";
            BackgroundJob.Enqueue(() => Console.WriteLine(msg));
            EmailSender.SendEmail(msg);
            return Ok(await _mediator.Send(payload));
        }

        [HttpGet]
        public async Task<ActionResult<BaseDto<ProductInput>>> Get()
        {
            var msg = "Get all Product Data";
            BackgroundJob.Enqueue(() => Console.WriteLine(msg));
            EmailSender.SendEmail(msg);
            return Ok(await _mediator.Send(new GetProductsQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseDto<ProductInput>>> GetbyId(int Id)
        {
            var msg = "Get a Product Data";
            BackgroundJob.Enqueue(() => Console.WriteLine(msg));
            EmailSender.SendEmail(msg);
            return Ok(await _mediator.Send(new GetProductQuery() { id = Id }));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BaseDto<ProductInput>>> PutbyId(int Id, [FromBody] BaseRequest<ProductInput> payload)
        {
            var msg = "Update a Product Data";
            BackgroundJob.Enqueue(() => Console.WriteLine(msg));
            EmailSender.SendEmail(msg);
            return Ok(await _mediator.Send(new UpdateProductCommand() { id = Id, data = payload.data }));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseDto<ProductInput>>> DeletebyId(int Id)
        {
            var msg = "Delete a Product Data";
            BackgroundJob.Enqueue(() => Console.WriteLine(msg));
            EmailSender.SendEmail(msg);
            return Ok(await _mediator.Send(new DeleteProductCommand() { id = Id }));
        }
    }
}
