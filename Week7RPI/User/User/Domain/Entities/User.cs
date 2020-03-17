using System;
using System.ComponentModel.DataAnnotations;

namespace User.Domain.Entities
{
    public class User_Model
    {
        public int id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; }
        public string password { get; set; }
        public string address { get; set; }
    }
}
