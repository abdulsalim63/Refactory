using System;
using McMaster.Extensions.CommandLineUtils;

namespace Week2WednesdayCLI
{
    public class Program
    {
        public static int Main(string[] args) => CommandLineApplication.Execute<Program>(args);

        [Option(ShortName = "l")]
        public int Length { get; }

        [Option(ShortName = "le")]
        public string Letters { get; }

        [Option(ShortName = "nu")]
        public string Numbers { get; }

        [Option(ShortName = "up")]
        public string Uppercase { get; }

        [Option(ShortName = "lo")]
        public string Lowercase { get; }

        private void OnExecute()
        {
            var length = Length.ToString() ?? "32";
            var letters = Letters ?? "true";
            var numbers = Numbers ?? "true";
            var uppercase = Uppercase ?? "false";
            var lowercase = Lowercase ?? "false";

            var trueLength = Convert.ToInt32(length);
            if (length == "0") { trueLength = 32; }

            var rand = new Random();
            var alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            for (int i = 0; i < trueLength; i++)
            {
                var n = (letters.ToLower() == "false") ? 1000 : ((numbers.ToLower() == "false") ? 0 : 500);
                var upperLower = (uppercase.ToLower() == "true") ? 0 : ((lowercase.ToLower() == "true") ? 1000 : 500);

                if (rand.Next(1, 1000) < n)
                {
                    Console.Write(rand.Next(0, 11));
                }
                else
                {
                    if (rand.Next(1, 1000) < upperLower)
                    {
                        Console.Write(alphabet[rand.Next(0, 26)]);
                    }
                    else
                    {
                        Console.Write(Char.ToUpper(alphabet[rand.Next(0, 26)]));
                    }
                }
            }
        }
    }
}