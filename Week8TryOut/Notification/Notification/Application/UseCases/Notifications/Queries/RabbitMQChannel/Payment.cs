using System;
using Notification.Infrastructure;
using Notification.Application.Models;
using Hangfire;
using System.Threading.Tasks;

namespace Notification.Application.UseCases.Notifications.Queries.RabbitMQChannel
{
    public class Payment
    {
        private readonly ProjectContext _context;

        public Payment(ProjectContext context)
        {
            _context = context;
        }

        public void SimpleAdd(int a, int b)
        {
            Console.WriteLine(a + b);
        }

        public void Trigger()
        {
            RecurringJob.AddOrUpdate(() => SimpleAdd(1, 2), Cron.Daily);
        }
    }
}
