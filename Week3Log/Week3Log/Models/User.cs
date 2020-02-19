using System;
using Newtonsoft.Json;

namespace Week3Log.Models
{
    public class User
    {
        public int Id { get; set; }

        [JsonProperty("First Name")]
        public string FirstName { get; set; }

        [JsonProperty("Last Name")]
        public string LastName { get; set; }

        public string NickName { get; set; }
    }
}
