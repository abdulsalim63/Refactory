using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Notification.Application.Models;
using Notification.Infrastructure;

namespace Notification.Application.UseCases.Notifications //.Queries.Gets
{
    public class GetNotificationsQueryHandler : IRequestHandler<GetNotificationsQuery, BaseDto<NotifGet>>
    {
        private readonly ProjectContext _context;

        public GetNotificationsQueryHandler(ProjectContext context)
        {
            _context = context;
        }

        public async Task<BaseDto<NotifGet>> Handle(GetNotificationsQuery request, CancellationToken cancellationToken)
        {
            var early = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            var notification_log = await _context.notificationLogs.Where(x =>  x.read_at != 0)
                                        .Select(s => new Logs
                                        {
                                            notification_id = s.notification_id,
                                            from = s.from,
                                            read_at = early.AddSeconds(s.read_at),
                                            target = s.target
                                        }).ToListAsync();
            var nullRead = await _context.notificationLogs.Where(x => x.read_at == 0)
                                        .Select(s => new Logs
                                        {
                                            notification_id = s.notification_id,
                                            from = s.from,
                                            read_at = null,
                                            target = s.target
                                        }).ToListAsync();
            notification_log.AddRange(nullRead);


            return new BaseDto<NotifGet>
            {
                message = "Success Retrieve Notification Data",
                success = true,
                data = new NotifGet
                {
                    total = notification_log.Count(),
                    read_count = notification_log.Where(x => x.read_at != null).Count(),
                    notifications = await _context.notifications.OrderBy(x => x.id).Select(s => new notificationsGet
                    {
                        id = s.id,
                        title = s.title,
                        message = s.message
                    }).ToListAsync(),
                    notification_logs = (request.include.ToLower() == "logs") ? notification_log.OrderBy(x => x.notification_id).ToList() : null
                }
            };
        }
    }
}
