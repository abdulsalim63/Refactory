using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Week5Mediator.Application.UseCases.CustomerCards.Queries.GetCustomerCard;
using Week5Mediator.Application.UseCases.CustomerCards.Queries.GetCustomerCards;
using Week5Mediator.Application.UseCases.CustomerCards.Command.CreateCustomerCard;
using Week5Mediator.Application.UseCases.CustomerCards.Command.DeleteCustomerCard;

namespace Week5Mediator.Presenter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerCardController : ControllerBase
    {
        private IMediator _mediatr;

        public CustomerCardController(IMediator mediator)
        {
            _mediatr = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<GetCustomerCardsDto>> Get()
        {
            return Ok(await _mediatr.Send(new GetCustomerCardsQuery() { }));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetCustomerCardDto>> Get(int id)
        {

            return Ok(await _mediatr.Send(new GetCustomerCardQuery() { id = id }));
        }

        [HttpPost]
        public async Task<ActionResult<CreateCustomerCardCommandDto>> Post([FromBody] CreateCustomerCardCommand payload)
        {

            return Ok(await _mediatr.Send(payload));
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<GetCustomerCardDto>> Delete(int id)
        {

            return Ok(await _mediatr.Send(new DeleteCustomerCardCommand() { id = id }));
        }

    }
}
