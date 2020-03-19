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

            Publisher.Send("localhost", $"{userData.id.ToString()} {userData.email}");

            //var baseValue = JsonConvert.DeserializeObject<BaseDto<IncomingNotif>>(response.Content).data;

            //var logs = baseValue.notification_logs.Where(x => x.from == _context.users.Last().id);
            //var Ids = logs.Select(s => s.notification_id).Distinct().ToList();
            //var notifications = baseValue.notifications.Where(x => Ids.Contains(x.id));

            //foreach(var us in notifications)
            //{
            //    foreach(var log in logs.Where(x => x.notification_id == us.id))
            //    {
            //        var emailClient = new RestClient($"http://localhost:6000/notification/logs?target={log.target}");
            //        emailClient.Timeout = -1;
            //        var emailRequest = new RestRequest(Method.GET);
            //        emailRequest.AddHeader("Content-Type", "application/json");
            //        emailRequest.AddParameter("application/json", "", ParameterType.RequestBody);
            //        var emailResponse = client.Execute(emailRequest);
            //        var email_destination = JsonConvert.DeserializeObject<List<string>>(emailResponse.Content);

            //        EmailSender.SendEmail(us.title, us.message, userData.email, userData.name, email_destination);
            //    }
            //}


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
