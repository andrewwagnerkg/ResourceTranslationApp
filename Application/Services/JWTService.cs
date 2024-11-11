using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services
{
    public class JWTService : IJWTService
    {
        private readonly IConfiguration _config;

        public JWTService(IConfiguration config)
        {
            _config = config;
        }

        public JwtSecurityToken GetToken(IEnumerable<Claim> claims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Secret"]!));
            _ = int.TryParse(_config["JWT:TokenValidityInHours"], out int TokenValidityInHours);
            var token = new JwtSecurityToken(
                        issuer: _config["JWT:ValidIssuer"],
                        audience: _config["JWT:ValidAudience"],
                        expires: DateTime.Now.AddMinutes(TokenValidityInHours),
                        claims: claims,
                        signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
            return token;
        }

        public string GetTokenString(Dictionary<string, object> claims)
        {
            return new JwtSecurityTokenHandler().WriteToken(GetToken(claims.Select(x => new Claim(x.Key, x.Value as string))));
        }

        public string GetTokenString(IEnumerable<Claim> claims)
        {
            return new JwtSecurityTokenHandler().WriteToken(GetToken(claims));
        }
    }
}
