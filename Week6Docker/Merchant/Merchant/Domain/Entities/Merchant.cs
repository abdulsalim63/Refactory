﻿using System;
namespace Merchant.Domain.Entities
{
    public class MerchantModel : Parent
    {
        public string name { get; set; }
        public string image { get; set; }
        public string address { get; set; }
        public double rating { get; set; }
    }
}
