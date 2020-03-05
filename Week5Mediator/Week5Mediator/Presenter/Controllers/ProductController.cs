using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Week5Mediator.Application.UseCases.Products.Queries.GetProduct;
using Week5Mediator.Application.UseCases.Products.Queries.GetProducts;
using Week5Mediator.Application.UseCases.Products.Command.CreateProduct;

namespace Week5Mediator.Presenter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private IMediator _mediatr;

        public ProductController(IMediator mediator)
        {
            _mediatr = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<GetProductsDto>> Get()
        {
            return Ok(await _mediatr.Send(new GetProductsQuery() { }));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetProductDto>> Get(int id)
        {

            return Ok(await _mediatr.Send(new GetProductQuery() { id = id }));
        }

        [HttpPost]
        public async Task<ActionResult<CreateProductCommandDto>> Post([FromBody] CreateProductCommand payload)
        {

            return Ok(await _mediatr.Send(payload));
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }

    }
}
