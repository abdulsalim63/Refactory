using System;
using Newtonsoft.Json;

namespace Week3WebApi.Model
{
    public class Contact
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        [JsonProperty("Full_Name")]
        public string FullName { get; set; }
    }
}
