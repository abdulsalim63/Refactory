using System;
using System.Collections.Generic;
using MediatR;
using Notification.Domain.Entities;

namespace Notification.Application.UseCases.Notifications //.Queries.Logs
{
    public class LogsQuery : IRequest<List<string>>
    {
        public int target { get; set; }
    }
}
