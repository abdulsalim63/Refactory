using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using RestSharp;
using User.Application.Models;
using User.Infrastructure;

namespace User.Application.UseCases.Users //.Command.Create
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, BaseDto<UserOutput>>
    {
        private readonly UserContext _context;

        public CreateUserCommandHandler(UserContext context)
        {
            _context = context;
        }

        public async Task<BaseDto<UserOutput>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userData = request.data.attributes;

            _context.users.Add(userData);
            await _context.SaveChangesAsync(cancellationToken);

            Publisher.Send($"{userData.id.ToString()}", userData.name, userData.email);

            return new BaseDto<UserOutput>
            {
                message = "Success Add User Data",
                success = true,
                data = _context.users.Select(s => new UserOutput
                {
                    id = s.id,
                    name = s.name,
                    username = s.username,
                    email = s.email,
                    address = s.address
                }).ToList().Last()
            };
        }
    }
}
