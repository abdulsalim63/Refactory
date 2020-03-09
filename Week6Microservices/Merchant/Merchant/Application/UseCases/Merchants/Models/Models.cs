using System;
namespace Merchant.Application.UseCases.Merchants //.Models
{
    public class MerchantInput
    {
        public string name { get; set; }
        public string image { get; set; }
        public string address { get; set; }
        public double rating { get; set; }
    }
}
