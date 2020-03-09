using System;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace Week5BackgroundServices.Presenter
{
    public class EmailSender
    {
        public static void SendEmail(string subject)
        {
            var message = new MimeMessage();
            var bodyBuilder = new BodyBuilder();

            message.To.Add(new MailboxAddress("Abdul Salim", "abdul.salim@gigaming.io"));
            message.From.Add(new MailboxAddress("Abdul Salim", "abdul.salim@gigaming.io"));

            message.Subject = subject;
            bodyBuilder.HtmlBody = subject;
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
