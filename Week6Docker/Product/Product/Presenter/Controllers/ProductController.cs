using System;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Product.Application.Models.Query;
using Product.Application.UseCases.Products;
using System.Threading.Tasks;

namespace Product.Presenter.Controllers
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
            return Ok(await _mediator.Send(payload));
        }

        [HttpGet]
        public async Task<ActionResult<BaseDto<ProductInput>>> Get()
        {
            return Ok(await _mediator.Send(new GetProductsQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseDto<ProductInput>>> GetbyId(int Id)
        {
            return Ok(await _mediator.Send(new GetProductQuery() { id = Id }));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BaseDto<ProductInput>>> PutbyId(int Id, [FromBody] BaseRequest<ProductInput> payload)
        {
            return Ok(await _mediator.Send(new UpdateProductCommand() { id = Id, data = payload.data }));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseDto<ProductInput>>> DeletebyId(int Id)
        {
            return Ok(await _mediator.Send(new DeleteProductCommand() { id = Id }));
        }
    }
}
