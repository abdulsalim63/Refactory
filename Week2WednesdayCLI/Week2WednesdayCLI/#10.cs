using System;
using System.Linq;

namespace Week2WednesdayCLI
{
    class number10
    {
        static void Main(string[] args)
        {
            var result = 0;
            var num = 1;
            while(true)
            {
                Console.WriteLine($"insert #{num} number: ");
                try
                {
                    var temp = Console.ReadLine();
                    num++;
                    result += Convert.ToInt32(temp);
                }
                catch
                {
                    break;
                }
                
            }
            Console.WriteLine($"Result: {result}");
        }
    }
}