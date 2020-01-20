using System;

namespace TryOut
{
    class Program
    {
        static void Main(string[] args)
        {
            NumberOne.hello();
            NumberTwo.birthday();
            NumberThree.CountString("Very Easy");
            NumberFour.Censor();
            Console.WriteLine(NumberFive.IsOdd(13));
            Console.WriteLine(NumberFive.IsEven(12));
            Console.WriteLine(NumberSix.Grade(72));
            Console.WriteLine(NumberSeven.CelciusToFahrenheit(0)); // Output: 32
            Console.WriteLine(NumberSeven.FahrenheitToCelcius(50)); // Output: 10
            Console.WriteLine(NumberSeven.CelciusToKelvin(100)); // Output: 373.15
            Console.WriteLine(NumberSeven.KelvinToCelcius(375)); // Output: 101.85
            Console.WriteLine(NumberSeven.KelvinToFahrenheit(375)); // Output: 215.33
            Console.WriteLine(NumberSeven.FahrenheitToKelvin(12)); // Output: 262.039
            Console.WriteLine(NumberEight.IsLeapYear(2021));
            var jakarta = Tuple.Create("Jakarta", 7);
            var bali = Tuple.Create("Bali", 8);
            var london = Tuple.Create("London", 0);
            var cairo = Tuple.Create("Cairo", 2);
            var denver = Tuple.Create("Denver", -6);
            var chicago = Tuple.Create("Chicago", -5);
            NumberNine.TimezoneDiff(jakarta, london);
            NumberNine.TimezoneDiff(cairo, chicago);
            NumberNine.TimezoneDiff(cairo, bali);
            NumberNine.TimezoneDiff(denver, jakarta);
            Console.WriteLine(NumberTen.Sum(19,21));
            Console.WriteLine(NumberTen.Substract(19,21));
            Console.WriteLine(NumberTen.Multiply(19,21));
            Console.WriteLine(NumberTen.Divide(19,21));
            // Different file for number eleven
            Console.WriteLine(NumberTwelve.uppercase("haiayaayaa"));
            Console.WriteLine(NumberThirteen.CountWords("this Wordss and you"));
            Console.WriteLine(NumberFourteen.IsPalindrome("malam"));
            Console.WriteLine(NumberFourteen.IsPalindrome("tidur"));
            Console.WriteLine(NumberFourteen.IsPalindrome("ibu ratna antar ubi"));
            Console.WriteLine(NumberFifteen.Mirror("--vv"));
            Console.WriteLine(NumberFifteen.Mirror("..ww"));
            string[] fruits = {"Jeruk", "Apel", "Anggur", "Pepaya", "Pisang", "Kiwi", "Markisa"};
            Console.WriteLine(NumberSixteen.IndexFinder(fruits, "Pisang"));
            NumberSeventeen.loop();
            int[] points = {2, 4, 54, 12, -65, 19, 40, 92, 88, 330, -4, 54};
            Console.WriteLine(NumberEighteen.FindMax(points));
            Console.WriteLine(NumberEighteen.FindMin(points));
            Console.WriteLine(NumberEighteen.FindAverage(points));
            Console.WriteLine(NumberNineteen.sorted(points));
            NumberTwenty item = new NumberTwenty();
            item.name = "Indomie Goreng";
            item.price = 3500;
            item.onSale = true;
            item.print();
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
        public static void TimezoneDiff(Tuple<string, int> a, Tuple<string, int> b)
        {
            int diff = a.Item2 - b.Item2;
            if (diff >= 0) { Console.WriteLine($"{a.Item1} {diff} hours ahead {b.Item1}"); }
            else { Console.WriteLine($"{a.Item1} {diff*-1} hours behind {b.Item1}"); }
        }
    }

    class NumberTen
    {
        public static double Sum(double a, double b) { return a+b; }
        public static double Substract(double a, double b) { return a-b; }
        public static double Multiply(double a, double b) { return a*b; }
        public static double Divide(double a, double b) { return a/b; }
    }

    class NumberTwelve
    {
        public static string uppercase(string hai) { return hai.ToUpper(); }
    }

    class NumberThirteen
    {
        public static int CountWords(string str)
        {
            string[] words = str.Split(" ");
            return words.Length;
        }
    }

    class NumberFourteen
    {
        public static bool IsPalindrome(string str)
        {
            bool trn = true;
            string str1 = "";
            for (int i=str.Length-1;i>=0;i--)
            {
                str1 += str[i];
            }
            for (int i=0;i<str.Length;i++)
            {
                if (str[i] != str1[i])
                {
                    trn = trn && false;
                }
            }
            return trn;
        }
    }

    class NumberFifteen
    {
        public static string Mirror(string arg)
        {
            string str = arg;
            for (int i=arg.Length-1;i>=0;i--)
            {
                str += arg[i];
            }
            return str;
        }
    }

    class NumberSixteen
    {
        public static int IndexFinder(string[] arr, string str)
        {
            return Array.IndexOf(arr, str);
        }
    }

    class NumberSeventeen
    {
        public static void loop()
        {
            for (int i=1;i<=1000;i++)
            {
                if (i%100 == 0) { Console.WriteLine($"{i}. Baz"); }
                else if (i%20 == 0) {Console.WriteLine($"{i}. Bar"); }
                else if (i%5 == 0) {Console.WriteLine($"{i}. Foo"); }
                else { Console.WriteLine($"{i}."); }
            }
        }
    }

    class NumberEighteen
    {
        public static int FindMax(int[] num)
        {
            int k = 0;
            foreach (int i in num)
            {
                if (i>k) { k = i; }
            }
            return k;
        }
        public static int FindMin(int[] num) 
        {
            int k = num[0];
            foreach (int i in num)
            {
                if (i<k) { k = i; }
            }
            return k;
        }
        public static double FindAverage(int[] num )
        {
            double k = 0;
            foreach (int i in num) { k += i; }
            return k/Convert.ToDouble(num.Length);
        }
    }

    class NumberNineteen
    {
        public static void sorted(int[] args)
        {
            Array.Sort(args);
            foreach (int i in args)
            {
                Console.WriteLine(i);
            }
        }
    }

    class NumberTwenty
    {
        public string name;
        public double price;
        public bool onSale;
        
        public void print()
        {
            if (onSale == true) {this.price *= 0.8;}
            Console.WriteLine($"{this.name} (Rp{this.price})");
        }

    }
}
