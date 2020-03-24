using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FirebaseAdmin.Messaging;

namespace Notification.Application.Models
{
    public class FCM
    {
        public static async Task SendAsync(string data, string msg)
        {
            // This registration token comes from the client FCM SDKs.
            var registrationToken = "AAAAEOUxe_Q:APA91bG_eOu9VcWVB2DYXTgeq3K4Nip5RS-qT2Itgo9dPWwE-" +
                "IejLq8wh4BAHi0QwVW5nUsWhPFb6Yy9sURd7lup66n3TiEa8eDpmIYSppP1SDZ6T1IfOqPVhsOoQoP2Zn790wwCpy7E";

            // See documentation on defining a message payload.
            var message = new Message()
            {
                Data = new Dictionary<string, string>()
                {
                    { data, msg}
                },
                Token = registrationToken
            };

            // Send a message to the device corresponding to the provided
            // registration token.
            string response = await FirebaseMessaging.DefaultInstance.SendAsync(message);
            // Response is a message ID string.
            Console.WriteLine("Successfully sent message: " + response);
        }
    }
}
