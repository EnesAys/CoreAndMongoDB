using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CoreAndMongoDB.Controllers
{/* For JWT Token Authorization
    [Authorize]
    [Produces("application/json")]
    [Route("api")]
    public class ApiController : Controller
    {
        private readonly IConfiguration _configuration;

        public ApiController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //[Authorize(Policy = "TrainedStaffOnly")]
        //[HttpPost("DeleteUser")]
        //public IActionResult DeleteUser(string username)
        //{
        //    // go wild, delete the user, do what you have to...
        //    return Ok("Deleted");
        //}

        [AllowAnonymous]
        [HttpPost]
        public IActionResult RequestToken([FromBody] TokenRequest request)
        {
            if (request.Username == "Enes" && request.Password == "Enes123")
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, request.Username),
                    //new Claim("CompletedBasicTraining", "")
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecurityKey"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "http://localhost:54206/",
                    audience: "http://localhost:54206/",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }

            return BadRequest("Could not verify username and password");
        }

    }

    public class TokenRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    */
}
