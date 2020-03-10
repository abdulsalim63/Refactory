using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Merchant.Presenter
{
    [ApiController]
    [Route("api/auth")]
    [Authorize]
    public class Authentication : ControllerBase
    {
        public List<Admin> admins = new List<Admin>
        {
            new Admin { username = "psychoville", password = "confidential" },
            new Admin { username = "kd", password = "warriorsRock" }
        };

        public Authentication()
        {
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult GetToken(Admin admin)
        {
            try
            {
                var result = admins.First(x => x.username == admin.username && x.password == admin.password);

                var tokenHandler = new JwtSecurityTokenHandler();

                var tokenDescription = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(new Claim[] {
                        new Claim(ClaimTypes.Name, result.username),
                        new Claim(ClaimTypes.Authentication, result.password)
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes("this is encryption key")), SecurityAlgorithms.HmacSha512Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescription);

                return Ok(new
                {
                    token = tokenHandler.WriteToken(token),
                    admin = result
                });
            }
            catch (Exception)
            {
                return Ok(new
                {
                    Message = "Failed generate token",
                    Status = false,
                    Data = admin
                });
            }
        }

        [HttpPost("admin")]
        public IActionResult AddAdmin(Admin admin)
        {
            if (!admins.Any(x => x.username == admin.username))
            {
                admins.Add(admin);
                return Ok(new
                {
                    Message = "Success add admin",
                    Status = true,
                    Data = admin
                });
            }
            else
            {
                return Ok(new
                {
                    Message = "Failed add admin (username already exists)",
                    Status = false,
                    Data = admin
                });
            }
        }
    }

    public class Admin
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}
