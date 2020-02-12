using System;
using System.Linq;

namespace Week2WednesdayCLI
{
    class number2
    {
        static void Main(string[] args)
        {
            var method = args[0];
            var input = args.ToList().GetRange(1, args.Length-1).ToList().ConvertAll(x => Convert.ToInt32(x));
            if (method.ToLower() == "add")
            {
                Console.WriteLine(input.Sum());
            }
            else if (method.ToLower() == "subtract")
            {
                Console.WriteLine(input[0] - (input.GetRange(1, input.Count-1)).Sum());
            }
            else if (method.ToLower() == "multiply")
            {
                var mult = 1;
                foreach (var i in input) { mult *= i; }
                Console.WriteLine(mult);
            }
            else
            {
                var div = (double)input[0];
                for (int d=1;d<input.Count;d++) { div /= (double)input[d]; }
                Console.WriteLine(div);
            }
        }
    }
}