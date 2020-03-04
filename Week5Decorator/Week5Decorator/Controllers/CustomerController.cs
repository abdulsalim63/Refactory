using System;
using System.Linq;
using Week5Decorator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Week5Decorator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerContext _context;
        private readonly long timestamp;

        public CustomerController(CustomerContext context)
        {
            _context = context;
            timestamp = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds;
        }

        [HttpPost]
        public IActionResult Post(Request<Customer> request)
        {
            var result = request.data.attributes;
            result.created_at = timestamp;
            result.updated_at = timestamp;
            _context.customers.Add(result);
            _context.SaveChanges();
            return Ok(new
            {
                message = "succes add data",
                status = "true",
                data = result
            });
        }

        [HttpGet]
        public IActionResult Get() => Ok( new {
            message = "succes retrieve data",
            status = "true",
            data = _context.customers.OrderBy(x => x.id) });

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
        public IActionResult PutbyId(int id, Request<Customer> request)
        {
            try
            {
                var result = _context.customers.First(x => x.id == id);
                var customer = request.data.attributes;
                result.updated_at = timestamp;
                result.full_name = customer.full_name;
                result.username = customer.username;
                result.birthdate = customer.birthdate;
                result.password = customer.password;
                result.gender = customer.gender;
                result.email = customer.email;
                result.phone_number = customer.phone_number;
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
