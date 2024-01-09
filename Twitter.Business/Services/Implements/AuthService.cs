using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Twitter.Business.Dtos.AuthDtos;
using Twitter.Business.Exceptions.Auth;
using Twitter.Business.ExtarnelServices.Interfaces;
using Twitter.Business.Services.Interfaces;
using Twitter.Core.Entities;

namespace Twitter.Business.Services.Implements
{
    public class AuthService : IAuthService
    {
        UserManager<AppUser> _userManager {  get; }
        ITokenService _tokenService { get; }

        public AuthService(UserManager<AppUser> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<string> Login(LoginDto dto)
        {
            AppUser? user = null;
            if (dto.UsernameOrEmail.Contains("@"))
            {
                user = await _userManager.FindByEmailAsync(dto.UsernameOrEmail);
            }
            else
            {
                user = await _userManager.FindByNameAsync(dto.UsernameOrEmail);
            }
            if (user == null) throw new UsernameOrPasswordWrongException();
            var result = await _userManager.CheckPasswordAsync(user, dto.Password);
            if (!result)
            {
                throw new UsernameOrPasswordWrongException();
            }

            return _tokenService.CreateToken(user);
        }
    }
}
