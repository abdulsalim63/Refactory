using System;
using Microsoft.EntityFrameworkCore;
using Notification.Domain.Entities;

namespace Notification.Infrastructure
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {
        }

        public DbSet<Notification_Model> notifications { get; set; }
        public DbSet<NotificationLogs> notificationLogs { get; set; }
    }
}
