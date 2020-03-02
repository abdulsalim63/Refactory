using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Week4JWTAuth.Models;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Week4Friday.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
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
        [AllowAnonymous]
        public IActionResult Post(RequestCustomer request)
        {
            var auth = request.data.attributes;
            var customer = new Customer()
            {
                full_name = auth.full_name,
                username = auth.username,
                email = auth.email,
                phone_number = auth.phone_number,
                created_at = timestamp,
                updated_at = timestamp
            };
            _context.customers.Add(customer);
            _context.SaveChanges();
            return Ok(new { message = "success add data", status = "true", data = customer });
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("auth")]
        public IActionResult PostAuth(RequestCustomer request)
        {
            var authentication = request.data.attributes;
            Customer result;

            try
            {
                result = _context.customers.First(x => x.username == authentication.username);
                var tokenHandler = new JwtSecurityTokenHandler();

                var tokenDescription = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, authentication.username),
                    new Claim(ClaimTypes.Authentication, authentication.password)
                }),
                    Expires = DateTime.UtcNow.AddMonths(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes("this is some secret shit")), SecurityAlgorithms.HmacSha512Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescription);

                var tokenResponse = new
                {
                    token = tokenHandler.WriteToken(token),
                    customer = result
                };

                return Ok(tokenResponse);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult Get() => Ok(new {
            message = "success retrieve data",
            status = "true",
            data = _context.customers.ToList()
        });

        [HttpGet("{id}")]
        public IActionResult GetbyId(int id)
        {
            try
            {
                var result = _context.customers.First(x => x.id == id);
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

        [HttpPut("{id}")]
        public IActionResult UpdatebyId(int id, RequestCustomer request)
        {
            var auth = request.data.attributes;
            try
            {
                var result = _context.customers.First(x => x.id == id);
                result.full_name = auth.full_name;
                result.username = auth.username;
                result.email = auth.email;
                result.phone_number = auth.phone_number;
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

        public class RequestCustomer
        {
            public DataCustomer data { get; set; }
        }

        public class DataCustomer
        {
            public Authentication attributes { get; set; }
        }

        public class Authentication : Customer
        {
            public string password { get; set; }
        }
    }
}
