using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Linq;
using System.IO;
using HtmlAgilityPack;

namespace Week2MondayHttp
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var getJsonResponse = await Fetcher.Get("https://httpbin.org/get");
            Console.WriteLine(getJsonResponse);
            var deleteJsonResponse = await Fetcher.Delete("https://httpbin.org/delete");
            Console.WriteLine(deleteJsonResponse);

            var jsonData = @"
                    {
                        ""id"" :30,
                        ""name"" : ""someone""
                    }
                ";

            var jsonPostContent = new StringContent(jsonData, System.Text.Encoding.UTF8, "post/json");
            var postJsonResponse = Fetcher.Post("https://httpbin.org/post", jsonPostContent);
            Console.WriteLine(postJsonResponse);

            var jsonPutContent = new StringContent(jsonData, System.Text.Encoding.UTF8, "put/json");
            var putJsonResponse = Fetcher.Put("https://httpbin.org/put", jsonPutContent);
            Console.WriteLine(putJsonResponse);

            var jsonPatchContent = new StringContent(jsonData, System.Text.Encoding.UTF8, "patch/json");
            var patchJsonResponse = Fetcher.Patch("https://httpbin.org/patch", jsonPatchContent);
            Console.WriteLine(patchJsonResponse);

            var client = new HttpClient();
            var jsonparse = await client.GetStringAsync("https://mul14.github.io/data/employees.json");
            var employeeList = JsonConvert.DeserializeObject<List<Employee>>(jsonparse);

            var hightSalary = new List<Employee>();
            var liveInJakarta = new List<Employee>();
            var marchBirthday = new List<Employee>();
            var deptRandD = new List<Employee>();
            var absencesOctober = new List<Employee>();

            foreach (var employee in employeeList)
            {
                if (employee.salary > 15000000)
                {
                    hightSalary.Add(employee);
                }

                foreach (var addr in employee.addresses)
                {
                    var live = addr.city.Split(' ').ToList();
                    if (addr.label == "home" && live.Contains("Jakarta"))
                    {
                        liveInJakarta.Add(employee);
                        break;
                    }
                }

                var montOfBirth = employee.birthday.Split('-')[1];
                if (montOfBirth == "03")
                {
                    marchBirthday.Add(employee);
                }

                if (employee.department.name == "Research and development")
                {
                    deptRandD.Add(employee);
                }

                if (employee.presence_list.Count < 25)
                {
                    absencesOctober.Add(employee);
                }


            }

            var jsonParse1 = await client.GetStringAsync("https://jsonplaceholder.typicode.com/posts");
            var jsonParse2 = await client.GetStringAsync("https://jsonplaceholder.typicode.com/users");
            var postsList = JsonConvert.DeserializeObject<List<posts>>(jsonParse1);
            var usersList = JsonConvert.DeserializeObject<List<user>>(jsonParse2);

            foreach (var post in postsList)
            {
                post.user = usersList.Where(x => x.id == post.userId).FirstOrDefault();

                File.AppendAllText(@"/Users/gigaming/Downloads/Refactory Image/Training/Refactory Task/Week2MondayHttp/Week2MondayHttp/Merge Json #3.json", JsonConvert.SerializeObject(post));
                File.AppendAllText(@"/Users/gigaming/Downloads/Refactory Image/Training/Refactory Task/Week2MondayHttp/Week2MondayHttp/Merge Json #3.json", "\n");
            }


            // #5 Kompas
            var kompas = new List<kompas>();

            HtmlAgilityPack.HtmlWeb webKompas = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument docKompas = webKompas.Load("https://www.kompas.com/");
            foreach (var link in docKompas.DocumentNode.SelectNodes("//a[@class = 'headline__thumb__link']"))
            {
                kompas.Add(new kompas { Title = link.InnerText, URL = link.GetAttributeValue("href", string.Empty) });
            }

            
            // #6 CGV
            var CGV = new List<CGV>();

            var webCGV = new HtmlAgilityPack.HtmlWeb();
            var docCGV = webCGV.Load("https://www.cgv.id/en/");
            var slides = docCGV.DocumentNode.SelectNodes("//ul[@class='slides']")[0].ChildNodes.ToList().Where(x => x.Name == "li").ToList();
            foreach (var i in slides)
            {
                var nestesdURL = i.ChildNodes.ToList().Where(x => x.Name == "a").ToList()[0].GetAttributeValue("href", string.Empty);
                var goUrl = webCGV.Load(nestesdURL);

                var movieDetail = goUrl.DocumentNode.SelectNodes("//div[@class='movie-add-info left']").ToList()[0]
                    .ChildNodes.ToList().Where(x => x.Name == "ul").ToList()[0]
                    .ChildNodes.ToList().Where(x => x.Name == "li").ToList();

                CGV.Add(new CGV
                {
                    Judul = goUrl.DocumentNode.SelectNodes("//div[@class='movie-info-title']").ToList()[0].InnerText,
                    JenisFilm = movieDetail[3].InnerText.Split(" : ")[1].Split(',').ToList(),
                    Sutradara = movieDetail[1].InnerText.Split(" : ")[1],
                    Casts = movieDetail[0].InnerText.Split(" : ")[1].Split(',').ToList(),
                    Trailer = goUrl.DocumentNode.SelectNodes("//div[@class='trailer-section']").ToList()[0]
                    .ChildNodes.Where(x => x.Name == "div").ToList()[0]
                    .ChildNodes.ToList().Where(x => x.Name == "img").ToList()[0]
                    .GetAttributeValue("src", string.Empty),
                    Sinopsis = goUrl.DocumentNode.SelectNodes("//div[@class='movie-synopsis right']").ToList()[0].InnerText.Split("\n")[1]
                }); ; ;
            }


            Console.WriteLine();
        }
    }

    class Fetcher
    {
        public static HttpClient client = new HttpClient();

        public async static Task<string> Get(string url)
        {
            return await client.GetStringAsync(url);
        }

        public async static Task<HttpResponseMessage> Delete(string url)
        {
            return await client.DeleteAsync(url);
        }

        public static async Task<HttpResponseMessage> Post(string url, object data)
        {
            var content = new StringContent(JsonConvert.SerializeObject(data), System.Text.Encoding.UTF8, "post/json");
            return await client.PostAsync(url, content);
        }

        public async static Task<HttpResponseMessage> Put(string url, object data)
        {
            var content = new StringContent(JsonConvert.SerializeObject(data), System.Text.Encoding.UTF8, "put/json");
            return await client.PutAsync(url, content);
        }

        public async static Task<HttpResponseMessage> Patch(string url, object data)
        {
            var content = new StringContent(JsonConvert.SerializeObject(data), System.Text.Encoding.UTF8, "patch/json");
            return await client.PatchAsync(url, content);
        }
    }

    //class RestAPI
    //{
    //    public static void GET()
    //    {
    //        
    //    }
    ////}
    ///
}
