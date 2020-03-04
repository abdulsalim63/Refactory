using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Week5Decorator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly List<Admin> admins = new List<Admin>
        {
            new Admin { name = "Larry", password = "dedoy"},
            new Admin { name = "Curry", password = "yak"}
        };

        [HttpPost]
        public IActionResult GetToken(Admin admin)
        {
            try
            {
                var result = admins.First(x => x.name == admin.name && x.password == admin.password);
                var tokenHandler = new JwtSecurityTokenHandler();

                var tokenDescription = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, result.name),
                    new Claim(ClaimTypes.Authentication, result.password)
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
            catch(Exception)
            {
                return NotFound();
            }
        }
    }

    public class Admin
    {
        public string name { get; set; }
        public string password { get; set; }
    }
}
