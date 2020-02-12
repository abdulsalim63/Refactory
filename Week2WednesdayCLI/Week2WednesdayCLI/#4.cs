using System;
using System.Linq;

namespace Week2WednesdayCLI
{
    class number4
    {
        static void Main(string[] args)
        {
            var method = args[0];
            var input = args[1];
            foreach (var i in input)
            {
                Console.Write($"&#{Convert.ToInt32(i)};");
            }
        }
    }
}