using System;
using MediatR;
using User.Application.Models;
using User.Domain.Entities;

namespace User.Application.UseCases.Users //.Command.Update
{
    public class UpdateUserCommand : BaseRequest<User_Model>, IRequest<BaseDto<UserOutput>>
    {
        public int id { get; set; }
    }
}
