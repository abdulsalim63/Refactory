using System;
using MediatR;
using Notification.Application.Models;

namespace Notification.Application.UseCases.Notifications //.Queries.Get
{
    public class GetNotificationQuery : IRequest<BaseDto<NotifGet>>
    {
        public int id { get; set; }
        public string include { get; set; }
    }
}
