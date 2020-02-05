using System;
namespace Day3UnitTesting
{
    public class _5
    {
        public string movieRated(int old)
        {
            if (old >= 21) { return "Dewasa"; }
            else if (old >= 13) { return "Remaja"; }
            else if (old >= 9) { return "Bimbingan Orang Tua"; }
            return "Semua Usia";
        }
    }
}
