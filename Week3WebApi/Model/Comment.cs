using System;
namespace Week3WebApi.Model
{
    public class PhotoComment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int Photo_id { get; set; }
        public int Contact_id { get; set; }
    }
}
