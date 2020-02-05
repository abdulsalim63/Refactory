using System;
using System.Collections.Generic;
using System.Linq;

namespace Day3UnitTesting
{
    public class _10
    {
        public string[] addArray(string[] arr, string s1, string s2)
        {
            var list = new List<string>();
            list.Add(s1);
            list.AddRange(arr);
            list.Add(s2);
            return list.ToArray();
        }
    }
}
