using System;
using MediatR;
using User.Application.Models;

namespace User.Application.UseCases.Users //.Queries.Get
{
    public class GetUserQuery : IRequest<BaseDto<UserOutput>>
    {
        public int id { get; set; }
    }
}
