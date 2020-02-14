using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Collections.Generic;
using RestSharp;
using McMaster.Extensions.CommandLineUtils;

namespace Week2CLIAPI
{
    class Program
    {
        public static int Main(string[] args) => CommandLineApplication.Execute<Program>(args);

        //static void Main(string[] args)
        //{
        //    var client = new RestClient("http://localhost:3000/todo");
        //    client.Timeout = -1;
        //    var request = new RestRequest(Method.POST);
        //    request.AddHeader("Content-Type", "application/json");
        //    var str = "I am";
        //    request.AddParameter("application/json", $"{{\n\t\"todo\" : \"{str}\"\n}}", ParameterType.RequestBody);
        //    IRestResponse response = client.Execute(request);
        //    Console.WriteLine(response.Content);
        //}

        [Argument(0)]
        public string[] todoMethod { get; }

        private void OnExecute()
        {
            var client = new RestClient("http://localhost:3000/todo");
            client.Timeout = -1;

            if (todoMethod[1].ToLower() == "list")
            {
                var requestList = new RestRequest(Method.GET);
                requestList.AddHeader("Content-Type", "list/json");
                var response = client.Execute(requestList);
                var jsonFile = JsonConvert.DeserializeObject<List<Todo>>(response.Content);

                foreach (var i in jsonFile)
                {
                    if (i.done) { Console.WriteLine($"{i.id}. {i.todo} (DONE)"); }
                    else { Console.WriteLine($"{i.id}. {i.todo}"); }
                }
            }
            else if (todoMethod[1].ToLower() == "add")
            {
                var content = todoMethod[2];
                Console.WriteLine($"{{\n\t\"todo\" : \"{content}\"\n}}");
                var requestAdd = new RestRequest(Method.POST);
                requestAdd.AddHeader("Content-Type", "application/json");
                requestAdd.AddParameter("application/json", $"{{\n\t\"todo\" : \"{content}\"\n, \n\t\"done\" : false\n}}", ParameterType.RequestBody);
                var response = client.Execute(requestAdd);
                Console.WriteLine(response.Content);
            }
            else if (todoMethod[1].ToLower() == "update")
            {
                var client1 = new RestClient($"http://localhost:3000/todo/{todoMethod[2]}");
                client1.Timeout = -1;
                var request = new RestRequest(Method.DELETE);
                request.AddHeader("Content-Type", "application/json");
                IRestResponse response = client1.Execute(request);

                var content = todoMethod[3];
                Console.WriteLine($"{{\n\t\"todo\" : \"{content}\"\n}}");
                var requestAdd = new RestRequest(Method.POST);
                requestAdd.AddHeader("Content-Type", "application/json");
                requestAdd.AddParameter("application/json", $"{{\n\t\"todo\" : \"{content}\"\n, \n\t\"done\" : false\n}}", ParameterType.RequestBody);
                var response1 = client.Execute(requestAdd);
                Console.WriteLine(response1.Content);
            }
            else if (todoMethod[1].ToLower() == "del")
            {
                var client1 = new RestClient($"http://localhost:3000/todo/{todoMethod[2]}");
                client1.Timeout = -1;
                var request = new RestRequest(Method.DELETE);
                request.AddHeader("Content-Type", "application/json");
                IRestResponse response = client1.Execute(request);
                Console.WriteLine(response.Content);
            }
            else if (todoMethod[1].ToLower() == "done")
            {
                var client1 = new RestClient($"http://localhost:3000/todo/{todoMethod[2]}");
                client1.Timeout = -1;

                var request0 = new RestRequest(Method.GET);
                var response0 = client1.Execute(request0);
                var content1 = JsonConvert.DeserializeObject<List<Todo>>(response0.Content);
                //var content = content1[0].todo;

                var request = new RestRequest(Method.DELETE);
                request.AddHeader("Content-Type", "application/json");
                IRestResponse response = client1.Execute(request);

                //Console.WriteLine($"{{\n\t\"todo\" : \"{content}\"\n}}");
                var requestAdd = new RestRequest(Method.POST);
                requestAdd.AddHeader("Content-Type", "application/json");
                requestAdd.AddParameter("application/json", $"{{\n\t\"id\" : {todoMethod[2]}, \n\t\"todo\" : \"spm\"\n, \n\t\"done\" : true\n}}", ParameterType.RequestBody);
                var response1 = client.Execute(requestAdd);
                Console.WriteLine(response1.Content);
            }
            else if (todoMethod[1].ToLower() == "undone")
            {
                var client1 = new RestClient($"http://localhost:3000/todo/{todoMethod[2]}");
                client1.Timeout = -1;
                var request = new RestRequest(Method.DELETE);
                request.AddHeader("Content-Type", "application/json");
                IRestResponse response = client1.Execute(request);

                var content = JsonConvert.DeserializeObject<List<Todo>>(response.Content)[0].todo;
                Console.WriteLine($"{{\n\t\"todo\" : \"{content}\"\n}}");
                var requestAdd = new RestRequest(Method.POST);
                requestAdd.AddHeader("Content-Type", "application/json");
                requestAdd.AddParameter("application/json", $"{{\n\t\"id\" : {todoMethod[2]}, \n\t\"todo\" : \"{content}\"\n, \n\t\"done\" : false\n}}", ParameterType.RequestBody);
                var response1 = client.Execute(requestAdd);
                Console.WriteLine(response1.Content);
            }
            else
            {
                Console.WriteLine(string.Join("\n", todoMethod));
            }
        }
    }
}
