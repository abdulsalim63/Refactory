using System;
using MediatR;
using Notification.Application.Models;

namespace Notification.Application.UseCases.Notifications//.Command.Update
{
    public class UpdateNotificationCommand : BaseRequest<NotifUpdate>, IRequest<BaseDto<NotifUpdate>>
    {
        public int id { get; set; }
    }
}
