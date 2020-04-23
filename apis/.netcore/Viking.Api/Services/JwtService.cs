using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Viking.Api
{
    public class JwtService
    {
        private readonly IConfiguration _configuration;

        public JwtService(IConfiguration config)
        {
            _configuration = config;
        }

        public string GenerateSecurityToken(string mail, string nombre, string id)
        {
            var claims = new[] {
                new Claim(ClaimTypes.NameIdentifier,id),
                new Claim(ClaimTypes.Name,nombre),
                new Claim(ClaimTypes.Email,mail),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt").GetSection("Key").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddMinutes(Convert.ToInt32(_configuration.GetSection("Jwt").GetSection("Expires").Value)),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);


            return tokenHandler.WriteToken(token);

        }
    }
}