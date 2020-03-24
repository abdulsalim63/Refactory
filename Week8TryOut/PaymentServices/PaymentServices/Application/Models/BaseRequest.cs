using System;
namespace PaymentServices.Application.Models
{
    public class BaseRequest<T>
    {
        public Data<T> data { get; set; }
    }

    public class Data<T>
    {
        public T attributes { get; set; }
    }
}
