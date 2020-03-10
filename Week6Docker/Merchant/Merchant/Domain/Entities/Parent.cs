using System;
namespace Merchant.Domain.Entities
{
    public class Parent
    {
        public int id { get; set; }
        public long created_at { get; set; } = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalDays;
        public long updated_at { get; set; } = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalDays;
    }
}
