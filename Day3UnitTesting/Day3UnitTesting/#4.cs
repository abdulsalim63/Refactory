using System;
namespace Day3UnitTesting
{
    public class _4
    {
        public string leapYear(int year)
        {
            if (year % 400 == 0) { return "Leap Year"; }
            else if (year%4 == 0 && year % 100 != 0) { return "Leap Year"; }
            return "Not Leap Year";
        }
    }
}
