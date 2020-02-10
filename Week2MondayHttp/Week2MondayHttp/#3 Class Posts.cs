using System;
namespace Week2MondayHttp
{
    public class posts
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public user user { get; set; }
    }
}
