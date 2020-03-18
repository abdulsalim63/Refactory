using System;
using System.Collections.Generic;
using MediatR;
using User.Application.Models;

namespace User.Application.UseCases.Users //.Queries.Gets
{
    public class GetUsersQuery : IRequest<BaseDto<List<UserOutput>>>
    {
    }
}
