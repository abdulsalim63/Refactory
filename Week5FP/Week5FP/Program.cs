using System;
using System.Collections.Generic;
using System.Linq;

namespace Week5FP
{
    class Program
    {
        static void Main(string[] args)
        {
            var str = "hello world again";

            var cap = str.Capitalize();
            var snake = str.SnakeCase();
            var kebab = str.KebabCase();

            var groupby = new [] { 1, 2, 3, 3, 2, 3, 4, 1 };
            var newg = groupby.Mode();

            var trim = str.Trim(8);

            var trimw = str.TrimWords(2);

            Console.WriteLine();
        }
    }

    public static class Extension
    {
        public static string Capitalize(this string s1) =>
            string.Join(" ", s1.Split(' ').Select(x => x.Substring(0, 1).ToUpper() + x.Substring(1)));

        public static string SnakeCase(this string s1) => s1.Replace(' ', '_');

        public static string KebabCase(this string s1) => s1.Replace(' ', '-');

        public static T Mode<T>(this IEnumerable<T> ie) =>
            ie.GroupBy(x => x)
              .Select(s => new { key = s.Key, count = s.Count() })
              .OrderByDescending(x => x.count).First().key;

        //public static string intToString(int i)
        //{

        //    return "satu";
        //}

        public static string Trim(this string s1, int i) => s1.Substring(0, i) + "...";

        public static string TrimWords(this string s1, int i) => string.Join(" ", s1.Split(' ').ToList().GetRange(0, i));
    }
}
