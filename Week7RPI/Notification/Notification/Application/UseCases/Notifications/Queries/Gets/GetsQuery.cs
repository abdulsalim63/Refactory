using System;
using MediatR;
using Notification.Application.Models;

namespace Notification.Application.UseCases.Notifications //.Queries.Gets
{
    public class GetNotificationsQuery : IRequest<BaseDto<NotifGet>>
    {
        public string include { get; set; }
    }
}
