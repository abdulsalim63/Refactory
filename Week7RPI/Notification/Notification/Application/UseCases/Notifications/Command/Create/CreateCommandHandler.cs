using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Notification.Application.Models;
using Notification.Infrastructure;
using Notification.Domain.Entities;

namespace Notification.Application.UseCases.Notifications//.Command.Create
{
    public class CreateNotificationCommandHandler : IRequestHandler<CreateNotificationCommand, BaseDto<NotifInput>>
    {
        private readonly ProjectContext _context;

        public CreateNotificationCommandHandler(ProjectContext context)
        {
            _context = context;
        }

        public async Task<BaseDto<NotifInput>> Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
        {
            var data = request.data.attributes;

            var notificationData = new Notification_Model
            {
                title = data.title,
                message = data.message
            };

            _context.notifications.Add(notificationData);
            
            //var 

            return new BaseDto<NotifInput>
            {

            };
        }
    }
}
