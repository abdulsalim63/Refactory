using System;
using System.Linq;

namespace Week2WednesdayCLI
{
    class number3
    {
        static void Main(string[] args)
        {
            var methodPalindrome = args[0];
            var input = args[1];
            var alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray().ToList();
            var palindromeString = "";
            foreach (var s in input)
            {
                if (alphabet.Contains(Char.ToLower(s)))
                {
                    palindromeString += Char.ToLower(s);
                }
            }
            Console.WriteLine(palindromeString == string.Join("", palindromeString.Reverse()));
        }
    }
}