using System;
using System.Text;
using RabbitMQ.Client;

namespace PaymentServices.Application.Models
{
    public class Publisher
    {
        public static void Send(string id, string type)
        {
            var message = $"{id} {type}";

            var connectionFactory = new ConnectionFactory()
            {
                HostName = "localhost"
            };
            using (var connection = connectionFactory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("notification", true, false, false, null);

                    var body = Encoding.UTF8.GetBytes(message);

                    var properties = channel.CreateBasicProperties();
                    properties.Persistent = true;

                    channel.BasicPublish("", "notification", properties, body);

                    Console.WriteLine($"Message from user {id} with type {type} has sent");
                }
            }
        }
    }
}
