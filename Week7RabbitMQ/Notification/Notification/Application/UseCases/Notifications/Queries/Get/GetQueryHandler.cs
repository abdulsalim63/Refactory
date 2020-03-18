using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Notification.Application.Models;
using Notification.Infrastructure;

namespace Notification.Application.UseCases.Notifications //.Queries.Get
{
    public class GetNotificationQueryHandler : IRequestHandler<GetNotificationQuery, BaseDto<NotifGet>>
    {
        private readonly ProjectContext _context;

        public GetNotificationQueryHandler(ProjectContext context)
        {
            _context = context;
        }

        public async Task<BaseDto<NotifGet>> Handle(GetNotificationQuery request, CancellationToken cancellationToken)
        {
            var result = _context.notifications.Where(x => x.id == request.id);
            if (result.Count() != 0)
            {
                return new BaseDto<NotifGet>
                {
                    message = "Success Retrieve Notification Data",
                    success = true,
                    data = new NotifGet
                    {
                        notifications = await result.Select(s =>  new notificationsGet
                        {
                            id = s.id,
                            title = s.title,
                            message = s.message
                        }).ToListAsync(),
                        notification_logs = (request.include.ToLower() == "logs") ?
                                            await _context.notificationLogs.Where(x => x.notification_id == request.id)
                                            .Select(s => new Logs
                                            {
                                                notification_id = s.notification_id,
                                                from = s.from,
                                                read_at = s.read_at,
                                                target = s.target
                                            }).ToListAsync() :
                                            null
                    }
                };
            }
            else
            {
                return new BaseDto<NotifGet>
                {
                    message = "Failed Retrieve Notification Data",
                    success = false,
                    data = null
                };
            }
        }
    }
}
