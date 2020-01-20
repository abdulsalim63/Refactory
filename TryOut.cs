using System;

namespace TryOut
{
    class Program
    {
        static void Main(string[] args)
        {
            // NumberOne.hello();
            // NumberTwo.birthday();
            // NumberThree.CountString("Very Easy");
            // NumberFour.Censor();
            // Console.WriteLine(NumberFive.IsOdd(13));
            // Console.WriteLine(NumberFive.IsEven(12));
            // Console.WriteLine(NumberSix.Grade(72));
            Console.WriteLine(NumberSeven.CelciusToFahrenheit(0)); // Output: 32
            Console.WriteLine(NumberSeven.FahrenheitToCelcius(50)); // Output: 10
            Console.WriteLine(NumberSeven.CelciusToKelvin(100)); // Output: 373.15
            Console.WriteLine(NumberSeven.KelvinToCelcius(375)); // Output: 101.85
            Console.WriteLine(NumberSeven.KelvinToFahrenheit(375)); // Output: 215.33
            Console.WriteLine(NumberSeven.FahrenheitToKelvin(12)); // Output: 262.039
            Console.WriteLine(NumberEight.IsLeapYear(2021));

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

    class NumberTwo
    {
        public static void birthday()
        {
            Console.WriteLine("Enter a month of your birthday : ");
            int month = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Now the date : ");
            int day = Convert.ToInt32(Console.ReadLine());
            DateTime today = DateTime.Today;
            DateTime birth = new DateTime(today.Year, month, day);
            TimeSpan diff = birth - today;
            Console.WriteLine($"{diff.Days} days remaining to my next birthday");
        }
    }

    class NumberThree
    {
        public static void CountString(string words)
        {
            Console.WriteLine($"{words} have {words.Length} characters");
        }
    }

    class NumberFour
    {
        public static void Censor()
        {
            string[] censoredWords = new string[]{"imperdiet", "dolor", "duo"};
            string paragraph = "Lorem ipsum dolor sit amet, imperdiet vituperata duo in, nonumy.";
            string copy = paragraph;
            foreach (string words in censoredWords)
            {
                string k = "";
                foreach(char n in words)
                {
                    k += "*";
                }
                copy = copy.Replace(words, k);
            }
            Console.WriteLine(copy);
        }
    }

    class NumberFive
    {
        public static bool IsOdd(int num)
        {
            return num%2 != 0;
        }

        public static bool IsEven(int num)
        {
            return num%2 == 0;
        }
    }

    class NumberSix
    {
        public static string Grade(int grade)
        {
            if (grade >= 90) { return "A"; }
            else if (grade >= 80) { return "B"; }
            else if (grade >= 70) { return "C"; }
            else if (grade >= 60) { return "D"; }
            else { return "E"; }
        }
    }

    class NumberSeven
    {
        public static double CelciusToFahrenheit(int d)
        {
            return ((d * 9) / 5) + 32;
        }

        public static double FahrenheitToCelcius(int d)
        {
            return ((d - 32) * 5) / 9;
        }

        public static double CelciusToKelvin(int d)
        {
            return d + 273.15;
        }

        public static double KelvinToCelcius(int d)
        {
            return d - 273.15;
        }
        
        public static double KelvinToFahrenheit(int d)
        {
            return ((d - 273.15) * 9) / 5 + 32;
        }

        public static double FahrenheitToKelvin(int d)
        {
            return ((d - 32) * 5) / 9 + 273.15;
        }
    }

    class NumberEight
    {
        public static bool IsLeapYear(int year)
        {
            return year%4 == 0;
        }
    }

    class NumberNine
    {
        var jakarta = Tuple.Create("Jakarta", 7);
        var bali = Tuple.Create("Bali", 8);
        var london = Tuple.Create("London", 0);
        var cairo = Tuple.Create("Cairo", 2);
        var denver = Tuple.Create("Denver", -6);
        var chicago = Tuple.Create("Chicago", -5);
    }
}