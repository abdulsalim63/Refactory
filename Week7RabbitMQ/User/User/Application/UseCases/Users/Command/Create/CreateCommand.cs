using System;
using MediatR;
using User.Application.Models;
using User.Domain.Entities;

namespace User.Application.UseCases.Users //.Command.Create
{
    public class CreateUserCommand : BaseRequest<User_Model>, IRequest<BaseDto<UserOutput>>
    {
        public string token { get; set; }
    }
}
