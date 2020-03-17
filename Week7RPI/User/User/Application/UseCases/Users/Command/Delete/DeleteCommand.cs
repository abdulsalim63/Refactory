using System;
using MediatR;
using User.Application.Models;

namespace User.Application.UseCases.Users //.Command.Delete
{
    public class DeleteUserCommand : IRequest<BaseDto<UserOutput>>
    {
        public int id { get; set; }
    }
}
