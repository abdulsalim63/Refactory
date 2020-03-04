using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Week5Decorator.Models;

namespace Week5Decorator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly MerchantProductContext _context;
        private readonly long timestamp;

        public ProductController(MerchantProductContext context)
        {
            _context = context;
            timestamp = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds;
        }

        [HttpPost]
        public IActionResult Post(Request<Product> request)
        {
            var result = request.data.attributes;
            result.created_at = timestamp;
            result.updated_at = timestamp;
            _context.products.Add(result);
            _context.SaveChanges();
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
            data = _context.products.OrderBy(x => x.id)
        });

        [HttpGet("{id}")]
        public IActionResult GetbyId(int id)
        {
            try
            {
                var result = _context.products.First(x => x.id == id);
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
        public IActionResult PutbyId(int id, Request<Product> request)
        {
            try
            {
                var result = _context.products.First(x => x.id == id);
                var customer = request.data.attributes;
                result.updated_at = timestamp;
                result.merchant_id = customer.merchant_id;
                result.name = customer.name;
                result.price = customer.price;
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
                var result = _context.products.First(x => x.id == id);
                _context.products.Remove(result);
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
