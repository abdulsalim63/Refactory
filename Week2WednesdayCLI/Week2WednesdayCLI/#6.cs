using System;
using System.Linq;
using System.Net;

namespace Week2WednesdayCLI
{
    class number6
    {
        [Obsolete]
        static void Main(string[] args)
        {
            var method = args[0];
            var hostName = Dns.GetHostName();
            var ip = Dns.GetHostByName(hostName).AddressList[0].ToString();
            Console.WriteLine(ip);
        }
    }
}