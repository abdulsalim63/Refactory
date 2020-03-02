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
            var numbers = new[] { 1, 2, 3, 4, 5, 6, 6, 8, 8, 6, 9 };
            var grades = new[] { 87.5, 88.5, 60.5, 90.5, 88.5 };

            var cap = str.Capitalize();
            var snake = str.SnakeCase();
            var kebab = str.KebabCase();
            var modeNumber = numbers.Mode();
            var modeGrades = grades.Mode();
            var numberToString1 = 1.intToString();
            var numberToString2 = 12.intToString();
            var numberToString3 = 30.intToString();
            var tulisanPanjang = "ini adalah tulisan yang sangat panjang".Trim(8);
            var tulisanPanjangAgain = "ini adalah tulisan yang sangat panjang".TrimWords(3);

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

        public static string intToString(this int i)
        {
            var words = "Satu Dua Tiga Empat Lima Enam Tujuh Delapan Sembilan Sepuluh Belas".Split(' ').ToList();

            return (i <= 10) ? words[i - 1] :
                    ((i < 20) ?  words[i%10 - 1]+" "+words[10] :
                        words[i/10 - 1]+" puluh"+((i%10 != 0) ? " "+words[i % 10 - 1] : "") ) ;
        }

        public static string Trim(this string s1, int i) => s1.Substring(0, i) + "...";

        public static string TrimWords(this string s1, int i) => string.Join(" ", s1.Split(' ').ToList().GetRange(0, i));


    }
}
