using System;
using System.Linq;

namespace Week2WednesdayCLI
{
    class numberOne
    {
        static void Main(string[] args)
        {
            var method = args[0];
            var input = args[1];
            if (method.ToLower() == "lowercase")
            {
                Console.WriteLine(input.ToLower());
            }
            else if (method.ToLower() == "uppercase")
            {
                Console.WriteLine(input.ToUpper());
            }
            else { Console.WriteLine(capitalize(input));  }
        }

        //public static string lowercase(string s) => s.ToLower();

        //public static string uppercase(string s) => s.ToUpper();

        public static string capitalize(string s)
        {
            var newS = s.Split(' ').ToList();
            var result = "\"";
            foreach (var i in newS)
            {
                result += i.Substring(0, 1).ToUpper() + i.Substring(1, i.Length - 1).ToLower() + " ";
            }
            return result.Substring(0,result.Length-1) + "\"";
        } 
    }
}
