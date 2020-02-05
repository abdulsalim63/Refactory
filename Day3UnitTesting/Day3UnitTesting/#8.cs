using System;
using System.Collections.Generic;

namespace Day3UnitTesting
{
    public class _8
    {
        public string[] print(int n)
        {
            var list = new List<string>();
            for (int i=1;i<=n;i++)
            {
                if (i%100 == 0) { list.Add("Kelipatan Seratus"); }
                else if (i%10 == 0) { list.Add("Genap Kelipatan Lima"); }
                else if (i%5 == 0) { list.Add("Ganjil Kelipatan Lima"); }
                else if (i%2 == 0) { list.Add("Genap"); }
                else
                {
                    list.Add("Ganjil");
                }
            }
            return list.ToArray();
        }
    }
}
