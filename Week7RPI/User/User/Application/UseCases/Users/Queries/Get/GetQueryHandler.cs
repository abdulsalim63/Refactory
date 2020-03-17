using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using User.Application.Models;
using User.Infrastructure;

namespace User.Application.UseCases.Users.Queries.Get
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, BaseDto<UserOutput>>
    {
        private readonly UserContext _context;

        public GetUserQueryHandler(UserContext context)
        {
            _context = context;
        }

        public async Task<BaseDto<UserOutput>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _context.users.FindAsync(request.id);

                return new BaseDto<UserOutput>
                {
                    message = "Success Retrieve User Data",
                    success = true,
                    data = new UserOutput
                    {
                        id = result.id,
                        name = result.name,
                        username = result.username,
                        email = result.email,
                        address = result.address
                    }
                };
            }
            catch (Exception)
            {
                return new BaseDto<UserOutput>
                {
                    message = "Failed Retrieve User Data",
                    success = false,
                    data = null
                };
            }
        }
    }
}
