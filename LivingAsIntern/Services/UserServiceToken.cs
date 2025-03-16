using LivingAsIntern.Data;
using LivingAsIntern.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LivingAsIntern.Services
{
    public class UserServiceToken
    {
        public string GenerateToken(User user)
        {
            var handlerTokenSecurity = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(Configuration.Configuration.PrivateKey);

            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = GenerateClaims(user),
                Expires = DateTime.UtcNow.AddDays(4),
                SigningCredentials = credentials,
            };

            var token = handlerTokenSecurity.CreateToken(tokenDescriptor);

            return handlerTokenSecurity.WriteToken(token);
        }

        public static ClaimsIdentity GenerateClaims(User user)
        {
            var ci = new ClaimsIdentity();
            ci.AddClaim(new Claim(ClaimTypes.Name, user.Username));
            return ci;
        }
    }
}
