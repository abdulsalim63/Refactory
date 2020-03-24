using System;
using Newtonsoft.Json;
using PaymentServices.Application.UseCases.Payments;
using PaymentServices.Domain.Entities;
using RestSharp;

namespace PaymentServices.Application.Models
{
    public class BankPayment
    {
        public static Payment payment(Payment_Input data)
        {
            var client = new RestClient("https://api.sandbox.midtrans.com/v2/charge");
            client.Timeout = -1;
            var requestPayment = new RestRequest(Method.POST);
            requestPayment.AddHeader("Accept", "application/json");
            requestPayment.AddHeader("Authorization", "Basic U0ItTWlkLXNlcnZlci1haEc2cmRzSEhTVVNNbTdtU0U2bzlYOXM=");
            requestPayment.AddHeader("Content-Type", "application/json");
            requestPayment.AddParameter("application/json", $"{{\n\t\"payment_type\" : \"{data.payment_type}\",\n\t\"transaction_details\" : {{\n\t\t\"order_id\" : \"order-{data.order_id}\",\n\t\t\"gross_amount\" : {data.gross_amount} \n\t}},\n\t\"bank_transfer\" : {{\n\t\t\"bank\" : \"{data.bank}\"\n\t}}\n}}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(requestPayment);

            var payment = JsonConvert.DeserializeObject<Midtrans>(response.Content);

            var paymentData = new Payment
            {
                order_id = data.order_id,
                transaction_id = payment.transaction_id,
                payment_type = data.payment_type,
                gross_amount = data.gross_amount.ToString(),
                transaction_time = payment.transaction_time,
                transaction_status = payment.transaction_status
            };

            return paymentData;
        }
    }
}
