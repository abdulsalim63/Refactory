using System;

namespace Week3WebApi.Model
{
    public class Photo
    {
        public int Id { get; set; }
        public string Caption { get; set; }
        public string Url { get; set; }
        public int Contact_id { get; set; }
    }
}
