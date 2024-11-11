using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Application.Interfaces
{
    public interface IJWTService
    {
        public JwtSecurityToken GetToken(IEnumerable<Claim> claims);
        public string GetTokenString(Dictionary<string, object> claims);
        public string GetTokenString(IEnumerable<Claim> claims);
    }
}
