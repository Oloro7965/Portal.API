using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Portal.Core.Enums;
using Portal.Core.Service;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Infraestructure.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string ComputeHash(string password)
        {
            using (var hash = SHA256.Create())
            {
                var passwordbytes = Encoding.UTF8.GetBytes(password);

                var bytehash = hash.ComputeHash(passwordbytes);

                var builder = new StringBuilder();
                for (var i = 0; i < bytehash.Length; i++)
                {
                    builder.Append(bytehash[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public string GenerateToken(string id, string email, EtipoUsuario role)
        {
            var issuer = _configuration["Jwt:Issuer"];
            var Audience = _configuration["Jwt:Audience"];
            var jwtKey = _configuration["Jwt:Key"] ?? throw new InvalidOperationException("JWT Key not found in configuration");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));


            var credenciais = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,id),
                new Claim("username",email),
                new Claim(ClaimTypes.Role,role.ToString())
            };
            var token = new JwtSecurityToken(issuer, Audience, claims, DateTime.UtcNow, DateTime.UtcNow.AddHours(2), credenciais);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
