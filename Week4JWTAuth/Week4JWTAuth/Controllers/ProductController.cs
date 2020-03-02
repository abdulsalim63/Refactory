using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Week4JWTAuth.Models;

namespace Week4JWTAuth.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class ProductController : ControllerBase
    {
        private readonly ProductContext _context;
        private readonly long timestamp;

        public ProductController(ProductContext context)
        {
            _context = context;
            timestamp = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds;
        }

        [HttpPost]
        public IActionResult Post(RequestProduct request)
        {
            var product = request.data.attributes;
            product.created_at = timestamp;
            product.updated_at = timestamp;
            _context.products.Add(product);
            _context.SaveChanges();
            return Ok(new { message = "success add data", status = "true", data = product });
        }

        [HttpGet]
        public IActionResult Get() => Ok(new {
            message = "success retrieve data",
            status = "true",
            data = _context.products.OrderBy(x => x.id).ToList()
        });

        [HttpGet("{id}")]
        public IActionResult GetbyId(int id)
        {
            try
            {
                var result = _context.products.First(x => x.id == id);
                return Ok(new
                {
                    message = "success retrieve data",
                    status = "true",
                    data = result
                });
            }
            catch (Exception)
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
                    message = "success delete data",
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
        public IActionResult UpdatebyId(int id, RequestProduct request )
        {
            var products = request.data.attributes;
            try
            {
                var result = _context.products.First(x => x.id == id);
                result.name = products.name;
                result.price = products.price;
                result.updated_at = timestamp;
                _context.SaveChanges();
                return Ok(new
                {
                    message = "success update data",
                    status = "true",
                    data = result
                });
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        public class RequestProduct
        {
            public DataProduct data { get; set; }
        }

        public class DataProduct
        {
            public Product attributes { get; set; }
        }
    }
}
