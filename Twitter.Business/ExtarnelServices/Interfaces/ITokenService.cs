using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Twitter.Business.Dtos.AuthDtos;
using Twitter.Core.Entities;

namespace Twitter.Business.ExtarnelServices.Interfaces
{
    public interface ITokenService
    {
        TokenDto CreateToken(TokenParamsDto dto);
    }
}
