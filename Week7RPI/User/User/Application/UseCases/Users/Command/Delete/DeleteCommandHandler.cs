using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using User.Application.Models;
using User.Infrastructure;

namespace User.Application.UseCases.Users //.Command.Delete
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, BaseDto<UserOutput>>
    {
        private readonly UserContext _context;

        public DeleteUserCommandHandler(UserContext context)
        {
            _context = context;
        }

        public async Task<BaseDto<UserOutput>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _context.users.FindAsync(request.id);
                _context.users.Remove(result);
                await _context.SaveChangesAsync(cancellationToken);

                return new BaseDto<UserOutput>
                {
                    message = "Success Delete User Data",
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
                    message = "Failed Delete User Data",
                    success = false,
                    data = null
                };
            }
        }
    }
}
