using System;
namespace Week5Mediator.Application.UseCases.Customers.Models
{
    public class CustomerData
    {
        public string full_name { get; set; }
        public string username { get; set; }
        public DateTime birthdate { get; set; }
        public string password { get; set; }
        public string gender { get; set; }
        public string email { get; set; }
        public string phone_number { get; set; }
    }
}
