using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace TemperatureSensor.Infrastructure.WebApi
{
    [Route("Api/Authentication")]
    public class AuthenticationController : ControllerBase
    {
        private IConfiguration _configuration;

        public AuthenticationController(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        [HttpPost("{Id}/{Password}")]
        public IActionResult Authenticate([FromRoute] User user)
        {
            bool isAdmin = user.Id == "Admin" && user.Password == "BestPasswordEver";

            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["SecretForKey"]));

            var signinigCreditentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim("id", user.Id));
            claimsForToken.Add(new Claim("isAdmin", isAdmin.ToString()));

            var jwtSecurityToken = new JwtSecurityToken(
                _configuration["Issuer"],
                _configuration["Audience"],
                claimsForToken,
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(4),
                signinigCreditentials);

            var tokentToReturn = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            return Ok(tokentToReturn);
        }
    }

    public record User
    {
        public string Id { get; set; }
        public string Password { get; set; }
    }
}
