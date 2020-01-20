using System;

namespace TryOut
{
    class Program
    {
        static void Main(string[] args)
        {
            NumberOne.hello();
        }
    };

    class NumberOne
    {
        public static void hello()
        {
            Console.WriteLine("Enter your name : ");
            string name = Console.ReadLine();
            Console.WriteLine($"Hello, my name is {name}");
        }
    }
}