using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Week4LINQ
{
    class Program
    {
        static void Main(string[] args)
        {

            //First Json
            var firstJson = File.ReadAllText("/Users/gigaming/Downloads/Refactory Image/Training/Refactory Task/Week4LINQ/Week4LINQ/#1.json");
            var firstClass = JsonConvert.DeserializeObject<List<user1>>(firstJson);

            var noPhone = firstClass.Where(x => x.profile.phones.Count() == 0).ToList();
            var haveArticles = firstClass.Where(x => x.articles.Count() > 0).ToList();
            Func<string, bool> HaveAnnis = delegate (string s1)
            {
                var charArray = s1.ToCharArray();
                var annis = "nnis".ToCharArray();
                for (int i=0;i<charArray.Length;i++)
                {
                    if (Char.ToLower(charArray[i]) == 'a' & i <= charArray.Length-4)
                    {
                        var temp = true;
                        for (int j=i+1,k=1;j<i+5;j++,k++)
                        {
                            if (charArray[j] != annis[k])
                            {
                                temp = false;
                                break;
                            }
                        }
                        if (temp) { return true; }
                    }
                }
                return false;
            };
            var haveAnnis = firstClass.Where(s => an(s.profile.full_name)).ToList();
            var year2020 = firstClass.Where(s => s.articles.Any(x => x.published_at.Substring(0, 4) == "2020")).ToList();
            var born1986 = firstClass.Where(s => s.profile.birthday.Substring(0, 4) == "1986").ToList();
            var tips = firstClass.SelectMany(x => x.articles.Where(s => s.title.Split(' ').ToList().Any(y => y.ToLower() == "tips")).ToList()).ToList() ;
            var articlesAugust = firstClass.SelectMany(x => x.articles.Where(s => Convert.ToInt32(s.published_at.Substring(0, 4)) <= 2019 && Convert.ToInt32(s.published_at.Substring(5, 2)) < 8)).ToList();


            //Second Json
            var secondJson = File.ReadAllText("/Users/gigaming/Downloads/Refactory Image/Training/Refactory Task/Week4LINQ/Week4LINQ/#2.json");
            var secondClass = JsonConvert.DeserializeObject<List<user2>>(secondJson);

            var febPurchase = secondClass.Where(x => x.created_at.Substring(5, 2) == "02").ToList();
            var ariGrandTotal = secondClass.Sum(x => x.items.Sum(s => s.qty*s.price));
            var grandTotal = secondClass.Select(x => new { Name = x.customer.name, Total = x.items.Sum(s => s.qty * s.price) }).ToList();


            //Third Json
            var thirdJson = File.ReadAllText("/Users/gigaming/Downloads/Refactory Image/Training/Refactory Task/Week4LINQ/Week4LINQ/#3.json");
            var thirdClass = JsonConvert.DeserializeObject<List<user3>>(thirdJson);

            var meetingRoom = thirdClass.Where(x => x.placement.name.ToLower() == "meeting room").ToList();
            File.WriteAllText("/Users/gigaming/Downloads/Refactory Image/Training/Refactory Task/Week4LINQ/Week4LINQ/MeetingRoom.json", JsonConvert.SerializeObject(meetingRoom));
            var elecDevices = thirdClass.Where(x => x.type.ToLower() == "electronic").ToList();
            File.WriteAllText("/Users/gigaming/Downloads/Refactory Image/Training/Refactory Task/Week4LINQ/Week4LINQ/Electronic.json", JsonConvert.SerializeObject(elecDevices));
            var furnitures = thirdClass.Where(x => x.type.ToLower() == "furniture").ToList();
            File.WriteAllText("/Users/gigaming/Downloads/Refactory Image/Training/Refactory Task/Week4LINQ/Week4LINQ/Furnitures.json", JsonConvert.SerializeObject(furnitures));
            var purchase16Jan = thirdClass.Where(x => x.purchased_at >= 1579132800 && x.purchased_at < 1579219200).ToList();
            File.WriteAllText("/Users/gigaming/Downloads/Refactory Image/Training/Refactory Task/Week4LINQ/Week4LINQ/16January.json", JsonConvert.SerializeObject(purchase16Jan));
            var brownColor = thirdClass.Where(x => x.tags.Any(t => t.ToLower() == "brown")).ToList();
            File.WriteAllText("/Users/gigaming/Downloads/Refactory Image/Training/Refactory Task/Week4LINQ/Week4LINQ/Browns.json", JsonConvert.SerializeObject(brownColor));

            Console.WriteLine(an("Annisa"));
        }

        public static bool an(string s1)
        {
            var charArray = s1.ToCharArray();
            var annis = "nnis".ToCharArray();
            for (int i = 0; i < charArray.Length; i++)
            {
                if (Char.ToLower(charArray[i]) == 'a' & i <= charArray.Length - 4)
                {
                    var temp = true;
                    for (int j = i + 1, k = 0; j < i + 5; j++, k++)
                    {
                        if (charArray[j] != annis[k])
                        {
                            temp = false;
                            break;
                        }
                    }
                    if (temp) { return true; }
                }
            }
            return false;
        }
    }
}
