using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MediatR;
using User.Application.Models;
using User.Infrastructure;

namespace User.Application.UseCases.Users //.Queries.Gets
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, BaseDto<List<UserOutput>>>
    {
        private readonly UserContext _context;

        public GetUsersQueryHandler(UserContext context)
        {
            _context = context;
        }

        public async Task<BaseDto<List<UserOutput>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return new BaseDto<List<UserOutput>>
            {
                message = "Success Retrieve User Datas",
                success = true,
                data = await _context.users.Select(s => new UserOutput {
                    id = s.id,
                    name = s.name,
                    username = s.username,
                    email = s.email,
                    address = s.address
                }).ToListAsync()
            };
        }
    }
}
