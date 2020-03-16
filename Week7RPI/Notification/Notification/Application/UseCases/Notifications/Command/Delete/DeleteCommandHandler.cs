using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notification.Application.Models;
using Notification.Infrastructure;

namespace Notification.Application.UseCases.Notifications //.Command.Delete
{
    public class DeleteNotificationsCommandHandler : IRequestHandler<DeleteNotificationCommand, BaseDto<NotifGet>>
    {
        private readonly ProjectContext _context;

        public DeleteNotificationsCommandHandler(ProjectContext context)
        {
            _context = context;
        }

        public async Task<BaseDto<NotifGet>> Handle(DeleteNotificationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _context.notifications.FindAsync(request.id);
                _context.notifications.Remove(result);
                await _context.SaveChangesAsync();

                var logs = _context.notificationLogs.Where(x => x.notification_id == request.id);
                _context.notificationLogs.RemoveRange(logs);
                await _context.SaveChangesAsync();

                return new BaseDto<NotifGet>
                {
                    message = "Success Delete Notification Data",
                    success = true,
                    data = null
                };
            }
            catch (Exception)
            {
                return new BaseDto<NotifGet>
                {
                    message = "Failed Delete Notification Data",
                    success = false,
                    data = null
                };
            }
        }
    }
}
