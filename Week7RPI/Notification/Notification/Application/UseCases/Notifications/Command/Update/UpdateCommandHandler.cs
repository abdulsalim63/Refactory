using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using MediatR;
using Notification.Application.Models;
using Notification.Infrastructure;

namespace Notification.Application.UseCases.Notifications //.Command.Update
{
    public class UpdateNotificationCommandHandler : IRequestHandler<UpdateNotificationCommand, BaseDto<NotifUpdate>>
    {
        private readonly ProjectContext _context;

        public UpdateNotificationCommandHandler(ProjectContext context)
        {
            _context = context;
        }

        public async Task<BaseDto<NotifUpdate>> Handle(UpdateNotificationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Get data from request's body
                var Data = request.data.attributes;

                // Find notification data base on request id
                var notifData = await _context.notifications.FindAsync(request.id);

                // Update notification logs data
                foreach (var notiflogs in Data.target)
                {
                    var temp = _context.notificationLogs.First(x => x.notification_id == notifData.id && x.target == notiflogs.id);
                    temp.read_at = (long)(Data.read_at - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds;
                    await _context.SaveChangesAsync();
                }

                return new BaseDto<NotifUpdate>
                {
                    message = "Success Update Notification Data",
                    success = true,
                    data = Data
                };
            }
            catch (Exception)
            {
                return new BaseDto<NotifUpdate>
                {
                    message = "Failed Update Notification Data",
                    success = false,
                    data = null
                };
            }
        }
    }
}
