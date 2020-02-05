using System;
using System.Collections.Generic;

namespace Day3UnitTesting
{
    public class _7
    {
        public int[] oddPrint(int n)
        {
            var list = new List<int>();
            for (int i=1;i<=n;i++)
            {
                if (i%2 != 0) { list.Add(i); }
            }
            return list.ToArray();
        }
    }
}
