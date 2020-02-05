using System;
using System.Linq;

namespace Day3UnitTesting
{
    public class _6
    {
        public int[] loopRange(int start, int end)
        {
            return Enumerable.Range(start, end-start+1).ToArray();
        }
    }
}
