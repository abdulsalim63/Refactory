using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Day4Json
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var read = File.ReadAllText("/Users/gigaming/Downloads/Refactory Image/Training/TryOut/Day4Json/Day4Json/#1.json");
            var readJson = JsonConvert.DeserializeObject<List<user>>(read);

            Console.WriteLine("This is the user who doesn't have phone number : [{0}]", string.Join(", ", phoneNumber(readJson)));
            Console.WriteLine("This is the user who have articles : [{0}]", string.Join(", ", haveArticles(readJson)));
            Console.WriteLine("This is the user who have \"annis\" in their name : [{0}]", string.Join(", ", haveAnnis(readJson)));
            Console.WriteLine("This is the user who have articles on year 2020 : [{0}]", string.Join(", ", haveYear2020(readJson)));
            Console.WriteLine("This is the user who are born in 1986 : [{0}]", string.Join(", ", born1986(readJson)));
            Console.WriteLine("This is the user whose articles contain \"tips\" : [{0}]", string.Join(", ", titleTips(readJson)));
            Console.WriteLine("This is the user whose articles published before August 2019 [{0}]", string.Join(", ", publishAugust(readJson)));


            var read1 = File.ReadAllText("/Users/gigaming/Downloads/Refactory Image/Training/TryOut/Day4Json/Day4Json/#2.json");
            var readJson1 = JsonConvert.DeserializeObject<List<user2>>(read1);

            Console.WriteLine("This is the user who purchase in February : [{0}]", string.Join(", ", purchase02(readJson1)));
            Console.WriteLine("These are all the total price purchase made by Ari : [{0}]", string.Join(", ", ariPurchase(readJson1)));
            Console.WriteLine("This is the user who purchase lower than 300000 : [{0}]", string.Join(", ", lower300000(readJson1)));


            var read2 = File.ReadAllText("/Users/gigaming/Downloads/Refactory Image/Training/TryOut/Day4Json/Day4Json/#3.json");
            var readJson2 = JsonConvert.DeserializeObject<List<user3>>(read2);

            var items = new List<user3>();
            var electronic = new List<user3>();
            var furniture = new List<user3>();
            var purchaseJan16 = new List<user3>();
            var brown = new List<user3>();

            foreach (var i in readJson2)
            {
                if (i.placement.name == "Meeting Room")
                {
                    items.Add(i);
                }

                if (i.type.ToLower() == "electronic")
                {
                    electronic.Add(i);
                }

                if (i.type.ToLower() == "furniture")
                {
                    furniture.Add(i);
                }

                if (i.purchased_at >= 1579132800 && i.purchased_at < 1579219200)
                {
                    purchaseJan16.Add(i);
                }

                if (i.tags.ToList().Contains("brown"))
                {
                    brown.Add(i);
                }
            }

            File.WriteAllText(@"/Users/gigaming/Downloads/Refactory Image/Training/TryOut/Day4Json/Day4Json/items.json", JsonConvert.SerializeObject(items));
            File.WriteAllText(@"/Users/gigaming/Downloads/Refactory Image/Training/TryOut/Day4Json/Day4Json/electronic.json", JsonConvert.SerializeObject(electronic));
            File.WriteAllText(@"/Users/gigaming/Downloads/Refactory Image/Training/TryOut/Day4Json/Day4Json/furnitures.json", JsonConvert.SerializeObject(furniture));
            File.WriteAllText(@"/Users/gigaming/Downloads/Refactory Image/Training/TryOut/Day4Json/Day4Json/purchased-at-2020-01-06.json", JsonConvert.SerializeObject(purchaseJan16));
            File.WriteAllText(@"/Users/gigaming/Downloads/Refactory Image/Training/TryOut/Day4Json/Day4Json/all-browns.json", JsonConvert.SerializeObject(brown));
        }

        public static string[] phoneNumber(List<user> us)
        {
            var result = new List<string>();
            foreach (var i in us)
            {
                if (i.profile.phones.Length == 0)
                {
                    result.Add(i.username);
                }
            }
            return result.ToArray();
        }

        public static string[] haveArticles(List<user> us)
        {
            var result = new List<string>();
            foreach (var i in us)
            {
                if (i.articles.Length != 0)
                {
                    result.Add(i.username);
                }
            }
            return result.ToArray();
        }

        public static string[] haveAnnis(List<user> us)
        {
            var result = new List<string>();
            foreach (var i in us)
            {
                var temp = i.profile.full_name.ToLower().ToCharArray().ToList();
                bool inside = true;
                foreach (var j in "annis".ToCharArray())
                {
                    if (temp.Contains(j)==false)
                    {
                        inside = false;
                    }
                }
                if (inside) { result.Add(i.username);  }
            }
            return result.ToArray();
        }

        public static string[] haveYear2020(List<user> us)
        {
            var result = new List<string>();
            foreach (var i in us)
            {
                if (i.articles.Length != 0)
                {
                    foreach (var j in i.articles)
                    {
                        var temp = j.published_at.Substring(0, 4);
                        if (temp == "2020")
                        {
                            result.Add(i.username);
                        }
                    }
                }
            }
            if (result.Count == 0) { result.Add("None");  }
            return result.ToArray();
        }

        public static string[] born1986(List<user> us)
        {
            var result = new List<string>();
            foreach (var i in us)
            {
                if (i.profile.birthday.Substring(0, 4) == "1986")
                {
                    result.Add(i.username);
                }
            }
            if (result.Count == 0) { result.Add("None"); }
            return result.ToArray();
        }

        public static string[] titleTips(List<user> us)
        {
            var result = new List<string>();
            foreach (var i in us)
            {
                if (i.articles.Length != 0)
                {
                    foreach (var j in i.articles)
                    {
                        var temp = j.title.ToLower().Split(' ');
                        if (temp.Contains("tips"))
                        {
                            result.Add($"{j.title} by {i.username}");
                        }
                    }
                }
            }
            if (result.Count == 0) { result.Add("None"); }
            return result.ToArray();
        }

        public static string[] publishAugust(List<user> us)
        {
            var result = new List<string>();
            foreach (var i in us)
            {
                if (i.articles.Length != 0)
                {
                    foreach (var j in i.articles)
                    {
                        var temp = j.published_at.Substring(0, 7).Split('-').ToArray();
                        int year = Convert.ToInt32(temp[0]);
                        int month = Convert.ToInt32(temp[1]);

                        if (year <= 2019 && month < 8)
                        {
                            result.Add($"{j.title} by {i.username}");
                        }
                    }
                }
            }
            if (result.Count == 0) { result.Add("None"); }
            return result.ToArray();
        }

        public static string[] purchase02(List<user2> us)
        {
            var result = new List<string>();
            foreach (var i in us)
            {
                var temp = i.created_at.Substring(5, 2);
                if (temp == "02")
                {
                    result.Add($"{i.customer.name} with order_id : {i.order_id}");
                }
            }
            return result.ToArray();
        }

        public static string[] ariPurchase(List<user2> us)
        {
            var result = new List<string>();
            foreach (var i in us)
            {
                if (i.customer.name == "Ari")
                {
                    int k = 0;
                    foreach (var j in i.items)
                    {
                        k += j.price;
                    }
                    result.Add($"{k}");
                }
            }
            return result.ToArray();
        }

        public static string[] lower300000(List<user2> us)
        {
            var result = new List<string>();
            foreach (var i in us)
            {
                int total = 0;
                foreach (var j in i.items)
                {
                    total += j.price;
                }
                if (result.Contains(i.customer.name) == false && total < 300000)
                {
                    result.Add(i.customer.name);
                }
            }
            return result.ToArray();
        }
    }
}
