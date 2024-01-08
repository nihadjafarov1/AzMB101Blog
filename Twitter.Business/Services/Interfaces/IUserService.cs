using Twitter.Business.Dtos.AuthDtos;

namespace Twitter.Business.Services.Interfaces
{
    public interface IUserService
    {
        public Task CreateAsync(RegisterDto dto);
    }
}
