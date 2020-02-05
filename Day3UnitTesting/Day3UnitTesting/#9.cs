using System;
namespace Day3UnitTesting
{
    public class _9
    {
        public string reverseAgain(string s)
        {
            var sArr = s.Split(' ');
            Array.Reverse(sArr);
            return string.Join(" ", sArr);
        }
    }
}
