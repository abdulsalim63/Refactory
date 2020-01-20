using System;

namespace eleven
{
    class NumberEleven
    {
        public static void Main(string[] args)
        {
            int k = 0;
            foreach (string i in args)
            {
                k += Convert.ToInt32(i);
            }
            Console.WriteLine(k);
        }
    }
}