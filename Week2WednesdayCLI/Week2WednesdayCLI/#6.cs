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
            //var method = args[0];
            var hostName = Dns.GetHostName();
            var ip = Dns.GetHostByName(hostName);
            foreach (var i in ip.AddressList)
            {
                Console.WriteLine(i.ToString()); // System.Net.Sockets.SocketException (0x80004005): Could not resolve host
            }
        }
    }
}