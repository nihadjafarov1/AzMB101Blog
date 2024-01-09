using Twitter.Business.Dtos.AuthDtos;
using Twitter.Core.Entities;

namespace Twitter.Business.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> Login(LoginDto dto);
    }
}
