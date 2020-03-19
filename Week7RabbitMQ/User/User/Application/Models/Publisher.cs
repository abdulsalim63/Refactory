using System;
using System.Text;
using RabbitMQ.Client;

namespace User.Application.Models
{
    public class Publisher
    {
        public static void Send(string host, string message)
        {
            var connectionFactory = new ConnectionFactory()
            {
                HostName = host
            };
            using (var connection = connectionFactory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("user", true, false, false, null);

                    var body = Encoding.UTF8.GetBytes(message);

                    var properties = channel.CreateBasicProperties();
                    properties.Persistent = true;

                    channel.BasicPublish("", "user", properties, body);

                    Console.WriteLine($"Message {message} has sent");
                }
            }
        }
    }
}
