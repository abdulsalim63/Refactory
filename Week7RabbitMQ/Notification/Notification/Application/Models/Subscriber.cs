using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Notification.Application.Models
{
    public class Subscriber
    {
        public static string Recieved()
        {
            string resultData;
            var connectionFactory = new ConnectionFactory()
            {
                HostName = "localhost"
            };
            using (var connection = connectionFactory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("user", true, false, false, null);
                    var consumer = new EventingBasicConsumer(channel);
                    BasicGetResult result = channel.BasicGet("user", true);
                    try
                    {
                        resultData = Encoding.UTF8.GetString(result.Body);
                    }
                    catch
                    {
                        resultData = "No message";
                    }
                }
            }
            Console.WriteLine(resultData);
            return resultData;
        }
    }
}
