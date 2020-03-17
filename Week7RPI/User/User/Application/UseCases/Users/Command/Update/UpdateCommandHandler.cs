using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using User.Application.Models;
using User.Infrastructure;

namespace User.Application.UseCases.Users //.Command.Update
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, BaseDto<UserOutput>>
    {
        private readonly UserContext _context;

        public UpdateUserCommandHandler(UserContext context)
        {
            _context = context;
        }

        public async Task<BaseDto<UserOutput>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _context.users.FindAsync(request.id);
                var data = request.data.attributes;

                result.name = data.name;
                result.username = data.username;
                result.password = data.password;
                result.email = data.email;
                result.address = data.address;

                await _context.SaveChangesAsync(cancellationToken);

                return new BaseDto<UserOutput>
                {
                    message = "Success Update User Data",
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
                    message = "Failed Update User Data",
                    success = false,
                    data = null
                };
            }
        }
    }
}
