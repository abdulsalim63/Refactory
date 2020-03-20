using System;
using System.Collections.Generic;
using System.Linq;
using MediatR;
using Notification.Infrastructure;
using Notification.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;
using Hangfire;
using Notification.Application.Models;

namespace Notification.Application.UseCases.Notifications //.Queries.Logs
{
    public class LogsQueryHandler : IRequestHandler<LogsQuery, List<string>>
    {
        private readonly ProjectContext _context;

        public LogsQueryHandler(ProjectContext context)
        {
            _context = context;
        }

        public async Task<List<string>> Handle(LogsQuery request, CancellationToken cancellationToken)
        {
            return await _context.notificationLogs.Where(x => x.target == request.target)
                .Select(s => s.email_destination).ToListAsync();
        }
    }
}
