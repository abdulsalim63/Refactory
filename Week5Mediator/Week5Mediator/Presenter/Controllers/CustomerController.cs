using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Week5Mediator.Application.UseCases.Customers.Queries.GetCustomer;
using Week5Mediator.Application.UseCases.Customers.Queries.GetCustomers;
using Week5Mediator.Application.UseCases.Customers.Command.CreateCustomer;

namespace Week5Mediator.Presenter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private IMediator _mediatr;

        protected IMediator Mediator => _mediatr ?? (_mediatr = HttpContext.RequestServices.GetService<IMediator>());

        public CustomerController()
        {
        }

        [HttpGet]
        public async Task<ActionResult<GetCustomersDto>> Get()
        {
            return Ok(await Mediator.Send(new GetCustomersQuery() { }));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetCustomerDto>> Get(int id)
        {

            return Ok(await Mediator.Send(new GetCustomerQuery() { id = id }));
        }

        [HttpPost]
        public async Task<ActionResult<CreateCustomerCommandDto>> Post([FromBody] CreateCustomerCommand payload)
        {

            return Ok(await Mediator.Send(payload));
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
