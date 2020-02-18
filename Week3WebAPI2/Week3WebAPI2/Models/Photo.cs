using System;

namespace Week3WebAPI2.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string Caption { get; set; }
        public string Url { get; set; }
        public int Contact_id { get; set; }
    }
}
