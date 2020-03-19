using System;
using System.Collections.Generic;
using MailKit.Net.Smtp;
using MimeKit;

namespace Notification.Application.Models
{
    public class EmailSender
    {
        public static void SendEmail(string title, string body, string from, string name, List<string> to)
        {
            foreach (var i in to)
            {
                emailHandler(title, body, from, name, i);
            }
        }

        public static void emailHandler(string title, string body, string from, string name, string to)
        {
            var message = new MimeMessage();
            var bodyBuilder = new BodyBuilder();

            message.To.Add(new MailboxAddress(to, to));
            message.From.Add(new MailboxAddress(name, from));

            message.Subject = title;
            bodyBuilder.HtmlBody = body;
            message.Body = bodyBuilder.ToMessageBody();

            var client = new SmtpClient();

            client.ServerCertificateValidationCallback = (s, c, h, e) => true;

            client.Connect("smtp.mailtrap.io", 2525);
            client.Authenticate("738dec87a79528", "c2f4ab6ae71e2a");
            client.Send(message);
            client.Disconnect(true);
        }
    }
}
