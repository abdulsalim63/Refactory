using System;
using System.ComponentModel.DataAnnotations;

namespace User.Application.UseCases.Users //.Models
{
    public class UserOutput
    {
        public int id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; }
        public string address { get; set; }
    }
}
