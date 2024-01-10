using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Twitter.Business.Dtos.AuthDtos;
using Twitter.Business.ExtarnelServices.Interfaces;
using Twitter.Core.Entities;

namespace Twitter.Business.ExtarnelServices.Implements
{
    public class TokenService : ITokenService
    {
        IConfiguration _config {  get; }

        public TokenService(IConfiguration config)
        {
            _config = config;
        }
        public TokenDto CreateToken(TokenParamsDto dto)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, dto.User.UserName));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, dto.User.Id));
            claims.Add(new Claim(ClaimTypes.Role, dto.Role));

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            SigningCredentials cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            DateTime expires = DateTime.Now.AddMinutes(Convert.ToInt32(_config["Jwt:ExpireMin"]));
            JwtSecurityToken jwt = new JwtSecurityToken
            (
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                DateTime.Now,
                expires,
                cred
            );
            JwtSecurityTokenHandler jwtHandler = new JwtSecurityTokenHandler();
            var token = jwtHandler.WriteToken(jwt);
            return new TokenDto
            {
                Expires = expires,
                Token = token
            };
        }
    }
}
