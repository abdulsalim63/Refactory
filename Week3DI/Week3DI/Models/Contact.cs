using System;
using Newtonsoft.Json;

namespace Week3DI.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Full_Name { get; set; }
    }
}
