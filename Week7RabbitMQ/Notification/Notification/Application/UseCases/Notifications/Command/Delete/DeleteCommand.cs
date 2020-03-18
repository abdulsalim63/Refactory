using System;
using MediatR;
using Notification.Application.Models;

namespace Notification.Application.UseCases.Notifications //.Command.Delete
{
    public class DeleteNotificationCommand : IRequest<BaseDto<NotifGet>>
    {
        public int id { get; set; }
    }
}
