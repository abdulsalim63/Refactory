using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Week5Decorator.Models;

namespace Week5Decorator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerPaymentController : ControllerBase
    {
        private readonly CustomerContext _context;
        private readonly long timestamp;

        public CustomerPaymentController(CustomerContext context)
        {
            _context = context;
            timestamp = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds;
        }

        [HttpPost]
        public IActionResult Post(Request<CustomerCard> request)
        {
            var result = request.data.attributes;
            result.created_at = timestamp;
            result.updated_at = timestamp;
            _context.customerCards.Add(result);
            //_context.SaveChanges();
            return Ok(new
            {
                message = "succes add data",
                status = "true",
                data = result
            });
        }

        [HttpGet]
        public IActionResult Get() => Ok(new
        {
            message = "succes retrieve data",
            status = "true",
            data = _context.customerCards.OrderBy(x => x.id)
        });

        [HttpGet("{id}")]
        public IActionResult GetbyId(int id)
        {
            try
            {
                var result = _context.customers.First(x => x.id == id);
                return Ok(new
                {
                    message = "succes retrieve data",
                    status = "true",
                    data = result
                });
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public IActionResult PutbyId(int id, Request<CustomerCard> request)
        {
            try
            {
                var result = _context.customerCards.First(x => x.id == id);
                var customer = request.data.attributes;
                result.updated_at = timestamp;
                result.customer_id = customer.customer_id;
                result.name_on_card = customer.name_on_card;
                result.exp_month = customer.exp_month;
                result.exp_year = customer.exp_year;
                result.postal_code = customer.postal_code;
                result.credit_card_number = customer.credit_card_number;
                _context.SaveChanges();
                return Ok(new
                {
                    message = "succes update data",
                    status = "true",
                    data = result
                });
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletebyId(int id)
        {
            try
            {
                var result = _context.customers.First(x => x.id == id);
                _context.customers.Remove(result);
                _context.SaveChanges();
                return Ok(new
                {
                    message = "succes delete data",
                    status = "true",
                    data = result
                });
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
