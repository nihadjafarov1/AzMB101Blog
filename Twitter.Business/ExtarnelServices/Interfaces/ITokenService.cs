using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Twitter.Core.Entities;

namespace Twitter.Business.ExtarnelServices.Interfaces
{
    public interface ITokenService
    {
        public string CreateToken(AppUser user)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.UserName));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
            claims.Add(new Claim("Test", user.BirthDay.ToString()));

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("345f33d3-7d79-4002-a95e-a1b497d8b4f7"));
            SigningCredentials cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            JwtSecurityToken jwt = new JwtSecurityToken
            (
                "https://localhost:7297/",
                "https://localhost:7297/api",
                claims,
                DateTime.Now,
                DateTime.Now.AddMinutes(10),
                cred
            );
            JwtSecurityTokenHandler jwtHandler = new JwtSecurityTokenHandler();
            var token = jwtHandler.WriteToken(jwt);
            return token;
        }
    }
}
