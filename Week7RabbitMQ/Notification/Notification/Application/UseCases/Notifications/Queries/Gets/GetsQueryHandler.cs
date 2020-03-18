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
            return new BaseDto<NotifGet>
            {
                message = "Success Retrieve Notification Datas",
                success = true,
                data = new NotifGet
                {
                    notifications = await _context.notifications.OrderBy(x => x.id).Select(s => new notificationsGet
                    {
                        id = s.id,
                        title = s.title,
                        message = s.message
                    }).ToListAsync(),
                    notification_logs = (request.include == "None") ? null :
                                    await _context.notificationLogs.OrderBy(x => x.notification_id).Select(s => new Logs {
                                        notification_id = s.notification_id,
                                        from = s.from,
                                        read_at = s.read_at,
                                        target = s.target
                                    }).ToListAsync()
                }
            };
        }
    }
}
