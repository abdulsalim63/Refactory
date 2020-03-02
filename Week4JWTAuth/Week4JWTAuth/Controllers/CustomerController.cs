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

        public CustomerController(CustomerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get() => Ok(new {
            message = "success retrieve data",
            status = "true",
            data = _context.customers.ToList()
        });

        [HttpPost]
        [AllowAnonymous]
        [Route("auth")]
        public IActionResult Post(RequestCustomer request)
        {
            var authentication = request.data.attributes;
            Customer result;

            try
            {
                result = _context.customers.First(x => x.username == authentication.username);
            }
            catch (Exception)
            {
                return NotFound();
            }

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
