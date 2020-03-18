using System;
using MediatR;
using Notification.Application.Models;

namespace Notification.Application.UseCases.Notifications//.Command.Create
{
    public class CreateNotificationCommand : BaseRequest<NotifInput>,  IRequest<BaseDto<NotifInput>>
    {
    }
}
