using System;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;
using User.Application.UseCases.Users;
using System.Collections.Generic;
using Microsoft.Extensions.Primitives;

namespace User.Presenter.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand request)
        {
            StringValues values;
            this.Request.Headers.TryGetValue("Authorization", out values);
            return Ok(await _mediator.Send(new CreateUserCommand() { data = request.data, token = values}));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetUsersQuery()));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetbyId(int Id)
        {
            return Ok(await _mediator.Send(new GetUserQuery() { id = Id }));
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdatebyId(int Id, [FromBody] CreateUserCommand request)
        {
            return Ok(await _mediator.Send(new UpdateUserCommand() {
                id = Id,
                data = request.data
            }));
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeletebyId(int Id)
        {
            return Ok(await _mediator.Send(new DeleteUserCommand() { id = Id }));
        }
    }
}
