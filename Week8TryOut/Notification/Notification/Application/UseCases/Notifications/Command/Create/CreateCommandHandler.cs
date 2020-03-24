using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Notification.Application.Models;
using Notification.Infrastructure;
using Notification.Domain.Entities;
using Hangfire;

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
            var recieved = BackgroundJob.Enqueue(() => Subscriber.Recieved());

            var Data = request.data.attributes;

            // Add Notification Data
            var notificationData = new Notification_Model
            {
                title = Data.title,
                message = Data.message
            };

            _context.notifications.Add(notificationData);
            await _context.SaveChangesAsync(cancellationToken);

            // Get Id for notification_id in notification logs
            var Id = await _context.notifications.ToListAsync();

            var userData = await _context.users.FindAsync(Data.from);

            // Add Notification Log Data
            foreach (var logs in Data.targets)
            {
                _context.notificationLogs.Add(new NotificationLogs
                {
                    notification_id = Id.Last().id,
                    type = Data.type,
                    from = Data.from,
                    target = logs.id,
                    email_destination = logs.email_destination
                });
                await _context.SaveChangesAsync();

                if (logs.email_destination != null)
                {
                    BackgroundJob.Enqueue(() => EmailSender.Send(notificationData.title, notificationData.message, userData.address, userData.name, logs.email_destination));
                }

                BackgroundJob.Enqueue(() => FCM.SendAsync(notificationData.title, notificationData.message));
            }

            return new BaseDto<NotifInput>
            {
                message = "Success add Notification Data",
                success = true,
                data = Data
            };
        }
    }
}
